using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DataProvider.MySQL
{

	public class DataAccess
	{
		private MySqlConnector dataConnection;

		public DataAccess(DataAccessType accessType = DataAccessType.DATA)
		{
			dataConnection = new MySqlConnector(accessType);
		}

		#region Data Access Methods

		//public MySqlDataReader GetReader(Command command)
		//{
		//	MySqlCommand cmd;
		//	MySqlDataReader reader;
		//	MySqlConnection connection = dataConnection.GetConnection();


		//	return 
		//}

		//public MySqlTransaction BeginTransaction()
		//{
		//	return dataConnection.PrimaryConnection.BeginTransaction();
		//}



		#endregion

	}

	public enum DataAccessType
	{
		DATA,
		LOGGING,
	}
}
