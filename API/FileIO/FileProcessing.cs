using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using API.Data;
using API.Logging;

namespace API.FileIO
{
	public static class FileProcessing
	{
		private static readonly List<string> SUB_FOLDERS;
		private const string RECORDS_DELETE_CAPTION = "Records Delete";
		private const string RECORDS_DELETE_ERROR_FORMAT = "Records Delete procedure gave the following error {0}.";

		static FileProcessing()
		{
			SUB_FOLDERS = new List<string>
			{
				"followup",
				"loi",
				"qualification"
			};
		}

		public static void CopyApplicationProcessFiles(FoundationDataFileState state)
		{
			CopyFilesToDestination(state.Files, state.OutputDirectory);

			if (!string.IsNullOrEmpty(state.SequesterPath) && state.SequesterFiles.Count > 0)
			{
				CopyFilesToDestination(state.SequesterFiles, state.SequesterPath);
			}
		}

		private static void ClearFiles(FoundationDataFileState state)
		{
			state.Files = new List<FileInfo>();
			state.SequesterFiles = new List<FileInfo>();
			state.TotalSize = 0;
		}

		public static void SetFileList(FoundationDataFileState state)
		{
			ClearFiles(state);
			if (state.FoundationApplicantProcessCodes != null)
			{
				foreach (string applicantProcessCode in state.FoundationApplicantProcessCodes)
				{
					string directoryPath = string.Format("{0}{1}", state.ClientRootDirectory, applicantProcessCode);
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
						if (!state.FileMask.ToLower()
							.Contains(file.Extension.ToLower()))
						{
							continue;
						}
					}

					if (state.SequesterExclusionPatterns != null && state.SequesterExclusionPatterns.Count > 0)
					{
						bool sequesterFile = state.SequesterExclusionPatterns.Any(sequesterPattern => file.Name.ToLower()
							.Contains(sequesterPattern.ToLower()));
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
			ClearFiles(state);
			SetFilesFromPath(state, state.ClientRootDirectory);

			foreach (FileInfo file in state.Files)
			{
				string partialFileName = file.FullName.Replace(state.ClientRootDirectory, string.Empty)
					.ToLower();
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
			{
				state.FilesNotFound = fileList;
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
				throw new ArgumentNullException("destinationFolder");
			}

			if (!Directory.Exists(destinationFolder))
			{
				Directory.CreateDirectory(destinationFolder);
			}

			foreach (FileInfo file in files)
			{
				string fullFileName = string.Format("{0}{1}", destinationFolder, BuildApplicationProcessFileName(file));
				try
				{
					var destinationFile = new FileInfo(fullFileName);
					int fileCounter = 1;
					while (destinationFile.Exists)
					{
						string baseFileName = destinationFile.Name.Substring(0,
							(destinationFile.Name.Length - destinationFile.Extension.Length));
						int repetitionIndex = destinationFile.Name.LastIndexOf(string.Format(" ({0})", fileCounter - 1),
							StringComparison.InvariantCulture);
						if (repetitionIndex > 0)
						{
							baseFileName = destinationFile.Name.Substring(0, repetitionIndex);
						}

						destinationFile =
							new FileInfo(string.Format("{0}\\{1} ({2}){3}", destinationFile.DirectoryName, baseFileName, fileCounter,
								destinationFile.Extension));
						fullFileName = destinationFile.FullName;
						fileCounter++;
					}

					File.Copy(file.FullName, fullFileName);
					Logger.Log("Copied file " + file.FullName + " to " + fullFileName, LogLevel.Info);
				}
				catch (Exception eError)
				{
					Logger.Log(string.Format("Unable to copy file {0}.  Error: {1} ", file.FullName, eError.Message), LogLevel.Error);
					throw;
				}
			}
		}

		//public static void LogStateData(FoundationDataFileState state)
		//{
		//	Logger.Log(string.Format("Foundation: {0}({1})", state.FoundationUrlKey, state.FoundationId) + state.BaseDirectory, LogLevel.Info);
		//	Logger.Log("Base Directory: " + state.BaseDirectory, LogLevel.Info);
		//	Logger.Log("Client Root Directory: " + state.ClientRootDirectory, LogLevel.Info);
		//	Logger.Log(string.Format("Files Count: {0}", state.Files != null ? state.Files.Count : 0), LogLevel.Info);
		//	Logger.Log(string.Format("SequesterFiles Count: {0}", state.SequesterFiles != null ? state.SequesterFiles.Count : 0), LogLevel.Info);
		//	Logger.Log(string.Format("Moved Sequestered Path: {0}", state.SequesterPath), LogLevel.Info);
		//	Logger.Log(string.Format("Files Not Found Count: {0}", state.FilesNotFound != null ? state.FilesNotFound.Count : 0), LogLevel.Info);
		//	Logger.Log(string.Format("Moved From Directory: {0}", state.MovedFromDirectory), LogLevel.Info);
		//	Logger.Log(string.Format("Moved To Directory: {0}", state.MovedToDirectory), LogLevel.Info);
		//	Logger.Log(string.Format("Copied File Directory: {0}", state.OutputDirectory), LogLevel.Info);
		//	Logger.Log(string.Format("Total File Size: {0}", state.TotalSize), LogLevel.Info);
		//}

		public static void MoveFilesToDestination(FoundationDataFileState state)
		{
			Logger.Log("Move unreferenced data files start", LogLevel.Info);
			Logger.Log(string.Format("Current Task State:\r\n{0}", state), LogLevel.Info);

			if (state.SequesterFiles == null || state.SequesterFiles.Count == 0)
			{
				Logger.Log("MoveFilesToDestination: no files selected to copy", LogLevel.Warn);
				return;
			}

			if (string.IsNullOrEmpty(state.OutputDirectory))
			{
				Logger.Log("MoveFilesToDestination: No destination selected for copy", LogLevel.Error);
				return;
			}

			if (!Directory.Exists(state.OutputDirectory))
			{
				Directory.CreateDirectory(state.OutputDirectory);
			}

			foreach (FileInfo file in state.SequesterFiles)
			{
				string directory = string.Format("{0}\\{1}", state.OutputDirectory, file.Directory.FullName.Substring(state.ClientRootDirectory.Length));
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

			Logger.Log("Move unreferenced data files end", LogLevel.Info);
		}

		//public static void MoveFilesBack(FoundationDataFileState state)
		//{
		//	ClearFiles(state);
		//	SetFilesFromPath(state, state.MovedToDirectory);

		//	foreach (FileInfo file in state.Files)
		//	{
		//		try
		//		{
		//			string fullDestination = string.Format("{0}{1}", state.MovedFromDirectory,
		//				file.FullName.Substring(state.MovedToDirectory.Length));
		//			File.Move(file.FullName, fullDestination);
		//		}
		//		catch (Exception eError)
		//		{
		//			Logger.Log(string.Format("Unable to undo file {0}.  Error: {1} ", file.FullName, eError.Message), LogLevel.Error);
		//			throw;
		//		}
		//	}
		//}

		private static string BuildApplicationProcessFileName(FileInfo file)
		{
			if (string.IsNullOrEmpty(file.DirectoryName))
			{
				return string.Empty;
			}

			string applicantProcessId = string.Empty;
			var fileName = new StringBuilder();
			bool useProcessSubFolderFormat = false;

			var folders = new List<string>();
			folders.AddRange(file.DirectoryName.ToLower()
				.Split(Path.DirectorySeparatorChar));

			if (folders.Count - 2 >= 0)
			{
				int applicantProcessValue;
				if (int.TryParse(folders[folders.Count - 2], out applicantProcessValue))
				{
					applicantProcessId = applicantProcessValue.ToString("D10");
				}
				else if (!string.IsNullOrWhiteSpace(folders[folders.Count - 2]))
				{
					applicantProcessId = folders[folders.Count - 2];
				}
				else
				{
					Logger.Log(
					           String.Format(
					                         "BuildApplicationProcessFileName: the folder location for File {0} is invalid and can not be processed",
						           file.FullName), LogLevel.Error);
					return string.Empty;
				}

				var rootFileFolder = new DirectoryInfo(string.Join("\\", folders.GetRange(0, folders.Count - 1)));
				List<DirectoryInfo> subFolders = rootFileFolder.GetDirectories()
					.ToList();
				useProcessSubFolderFormat = subFolders.Where(sub => SUB_FOLDERS.Any(s => sub.FullName.Contains(s)))
					.Any();
			}

			if (useProcessSubFolderFormat)
			{
				fileName.AppendFormat("{0}_{1}_{2}", applicantProcessId, folders.Last(), file.Name);
			}
			else
			{
				fileName.AppendFormat("{0}_{1}", applicantProcessId, file.Name);
			}

			return fileName.ToString();

			//if (SUB_FOLDERS.Contains(folders.Last()))
			//	subFolderId = string.Format("_{0}", folders.Last());

			//fileName.Clear();
			//fileName.Append(applicantProcessId);
			//fileName.Append(subFolderId);
			//fileName.Append(string.Format("_{0}", file.Name));

			//return fileName.ToString();
		}

		public static void DeleteRecords(FoundationDataFileState state)
		{
			List<string> fileList = state.FilesNotFound;

			foreach (string file in fileList)
			{
				string[] splitPath = file.Split('\\');

				if (splitPath[1] == "supportingdocuments")
				{
					DeleteSupportingRecords(splitPath);
				}
				else if (splitPath[0].Contains("shared"))
				{
					DeleteSharedRecords(splitPath);
				}
				else
				{
					DeleteRequestRecords(splitPath, state);
				}
			}
		}

		private static void DeleteSupportingRecords(string[] splitPath)
		{
			try
			{
				if (splitPath[0].Contains("ORG-"))
				{
					int organizationId = Int32.Parse(splitPath[0].Substring(4));
					string fileName = splitPath[splitPath.Length - 1];

					RequestQuery.DeleteOrganizationSupportingRecords(organizationId, fileName);
				}
				else
				{
					int requestId = Int32.Parse(splitPath[0]);
					string fileName = splitPath[splitPath.Length - 1];

					RequestQuery.DeleteRequestSupportingRecords(requestId, fileName);
				}
			}

			catch (Exception eError)
			{
				MessageBox.Show(string.Format(RECORDS_DELETE_ERROR_FORMAT, eError.Message), RECORDS_DELETE_CAPTION,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private static void DeleteSharedRecords(string[] splitPath)
		{
			try
			{
				string fileName = splitPath[splitPath.Length - 1];

				RequestQuery.DeleteSharedRecords(fileName);
			}

			catch (Exception eError)
			{
				MessageBox.Show(string.Format(RECORDS_DELETE_ERROR_FORMAT, eError.Message), RECORDS_DELETE_CAPTION,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private static void DeleteRequestRecords(string[] splitPath, FoundationDataFileState state)
		{
			try
			{
				string requestProcessCode = splitPath[0];
				string stageName = splitPath[1];
				string fileName = splitPath[splitPath.Length - 1];

				RequestQuery.DeleteRequestRecords(state.FoundationId, requestProcessCode, stageName, fileName);
			}

			catch (Exception eError)
			{
				MessageBox.Show(string.Format(RECORDS_DELETE_ERROR_FORMAT, eError.Message), RECORDS_DELETE_CAPTION,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}