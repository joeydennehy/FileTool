using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using DataProvider.MySQL;
using MySql.Data.MySqlClient;

namespace API.Data
{
	public class ApplicantProcessQuery
	{
		public Dictionary<string, List<string>> BuildFoundationDictionary()
		{
			var command = new Command
			{
				SqlStatementId = "SELECT_ALL_URL_KEYS_AND_NAMES"
			};

			var access = new DataAccess();

			var foundations = new Dictionary<string, List<string>>();

			using (MySqlDataReader reader = access.GetReader(command))
			{
				while (reader.Read())
				{
					string foundationId = !reader.IsDBNull(0) ? reader.GetString(0) : string.Empty;
					string foundationUrlKey = !reader.IsDBNull(0) ? reader.GetString(1) : string.Empty;
					string foundationName = !reader.IsDBNull(1) ? reader.GetString(2) : string.Empty;

					var foundationData = new List<string>();
					foundationData.Add(foundationId);
					foundationData.Add(foundationUrlKey);

					foundations.Add(string.Format("{0} - {1}", foundationUrlKey, foundationName), foundationData);
				}
			}

			return foundations;
		}

		public Dictionary<string, string> BuildFoundationProcessInfoDictionary(string urlKey)
		{
			var parameters = new ParameterSet();
			parameters.Add(DbType.String, "URL_KEY", urlKey);
			var command = new Command
			{
				SqlStatementId = "SELECT_FOUNDATION_PROCESS_INFO",
				ParameterCollection = parameters
			};

			var access = new DataAccess();

			var foundationProcesses = new Dictionary<string, string>();

			using (MySqlDataReader reader = access.GetReader(command))
			{
				while (reader.Read())
				{
					string foundationProcessId = reader.GetString(0);
					foundationProcesses.Add(foundationProcessId + " - " + reader.GetString(1), foundationProcessId);
				}
			}

			return foundationProcesses;
		}

		public static List<string> GetFoundationFileList(string urlKey)
		{
			var fileList = new List<string>();

			var queryIds = new List<string>
			{
				"SELECT_SHARED_FILES_BY_FOUNDATION_ID",
				"SELECT_ORG_SUPPORTING_DOCUMENTS_BY_FOUNDATION_ID",
				"SELECT_APPLICATION_SUPPORTING_DOCUMENTS_BY_FOUNDATION_ID",
				"SELECT_REQUEST_FILES_BY_URL_KEY"
			};

			var parameters = new ParameterSet();
			parameters.Add(DbType.String, "URL_KEY", urlKey);
			var access = new DataAccess();

			foreach (string queryId in queryIds)
			{
				var command = new Command()
				{
					SqlStatementId = queryId,
					ParameterCollection = parameters
				};

				using (MySqlDataReader reader = access.GetReader(command))
				{
					while (reader.Read())
					{
						if (!reader.IsDBNull(0))
						{
							string partialFileName = reader.GetString(0)
								.Split(new[] {"[:|:]"}, StringSplitOptions.None)[0];
							string fileName = Path.GetFileName(partialFileName);

							if (!string.IsNullOrEmpty(fileName) && !fileList.Contains(partialFileName))
							{
								fileList.Add(partialFileName.ToLower());
							}
						}
					}
				}
			}

			return fileList;
		}

		public List<int> RetrieveApplicationProcessInfo(int foundationProcess)
		{
			var parameters = new ParameterSet();
			parameters.Add(DbType.Int32, "FOUNDATION_PROCESS", foundationProcess);
			var command = new Command
			{
				SqlStatementId = "SELECT_APPLICATION_PROCESS_INFO",
				ParameterCollection = parameters
			};

			var access = new DataAccess();

			var foundationProcesses = new List<int>();

			using (MySqlDataReader reader = access.GetReader(command))
			{
				while (reader.Read())
				{
					foundationProcesses.Add(reader.GetInt32(0));
				}
			}

			return foundationProcesses;
		}
	}
}