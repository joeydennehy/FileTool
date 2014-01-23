using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using DataProvider.MySQL;
using MySql.Data.MySqlClient;
using System.Linq;

namespace API
{
	public class ApplicantProcessQuery
	{

		//public  methods to retrieve:

		//1Client URLKeys and names
		public Dictionary<string, string> RetrieveFoundationInformation()
		{
			Command command = new Command {SqlStatementId = "SELECT_ALL_URL_KEYS_AND_NAMES"};

			DataAccess access = new DataAccess();

			Dictionary<string, string> foundations = new Dictionary<string, string>();

			using (MySqlDataReader reader = access.GetReader(command))
			{
				while (reader.Read())
				{
					if (!reader.IsDBNull(0))
					{
						var foundationId = reader.GetString(0);
						foundations.Add(foundationId + " - " + reader.GetString(1), foundationId);
					}
				}
			}


			return foundations;
		}

		// 2All process IDs
		public Dictionary<string, string> RetrieveFoundationProcessInfo(string urlKey)
		{
			ParameterSet parameters = new ParameterSet();
			parameters.Add(DbType.String, "URL_KEY", urlKey);
			Command command = new Command {SqlStatementId = "SELECT_FOUNDATION_PROCESS_INFO", ParameterCollection = parameters};

			DataAccess access = new DataAccess();

			Dictionary<string, string> foundationProcesses = new Dictionary<string, string>();

			using (MySqlDataReader reader = access.GetReader(command))
			{
				while (reader.Read())
				{
					var foundationProcessId = reader.GetString(0);
					foundationProcesses.Add(foundationProcessId + " - " + reader.GetString(1), foundationProcessId);
				}
			}

			return foundationProcesses;
		}

		//3 ApplicantProcesscodes with a give process ID

		public List<int> RetrieveApplicationProcessInfo(string foundationProcess)
		{
			ParameterSet parameters = new ParameterSet();
			parameters.Add(DbType.Int32, "FOUNDATION_PROCESS", foundationProcess);
			Command command = new Command {SqlStatementId = "SELECT_APPLICATION_PROCESS_INFO", ParameterCollection = parameters};

			DataAccess access = new DataAccess();

			List<int> foundationProcesses = new List<int>();

			using (MySqlDataReader reader = access.GetReader(command))
			{
				while (reader.Read())
				{
					foundationProcesses.Add(reader.GetInt32(0));
				}
			}

			return foundationProcesses;
		}

		public void RetrieveFiles(string baseDirectory, string urlKey, List<int> applicantProcessIds, string copyDirectory)
		{
			if (!Directory.Exists(copyDirectory))
			{
				Directory.CreateDirectory(copyDirectory);
			}
			List<string> files = new List<string>();
			foreach (var applicantProcessId in applicantProcessIds)
			{
				string directoryPath = baseDirectory + "/" + urlKey + "/" + applicantProcessId;
				if (Directory.Exists(directoryPath))
				{
					files.AddRange(Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories));
				}
			}


			bool hasOtherStages = files.Any(file => Path.GetDirectoryName(file)
			                                            .TrimEnd(Path.DirectorySeparatorChar)
			                                            .Split(Path.DirectorySeparatorChar)
			                                            .Last()
			                                            .Contains("loi") || Path.GetDirectoryName(file)
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
				string destFile = Path.Combine(copyDirectory, fileName);

				if (File.Exists(destFile))
				{
					int interation = 1;
					string tempFullFileName = destFile;
					while (!File.Exists(tempFullFileName))
					{
						string tempFileName = Path.GetFileNameWithoutExtension(fileName) + "(" + interation + ")" + Path.GetExtension(fileName);
						tempFullFileName = Path.Combine(copyDirectory, tempFileName);
						++interation;
					}
					destFile = tempFullFileName;
				}
				File.Copy(file, destFile, true);
			}
		}

	}

}
