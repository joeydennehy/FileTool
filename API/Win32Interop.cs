using System;
using System.Runtime.InteropServices;
using System.Text;

namespace API
{
	// ReSharper disable InconsistentNaming
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable FieldCanBeMadeReadOnly.Global

	public static class Win32Interop
	{

		#region DLL Imports

		[DllImport("ole32.dll")]
		public static extern void CoTaskMemFree(IntPtr ptr);

		[DllImport("credui.dll", CharSet = CharSet.Auto)]
		public static extern bool CredUnPackAuthenticationBuffer(
			int dwFlags,
			IntPtr pAuthBuffer,
			uint cbAuthBuffer,
			StringBuilder pszUserName,
			ref int pcchMaxUserName,
			StringBuilder pszDomainName,
			ref int pcchMaxDomainame,
			StringBuilder pszPassword,
			ref int pcchMaxPassword
		);

		[DllImport("credui.dll", CharSet = CharSet.Auto)]
		public static extern int CredUIPromptForWindowsCredentials(
			ref CREDUI_INFO notUsedHere,
			int authError,
			ref uint authPackage,
			IntPtr inAuthBuffer,
			uint inAuthBufferSize,
			out IntPtr refOutAuthBuffer,
			out uint refOutAuthBufferSize,
			ref bool fSave,
			int flags
		);

		[DllImport("mpr.dll")]
		public static extern int WNetAddConnection2(
			ref NETRESOURCE netResource,
			string password, 
			string username, 
			uint flags
		);

		[DllImport("mpr.dll")]
		public static extern int WNetCancelConnection2(
			string name, 
			int flags,
			bool force
		);

		#endregion

		#region Structs
		
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct CREDUI_INFO
		{
			public int cbSize;
			public IntPtr hwndParent;
			public string pszMessageText;
			public string pszCaptionText;
			public IntPtr hbmBanner;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct NETRESOURCE
		{
			public ResourceScope Scope;
			public ResourceType ResourceType;
			public ResourceDisplaytype DisplayType;
			public int Usage;
			public string LocalName;
			public string RemoteName;
			public string Comment;
			public string Provider;
		}

		#endregion
	}

	// ReSharper restore FieldCanBeMadeReadOnly.Global
	// ReSharper restore MemberCanBePrivate.Global
	// ReSharper restore InconsistentNaming
}
