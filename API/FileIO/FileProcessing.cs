using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using API.Logging;

namespace API.FileIO
{
	public class FileProcessingState
	{
		public string BaseDirectory { get; set; }
		public string FoundationUrlKey { get; set; }
		public int FoundationProcessId { get; set; }
		public List<int> FoundationApplicantProcessIds { get; set; }
		public string OutputDirectory { get; set; }
		public string FileMask { get; set; }
		public List<FileInfo> Files { get; set; }
		public long TotalSize { get; set; }
		public List<string> SequesterPatterns { get; set; }
		public string SequesterPath { get; set; }
 
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

			//Defaulting the set for now.
			SequesterPatterns = new List<string>
			{
				"IRS",
				"W9",
				"W-9",
				"501",
				"990"
			};
			SequesterPath = OutputDirectory + "\\Sequester";
		}

		public bool Validate()
		{
			return 
				!string.IsNullOrEmpty(BaseDirectory) 
				&& !string.IsNullOrEmpty(FoundationUrlKey)
				&& !string.IsNullOrEmpty(OutputDirectory)
				&& FoundationProcessId > 0
				&& (FoundationApplicantProcessIds != null && FoundationApplicantProcessIds.Count != 0)
			;
		}
	}

	public static class FileProcessing
	{
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
							}
							state.Files.Add(file);
							state.TotalSize += file.Length;
						}
					}
				}
			}
		}

		public static void CopyFilesToDestination(FileProcessingState state)
		{
			//if (!Directory.Exists(state.OutputDirectory))
			//{
			//	Directory.CreateDirectory(state.OutputDirectory);
			//}

			//foreach (FileInfo file in state.Files)
			//{
			//	file.DirectoryName
			//}
		}

		public static void CopyFilesToDestinationOld(FileProcessingState state)
		{
			//	if (!Directory.Exists(state.OutputDirectory))
			//	{
			//		Directory.CreateDirectory(state.OutputDirectory);
			//	}

			//bool hasOtherStages = state.Files.Any(
			//	file => Path.GetDirectoryName(file)
			//		.TrimEnd(Path.DirectorySeparatorChar)
			//		.Split(Path.DirectorySeparatorChar)
			//		.Last()
			//		.Contains("loi")
			//	|| Path.GetDirectoryName(file)
			//		.TrimEnd(Path.DirectorySeparatorChar)
			//		.Split(Path.DirectorySeparatorChar)
			//		.Last()
			//		.Contains("qualification"));

			//// Copy the files and overwrite destination files if they already exist. \
			//int i = 0;
			//foreach (string file in state.Files)
			//{
			//	// Use static Path methods to extract only the file name from the path.
			//	string[] directory = Path.GetDirectoryName(file)
			//									 .TrimEnd(Path.DirectorySeparatorChar)
			//									 .Split(Path.DirectorySeparatorChar);
			//	string stage = directory.Last();
			//	string applicantProcessId = directory[directory.Count() - 2];
			//	string fileName = string.Format("{0}{1}_{2}", applicantProcessId, hasOtherStages ? "_" + stage : "",
			//											  Path.GetFileName(file));
			//	string destFile = Path.Combine(state.OutputDirectory, fileName);

			//	if (File.Exists(destFile))
			//	{
			//		int iteration = 1;
			//		string tempFullFileName = destFile;
			//		while (!File.Exists(tempFullFileName))
			//		{
			//			string tempFileName = Path.GetFileNameWithoutExtension(fileName) + "(" + iteration + ")" + Path.GetExtension(fileName);
			//			tempFullFileName = Path.Combine(state.OutputDirectory, tempFileName);
			//			++iteration;
			//		}
			//		destFile = tempFullFileName;
			//	}

			//	global::System.Diagnostics.Debug.Print(string.Format("{0}:From:[{1}] To:[{2}", i++, file, destFile));

			//	File.Copy(file, destFile, true);
			//	Logger.Log("Copy file " + file + " to " + destFile, Logger.INFO);
			//	if (state.SequesterPatterns != null && state.SequesterPatterns.Count > 0)
			//	{
			//		string tempFileName = Path.GetFileNameWithoutExtension(destFile);
			//		if (state.SequesterPatterns.Any(tempFileName.Contains))
			//		{
			//			File.Copy(destFile, state.OutputDirectory + "\\" + state.SequesterPath + "\\" + tempFileName + Path.GetExtension(destFile), true);
			//			File.Delete(destFile);
			//		}
			//	}
			//}
		}

	}
}
