using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.MySQL;

namespace API
{
	 public class ApplicantProcessQuery
	 {
		
		//public  methods to retrieve:

		//1Client URLKeys and names
		public Dictionary<string, int> RetrieveFoundationInformation()
		{
			Command command = new Command("SELECT_ALL_URL_KEYS_AND_NAMES");

			SqlDataReader reader = command.ExecuteReader();

			Dictionary<string, int> foundations = new Dictionary<string, int>();

			if (reader.HasRows)
			{
				while (reader.Read())
				{
					foundations.Add(reader.GetString(0) + " - " + reader.GetString(1), reader.GetInt32(0));
				}
			}

			return foundations;
		}
		// 2All process IDs
		public Dictionary<string, int> RetrieveFoundationProcessInfo(string urlKey)
		{
			Parameters parameters = new Parameters();
			parameters.Add(DbType.Int32, "URL_KEY", urlKey);
			Command command = new Command("SELECT_FOUNDATION_PROCESS_INFO", parameters);

			SqlDataReader reader = command.ExecuteReader();

			Dictionary<string, int> foundationProcesses = new Dictionary<string, int>();

			if (reader.HasRows)
			{
				while (reader.Read())
				{
					foundationProcesses.Add(reader.GetString(0) + " - " + reader.GetString(1), reader.GetInt32(0));
				}
			}

			return foundationProcesses;
		}

		//3 ApplicantProcesscodes with a give process ID

		public List<int> RetrieveApplicationProcessInfo(string foundationProcess)
		{
			Parameters parameters = new Parameters();
			parameters.Add(DbType.Int32, "FOUNDATION_PROCESS", foundationProcess);
			Command command = new Command("SELECT_APPLICATION_PROCESS_INFO", parameters);

			SqlDataReader reader = command.ExecuteReader();

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
