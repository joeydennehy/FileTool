using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using API.Config;

namespace UI.Controls
{
	public partial class SourcePathBlockControl : UserControl
	{

		#region Member Variables

		private const string INVALID_PATH_ERROR = "Path not found!";
		private const string VALIDATION_CAPTION = "Validation Error";
		private const string VIRTUAL_PATH_MESSAGE = "Virtual path selections are not being accepted for the source location at this time.";

		private readonly GLMFileUtilityTool parentControl;

		#endregion

		#region Constructor
		
		public SourcePathBlockControl(GLMFileUtilityTool parent)
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
			SetLocationSelection(ApplicationConfiguration.GetSetting(ApplicationConfiguration.BASE_UPLOAD_PATH_KEY));
			SetDisplayText(SourceLocation);
		}

		private void SetDisplayText(string directoryPath)
		{
			sourceLocationText.TextChanged -= TextChanged_SourceFolder;

			sourceLocationText.Text = directoryPath;

			int firstFolderLocation = sourceLocationText.Text.IndexOf('\\');
			int lastFolderLocation = sourceLocationText.Text.LastIndexOf('\\');
			sourceLocationText.SelectionStart = firstFolderLocation - lastFolderLocation == 0
				? sourceLocationText.Text.Length
				: sourceLocationText.Text.Length - 1;

			sourceLocationText.SelectionLength = 0;

			sourceLocationText.TextChanged += TextChanged_SourceFolder;
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

			if (directoryPath.StartsWith("\\"))
				throw new ArgumentException(VIRTUAL_PATH_MESSAGE);

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
				ShowNewFolderButton = false
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
			if(!selectedPath.EndsWith("\\"))
				selectedPath = string.Format("{0}\\", selectedPath);

			selectedPath = selectedPath.Replace("\\\\", "\\");

			if (selectedPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
			{
				string[] pathPartStrings = selectedPath.Split(Path.GetInvalidPathChars(), StringSplitOptions.RemoveEmptyEntries);
				selectedPath = string.Join("", pathPartStrings);
			}

			if (string.Compare(selectedPath, sourceLocationText.Text, true, CultureInfo.CurrentCulture) != 0)
			{
				SetDisplayText(selectedPath);
				SetLocationSelection(sourceLocationText.Text);
			}
		}

		#endregion

		#endregion

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
