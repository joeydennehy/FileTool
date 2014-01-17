using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Database.MySQL
{
	public class MySqlConnector
	{
		#region Private Variable

		private const string PRIMARY_DB_CONNECTION_NAME = "MasterDatabase";
		private const string LOG_DB_CONNECTION_NAME = "LogConnection";

		private string PrimaryConnectionString = string.Empty;
		private string LoggingConnectionString = string.Empty;

		MySqlConnection connection = null;

		#endregion

		#region Constructor

		public MySqlConnector()
		{
			Initialize();
		}

		#endregion
		
		#region Public Properties

		public MySqlConnection Connection
		{ get { return connection; } }

		#endregion

		#region Private Methods
		private void Initialize()
		{
			try
			{
				PrimaryConnectionString = ConfigurationManager.ConnectionStrings[PRIMARY_DB_CONNECTION_NAME].ConnectionString;
			}
			catch (ConfigurationErrorsException e)
			{
				throw new Exception("Unable to read primary database configuration file", e);
			}

			try
			{
				LoggingConnectionString = ConfigurationManager.ConnectionStrings[LOG_DB_CONNECTION_NAME].ConnectionString;
			}
			catch (ConfigurationErrorsException e)
			{
				throw new Exception("Unable to read logging database configuration file", e);
			}
		}

		#endregion

		#region Public Methods

		public void Close()
		{
			try
			{
				if (connection != null && connection.State == ConnectionState.Open)
					connection.Close();
			}
			catch (MySqlException e)
			{
				throw new Exception(string.Format("MySQL gave the following error: {0}", e.Message));
			}
		}
		
		public bool Open()
		{
			try
			{
				connection = new MySqlConnection(PrimaryConnectionString);
				connection.Open();
				return true;
			}
			catch (MySqlException e)
			{
				throw new Exception(string.Format("MySQL gave the following error: {0}", e.Message));
			}
		}

		#endregion
	}
}
