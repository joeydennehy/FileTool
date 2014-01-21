using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace DataProvider.MySQL
{
	internal class MySqlConnector
	{
		#region Private Variable

		private readonly DataAccessType dataAccessType;

		private const string PRIMARY_DB_CONNECTION_NAME = "MasterDatabase";
		private const string LOG_DB_CONNECTION_NAME = "LogConnection";

		private string primaryConnectionString = string.Empty;
		private string loggingConnectionString = string.Empty;

		#endregion

		#region Constructor

		public MySqlConnector(DataAccessType accessType = DataAccessType.DATA)
		{
			dataAccessType = accessType;
			Initialize();
		}

		#endregion
		
		#region Public Properties

		private MySqlConnection LoggingConnection { get; set; }

		private MySqlConnection PrimaryConnection { get; set; }

		#endregion

		#region Private Methods
		private void Initialize()
		{
			try
			{
				primaryConnectionString = ConfigurationManager.ConnectionStrings[PRIMARY_DB_CONNECTION_NAME].ConnectionString;
			}
			catch (ConfigurationErrorsException e)
			{
				throw new Exception("Unable to read primary database configuration file", e);
			}

			try
			{
				loggingConnectionString = ConfigurationManager.ConnectionStrings[LOG_DB_CONNECTION_NAME].ConnectionString;
			}
			catch (ConfigurationErrorsException e)
			{
				throw new Exception("Unable to read logging database configuration file", e);
			}
		}

		#endregion

		#region Public Methods

		public MySqlConnection GetConnection()
		{
				try
			{
				if (dataAccessType == DataAccessType.DATA)
				{
					PrimaryConnection = new MySqlConnection(primaryConnectionString);
					return PrimaryConnection;
				}
				else
				{
					LoggingConnection = new MySqlConnection(loggingConnectionString);
					return LoggingConnection;
				}
			}
				catch (MySqlException e)
				{
					throw new Exception(string.Format("MySQL gave the following error: {0}", e.Message));
				}
		}

		//public void Close()
		//{
		//	try
		//	{
		//		MySqlConnection connection = dataAccessType == DataAccessType.DATA ? PrimaryConnection : LoggingConnection;

		//		if (connection != null && connection.State == ConnectionState.Open)
		//			connection.Close();
		//	}
		//	catch (MySqlException e)
		//	{
		//		throw new Exception(string.Format("MySQL gave the following error: {0}", e.Message));
		//	}
		//}

		//public bool Open()
		//{
		//	try
		//	{
		//		if (dataAccessType == DataAccessType.DATA)
		//		{
		//			PrimaryConnection = new MySqlConnection(primaryConnectionString);
		//			PrimaryConnection.Open();
		//		}
		//		else
		//		{
		//			LoggingConnection = new MySqlConnection(loggingConnectionString);
		//			LoggingConnection.Open();
		//		}
				
		//		return true;
		//	}
		//	catch (MySqlException e)
		//	{
		//		throw new Exception(string.Format("MySQL gave the following error: {0}", e.Message));
		//	}
		//}

		#endregion
	}
}
