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
		private const string RECORDS_DELETE_CAPTION = "Records Delete";
		private const string RECORDS_DELETE_ERROR_FORMAT = "Records Delete procedure gave the following error {0}.";

		public static void CopyApplicationProcessFiles(FoundationDataFileState state)
		{
			CopyFilesToDestination(state, state.OutputDirectory);

			if (!string.IsNullOrEmpty(state.SequesterPath) && state.SequesterFiles.Count > 0)
			{
				CopyFilesToDestination(state, state.SequesterPath);
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
			if (string.IsNullOrEmpty(state.FileType) || state.FileType == "All")
			{
				SetRequestFiles(state);
				SetOrganizationSupportingFiles(state);
				SetAttachmentFiles(state);
				SetMergeTemplateFiles(state);
				SetSharedDocumentFiles(state);
			}
			else
			{
				switch (state.FileType)
				{
					case "requests":
						SetRequestFiles(state);
						break;
					case "organizations":
						SetOrganizationSupportingFiles(state);
						break;
					case "attachments":
						SetAttachmentFiles(state);
						break;
					case "mergetemplates":
						SetMergeTemplateFiles(state);
						break;
					case "shareddocuments":
						SetSharedDocumentFiles(state);
						break;
				}
			}
		}

		private static void SetRequestFiles(FoundationDataFileState state)
		{
			string directoryPath = "";
			List<string> pathChecked = new List<string>();

			foreach (FoundationDataFileState.FileInfo requestFile in state.RequestFiles)
			{
				directoryPath = string.Format("{0}requests\\request.{1}\\submission.{2}", state.ClientRootDirectory,
					requestFile.RequestId, requestFile.SubmissionId);
				if (!pathChecked.Contains(directoryPath))
				{
					SetFilesFromPath(state, directoryPath);
					pathChecked.Add(directoryPath);
				}
			}

			foreach (FoundationDataFileState.FileInfo requestSupportingFile in state.RequestSupportingFiles)
			{
				directoryPath = string.Format("{0}requests\\request.{1}\\documents", state.ClientRootDirectory,
					requestSupportingFile.RequestId);
				if (!pathChecked.Contains(directoryPath))
				{
					SetFilesFromPath(state, directoryPath);
					pathChecked.Add(directoryPath);
				}
			}
		}

		private static void SetOrganizationSupportingFiles(FoundationDataFileState state)
		{
			string directoryPath = "";
			List<string> pathChecked = new List<string>();

			foreach (FoundationDataFileState.FileInfo orgSupportingFile in state.OrganizationSupportingFiles)
			{
				directoryPath = string.Format("{0}organizations\\organization.{1}\\documents", state.ClientRootDirectory,
					orgSupportingFile.OrganizationId);
				if (!pathChecked.Contains(directoryPath))
				{
					SetFilesFromPath(state, directoryPath);
					pathChecked.Add(directoryPath);
				}
			}
		}

		private static void SetAttachmentFiles(FoundationDataFileState state)
		{
			string directoryPath = string.Format("{0}attachments", state.ClientRootDirectory);
			SetFilesFromPath(state, directoryPath);
		}

		private static void SetMergeTemplateFiles(FoundationDataFileState state)
		{
			string directoryPath = string.Format("{0}mergetemplates", state.ClientRootDirectory);
			SetFilesFromPath(state, directoryPath);
		}

		private static void SetSharedDocumentFiles(FoundationDataFileState state)
		{
			string directoryPath = string.Format("{0}shareddocuments", state.ClientRootDirectory);
			SetFilesFromPath(state, directoryPath);
		}
	

	private static void SetFilesFromPath(FoundationDataFileState state, string FilePath)
		{
			if (Directory.Exists(FilePath))
			{
				string[] files = Directory.GetFiles(FilePath, "*.*", SearchOption.AllDirectories)
					.ToArray();

				foreach (string fileString in files)
				{
					var file = new FileInfo(fileString);
					state.Files.Add(file);
					state.TotalSize += file.Length;
				}
			}
		}

		public static void ReconcileFileListToDatabase(FoundationDataFileState state, Dictionary<string, string> fileList)
		{
			ClearFiles(state);
			SetFilesFromPath(state, state.ClientRootDirectory);

			foreach (FileInfo file in state.Files)
			{
				string partialFileName = "\\" + file.FullName.Replace(state.ClientRootDirectory, string.Empty)
					.ToLower();
				if (!fileList.Keys.Contains(partialFileName))
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

		/*public static void CleanUpFolders(FoundationDataFileState state)
		{
			string[] validDirectories =
			{
				"loi", "application", "qualification", "evaluation 1", "evaluation 2", "followup",
				"supportingdocuments"
			};

			string[] directories = Directory.GetDirectories(state.ClientRootDirectory);

			foreach (string directory in directories)
			{
				if (!directory.Contains("shared"))
				{
					string[] subDirectories = Directory.GetDirectories(directory);

					foreach (string subDirectory in subDirectories)
					{
						if (!validDirectories.Any(dir => subDirectory.Contains(dir)))
						{
							Directory.Delete(subDirectory, true);
						}
					}
				}
			}
		}

		public static bool CheckFoundationPath(FoundationDataFileState state)
		{
			return Directory.Exists(state.ClientRootDirectory);
		}

		public static bool CheckDirectoryExist(string directory)
		{
			if (Directory.Exists(directory))
			{
				return true;
			}

			return false;
		}*/

		private static void CopyFilesToDestination(FoundationDataFileState state, string destinationFolder)
		{
			if (state.Files == null || state.Files.Count == 0)
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

			foreach (FoundationDataFileState.FileInfo file in state.RequestFiles)
			{
				string sourcePath = string.Format("{0}requests\\request.{1}\\submission.{2}\\answer.{3}", state.ClientRootDirectory,
					file.RequestId, file.SubmissionId, file.AnswerId);
				CopyFile(sourcePath, destinationFolder, file);
			}

			foreach (FoundationDataFileState.FileInfo file in state.RequestSupportingFiles)
			{
				string sourcePath = string.Format("{0}requests\\request.{1}\\documents\\document.{2}", state.ClientRootDirectory,
					file.RequestId, file.DocumentId);
				CopyFile(sourcePath, destinationFolder, file);
			}

			foreach (FoundationDataFileState.FileInfo file in state.OrganizationSupportingFiles)
			{
				string sourcePath = string.Format("{0}organizations\\organization.{1}\\documents\\document.{2}", state.ClientRootDirectory,
					file.OrganizationId, file.DocumentId);
				CopyFile(sourcePath, destinationFolder, file);
			}

			foreach (FoundationDataFileState.FileInfo file in state.AttachmentFiles)
			{
				string sourcePath = string.Format("{0}attachments\\attachment.{1}", state.ClientRootDirectory, file.AttachmentId);
				CopyFile(sourcePath, destinationFolder, file);
			}

			foreach (FoundationDataFileState.FileInfo file in state.MergeTemplateFiles)
			{
				string sourcePath = string.Format("{0}mergetemplates\\mergetemplate.{1}", state.ClientRootDirectory, file.MergeTemplateId);
				CopyFile(sourcePath, destinationFolder, file);
			}

			foreach (FoundationDataFileState.FileInfo file in state.SharedFiles)
			{
				string sourcePath = string.Format("{0}shareddocuments\\document.{1}", state.ClientRootDirectory, file.DocumentId);
				CopyFile(sourcePath, destinationFolder, file);
			}
		}

		private static void CopyFile(string sourcePath, string destinationFolder, FoundationDataFileState.FileInfo file)
		{
			string fullFileName = string.Format("{0}{1}", destinationFolder, BuildFilePath(file));
			string directory = Path.GetDirectoryName(fullFileName);
			if (directory == null || !Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}

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
				try
				{
					File.Copy(sourcePath, fullFileName);
					Logger.Log("Copied file " + sourcePath + " to " + fullFileName, LogLevel.Info);
				}
				catch (Exception e) { }
			}
			catch (Exception eError)
			{
				Logger.Log(string.Format("Unable to copy file {0}.  Error: {1} ", sourcePath, eError.Message), LogLevel.Error);
				throw;
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

		/*public static void MoveFilesToDestination(FoundationDataFileState state, ref StringBuilder outputData,
			bool cleanSequesterFolder = false)
		{
			if (outputData == null)
			{
				outputData = new StringBuilder();
			}
			var movedFilesOutput = new StringBuilder();
			var errorFilesOutput = new StringBuilder();

			int movedFileCount = 0, errorCount = 0;

			Logger.Log("Move unreferenced data files start", LogLevel.Info);
			Logger.Log(string.Format("Current Task State:\r\n{0}", state), LogLevel.Info);

			if (state.SequesterFiles == null || state.SequesterFiles.Count == 0)
			{
				const string OUTPUT_WARNING = "MoveFilesToDestination: no files selected to copy";
				Logger.Log(OUTPUT_WARNING, LogLevel.Warn);
				outputData.AppendLine(OUTPUT_WARNING);
				return;
			}

			if (string.IsNullOrEmpty(state.OutputDirectory))
			{
				const string OUTPUT_ERROR = "MoveFilesToDestination: No destination selected for copy";
				Logger.Log(OUTPUT_ERROR, LogLevel.Error);
				outputData.AppendLine(OUTPUT_ERROR);
				return;
			}
			string outputFolder = state.OutputDirectory;
			if (outputFolder.LastIndexOf(state.FoundationUrlKey, StringComparison.CurrentCulture) < 0)
			{
				outputFolder = string.Format("{0}\\{1}", outputFolder, state.FoundationUrlKey);
			}

			if (!Directory.Exists(outputFolder))
			{
				Directory.CreateDirectory(outputFolder);
			}
			else
			{
				if (cleanSequesterFolder)
				{
					foreach (string directory in Directory.GetDirectories(outputFolder))
					{
						var subFolder = new DirectoryInfo(directory);
						subFolder.Delete(true);
					}
					foreach (string file in Directory.GetFiles(outputFolder))
					{
						var fileInfo = new FileInfo(file);
						fileInfo.Delete();
					}
				}
				else
				{
					throw new IOException("Directory Not Empty");
				}
			}

			foreach (FileInfo file in state.SequesterFiles)
			{
				string directory = string.Format("{0}\\{1}", outputFolder,
					file.Directory.FullName.Substring(state.ClientRootDirectory.Length - 1));
				if (!Directory.Exists(directory))
				{
					Directory.CreateDirectory(directory);
				}
				string fullDestinationPath = string.Format("{0}\\{1}", directory, file.Name);
				try
				{
					File.Move(file.FullName, fullDestinationPath);
					string movedFileOutput = string.Format("Moved file " + file.FullName + " to " + fullDestinationPath);
					movedFileCount += 1;
					movedFilesOutput.AppendLine(movedFileOutput);
					Logger.Log(movedFileOutput, LogLevel.Info);
				}
				catch (Exception eError)
				{
					string errorText = string.Format("Unable to move file {0}.  Error: {1} ", file.FullName, eError.Message);
					errorCount += 1;
					errorFilesOutput.AppendLine(errorText);
					Logger.Log(string.Format(errorText), LogLevel.Error);
				}
			}

			outputData.AppendLine("File Move Details:");
			outputData.AppendLine(string.Format("Total number of files moved: {0}", movedFileCount));
			outputData.AppendLine(string.Format("Total number of errors encountered: {0}", errorCount));

			outputData.AppendLine("Files Moved:");
			outputData.Append(movedFilesOutput);
			outputData.AppendLine();

			if (errorCount > 0)
			{
				outputData.AppendLine("Errors Encountered:");
				outputData.Append(errorFilesOutput);
				outputData.AppendLine();
			}

			Logger.Log("Move unreferenced data files end", LogLevel.Info);
		}*/

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

		private static string BuildFilePath(FoundationDataFileState.FileInfo file)
		{
			if (string.IsNullOrEmpty(file.FileName))
			{
				return string.Empty;
			}

			var fileName = new StringBuilder();
			fileName.Append(string.Format("{0}", file.FilePath));

			return fileName.ToString();
		}
	}
}