using DataProvider.MySQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;

namespace Test.Database.MySQL
{
	/// <summary>
	/// Summary description for DataAccess
	/// </summary>
	[TestClass]
	public class DataAccessTest
	{
		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		[TestMethod]
		public void TestGetReaderWorks()
		{
			DataAccess access = new DataAccess();
			Command command = new Command
			{
				SqlStatementId = "UNIT_TEST_ONLY"
			};

			MySqlDataReader reader = access.GetReader(command);

			Assert.IsNotNull(reader);

			int lineCount = 0;
			while (reader.Read())
			{
				lineCount++;
			}
			Assert.IsTrue(lineCount > 0);
		}
	}
}
