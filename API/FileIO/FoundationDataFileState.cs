using System.Collections.Generic;
using System.IO;

namespace API.FileIO
{
	public class FoundationDataFileState
	{
		public string BaseDirectory { get; set; }
		public int FoundationId { get; set; }
		public string FileMask { get; set; }
		public List<FileInfo> Files { get; set; }
		public List<string> FilesNotFound { get; set; }
		public List<int> FoundationApplicantProcessIds { get; set; }
		public int FoundationProcessId { get; set; }
		public string FoundationUrlKey { get; set; }
		public string OutputDirectory { get; set; }
		public List<FileInfo> SequesterFiles { get; set; }
		public string SequesterPath { get; set; }
		public List<string> SequesterPatterns { get; set; }
		public long TotalSize { get; set; }

		//Keeping for the possibility of future use
		//public NetworkCredential BaseDirectoryCredentials { get; set; }
		//public NetworkCredential OutputDirectoryCredentials { get; set; }

		public string ClientRootDirectory
		{
			get { return string.Format("{0}\\{1}\\", BaseDirectory.TrimEnd(new[] { Path.DirectorySeparatorChar }), FoundationUrlKey); }
		}

		public FoundationDataFileState()
		{
			FileMask = "*.*";

			Files = new List<FileInfo>();
			FoundationApplicantProcessIds = new List<int>();
			SequesterFiles = new List<FileInfo>();
		}
	}
}
