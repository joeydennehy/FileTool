using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using API.Logging;

namespace API.FileIO
{
	public class FileProcessingState
	{
		public string BaseDirectory { get; set; }
		public string FileMask { get; set; }
		public List<FileInfo> Files { get; set; }
		public List<int> FoundationApplicantProcessIds { get; set; }
		public int FoundationProcessId { get; set; }
		public string FoundationUrlKey { get; set; }
		public string OutputDirectory { get; set; }
		public List<FileInfo> SequesterFiles { get; set; }
		public string SequesterPath { get; set; }
		public List<string> SequesterPatterns { get; set; }
		public long TotalSize { get; set; }
		public long TotalSequesterFileSize { get; set; }
		
		public NetworkCredential BaseDirectoryCredentials { get; set; }
		public NetworkCredential OutputDirectoryCredentials { get; set; }

		public string RootProcessDirectory
		{
			get { return string.Format("{0}\\{1}\\", BaseDirectory, FoundationUrlKey); }
		}

		public FileProcessingState()
		{
			FileMask = "*.*";

			Files = new List<FileInfo>();
			FoundationApplicantProcessIds = new List<int>();
			SequesterFiles = new List<FileInfo>();
		}
	}

	public static class FileProcessing
	{
		private static readonly List<string> SUB_FOLDERS;

		static FileProcessing()
		{
			SUB_FOLDERS = new List<string> {"followup", "loi", "qualification"};
		}

		public static void CopyApplicationProcessFiles(FileProcessingState state)
		{
			CopyFilesToDestination(state.Files, state.OutputDirectory);

			if (state.SequesterFiles.Count > 0)
				CopyFilesToDestination(state.SequesterFiles, state.SequesterPath);
		}

		public static void SetFilelist(FileProcessingState state)
		{
			state.Files = new List<FileInfo>();
			state.TotalSize = 0;

			if (state.FoundationApplicantProcessIds != null)
			{
				foreach (int applicantProcessId in state.FoundationApplicantProcessIds)
				{
					string directoryPath = string.Format("{0}{1}", state.RootProcessDirectory, applicantProcessId);
					if (Directory.Exists(directoryPath))
					{
						string[] directoryFiles = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories);
						foreach (string directoryFile in directoryFiles)
						{
							FileInfo file = new FileInfo(directoryFile);
							if (string.Compare(state.FileMask, "*.*", StringComparison.InvariantCulture) != 0)
							{
								if (!state.FileMask.ToLower().Contains(file.Extension.ToLower()))
								{
									continue;
								}

								if (state.SequesterPatterns != null && state.SequesterPatterns.Count > 0)
								{
									bool sequesterFile = state.SequesterPatterns.Any(sequesterPattern => file.Name.ToLower().Contains(sequesterPattern.ToLower()));
									if (sequesterFile)
									{
										if (state.SequesterPath != string.Empty)
										{
											state.SequesterFiles.Add(file);
											state.TotalSequesterFileSize += file.Length;
										}
										continue;
									}
								}
							}
							state.Files.Add(file);
							state.TotalSize += file.Length;
						}
					}
				}
			}
		}

		private static void CopyFilesToDestination(List<FileInfo> files, string destinationFolder)
		{
			if (files == null || files.Count == 0)
			{
				Logger.Log("CopyFilesToDestination: no files selected to copy", LogLevel.Warn);
				return;
			}

			if (string.IsNullOrEmpty(destinationFolder))
			{
				Logger.Log("CopyFilesToDestination: No destination selected for copy", LogLevel.Error);
				return;
			}

			if (!Directory.Exists(destinationFolder))
			{
				Directory.CreateDirectory(destinationFolder);
			}

			foreach (FileInfo file in files)
			{
				string fullFileName = string.Format("{0}\\{1}", destinationFolder, BuildApplicationProcessFileName(file));
				try
				{
					File.Copy(file.FullName, fullFileName, true);
					Logger.Log("Copied file " + file.FullName + " to " + fullFileName, LogLevel.Info);
				}
				catch (Exception eError)
				{
					Logger.Log(string.Format("Unable to copy file {0}.  Error: {1} ", file.FullName, eError.Message), LogLevel.Error);
					throw;
				}
			}
		}

		private static string BuildApplicationProcessFileName(FileInfo file)
		{
			if (string.IsNullOrEmpty(file.DirectoryName))
				return string.Empty;

			string applicantProcessId = string.Empty;
			string subFolderId = string.Empty;
			StringBuilder fileName = new StringBuilder();

			List<string> folders = new List<string>();
			folders.AddRange(file.DirectoryName.ToLower().Split(Path.DirectorySeparatorChar));

			int applicantProcessValue;
			if (folders.Count - 2 >= 0 && int.TryParse(folders[folders.Count - 2], out applicantProcessValue))
			{
				if (applicantProcessValue > 0)
				{
					applicantProcessId = applicantProcessValue.ToString("D10");
				}
				else
				{
					Logger.Log(String.Format("BuildApplicationProcessFileName: the folder location for File {0} is invalid and can not be processed", file.FullName), LogLevel.Error);
					return string.Empty;
				}
			}

			if (SUB_FOLDERS.Contains(folders.Last()))
				subFolderId = string.Format("_{0}", folders.Last());

			fileName.Clear();
			fileName.Append(applicantProcessId);
			fileName.Append(subFolderId);
			fileName.Append(string.Format("_{0}", file.Name));

			return fileName.ToString();
		}
	}
}
