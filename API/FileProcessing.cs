using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API
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
 
		public NetworkCredential BaseDirectoryCredentials { get; set; }
		public NetworkCredential OutputDirectoryCredentials { get; set; }

		public FileProcessingState()
		{
			FileMask = "*.*";
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
		public static void SetFilelist(FileProcessingState fileProcessingInfo)
		{
			fileProcessingInfo.Files = new List<string>();
			foreach (var applicantProcessId in fileProcessingInfo.FoundationApplicantProcessIds)
			{
				
				string directoryPath = fileProcessingInfo.BaseDirectory + "\\" + fileProcessingInfo.FoundationUrlKey + "\\" + applicantProcessId;
				if (Directory.Exists(directoryPath))
				{
					fileProcessingInfo.Files.AddRange(Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories));
				}
			}
		}

		public static void CopyFilesToDestination(FileProcessingState fileProcessingInfo)
		{
			if (!Directory.Exists(fileProcessingInfo.OutputDirectory))
			{
				Directory.CreateDirectory(fileProcessingInfo.OutputDirectory);
			}

			string directoryPath;
			List<string> files = new List<string>();
			foreach (var applicantProcessId in fileProcessingInfo.FoundationApplicantProcessIds)
			{
				directoryPath = fileProcessingInfo.BaseDirectory + "/" + fileProcessingInfo.FoundationUrlKey + "/" + applicantProcessId;
				if (Directory.Exists(directoryPath))
				{
					files.AddRange(Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories));
				}
			}
			//List<string> files = new List<string>();
			//foreach (var applicantProcessId in fileProcessingInfo.FoundationApplicantProcessIds)
			//{
			//	string directoryPath = fileProcessingInfo.BaseDirectory + "/" + fileProcessingInfo.FoundationUrlKey + "/" + applicantProcessId;
			//	if (Directory.Exists(directoryPath))
			//	{
			//		files.AddRange(Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories));
			//	}
			//}

			bool hasOtherStages = files.Any(
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

			// Copy the files and overwrite destination files if they already exist. 
			foreach (string file in files)
			{
				// Use static Path methods to extract only the file name from the path.
				string[] directory = Path.GetDirectoryName(file)
												 .TrimEnd(Path.DirectorySeparatorChar)
												 .Split(Path.DirectorySeparatorChar);
				string stage = directory.Last();
				string applicantProcessId = directory[directory.Count() - 2];
				string fileName = string.Format("{0}{1}_{2}", applicantProcessId, hasOtherStages ? "_" + stage : "",
														  Path.GetFileName(file));
				string destFile = Path.Combine(fileProcessingInfo.OutputDirectory, fileName);

				if (File.Exists(destFile))
				{
					int interation = 1;
					string tempFullFileName = destFile;
					while (!File.Exists(tempFullFileName))
					{
						string tempFileName = Path.GetFileNameWithoutExtension(fileName) + "(" + interation + ")" + Path.GetExtension(fileName);
						tempFullFileName = Path.Combine(fileProcessingInfo.OutputDirectory, tempFileName);
						++interation;
					}
					destFile = tempFullFileName;
				}
				File.Copy(file, destFile, true);
			}
		}

	}
}
