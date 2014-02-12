using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using API.Data;
using API.FileIO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.API
{
	/// <summary>
	/// Summary description for FileProcessing
	/// </summary>
	[TestClass]
	public class FileProcessingTest
	{
		//private string rootPath;
		//private FileProcessingState state;
		//public FileProcessingTest()
		//{
		//	state = new FileProcessingState();
		//	state.BaseDirectory = string.Format("{0}\\TestSet", Directory.GetCurrentDirectory());
		//	Directory.CreateDirectory(state.BaseDirectory);


//<drive>
//---<URLKey>
//---|---<########1>
//---|---|---<application>
//---|---|---<followup>
//---|---|---<loi>
//---|---|---<qualification>
//---|---|---<supportingdocuments>

			//
			// TODO: Add constructor logic here
			//
		//}

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
		public void TestMethod1()
		{
			List<string> items = RequestQuery.GetFoundationFileList(465);

			FoundationDataFileState state = new FoundationDataFileState();
			state.FoundationId = 84;
			state.BaseDirectory = "E:\\";
			state.FoundationUrlKey = "petco";

			FileProcessing.ReconcileFileListToDatabase(state, items);
		}
	}
}
