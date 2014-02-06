using System.Collections.Generic;
using System.Data;
using DataProvider.MySQL;
using MySql.Data.MySqlClient;

namespace API.Data
{
	public class ApplicantProcessQuery
	{
        public Dictionary<string, List<string>> BuildFoundationDictionary()
		{
			Command command = new Command {SqlStatementId = "SELECT_ALL_URL_KEYS_AND_NAMES"};

			DataAccess access = new DataAccess();

			Dictionary<string, List<string>> foundations = new Dictionary<string, List<string>>();

			using (MySqlDataReader reader = access.GetReader(command))
			{
				while (reader.Read())
				{
                    string foundationId = !reader.IsDBNull(0) ? reader.GetString(0) : string.Empty;
					string foundationUrlKey = !reader.IsDBNull(0) ? reader.GetString(1) : string.Empty;
					string foundationName = !reader.IsDBNull(1) ? reader.GetString(2) : string.Empty;

				    List<string> foundationData = new List<string>();
                    foundationData.Add(foundationId);
                    foundationData.Add(foundationUrlKey);

                    foundations.Add(string.Format("{0} - {1}", foundationUrlKey, foundationName), foundationData);
				}
			}

			return foundations;
		}

		public Dictionary<string, string> BuildFoundationProcessInfoDictionary(string urlKey)
		{
			ParameterSet parameters = new ParameterSet();
			parameters.Add(DbType.String, "URL_KEY", urlKey);
			Command command = new Command
			{
				SqlStatementId = "SELECT_FOUNDATION_PROCESS_INFO", 
				ParameterCollection = parameters
			};

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

		public List<int> RetrieveApplicationProcessInfo(int foundationProcess)
		{
			ParameterSet parameters = new ParameterSet();
			parameters.Add(DbType.Int32, "FOUNDATION_PROCESS", foundationProcess);
			Command command = new Command
			{
				SqlStatementId = "SELECT_APPLICATION_PROCESS_INFO", 
				ParameterCollection = parameters
			};

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

		

	}

}
