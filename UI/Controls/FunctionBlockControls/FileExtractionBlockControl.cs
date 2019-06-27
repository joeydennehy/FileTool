using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using API.Config;
using API.Data;
using API.FileIO;
using UI.Controls.FunctionBlockControls;

namespace UI.Controls
{
	public partial class FileExtractionBlockControl : FunctionBlockBaseControl
	{

		#region Member Variables

		private const string INVALID_PATH_ERROR = "Path not found!";
		private const string VALIDATION_CAPTION = "Validation Error";
		private const string VIRTUAL_PATH_MESSAGE = "Virtual path selections are not being accepted for the source location at this time.";

		private const string APPLICANT_PROCESS_FORMAT = "Total Applicant Process IDs: {0}";
		private const string FILE_COPY_CAPTION = "File Copy";
		private const string FILE_COPY_COMPLETE = "File copy has completed.";
		private const string FILE_COPY_ERROR_FORMAT = "File copy procedure gave the following error {0}.";

		private const string FILE_DELETE_ERROR_FORMAT =
			"Unable to remove file: {0} due to the following error: {1}. /r/n The copy process will abort.";

		private const string FILE_COUNT_FORMAT = "[{0} files, totaling {1:n} MB]";
		private const string FILE_EXCLUDED_COUNT_FORMAT = "[{0} files]";
		private const string NO_FILE_COUNT = "[No Files Found]";
		private const string NO_FILE_EXCLUSIONS = "[No Files Excluded]";
		private const string VALIDATION_ERROR_CAPTION = "Invalid Processing State";

		private const string VALIDATION_ERROR_FOLDER_NOT_FOUND_FORMAT =
			"{0}   WARNING!: Cannot find or access specified folder.";

		private const string VALIDATION_ERROR_FOLDER_NOT_EMPTY =
			"Warning: All files in the destination folder will be removed, do you wish to proceed?";

		private const string VALIDATION_ERROR_OUTPUT_NOT_SELECTED = "Please select an output destination before continuing.";
		private const string WORKING = "[Working...]";

		private readonly GLMFileUtilityTool parentControl;
		private FoundationDataFileState state;

		public override string TitleBlockText { get { return "File Extraction"; } }

		#endregion

		#region Constructor
		
		public FileExtractionBlockControl(GLMFileUtilityTool parent)
		{
			parentControl = parent;
			InitializeComponent();
			Initialize();
		}

		#endregion

		#region Properties

		public string SourceLocation { get; private set; }

		#endregion

		#region Private Methods

		private void Initialize()
		{
			state = new FoundationDataFileState();

			SetLocationSelection(ApplicationConfiguration.GetSetting(ApplicationConfiguration.BASE_UPLOAD_PATH_KEY));
			SetDisplayText(SourceLocation);
		}

		private void SetDisplayText(string directoryPath)
		{
			sourceLocationText.Text = directoryPath;

			sourceLocationText.SelectionStart = sourceLocationText.Text.Length;
			sourceLocationText.SelectionLength = 0;
		}

