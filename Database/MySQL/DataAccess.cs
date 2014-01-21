using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;

namespace DataProvider.MySQL
{

	public enum DataAccessType
	{
		Data,
		Logging,
	}

	public class DataAccess
	{
		public MySqlDataReader GetReader(Command command)
		{
			MySqlConnection connection = Connector.GetConnection();

			MySqlCommand cmd = new MySqlCommand(command.SqlStatement, connection);

			if (command.ParameterCollection != null && command.ParameterCollection.Parameters.Any())
			{
				cmd.Parameters.AddRange(command.ParameterCollection.Parameters);
			}

			connection.Open();
			return cmd.ExecuteReader(CommandBehavior.CloseConnection|CommandBehavior.SequentialAccess);
		}
	}
	
}

