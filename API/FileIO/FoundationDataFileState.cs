using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace API.FileIO
{
	public class FoundationDataFileState
	{
		public string BaseDirectory { get; set; }
		public string FileMask { get; set; }
		public List<FileInfo> Files { get; set; }
		public int FoundationId { get; set; }
		public int FoundationProcessId { get; set; }
		public string FoundationUrlKey { get; set; }
		public string OutputDirectory { get; set; }
		public List<string> SequesterExclusionPatterns { get; set; }
		public List<FileInfo> SequesterFiles { get; set; }
		public string SequesterPath { get; set; }
		public long TotalSize { get; set; }
		
		public List<string> FilesNotFound { get; set; }
		public List<string> FoundationApplicantProcessCodes { get; set; }
		
		
		//public string MovedToDirectory { get; set; }
		//public string MovedFromDirectory { get; set; }

		//Keeping for the possibility of future use
		//public NetworkCredential BaseDirectoryCredentials { get; set; }
		//public NetworkCredential OutputDirectoryCredentials { get; set; }

		public string ClientRootDirectory
		{
			get
			{
				return string.Format("{0}\\{1}\\",
					!string.IsNullOrWhiteSpace(BaseDirectory) ? BaseDirectory.TrimEnd(new[] {Path.DirectorySeparatorChar}) : "",
					FoundationUrlKey);
			}
		}

		public FoundationDataFileState()
		{
			FileMask = "*.*";

			Files = new List<FileInfo>();
			FoundationApplicantProcessCodes = new List<string>();
			SequesterFiles = new List<FileInfo>();
		}

		public override string ToString()
		{
			var stateOutput = new StringBuilder();

			stateOutput.AppendFormat("Foundation URL Key: {0}\r\n", string.IsNullOrWhiteSpace(FoundationUrlKey) ? "Not Found!" : FoundationUrlKey);
			stateOutput.AppendFormat("Foundation ID: {0}\r\n", FoundationId >= 0 ? "Not Found!" : FoundationId.ToString(CultureInfo.CurrentCulture));
			stateOutput.AppendFormat("Foundation Process ID: {0}\r\n", FoundationProcessId >= 0 ? "Not Selected!" : FoundationProcessId.ToString(CultureInfo.CurrentCulture));
			stateOutput.AppendFormat("Base Directory: {0}\r\n", string.IsNullOrWhiteSpace(BaseDirectory) ? "Not Found!" : BaseDirectory);
			stateOutput.AppendFormat("File Mask {0}\r\n", FileMask);
			stateOutput.AppendFormat("Total File Count: {0}\r\n", Files != null ? Files.Count : 0);
			stateOutput.AppendFormat("Total Byte Count: {0}\r\n", TotalSize);
			stateOutput.AppendFormat("Sequester Path: {0}\r\n", string.IsNullOrWhiteSpace(SequesterPath) ? "Not Set" : SequesterPath);
			stateOutput.AppendFormat("Sequester Exclusion Patterns {0}\r\n", SequesterExclusionPatterns == null ? "None" : string.Join(";", SequesterExclusionPatterns));
			stateOutput.AppendFormat("Sequester File Count: {0}\r\n", SequesterFiles != null ? SequesterFiles.Count : 0);
			stateOutput.AppendFormat("Output Directory: {0}\r\n", string.IsNullOrWhiteSpace(OutputDirectory) ? "Not Set" : OutputDirectory);


			return stateOutput.ToString();
		}
	}
}