		private void SetLocationSelection(string directoryPath)
		{
			try
			{
				if (ValidateLocationSelection(directoryPath))
				{
					SourceLocation = directoryPath;
				}
				else
				{
					SourceLocation = ApplicationConfiguration.GetSetting(ApplicationConfiguration.BASE_UPLOAD_PATH_KEY);
					SetDisplayText(SourceLocation);
				}
				parentControl.SourceLocation = SourceLocation;
			}
			catch (Exception eError)
			{
				MessageBox.Show(this, eError.Message, VALIDATION_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
				sourceLocationText.Focus();
			}

		}

		private bool ValidateLocationSelection(string directoryPath)
		{
			if (string.IsNullOrWhiteSpace(directoryPath))
				return false;

			var directory = new DirectoryInfo(directoryPath);
			if(!directory.Exists)
				throw new ArgumentException(INVALID_PATH_ERROR);

			return true;
		}

		#region Event Handlers

		private void ButtonClick_BrowseFolders(object sender, EventArgs e)
		{
			var folderBrowser = new FolderBrowserDialog
			{
				ShowNewFolderButton = false,
				SelectedPath = "\\\\flash\\Public\\File Extracts"
			};

			DialogResult result = folderBrowser.ShowDialog();
			if (result == DialogResult.OK)
			{
				SetDisplayText(folderBrowser.SelectedPath);
				SetLocationSelection(folderBrowser.SelectedPath);
			}
		}

		private void OnLeave_SourcePathBlockControl(object sender, EventArgs e)
		{
			SetLocationSelection(sourceLocationText.Text);
		}

		private void TextChanged_SourceFolder(object sender, EventArgs e)
		{
			string selectedPath = sourceLocationText.Text;
			if (selectedPath.EndsWith("\\"))
				selectedPath = selectedPath.TrimEnd('\\');

			if (selectedPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
			{
				string[] pathPartStrings = selectedPath.Split(Path.GetInvalidPathChars(), StringSplitOptions.RemoveEmptyEntries);
				selectedPath = string.Join("", pathPartStrings);
			}

				SetDisplayText(selectedPath);
				SetLocationSelection(sourceLocationText.Text);

			var urlKey = selectedPath.Split('\\')
				.Last();

			state.ClientRootDirectory = selectedPath;
			state.FoundationUrlKey = urlKey;
			state.FoundationId = RequestQuery.GetFoundationId(urlKey);

			RequestQuery.RefreshFoundationProcessData(state.FoundationId);

				if (RequestQuery.FoundationProcessData.Rows.Count == 0)
				{
					processIdComboBox.DataSource = null;
					return;
				}

				processIdComboBox.DataSource = RequestQuery.FoundationProcessData;
				processIdComboBox.DisplayMember = "ProcessDisplayText";
				processIdComboBox.ValueMember = "ProcessId";

				string[] validDirectories = { "answers", "documents" };
				fileTypeComboBox.DataSource = null;
				if (Directory.Exists(selectedPath))
				{
					List<string> directories = Directory.GetDirectories(string.Format("{0}", selectedPath))
						.ToList();
					for (int x = 0; x < directories.Count(); ++x)
					{
						directories[x] = new DirectoryInfo(directories[x]).Name;
					}

					directories = directories.Where(validDirectories.Contains)
						.ToList();
					directories.Insert(0, "All");
					fileTypeComboBox.DataSource = directories;
					fileTypeComboBox.SelectedIndex = 0;
				}
		}

		#endregion

		private void processIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int processId = -1;

			if (((ComboBox)sender).SelectedItem != null)
			{
				DataRow selectedRow = ((DataRowView)((ComboBox)sender).SelectedItem).Row;
				processId = (int)selectedRow[0];
			}
			try
			{
				Cursor = Cursors.WaitCursor;

				//ApplicantProcessIdsLabel.Text = string.Format(APPLICANT_PROCESS_FORMAT, "");
				fileCountLinkLabel.Text = WORKING;

				state.ProcessId = processId;

				try
				{
					if (string.IsNullOrEmpty(state.FileType) || state.FileType == "All")
					{
						if (processId == -999)
						{
							state.RequestFiles = RequestQuery.RetrieveAllRequestInfo(state.FoundationId);
							state.RequestSupportingFiles = RequestQuery.RetrieveAllRequestSupportingInfo(state.FoundationId);
						}
						else
						{
							state.RequestFiles = RequestQuery.RetrieveRequestInfo(processId);
							state.RequestSupportingFiles = RequestQuery.RetrieveRequestSupportingInfo(processId);
						}
						state.OrganizationSupportingFiles = RequestQuery.RetrieveAllOrganizationSupportingInfo(state.FoundationId);
						state.MergeTemplateFiles = RequestQuery.RetrieveAllMergeTemplateInfoByFoundation(state.FoundationId);
						state.AttachmentFiles = RequestQuery.RetrieveAllAttachmentInfo(state.FoundationId);
						state.SharedFiles = RequestQuery.RetrieveAllSharedInfo(state.FoundationId);
					}
					else
					{
						switch (state.FileType)
						{
							case "requests":
								if (processId == -999)
								{
									state.RequestFiles = RequestQuery.RetrieveAllRequestInfo(state.FoundationId);
									state.RequestSupportingFiles = RequestQuery.RetrieveAllRequestSupportingInfo(state.FoundationId);
								}
								else
								{
									state.RequestFiles = RequestQuery.RetrieveRequestInfo(processId);
									state.RequestSupportingFiles = RequestQuery.RetrieveRequestSupportingInfo(processId);
								}
								break;
							case "organizations":
								state.OrganizationSupportingFiles = RequestQuery.RetrieveAllOrganizationSupportingInfo(state.FoundationId);
								break;
							case "mergetemplates":
								state.MergeTemplateFiles = RequestQuery.RetrieveAllMergeTemplateInfoByFoundation(state.FoundationId);
								break;
							case "attachments":
								state.AttachmentFiles = RequestQuery.RetrieveAllAttachmentInfo(state.FoundationId);
								break;
							case "shareddocuments":
								state.SharedFiles = RequestQuery.RetrieveAllSharedInfo(state.FoundationId);
								break;
						}
					}
				}
				catch (Exception eError)
				{
					MessageBox.Show(this, string.Format(FILE_COPY_ERROR_FORMAT, eError.Message), FILE_COPY_CAPTION,
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				//ApplicantProcessIdsLabel.Text = string.Format(APPLICANT_PROCESS_FORMAT, state.FoundationApplicantProcessCodes.Count);

				FileProcessing.SetFileList(state);

				if (state.Files != null && state.Files.Count > 0)
				{
					fileCountLinkLabel.Text = string.Format(FILE_COUNT_FORMAT, state.Files.Count,
						(float)state.TotalSize / (1024 * 1024));
				}
				else
				{
					fileCountLinkLabel.Text = NO_FILE_COUNT;
				}
			}
			catch (Exception eError)
			{
				MessageBox.Show(this, string.Format(FILE_COPY_ERROR_FORMAT, eError.Message), FILE_COPY_CAPTION, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		#endregion

		private void fileTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (((ComboBox)sender).SelectedItem != null)
			{
				state.FileType = ((ComboBox)sender).SelectedItem.ToString();
				processIdComboBox_SelectedIndexChanged(processIdComboBox, new EventArgs());
			}
		}

		private void fileCountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var fileListDisplay = new FileListDisplayForm(state.Files);

			fileListDisplay.ShowDialog(this);
		}

		private void copyFilesButton_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				var outputDirectory = new DirectoryInfo(sourceLocationText.Text + "\\..\\" + state.FoundationUrlKey + "_Extract");
				state.OutputDirectory = outputDirectory.ToString();

				if (outputDirectory.Exists && outputDirectory.GetFiles()
					.Any())
				{
					DialogResult prompt = MessageBox.Show(this, VALIDATION_ERROR_FOLDER_NOT_EMPTY, FILE_COPY_CAPTION,
						MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

					if (prompt == DialogResult.Yes)
					{
						foreach (FileInfo fileInfo in outputDirectory.GetFiles())
						{
							try
							{
								File.Delete(fileInfo.FullName);
							}
							catch (Exception eError)
							{
								MessageBox.Show(this, string.Format(FILE_DELETE_ERROR_FORMAT, fileInfo.Name, eError.Message), FILE_COPY_CAPTION,
									MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}
						}
					}
					else
					{
						return;
					}
				}

				FileProcessing.CopyApplicationProcessFiles(state);

				MessageBox.Show(this, FILE_COPY_COMPLETE, FILE_COPY_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception eError)
			{
				MessageBox.Show(this, string.Format(FILE_COPY_ERROR_FORMAT, eError.Message), FILE_COPY_CAPTION, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void SourcePathBlockControl_Load(object sender, EventArgs e)
		{

		}

		#region Public Methods
		#endregion

		//public void Setup()
		//{
		//	SetLocation(ApplicationConfiguration.GetSetting(ApplicationConfiguration.BASE_UPLOAD_PATH_KEY));
		//}

		//TODO: Check Network credentials - this code does work, but the timing problem it introduces during startup
		// will have to change when this type of code gets called.  Removing for now.

		//private const string CREDENTIALS_NEEDED = "Please enter network credentials to access the specified folder share.";
		//private const string AUTHENTICATION_ERROR = "Network Authentication encountered the following error: {0}";
		//private const string AUTHENTICATION_PROMPT = "Please enter credentials for: {0}";
		//private const string VALIDATION_ERROR = "Unable to validate path {0}.";
		//private const string VALIDATION_ERROR_CAPTION = "Network Access Error";

		//private NetworkCredential GetNetworkCredentials(string directoryPath)
		//{
		//	NetworkCredential accessCredential = null;

		//	Win32Interop.CREDUI_INFO credentialUiInfo = new Win32Interop.CREDUI_INFO
		//	{
		//		pszCaptionText = string.Format(AUTHENTICATION_PROMPT, directoryPath),
		//		pszMessageText = string.Empty,
		//	};

		//	credentialUiInfo.cbSize = Marshal.SizeOf(credentialUiInfo);

		//	uint authPackage = 0;
		//	IntPtr outCredBuffer;
		//	uint outCredSize;
		//	bool save = false;

		//	int result = Win32Interop.CredUIPromptForWindowsCredentials(ref credentialUiInfo, 0, ref authPackage, IntPtr.Zero, 0,
		//		out outCredBuffer, out outCredSize, ref save, 1);

		//	var usernameBuffer = new StringBuilder(100);
		//	var passwordBuffer = new StringBuilder(100);
		//	var domainBuffer = new StringBuilder(100);

		//	int maxUserName = 100;
		//	int maxDomain = 100;
		//	int maxPassword = 100;

		//	if (result == 0)
		//	{
		//		if (Win32Interop.CredUnPackAuthenticationBuffer(0, outCredBuffer, outCredSize, usernameBuffer, ref maxUserName,
		//			domainBuffer, ref maxDomain, passwordBuffer, ref maxPassword))
		//		{
		//			Win32Interop.CoTaskMemFree(outCredBuffer);
		//			accessCredential = new NetworkCredential()
		//			{
		//				UserName = usernameBuffer.ToString(),
		//				Password = passwordBuffer.ToString(),
		//				Domain = domainBuffer.ToString()
		//			};

		//		}
		//	}

		//	return accessCredential;
		//}

		//private void SetLocation(string directoryPath)
		//{
		//	if (!CheckLocationAccessAndSet(directoryPath))
		//	{
		//		try
		//		{
		//			NetworkCredential access = null;
		//			if (!API.NetworkAccess.HasAccessToPath(directoryPath))
		//			{
		//				MessageBox.Show(this, CREDENTIALS_NEEDED);
		//				access = GetNetworkCredentials(directoryPath);
		//			}

		//			if (access != null)
		//			{
		//				using (new API.NetworkAccess(directoryPath, access))
		//				{
		//					CheckLocationAccessAndSet(directoryPath);
		//				}
		//			}
		//		}
		//		catch (Exception eError)
		//		{
		//			MessageBox.Show(string.Format(AUTHENTICATION_ERROR, eError.Message), VALIDATION_ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
		//			return;
		//		}

		//		if (string.IsNullOrEmpty(SourceLocation))
		//			MessageBox.Show(string.Format(VALIDATION_ERROR, SourceLocation));
		//	}
		//}

		//private void BrowseButtonClick(object sender, EventArgs e)
		//{
		//	FolderBrowserDialog folderBrowser = new FolderBrowserDialog
		//	{
		//		ShowNewFolderButton = false
		//	};

		//	DialogResult result = folderBrowser.ShowDialog();
		//	if (result == DialogResult.OK)
		//	{
		//		SetLocation(folderBrowser.SelectedPath);
		//	}
		//}
		
		//Tasks for this control:
		//Call API to get the default location
		//Enable Folder Browse and validate the location is navigable by the app\
		//Make folder location publicly accessible.
	}
}
