﻿using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using API;

namespace UI.Controls
{
	public partial class SourcePathBlockControl : UserControl
	{
		private const string CREDENTIALS_NEEDED = "Please enter network credentials to access the specified folder share.";
		private const string AUTHENTICATION_ERROR = "Network Authentication encountered the following error: {0}";
		private const string AUTHENTICATION_PROMPT = "Please enter credentials for: {0}";
		private const string VALIDATION_ERROR = "Unable to validate path {0}.";
		private const string VALIDATION_ERROR_CAPTION = "Network Access Error";

		private readonly GLMFileUtilityTool parentControl;

		public SourcePathBlockControl(GLMFileUtilityTool parent)
		{
			InitializeComponent();
			parentControl = parent;
		}

		public void Setup()
		{
			SetLocation(ApplicationConfiguration.GetSetting(ApplicationConfiguration.BASE_UPLOAD_PATH_KEY));
		}

		//public string[] Files { get; private set; }
		public string SourceLocation { get; private set; }
		
		private bool CheckLocationAccessAndSet(string directoryPath)
		{
			DirectoryInfo directory = new DirectoryInfo(directoryPath);

			if (directory.Exists)
			{
				//Files = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories);
				SourceLocation = directoryPath;
				sourceLocationText.Text = SourceLocation;
				parentControl.SourceLocation = SourceLocation;
				return true;
			}

			SourceLocation = string.Empty;
			return false;
		}

		private NetworkCredential GetNetworkCredentials(string directoryPath)
		{
			NetworkCredential accessCredential = null;

			Win32Interop.CREDUI_INFO credentialUiInfo = new Win32Interop.CREDUI_INFO
			{
				pszCaptionText = string.Format(AUTHENTICATION_PROMPT, directoryPath),
				pszMessageText = string.Empty,
			};

			credentialUiInfo.cbSize = Marshal.SizeOf(credentialUiInfo);

			uint authPackage = 0;
			IntPtr outCredBuffer;
			uint outCredSize;
			bool save = false;

			int result = Win32Interop.CredUIPromptForWindowsCredentials(ref credentialUiInfo, 0, ref authPackage, IntPtr.Zero, 0,
				out outCredBuffer, out outCredSize, ref save, 1);

			var usernameBuffer = new StringBuilder(100);
			var passwordBuffer = new StringBuilder(100);
			var domainBuffer = new StringBuilder(100);

			int maxUserName = 100;
			int maxDomain = 100;
			int maxPassword = 100;

			if (result == 0)
			{
				if (Win32Interop.CredUnPackAuthenticationBuffer(0, outCredBuffer, outCredSize, usernameBuffer, ref maxUserName,
					domainBuffer, ref maxDomain, passwordBuffer, ref maxPassword))
				{
					Win32Interop.CoTaskMemFree(outCredBuffer);
					accessCredential = new NetworkCredential()
					{
						UserName = usernameBuffer.ToString(),
						Password = passwordBuffer.ToString(),
						Domain = domainBuffer.ToString()
					};

				}
			}

			return accessCredential;
		}

		private void SetLocation(string directoryPath)
		{
			if (!CheckLocationAccessAndSet(directoryPath))
			{
				try
				{
					NetworkCredential access = null;
					if (!API.NetworkAccess.HasAccessToPath(directoryPath))
					{
						MessageBox.Show(this, CREDENTIALS_NEEDED);
						access = GetNetworkCredentials(directoryPath);
					}

					if (access != null)
					{
						using (new API.NetworkAccess(directoryPath, access))
						{
							CheckLocationAccessAndSet(directoryPath);
						}
					}
				}
				catch (Exception eError)
				{
					MessageBox.Show(string.Format(AUTHENTICATION_ERROR, eError.Message), VALIDATION_ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				
				if (string.IsNullOrEmpty(SourceLocation))
					MessageBox.Show(string.Format(VALIDATION_ERROR, SourceLocation));
			}
		}

		private void BrowseButtonClick(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowser = new FolderBrowserDialog
			{
				ShowNewFolderButton = false
			};

			DialogResult result = folderBrowser.ShowDialog();
			if (result == DialogResult.OK)
			{
				SetLocation(folderBrowser.SelectedPath);
			}
		}
		
		//Tasks for this control:
		//Call API to get the default location
		//Enable Folder Browse and validate the location is navigable by the app\
		//Make folder location publicly accessible.
	}
}