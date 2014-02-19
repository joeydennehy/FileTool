using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using API;
using API.Config;

namespace UI.Controls
{
	public partial class SourcePathBlockControl : UserControl
	{

		#region Member Variables

		private const string CREDENTIALS_NEEDED = "Please enter network credentials to access the specified folder share.";
		private const string AUTHENTICATION_ERROR = "Network Authentication encountered the following error: {0}";
		private const string AUTHENTICATION_PROMPT = "Please enter credentials for: {0}";
		private const string VALIDATION_ERROR = "Unable to validate path {0}.";
		private const string VALIDATION_ERROR_CAPTION = "Network Access Error";

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

		private bool CheckLocationAccessAndSet(string directoryPath)
		{
			DirectoryInfo directory = new DirectoryInfo(directoryPath);

			if (directory.Exists)
			{
				SourceLocation = directoryPath;
				sourceLocationText.Text = SourceLocation;
				parentControl.SourceLocation = SourceLocation;
				return true;
			}

			SourceLocation = string.Empty;
			return false;
		}

		private void Initialize()
		{
			CheckLocationAccessAndSet(ApplicationConfiguration.GetSetting(ApplicationConfiguration.BASE_UPLOAD_PATH_KEY));
		}

		#region Event Handlers

		private void TextChanged_SourceFolder(object sender, EventArgs e)
		{
			if (sourceLocationText.Text.StartsWith("\\"))
			{
				MessageBox.Show(this, "You cannot type virtual paths in source field.");
				CheckLocationAccessAndSet(ApplicationConfiguration.GetSetting(ApplicationConfiguration.BASE_UPLOAD_PATH_KEY));
			}
			else
			{
				CheckLocationAccessAndSet(sourceLocationText.Text);
			}
		}

		private void ButtonClick_BrowseFolders(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowser = new FolderBrowserDialog
			{
				ShowNewFolderButton = false
			};

			DialogResult result = folderBrowser.ShowDialog();
			if (result == DialogResult.OK)
			{
				CheckLocationAccessAndSet(folderBrowser.SelectedPath);
			}
		}

		#endregion

        private void sourceLabel_Click(object sender, EventArgs e)
        {

        }

		#endregion

		#region Public Methods
		#endregion

		//public void Setup()
		//{
		//	SetLocation(ApplicationConfiguration.GetSetting(ApplicationConfiguration.BASE_UPLOAD_PATH_KEY));
		//}

		//TODO: Check Network credentials - this code does work, but the timing problem it introduces during startup
		// will have to change when this type of code gets called.  Removing for now.
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
