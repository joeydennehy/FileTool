﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

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
		public List<string> Files { get; set; }
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
			state.Files = new List<string>();
			state.TotalSize = 0;
			string[] maskPatterns = state.FileMask.Split('|');

			foreach (var applicantProcessId in state.FoundationApplicantProcessIds)
			{
				string directoryPath = state.RootProcessDirectory + applicantProcessId;
				if (Directory.Exists(directoryPath))
				{
					foreach (string maskPattern in maskPatterns)
					{
						state.Files.AddRange(Directory.GetFiles(directoryPath, maskPattern, SearchOption.AllDirectories));
						//state.TotalSize += DirectorySize(directoryPath, maskPattern, true);
					}
				}
			}
		}

		private static long DirectorySize(string sourceDir, string maskPattern, bool recurse)
		{
			long size = 0;
			string[] fileEntries = Directory.GetFiles(sourceDir, maskPattern);

			foreach (string fileName in fileEntries)
			{
				Interlocked.Add(ref size, (new FileInfo(fileName)).Length);
			}

			if (recurse)
			{
				string[] subdirEntries = Directory.GetDirectories(sourceDir);

				Parallel.For<long>(0, subdirEntries.Length, () => 0, (i, loop, subtotal) =>
				{
					if ((File.GetAttributes(subdirEntries[i]) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
					{
						subtotal += DirectorySize(subdirEntries[i], maskPattern, true);
						return subtotal;
					}
					return 0;
				},
					 (x) => Interlocked.Add(ref size, x)
				);
			}
			return size;
		}

		public static void CopyFilesToDestination(FileProcessingState state)
		{
			if (!Directory.Exists(state.OutputDirectory))
			{
				Directory.CreateDirectory(state.OutputDirectory);
			}

			bool hasOtherStages = state.Files.Any(
				file => Path.GetDirectoryName(file)
					.TrimEnd(Path.DirectorySeparatorChar)
					.Split(Path.DirectorySeparatorChar)
					.Last()
					.Contains("loi")
				|| Path.GetDirectoryName(file)
					.TrimEnd(Path.DirectorySeparatorChar)
					.Split(Path.DirectorySeparatorChar)
					.Last()
					.Contains("qualification"));

			// Copy the files and overwrite destination files if they already exist. \
			int i = 0;
			foreach (string file in state.Files)
			{
				// Use static Path methods to extract only the file name from the path.
				string[] directory = Path.GetDirectoryName(file)
												 .TrimEnd(Path.DirectorySeparatorChar)
												 .Split(Path.DirectorySeparatorChar);
				string stage = directory.Last();
				string applicantProcessId = directory[directory.Count() - 2];
				string fileName = string.Format("{0}{1}_{2}", applicantProcessId, hasOtherStages ? "_" + stage : "",
														  Path.GetFileName(file));
				string destFile = Path.Combine(state.OutputDirectory, fileName);

				if (File.Exists(destFile))
				{
					int iteration = 1;
					string tempFullFileName = destFile;
					while (!File.Exists(tempFullFileName))
					{
						string tempFileName = Path.GetFileNameWithoutExtension(fileName) + "(" + iteration + ")" + Path.GetExtension(fileName);
						tempFullFileName = Path.Combine(state.OutputDirectory, tempFileName);
						++iteration;
					}
					destFile = tempFullFileName;
				}

				global::System.Diagnostics.Debug.Print(string.Format("{0}:From:[{1}] To:[{2}", i++, file, destFile));

				File.Copy(file, destFile, true);

				if (state.SequesterPatterns != null && state.SequesterPatterns.Count > 0)
				{
					string tempFileName = Path.GetFileNameWithoutExtension(destFile);
					if (state.SequesterPatterns.Any(tempFileName.Contains)) {
						File.Copy(destFile, state.OutputDirectory + "\\" + state.SequesterPath + "\\" + tempFileName + Path.GetExtension(destFile), true);
						File.Delete(destFile);
					}
				}
			}
		}

	}
}