using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Test.API
{
	[TestClass]
	public class ApplicantProcessQueryTest
	{
		[TestMethod]
		public void Test_RetrieveFoundationInformation()
		{
			ApplicantProcessQuery query = new ApplicantProcessQuery();
			Dictionary<string, string> data = query.BuildFoundationDictionary();
			Assert.IsTrue(data.Count > 0);
			var first = data.First();
			string keyPattern = "[A-Za-z0-9]+ - [()A-Za-z0-9]+";
			string valuePattern = "[A-Za-z0-9]+";
			Match matchKey = Regex.Match(first.Key, keyPattern);
			Assert.IsTrue(matchKey.Success);
			Match matchValue = Regex.Match(first.Value, valuePattern);
			Assert.IsTrue(matchValue.Success);
		}

		[TestMethod]
		public void Test_RetrieveFoundationProcessInfo()
		{
			ApplicantProcessQuery query = new ApplicantProcessQuery();
			Dictionary<string, string> data = query.BuildFoundationProcessInfoDictionary("ff");
			Assert.IsTrue(data.Count > 0);
			var first = data.First();
			string keyPattern = "[0-9]+ - [A-Za-z0-9]+";
			string valuePattern = "[0-9]+";
			Match matchKey = Regex.Match(first.Key, keyPattern);
			Assert.IsTrue(matchKey.Success);
			Match matchValue = Regex.Match(first.Value, valuePattern);
			Assert.IsTrue(matchValue.Success);
		}

		[TestMethod]
		public void Test_RetrieveApplicationProcessInfo()
		{
			ApplicantProcessQuery query = new ApplicantProcessQuery();
			List<int> data = query.RetrieveApplicationProcessInfo(31);
			Assert.IsTrue(data.Count > 0);
			var first = data.First();
			string valuePattern = "[0-9]+";
			Match matchValue = Regex.Match(first.ToString(), valuePattern);
			Assert.IsTrue(matchValue.Success);
		}

		[TestMethod]
		public void Test_RetrieveFiles()
		{
			ApplicantProcessQuery query = new ApplicantProcessQuery();
			//Assembly.GetExecutingAssembly().Location
			FileProcessingState state = new FileProcessingState
			{
				BaseDirectory = "C:/Users/Joey/Desktop/petcocopy",
				OutputDirectory = "C:/petcocopy",
				FoundationUrlKey = "petco",
				FoundationApplicantProcessIds = query.RetrieveApplicationProcessInfo(7043)
			};

			FileProcessing.CopyFilesToDestination(state);
			Assert.IsTrue(Directory.Exists("C:/petcocopy"));
		}
	}
}
