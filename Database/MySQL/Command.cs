namespace DataProvider.MySQL
{
	public class Command
	{
		public string SqlStatementId { get; set; }
		public CommandParameters Parameters { get; set; }

		//private readonly MySqlCommand mySqlCommand;

		public Command(string sqlStatement)
		{
			//MySqlConnector mySqlConnector = new MySqlConnector();
			//mySqlCommand = new MySqlCommand(sqlStatement, mySqlConnector.PrimaryConnection);
		}

		public Command(string sqlStatmentId, CommandParameters parameters = null)
		{
			//Add resource manager here
			//mySqlCommand.CommandText = sqlStatmentId;

			//if (parameters != null)
			//{
			//	mySqlCommand.Parameters.AddRange(parameters.ParameterCollection);
			//}
		}

	}
}
