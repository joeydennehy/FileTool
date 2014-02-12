using System;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;

namespace DataProvider.MySQL
{

	public enum DataAccessType
	{
		Data,
		Logging
	}

	public class DataAccess
	{
		public MySqlDataReader GetReader(Command command)
		{
			MySqlConnection connection = Connector.GetConnection();

			MySqlCommand cmd = new MySqlCommand(command.SqlStatement, connection);
			cmd.CommandTimeout = 10000;

			if (command.ParameterCollection != null && command.ParameterCollection.Parameters.Any())
			{
				cmd.Parameters.AddRange(command.ParameterCollection.Parameters);
			}

			connection.Open();

			MySqlDataReader dataReader;
			try
			{
				dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection|CommandBehavior.SequentialAccess);
			}
			catch (Exception eError)
			{
				throw new Exception(string.Format("{0}:{1}", eError.Message, eError.StackTrace));
			}
			return dataReader;
		}
	}
	
}

