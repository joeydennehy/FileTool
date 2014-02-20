using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using API.FileIO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.API.FileIO
{
	/// <summary>
	/// Summary description for FileProcessing
	/// </summary>
	[TestClass]
	public class FileProcessingTest
	{
		private const string TEST_KEY = "testfoundation";
		private static string rootPath;
		private static string rootControlFolderPath;
		private static FoundationDataFileState state;
		private static Dictionary<string, string> FileTestCases;

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

		[ClassInitialize]
		public static void FileProcessingTestClassInitialize(TestContext testContext)
		{
			var executionFileInfo = new FileInfo(Assembly.GetExecutingAssembly().Location);
			rootPath = string.Format("{0}\\TestFiles", executionFileInfo.DirectoryName);
		}

		[ClassCleanup]
		public static void FileProcessingTestClassCleanup()
		{
			ClearFolder(rootPath);
			var di = new DirectoryInfo(rootPath);

			if(di.Exists)
				di.Delete(true);
		}
		
		[TestInitialize()]
		public void FileProcessingTestInitialize()
		{

			ClearFolder(rootPath);

			state = new FoundationDataFileState();
			state.OutputDirectory = string.Format("{0}\\test", rootPath);

			rootControlFolderPath = string.Format("{0}\\control\\{1}", rootPath, TEST_KEY);
			FileTestCases = new Dictionary<string, string>();

			state.BaseDirectory = string.Format("{0}\\control\\", rootPath);
			state.FoundationUrlKey = TEST_KEY;

			//Test Cases

			FileTestCases = new Dictionary<string, string>
			{
				{ string.Format("{0}\\1\\application\\test_app.txt", rootControlFolderPath), string.Format("{0}\\0000000001_application_test_app.txt", state.OutputDirectory) },
				{ string.Format("{0}\\1\\evaluation 1\\test_eval 1.txt", rootControlFolderPath), string.Format("{0}\\0000000001_evaluation 1_test_eval 1.txt", state.OutputDirectory) },
				{ string.Format("{0}\\1\\evaluation 2\\test_eval 2.txt", rootControlFolderPath), string.Format("{0}\\0000000001_evaluation 2_test_eval 2.txt", state.OutputDirectory) },
				{ string.Format("{0}\\1\\followup\\test_followup.txt", rootControlFolderPath), string.Format("{0}\\0000000001_followup_test_followup.txt", state.OutputDirectory) },
				{ string.Format("{0}\\1\\loi\\test_loi.txt", rootControlFolderPath), string.Format("{0}\\0000000001_loi_test_loi.txt", state.OutputDirectory) },
				{ string.Format("{0}\\1\\qualification\\test_qual.txt", rootControlFolderPath), string.Format("{0}\\0000000001_qualification_test_qual.txt", state.OutputDirectory) },
				{ string.Format("{0}\\1\\supportingdocuments\\test_doc.txt", rootControlFolderPath), string.Format("{0}\\0000000001_supportingdocuments_test_doc.txt", state.OutputDirectory) },

				{ string.Format("{0}\\2\\application\\test_app.txt", rootControlFolderPath), string.Format("{0}\\0000000002_application_test_app.txt", state.OutputDirectory) },
				{ string.Format("{0}\\2\\evaluation 1\\test_eval 1.txt", rootControlFolderPath), string.Format("{0}\\0000000002_evaluation 1_test_eval 1.txt", state.OutputDirectory) },
				{ string.Format("{0}\\2\\evaluation 2\\test_eval 2.txt", rootControlFolderPath), string.Format("{0}\\0000000002_evaluation 2_test_eval 2.txt", state.OutputDirectory) },
				{ string.Format("{0}\\2\\followup\\test_followup.txt", rootControlFolderPath), string.Format("{0}\\0000000002_followup_test_followup.txt", state.OutputDirectory) },
				{ string.Format("{0}\\2\\loi\\test_loi.txt", rootControlFolderPath), string.Format("{0}\\0000000002_loi_test_loi.txt", state.OutputDirectory) },
				{ string.Format("{0}\\2\\qualification\\test_qual.txt", rootControlFolderPath), string.Format("{0}\\0000000002_qualification_test_qual.txt", state.OutputDirectory) },
				{ string.Format("{0}\\2\\supportingdocuments\\test_doc.txt", rootControlFolderPath), string.Format("{0}\\0000000002_supportingdocuments_test_doc.txt", state.OutputDirectory) },

				{ string.Format("{0}\\3\\application\\test.txt", rootControlFolderPath), string.Format("{0}\\0000000003_test.txt", state.OutputDirectory) },
				{ string.Format("{0}\\3\\evaluation 1\\test.txt", rootControlFolderPath), string.Format("{0}\\0000000003_test (1).txt", state.OutputDirectory) },
				{ string.Format("{0}\\3\\evaluation 2\\test.txt", rootControlFolderPath), string.Format("{0}\\0000000003_test (2).txt", state.OutputDirectory) },

				{ string.Format("{0}\\ORG-1\\supportingdocuments\\test_doc.txt", rootControlFolderPath), "" },

				{ string.Format("{0}\\organization-2--00010101_1\\application\\test_app.txt", rootControlFolderPath), string.Format("{0}\\organization-2--00010101_1_application_test_app.txt", state.OutputDirectory) },
				{ string.Format("{0}\\organization-2--00010101_1\\evaluation 1\\test_eval 1.txt", rootControlFolderPath), string.Format("{0}\\organization-2--00010101_1_evaluation 1_test_eval 1.txt", state.OutputDirectory) },
				{ string.Format("{0}\\organization-2--00010101_1\\evaluation 2\\test_eval 2.txt", rootControlFolderPath), string.Format("{0}\\organization-2--00010101_1_evaluation 2_test_eval 2.txt", state.OutputDirectory) },
				{ string.Format("{0}\\organization-2--00010101_1\\followup\\test_followup.txt", rootControlFolderPath), string.Format("{0}\\organization-2--00010101_1_followup_test_followup.txt", state.OutputDirectory) },
				{ string.Format("{0}\\organization-2--00010101_1\\loi\\test_loi.txt", rootControlFolderPath), string.Format("{0}\\organization-2--00010101_1_loi_test_loi.txt", state.OutputDirectory) },
				{ string.Format("{0}\\organization-2--00010101_1\\qualification\\test_qual.txt", rootControlFolderPath), string.Format("{0}\\organization-2--00010101_1_qualification_test_qual.txt", state.OutputDirectory) },
				{ string.Format("{0}\\organization-2--00010101_1\\supportingdocuments\\test_doc.txt", rootControlFolderPath), string.Format("{0}\\organization-2--00010101_1_supportingdocuments_test_doc.txt", state.OutputDirectory) },

				{ string.Format("{0}\\scholarshipactor-3--00010101_1\\application\\test_app.txt", rootControlFolderPath), string.Format("{0}\\scholarshipactor-3--00010101_1_application_test_app.txt", state.OutputDirectory) },
				{ string.Format("{0}\\scholarshipactor-3--00010101_1\\evaluation 1\\test_eval 1.txt", rootControlFolderPath), string.Format("{0}\\scholarshipactor-3--00010101_1_evaluation 1_test_eval 1.txt", state.OutputDirectory) },
				{ string.Format("{0}\\scholarshipactor-3--00010101_1\\evaluation 2\\test_eval 2.txt", rootControlFolderPath), string.Format("{0}\\scholarshipactor-3--00010101_1_evaluation 2_test_eval 2.txt", state.OutputDirectory) },
				{ string.Format("{0}\\scholarshipactor-3--00010101_1\\followup\\test_followup.txt", rootControlFolderPath), string.Format("{0}\\scholarshipactor-3--00010101_1_followup_test_followup.txt", state.OutputDirectory) },
				{ string.Format("{0}\\scholarshipactor-3--00010101_1\\loi\\test_loi.txt", rootControlFolderPath), string.Format("{0}\\scholarshipactor-3--00010101_1_loi_test_loi.txt", state.OutputDirectory) },
				{ string.Format("{0}\\scholarshipactor-3--00010101_1\\qualification\\test_qual.txt", rootControlFolderPath), string.Format("{0}\\scholarshipactor-3--00010101_1_qualification_test_qual.txt", state.OutputDirectory) },
				{ string.Format("{0}\\scholarshipactor-3--00010101_1\\supportingdocuments\\test_doc.txt", rootControlFolderPath), string.Format("{0}\\scholarshipactor-3--00010101_1_supportingdocuments_test_doc.txt", state.OutputDirectory) },

				{ string.Format("{0}\\emailattachments\\1.txt", rootControlFolderPath), "" },
				{ string.Format("{0}\\GuideStar\\1.txt", rootControlFolderPath), "" },
				{ string.Format("{0}\\MailMerge\\1.txt", rootControlFolderPath), "" },
				{ string.Format("{0}\\shared\\1.txt", rootControlFolderPath), "" },
			};

			foreach (string filePath in FileTestCases.Keys)
			{
				var fi = new FileInfo(filePath);
				state.Files.Add(fi);
				if (!string.IsNullOrEmpty(fi.DirectoryName))
				{
					var di = new DirectoryInfo(fi.DirectoryName);
					di.Create();
				}
				using (var fstr = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
				{
					fstr.Write(new byte[1], 0, 0);
					fstr.Flush();
					fstr.Close();
				}
			}

			state.FoundationId = 1;
			state.FoundationUrlKey = TEST_KEY;
		}

		[TestCleanup]
		public void FileProcessingTestCleanup()
		{
			try
			{
				ClearFolder(rootPath);
				var di = new DirectoryInfo(rootPath);
				di.Delete(true);
			}
			catch
			{
			}
			
		}
		
		#endregion

		[TestMethod]
		public void CopyFilesToDestinationTest_CreatesDestinationFolder()
		{
			var directory = new DirectoryInfo(state.OutputDirectory);

			Assert.IsFalse(directory.Exists);

			FileProcessing.CopyApplicationProcessFiles(state);

			directory = new DirectoryInfo(state.OutputDirectory);
			Assert.IsTrue(directory.Exists);
		}

		[TestMethod]
		public void CopyFilesToDestinationTest_OnlyCopiesRequestProcessFiles()
		{
			var requestIds = new List<string>();
			var expectedFiles = new Dictionary<string, string>();

			state.Files.Clear();

			foreach (KeyValuePair<string, string> fileTestCase in FileTestCases)
			{
				Match matchSet = Regex.Match(fileTestCase.Key, @"[\\][\d]\\");
				if (matchSet.Success && !fileTestCase.Key.Contains("supportingdocuments"))
				{
					string requestId = matchSet.Value.Replace("\\", "");
					if (!requestIds.Contains(requestId))
						requestIds.Add(requestId);
					expectedFiles.Add(fileTestCase.Key, fileTestCase.Value);
					var file = new FileInfo(fileTestCase.Key);
					state.Files.Add(file);
				}
			}

			state.FoundationApplicantProcessCodes = requestIds;
			FileProcessing.CopyApplicationProcessFiles(state);

			List<string> testFileList = new List<string>();
			DirectoryInfo outputDirectoryInfo = new DirectoryInfo(state.OutputDirectory);
			
			Assert.IsFalse(outputDirectoryInfo.GetDirectories().Any());

			foreach (FileInfo outputFile in outputDirectoryInfo.GetFiles())
			{
				testFileList.Add(outputFile.FullName);
			}

			foreach (KeyValuePair<string, string> expectedFile in expectedFiles)
			{
				if (testFileList.Contains(expectedFile.Value))
					testFileList.Remove(expectedFile.Value);
			}

			Assert.IsTrue(testFileList.Count == 0);
		}

		[TestMethod]
		public void MoveFilesToDestinationTest()
		{
			FileProcessing.MoveFilesToDestination(state.Files, state.OutputDirectory, rootControlFolderPath);

			string [] outputFiles = Directory.GetFiles(state.OutputDirectory, "*.*", SearchOption.AllDirectories);

			Assert.IsTrue(outputFiles.Length == state.Files.Count);
		}

		[TestMethod]
		public void CopyFilesToDestinationTest_AllRequestProcessFiles()
		{
			var requestIds = new List<string>();
			var expectedFiles = new Dictionary<string, string>();

			state.Files.Clear();

			foreach (KeyValuePair<string, string> fileTestCase in FileTestCases)
			{
				if (!fileTestCase.Key.Contains("emailattachments") && !fileTestCase.Key.Contains("GuideStar")
				    && !fileTestCase.Key.Contains("MailMerge") && !fileTestCase.Key.Contains("shared")
				    && !fileTestCase.Key.Contains("ORG-") && !fileTestCase.Key.Contains("supportingdocuments"))
				{
					string requestId = fileTestCase.Key.Split('\\')[1];
					if (!requestIds.Contains(requestId))
						requestIds.Add(requestId);
					expectedFiles.Add(fileTestCase.Key, fileTestCase.Value);
					var file = new FileInfo(fileTestCase.Key);
					state.Files.Add(file);
				}
			}

			state.FoundationApplicantProcessCodes = requestIds;
			FileProcessing.CopyApplicationProcessFiles(state);

			List<string> testFileList = new List<string>();
			DirectoryInfo outputDirectoryInfo = new DirectoryInfo(state.OutputDirectory);

			Assert.IsFalse(outputDirectoryInfo.GetDirectories().Any());

			foreach (FileInfo outputFile in outputDirectoryInfo.GetFiles())
			{
				testFileList.Add(outputFile.FullName);
			}

			foreach (KeyValuePair<string, string> expectedFile in expectedFiles)
			{
				if (testFileList.Contains(expectedFile.Value))
					testFileList.Remove(expectedFile.Value);
			}

			Assert.IsTrue(testFileList.Count == 0);
		}

		[TestMethod]
		public void CopyFilesToDestinationTest_OldRequestFiles()
		{
			var requestIds = new List<string>();
			var expectedFiles = new Dictionary<string, string>();

			state.Files.Clear();

			foreach (KeyValuePair<string, string> fileTestCase in FileTestCases)
			{
				if (fileTestCase.Key.Contains("organization") || fileTestCase.Key.Contains("scholarshipactor-3--00010101_1"))
				{
					string requestId = fileTestCase.Key.Split('\\')[1];
					if (!requestIds.Contains(requestId))
						requestIds.Add(requestId);
					expectedFiles.Add(fileTestCase.Key, fileTestCase.Value);
					var file = new FileInfo(fileTestCase.Key);
					state.Files.Add(file);
				}
			}

			state.FoundationApplicantProcessCodes = requestIds;
			FileProcessing.CopyApplicationProcessFiles(state);

			List<string> testFileList = new List<string>();
			DirectoryInfo outputDirectoryInfo = new DirectoryInfo(state.OutputDirectory);

			Assert.IsFalse(outputDirectoryInfo.GetDirectories().Any());

			foreach (FileInfo outputFile in outputDirectoryInfo.GetFiles())
			{
				testFileList.Add(outputFile.FullName);
			}

			foreach (KeyValuePair<string, string> expectedFile in expectedFiles)
			{
				if (testFileList.Contains(expectedFile.Value))
					testFileList.Remove(expectedFile.Value);
			}

			Assert.IsTrue(testFileList.Count == 0);
		}

		[TestMethod]
		public void CopyFilesToDestinationTest_DuplicateNameCopy()
		{
			var testFiles = state.Files.Where(file => file.FullName.Contains("\\3\\")).ToList();
			var expectedResults = FileTestCases.Values.Where(s => s.Contains("\\3\\")).ToList();
			state.Files = testFiles;
			FileProcessing.CopyApplicationProcessFiles(state);

			var outputFolderInfo = new DirectoryInfo(state.OutputDirectory);
			var testOutputFiles = outputFolderInfo.GetFiles();

			foreach (FileInfo outputFile in testOutputFiles)
			{
				if (expectedResults.Contains(outputFile.FullName))
					expectedResults.Remove(outputFile.Name);
			}
			Assert.IsTrue(expectedResults.Count == 0);
		}

		private static void ClearFolder(string directoryPath)
		{
			var directory = new DirectoryInfo(directoryPath);
			
			if (!directory.Exists)
				return;

			foreach (FileInfo file in directory.GetFiles())
			{
				try
				{
					file.IsReadOnly = false;
					file.Delete();
				}
				catch { }
				
			}

			foreach (DirectoryInfo dir in directory.GetDirectories())
			{
				ClearFolder(dir.FullName);
				try
				{
					dir.Delete();
				}
				catch {}
				
			}
		}
	}
}
