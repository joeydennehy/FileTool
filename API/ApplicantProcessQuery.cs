using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DataProvider.MySQL;
using MySql.Data.MySqlClient;

namespace API
{
	 public class ApplicantProcessQuery
	 {
		
		//public  methods to retrieve:

		//1Client URLKeys and names
		 public Dictionary<string, string> RetrieveFoundationInformation()
		{
			Command command = new Command
			{
				SqlStatementId = "SELECT_ALL_URL_KEYS_AND_NAMES"
			};

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
		public Dictionary<string, int> RetrieveFoundationProcessInfo(string urlKey)
		{
			ParameterSet parameters = new ParameterSet();
			parameters.Add(DbType.String, "URL_KEY", urlKey);
			Command command = new Command {SqlStatementId = "SELECT_FOUNDATION_PROCESS_INFO", ParameterCollection = parameters};

			DataAccess access = new DataAccess();
			MySqlDataReader reader = access.GetReader(command);

			Dictionary<string, int> foundationProcesses = new Dictionary<string, int>();

			if (reader.HasRows)
			{
				while (reader.Read())
				{
					var foundationProcessId = reader.GetInt32(0);
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
			MySqlDataReader reader = access.GetReader(command);

			List<int> foundationProcesses = new List<int>();

			if (reader.HasRows)
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
