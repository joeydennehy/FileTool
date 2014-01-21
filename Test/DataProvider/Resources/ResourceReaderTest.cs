using System;
using System.Resources;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourceReader = DataProvider.Resources.ResourceReader;

namespace Test.DataProvider.Resources
{
	/// <summary>
	/// Summary description for ResourceReaderTest
	/// </summary>
	[TestClass]
	public class ResourceReaderTest
	{
		private const string RESOURCE_TEST_STRING = "UNIT_TEST_ONLY";

		public ResourceReaderTest()
		{
			//
			// TODO: Add constructor logic here
			//
		}

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
		public void ResourceCanBeRetrieved()
		{
			string testValue = ResourceReader.GetSql(RESOURCE_TEST_STRING);
			Assert.IsTrue(!string.IsNullOrEmpty(testValue));
		}
	}
}
