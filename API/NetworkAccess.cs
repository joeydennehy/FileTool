using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;

namespace API
{
	public sealed class NetworkAccess : IDisposable
	{

		private readonly string networkResourceName;

		public NetworkAccess(string networkResourcePath, NetworkCredential credentials)
		{
			networkResourceName = networkResourcePath;

			Win32Interop.NETRESOURCE networkResource = new Win32Interop.NETRESOURCE
			{
				Scope = ResourceScope.GlobalNetwork,
				ResourceType = ResourceType.Disk,
				DisplayType = ResourceDisplaytype.Share,
				RemoteName = networkResourceName
			};

			string userName = string.IsNullOrEmpty(credentials.Domain)
				? credentials.UserName
				: string.Format(@"{0}\{1}", credentials.Domain, credentials.UserName);

			int result = Win32Interop.WNetAddConnection2(
				 ref networkResource,
				 credentials.Password,
				 userName,
				 0);

			if (result != 0)
			{
				throw new Win32Exception(result, "Error connecting to remote share");
			}
		}

		~NetworkAccess()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			Win32Interop.WNetCancelConnection2(networkResourceName, 0, true);
		}

		public static bool HasAccessToPath(string path)
		{
			if (string.IsNullOrEmpty(path))
				return false;

			string pathRoot = Path.GetPathRoot(path);

			if (string.IsNullOrEmpty(pathRoot))
				return false;

			ProcessStartInfo proc = new ProcessStartInfo("net", "use")
			{
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				UseShellExecute = false
			};

			string output;
			using (Process process = Process.Start(proc))
			{
				output = process.StandardOutput.ReadToEnd();
			}

			return output.Split('\n').Any(outputLine => outputLine.Contains(pathRoot) && outputLine.Contains("OK"));
		}

	}

	public enum ResourceScope : int
	{
		Connected = 1,
		GlobalNetwork,
		Remembered,
		Recent,
		Context
	};

	public enum ResourceType : int
	{
		Any = 0,
		Disk = 1,
		Print = 2,
		Reserved = 8,
	}

	public enum ResourceDisplaytype : int
	{
		Generic = 0x0,
		Domain = 0x01,
		Server = 0x02,
		Share = 0x03,
		File = 0x04,
		Group = 0x05,
		Network = 0x06,
		Root = 0x07,
		Shareadmin = 0x08,
		Directory = 0x09,
		Tree = 0x0a,
		Ndscontainer = 0x0b
	}
}
