using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Database.MySQL
{
	public class Command
	{
		private MySqlCommand mySqlCommand;
		private MySqlConnector mySqlConnector;

		public Command(string SqlStatement)
		{ 
			mySqlConnector = new MySqlConnector();
			mySqlCommand = new MySqlCommand(SqlStatement, mySqlConnector.Connection);
		}

		public Command(string SqlStatmentId, Parameters parameters = null)
		{
			//Add resource manager here
			mySqlCommand.CommandText = SqlStatmentId;

			if (parameters != null)
			{
				mySqlCommand.Parameters.AddRange(parameters.ParameterCollection);
			}
		}

	}
}
