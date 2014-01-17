using System;
using Database.MySQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Database
{
	[TestClass]
	public class ConnectionTest
	{
		[TestMethod]
		[TestCategory("LocalOnly")]
		public void TestMySQLConnectorOpenClose()
		{
			MySqlConnector connection = new MySqlConnector();
			bool testOpenValue = false;
			Exception testError = null;
			string testErrorMessage = string.Empty;

			try
			{
				testOpenValue = connection.Open();
				Assert.IsTrue(testOpenValue, "Connector did not open");
			}
			catch (Exception e)
			{
				testError = e;
				testErrorMessage = e.Message.ToString();
			}
			finally 
			{
				connection.Close();
			}

			Assert.IsTrue(testError == null, testErrorMessage);
		}
	}
}
