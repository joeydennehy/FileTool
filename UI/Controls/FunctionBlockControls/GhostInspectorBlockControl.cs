using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Config;
using API.Data;
using API.FileIO;
using UI.Controls.FunctionBlockControls;

namespace UI.Controls
{
	public partial class GhostInspectorBlockControl : FunctionBlockBaseControl
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

		public GhostInspectorBlockControl(GLMFileUtilityTool parent)
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
				}
				parentControl.SourceLocation = SourceLocation;
			}
			catch (Exception eError)
			{
				MessageBox.Show(this, eError.Message, VALIDATION_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

		}

		private void TextChanged_SourceFolder(object sender, EventArgs e)
		{

		}

		#endregion

		

		#endregion


		private void GhostInspectorButton_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			try
			{

				resultsTextBox.Text = "";
				DataRow selectedRow = ((DataRowView)(FolderList.SelectedItem)).Row;
				foreach (var currentLine in FileProcessing.GetGhostInspectorSuites(state, selectedRow[0].ToString()))
				{
					FileProcessing.RunGhostInspector(state, currentLine);
				}
				

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

		private void apiKeyText_TextChanged(object sender, EventArgs e)
		{
			state.APIKey = apiKeyText.Text;
			FolderList.DataSource = FileProcessing.GetGhostInspectorFolders(state);
			FolderList.DisplayMember = "folderName";
		}

		private void FolderList_SelectedIndexChanged(object sender, EventArgs e)
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
