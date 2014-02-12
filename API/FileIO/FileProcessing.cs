using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using API.Logging;

namespace API.FileIO
{
	public static class FileProcessing
	{
		private static readonly List<string> SUB_FOLDERS;

		static FileProcessing()
		{
			SUB_FOLDERS = new List<string> {"followup", "loi", "qualification"};
		}

		public static void CopyApplicationProcessFiles(FoundationDataFileState state)
		{
			CopyFilesToDestination(state.Files, state.OutputDirectory);

			if (!string.IsNullOrEmpty(state.SequesterPath) && state.SequesterFiles.Count > 0)
				CopyFilesToDestination(state.SequesterFiles, state.SequesterPath);
		}

		public static void SetFileList(FoundationDataFileState state)
		{
			state.Files = new List<FileInfo>();
			state.SequesterFiles = new List<FileInfo>();
			state.TotalSize = 0;

			if (state.FoundationApplicantProcessIds != null)
			{
				foreach (int applicantProcessId in state.FoundationApplicantProcessIds)
				{
					string directoryPath = string.Format("{0}{1}", state.ClientRootDirectory, applicantProcessId);
					SetFilesFromPath(state, directoryPath);
				}
			}
		}

		private static void SetFilesFromPath(FoundationDataFileState state, string directoryPath)
		{
			if (Directory.Exists(directoryPath))
			{
				string[] directoryFiles = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories);
				foreach (string directoryFile in directoryFiles)
				{
					var file = new FileInfo(directoryFile);
					if (string.Compare(state.FileMask, "*.*", StringComparison.InvariantCulture) != 0)
					{
						if (!state.FileMask.ToLower().Contains(file.Extension.ToLower()))
						{
							continue;
						}
					}

					if (state.SequesterPatterns != null && state.SequesterPatterns.Count > 0)
					{
						bool sequesterFile = state.SequesterPatterns.Any(sequesterPattern => file.Name.ToLower().Contains(sequesterPattern.ToLower()));
						if (sequesterFile)
						{
							state.SequesterFiles.Add(file);
							continue;
						}
					}

					state.Files.Add(file);
					state.TotalSize += file.Length;
				}
			}
		}

		public static void ReconcileFileListToDatabase(FoundationDataFileState state, List<string> fileList)
		{
			SetFilesFromPath(state, state.ClientRootDirectory);

			foreach (FileInfo file in state.Files)
			{
				string partialFileName = file.FullName.Replace(state.ClientRootDirectory, string.Empty).ToLower();
				if (!fileList.Contains(partialFileName))
				{
					state.SequesterFiles.Add(file);
				}
				else
				{
					fileList.Remove(partialFileName);
				}
			}

			if (fileList.Count > 0)
				state.FilesNotFound = fileList;
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

		public static void MoveFilesToDestination(List<FileInfo> files, string destinationFolder, string root)
		{
			if (files == null || files.Count == 0)
			{
				Logger.Log("MoveFilesToDestination: no files selected to copy", LogLevel.Warn);
				return;
			}

			if (string.IsNullOrEmpty(destinationFolder))
			{
				Logger.Log("MoveFilesToDestination: No destination selected for copy", LogLevel.Error);
				return;
			}

			if (!Directory.Exists(destinationFolder))
			{
				Directory.CreateDirectory(destinationFolder);
			}

			foreach (FileInfo file in files)
			{
				string directory = string.Format("{0}\\{1}", destinationFolder, file.Directory.FullName.Substring(root.Length));
				if (!Directory.Exists(directory))
				{
					Directory.CreateDirectory(directory);
				}
				string fullDestinationPath = string.Format("{0}\\{1}", directory, file.Name);
				try
				{
					File.Move(file.FullName, fullDestinationPath);
					Logger.Log("Moved file " + file.FullName + " to " + fullDestinationPath, LogLevel.Info);
				}
				catch (Exception eError)
				{
					Logger.Log(string.Format("Unable to move file {0}.  Error: {1} ", file.FullName, eError.Message), LogLevel.Error);
					throw;
				}
			}
		}

		public static void Undo(FoundationDataFileState state)
		{
			SetFilesFromPath(state, state.MovedToDirectory);

			foreach (FileInfo file in state.Files)
			{
				try
				{
					string fullDestination = string.Format("{0}{1}", state.MovedFromDirectory, file.FullName.Substring(state.MovedToDirectory.Length));
					File.Move(file.FullName, fullDestination);
				}
				catch (Exception eError)
				{
					Logger.Log(string.Format("Unable to undo file {0}.  Error: {1} ", file.FullName, eError.Message), LogLevel.Error);
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
