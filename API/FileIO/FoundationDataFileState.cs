using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using API.Data;

namespace API.FileIO
{
	public class FoundationDataFileState
	{
		public string BaseDirectory { get; set; }
		private string FileMask { get; set; }
		public List<global::System.IO.FileInfo> Files { get; set; }
		public int FoundationId { get; set; }
		public int ProcessId { get; set; }
		public string FoundationUrlKey { get; set; }
		public string OutputDirectory { get; set; }
		public string InputFile { get; set; }
		public string APIKey { get; set; }
		public List<string> SequesterExclusionPatterns { get; set; }
		public List<global::System.IO.FileInfo> SequesterFiles { get; set; }
		public string SequesterPath { get; set; }
		public long TotalSize { get; set; }
		public string FileType { get; set; }
		public List<RequestQuery.UnsyncedAnswer> UnsyncedAnswers { get; set; }

		public Dictionary<string, string> FilesNotFound { get; set; }

		public struct FileInfo
		{
			public Guid DocumentId;
			public Guid AnswerId;
			public int SubmissionId;
			public int RequestId;
			public Guid RequestGuid;
			public int AttachmentId;
			public int MergeTemplateId;
			public int ProcessId;
			public Guid OrganizationId;
			public string FileName;
			public string FilePath;
			public string Question;
			public string OrganizationName;
			public string OrganizationTaxId;
			
			
		}

		public List<FileInfo> RequestFiles { get; set; }
		public List<FileInfo> RequestSupportingFiles { get; set; }
		public List<FileInfo> OrganizationSupportingFiles { get; set; }
		public List<FileInfo> AttachmentFiles { get; set; }
		public List<FileInfo> SharedFiles { get; set; }
		public List<FileInfo> MergeTemplateFiles { get; set; }

		public string ClientRootDirectory { get; set; }

		public FoundationDataFileState()
		{
			FileMask = "*.*";

			Files = new List<global::System.IO.FileInfo>();
			SequesterFiles = new List<global::System.IO.FileInfo>();
			UnsyncedAnswers = new List<RequestQuery.UnsyncedAnswer>();
		}

		public override string ToString()
		{
			var stateOutput = new StringBuilder();

			stateOutput.AppendFormat("Foundation URL Key: {0}\r\n",
				string.IsNullOrWhiteSpace(FoundationUrlKey) ? "Not Found!" : FoundationUrlKey);
			stateOutput.AppendFormat("Foundation ID: {0}\r\n",
				FoundationId >= 0 ? "Not Found!" : FoundationId.ToString(CultureInfo.CurrentCulture));
			stateOutput.AppendFormat("Foundation Process ID: {0}\r\n",
				ProcessId >= 0 ? "Not Selected!" : ProcessId.ToString(CultureInfo.CurrentCulture));
			stateOutput.AppendFormat("Base Directory: {0}\r\n",
				string.IsNullOrWhiteSpace(BaseDirectory) ? "Not Found!" : BaseDirectory);
			stateOutput.AppendFormat("File Mask {0}\r\n", FileMask);
			stateOutput.AppendFormat("Total File Count: {0}\r\n", Files != null ? Files.Count : 0);
			stateOutput.AppendFormat("Total Byte Count: {0}\r\n", TotalSize);
			stateOutput.AppendFormat("Sequester Path: {0}\r\n",
				string.IsNullOrWhiteSpace(SequesterPath) ? "Not Set" : SequesterPath);
			stateOutput.AppendFormat("Sequester Exclusion Patterns {0}\r\n",
				SequesterExclusionPatterns == null ? "None" : string.Join(";", SequesterExclusionPatterns));
			stateOutput.AppendFormat("Sequester File Count: {0}\r\n", SequesterFiles != null ? SequesterFiles.Count : 0);
			stateOutput.AppendFormat("Output Directory: {0}\r\n",
				string.IsNullOrWhiteSpace(OutputDirectory) ? "Not Set" : OutputDirectory);


			return stateOutput.ToString();
		}
	}
}