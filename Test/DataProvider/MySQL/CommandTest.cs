using System;
using DataProvider.MySQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.DataProvider.MySQL
{
	[TestClass]
	public class CommandTest
	{
		[TestMethod]
		public void Command_SetSqlStatementId_sets_SqlStatement()
		{
			Exception error = null;
			try
			{
				Command command = new Command
				{
					SqlStatementId = "UNIT_TEST_ONLY"
				};

				Assert.IsFalse(string.IsNullOrEmpty(command.SqlStatementId));
				Assert.IsFalse(string.IsNullOrEmpty(command.SqlStatement));
			}
			catch (Exception e)
			{
				error = e;
			}

			Assert.IsNull(error);
		}

		[TestMethod]
		public void Command_SetSqlStatementId_gives_error_on_empty_id()
		{
			Exception error = null;
			try
			{
				Command command = new Command
				{
					SqlStatementId = string.Empty
				};

				//this code should be unreachable at run time for this test.
				Assert.IsTrue(string.IsNullOrEmpty(command.SqlStatementId));
				Assert.IsTrue(string.IsNullOrEmpty(command.SqlStatement));
			}
			catch (Exception e)
			{
				error = e;
			}

			Assert.IsNotNull(error);
		}

		[TestMethod]
		public void Command_SetSqlStatementId_gives_error_on_invalid_id()
		{
			Exception error = null;
			bool bErrorOut = true;
			try
			{
				Command command = new Command
				{
					SqlStatementId = "NonsenseId"
				};

				bErrorOut = false;
				//this code should be unreachable at run time for this test.
				Assert.IsTrue(string.IsNullOrEmpty(command.SqlStatementId));
				Assert.IsTrue(string.IsNullOrEmpty(command.SqlStatement));
			}
			catch (Exception e)
			{
				error = e;
			}

			Assert.IsTrue(bErrorOut);
			Assert.IsNotNull(error);
		}
	}
}
