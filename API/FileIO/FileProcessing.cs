using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using API.Data;
using API.Logging;
using Aspose.Words;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace API.FileIO
{
	public static class FileProcessing
	{
		public static void CopyApplicationProcessFiles(FoundationDataFileState state)
		{
			CopyFilesToDestination(state, state.OutputDirectory);
		}

		public static void RunGhostInspector(FoundationDataFileState state, string line)
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

			//GET Method 
			try
			{
				WebRequest requestObjGet =
					WebRequest.Create($"https://api.ghostinspector.com/v1/suites/{line}/execute/?apiKey={state.APIKey}");
				requestObjGet.Method = "POST";
				requestObjGet.GetResponseAsync();
				Thread.Sleep(3000);
				requestObjGet.Abort();
			}
			catch (Exception e)
			{

				
			}
		}

	


		private static void GetResponseCallback(IAsyncResult asynchronousResult)
		{
			HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;

			// End the operation
			request.EndGetRequestStream(asynchronousResult);
			/*Stream streamResponse = response.GetResponseStream();
			StreamReader sr = new StreamReader(streamResponse);
			var resultBabe = sr.ReadToEnd();
			sr.Close();

			var json = JObject.Parse(resultBabe)["data"];
			StringBuilder sb = new StringBuilder();
			foreach (var result in json.Children())
			{
				sb.AppendLine(result["name"] + " - " + (bool.Parse(result["passing"].ToString()) ? "Passed" : "Failed"));
			}
			Console.WriteLine(sb);
			// Close the stream object
			streamResponse.Close();
			sr.Close();

			// Release the HttpWebResponse
			response.Close();*/
		}

		public static DataTable GetGhostInspectorFolders(FoundationDataFileState state)
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

			//GET Method 
			try
			{
				WebRequest requestObjGet = WebRequest.Create($"https://api.ghostinspector.com/v1/folders/?apiKey={state.APIKey}");
				requestObjGet.Method = "GET";
				HttpWebResponse responseObjGet = null;
				requestObjGet.Timeout = 600000;
				responseObjGet = (HttpWebResponse)requestObjGet.GetResponse();

				using (Stream stream = responseObjGet.GetResponseStream())
				{
					StreamReader sr = new StreamReader(stream);
					var resultBabe = sr.ReadToEnd();
					sr.Close();

					var json = JObject.Parse(resultBabe)["data"];
					DataTable table = new DataTable();
					table.Columns.Add("folderId");
					table.Columns.Add("folderName");
					foreach (var result in json.Children())
					{
							DataRow row = table.NewRow();
							row["folderName"] = result["name"].ToString();
							row["folderId"] = result["_id"].ToString();

						table.Rows.Add(row);
					}
					return table;
				};
			}
			catch (Exception e)
			{

				return null;
			}
		}

		public static List<string> GetGhostInspectorSuites(FoundationDataFileState state, string folderId)
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

			//GET Method 
			try
			{
				WebRequest requestObjGet = WebRequest.Create($"https://api.ghostinspector.com/v1/folders/{folderId}/suites/?apiKey={state.APIKey}");
				requestObjGet.Method = "GET";
				HttpWebResponse responseObjGet = null;
				requestObjGet.Timeout = 600000;
				responseObjGet = (HttpWebResponse)requestObjGet.GetResponse();

				using (Stream stream = responseObjGet.GetResponseStream())
				{
					StreamReader sr = new StreamReader(stream);
					var resultBabe = sr.ReadToEnd();
					sr.Close();

					var json = JObject.Parse(resultBabe)["data"];
					List<string> suites = new List<string>();
					foreach (var result in json.Children())
					{
						suites.Add(result["_id"].ToString());
					}
					return suites;
				};
			}
			catch (Exception e)
			{

				return null;
			}
		}


		private static void ClearFiles(FoundationDataFileState state)
		{
			state.Files = new List<FileInfo>();
			state.SequesterFiles = new List<FileInfo>();
			state.TotalSize = 0;
		}

		public static void SetFileList(FoundationDataFileState state)
		{
			ClearFiles(state);
			if (string.IsNullOrEmpty(state.FileType) || state.FileType == "All")
			{
				SetRequestFiles(state);
				SetOrganizationSupportingFiles(state);
				SetAttachmentFiles(state);
				SetMergeTemplateFiles(state);
				SetCustomPrintPacketFiles(state);
				SetSharedDocumentFiles(state);
			}
			else
			{
				switch (state.FileType)
				{
					case "answers":
						SetRequestFiles(state);
						break;
					case "documents":
						SetOrganizationSupportingFiles(state);
						break;
					case "attachments":
						SetAttachmentFiles(state);
						break;
					case "mergetemplates":
						SetMergeTemplateFiles(state);
						break;
					case "settingvalues":
						SetCustomPrintPacketFiles(state);
						break;
					case "shareddocuments":
						SetSharedDocumentFiles(state);
						break;
				}
			}
		}

		private static void SetRequestFiles(FoundationDataFileState state)
		{
			string directoryPath;
			var pathChecked = new List<string>();

			foreach (FoundationDataFileState.FileInfo requestFile in state.RequestFiles)
			{
				directoryPath = string.Format("{0}\\", state.ClientRootDirectory);
				if (!pathChecked.Contains(directoryPath))
				{
					SetFilesFromPath(state, directoryPath);
					pathChecked.Add(directoryPath);
				}
			}

			foreach (FoundationDataFileState.FileInfo requestSupportingFile in state.RequestSupportingFiles)
			{
				//directoryPath = string.Format("{0}\\documents\\{1}.{2}", state.ClientRootDirectory,
					//requestSupportingFile.DocumentId, requestSupportingFile.FileName.Split('.').Last());
				directoryPath = string.Format("{0}\\documents\\", state.ClientRootDirectory);
				if (!pathChecked.Contains(directoryPath))
				{
					SetFilesFromPath(state, directoryPath);
					pathChecked.Add(directoryPath);
				}
			}
		}

		private static void SetOrganizationSupportingFiles(FoundationDataFileState state)
		{
			var pathChecked = new List<string>();

			foreach (FoundationDataFileState.FileInfo orgSupportingFile in state.OrganizationSupportingFiles)
			{
				var directoryPath = string.Format("{0}\\documents\\{1}.{2}", state.ClientRootDirectory,
				                                  orgSupportingFile.DocumentId, orgSupportingFile.FileName.Split('.').Last());
				if (!pathChecked.Contains(directoryPath))
				{
					SetFilesFromPath(state, directoryPath);
					pathChecked.Add(directoryPath);
				}
			}
		}

		private static void SetAttachmentFiles(FoundationDataFileState state)
		{
			string directoryPath = string.Format("{0}\\attachments", state.ClientRootDirectory);
			SetFilesFromPath(state, directoryPath);
		}

		private static void SetCustomPrintPacketFiles(FoundationDataFileState state)
		{
			string directoryPath = string.Format("{0}\\settingvalues", state.ClientRootDirectory);
			SetFilesFromPath(state, directoryPath);
		}

		private static void SetMergeTemplateFiles(FoundationDataFileState state)
		{
			string directoryPath = string.Format("{0}\\mergetemplates", state.ClientRootDirectory);
			SetFilesFromPath(state, directoryPath);
		}

		private static void SetSharedDocumentFiles(FoundationDataFileState state)
		{
			string directoryPath = string.Format("{0}\\shareddocuments", state.ClientRootDirectory);
			SetFilesFromPath(state, directoryPath);
		}

		private static void SetFilesFromPath(FoundationDataFileState state, string filePath)
		{
			if (Directory.Exists(filePath))
			{
				string[] files = Directory.GetFiles(filePath, "*.*", SearchOption.AllDirectories)
					.ToArray();

				foreach (string fileString in files)
				{
					var file = new FileInfo(fileString);
					state.Files.Add(file);
					state.TotalSize += file.Length;
				}
			}
		}

		public static void ReconcileFileListToDatabase(FoundationDataFileState state, Dictionary<string, string> fileList)
		{
			ClearFiles(state);
			SetFilesFromPath(state, state.ClientRootDirectory);

			foreach (FileInfo file in state.Files)
			{
				string partialFileName = "\\" + file.FullName.Replace(state.ClientRootDirectory, string.Empty)
					.ToLower();
				if (!fileList.Keys.Contains(partialFileName))
				{
					state.SequesterFiles.Add(file);
				}
				else
				{
					fileList.Remove(partialFileName);
				}
			}

			if (fileList.Count > 0)
			{
				state.FilesNotFound = fileList;
			}
		}

		public static IEnumerable<FileInfo> BuildMergeTemplateFileInfo(DataTable mergeTemplateData, string rootDirectory)
		{
			return (from DataRow row in mergeTemplateData.Rows
				select new FileInfo(string.Format("{0}\\{1}\\mergetemplates\\mergetemplate.{2}", rootDirectory, row[1], row[2])))
				.ToList();
		}

		public static IEnumerable<FileInfo> BuildCustomPrintPacketInfo(DataTable customPrintPacketData, string rootDirectory)
		{
			return (from DataRow row in customPrintPacketData.Rows
				select new FileInfo(string.Format("{0}\\{1}\\settingvalues\\settingvalue.{2}", rootDirectory, row[1], row[2])))
				.ToList();
		}

		private static void CopyFilesToDestination(FoundationDataFileState state, string destinationFolder)
		{
			string sourcePath = "";
			try
			{
				if (state.Files == null || state.Files.Count == 0)
				{
					Logger.Log("CopyFilesToDestination: no files selected to copy", LogLevel.Warn);
					return;
				}

				if (string.IsNullOrEmpty(destinationFolder))
				{
					Logger.Log("CopyFilesToDestination: No destination selected for copy", LogLevel.Error);
					throw new ArgumentNullException("destinationFolder");
				}

				if (!Directory.Exists(destinationFolder))
				{ 
					Directory.CreateDirectory(destinationFolder);
				}

				string[] fileTypes = state.FileType != "All" ? new[] { state.FileType } : new[] { "answers", "documents" };

				foreach (var fileyType in fileTypes)
				{
					var sb = new StringBuilder();
					switch (fileyType)
					{
						case "answers":
							List<string> faildList = new List<string>();
								sb.AppendLine("Request Id, Request Guid,Submission Id,Answer Id, Question, File Path, File Name");

								foreach (FoundationDataFileState.FileInfo file in state.RequestFiles)
								{
									sourcePath = string.Format("{0}\\answers\\{1}.{2}",
									                           state.ClientRootDirectory, file.AnswerId, file.FileName.Split('.').Last());
									try
									{
										CopyFile(sourcePath, destinationFolder, file);
										if (!string.IsNullOrWhiteSpace(file.FileName))
										{
											sb.AppendLine(string.Format("{0},{1},{2},{3},\"{4}\",\"{5}\",\"{6}\",\"{7}\"", file.RequestId,
											                            file.RequestGuid, file.SubmissionId, file.AnswerId, file.Question, file.FilePath,
											                            file.FileName, file.ProcessId));
										}
									}
									catch (Exception e)
									{
										faildList.Add(sourcePath);
									}
								}
								File.WriteAllText(destinationFolder + "\\Request.csv", sb.ToString());
							break;
						case "documents":
							sb = new StringBuilder();
							foreach (FoundationDataFileState.FileInfo file in state.RequestSupportingFiles)
							{
								sourcePath = string.Format("{0}\\documents\\{1}.{2}",
									state.ClientRootDirectory, file.DocumentId, file.FileName.Split('.').Last());
								CopyFile(sourcePath, destinationFolder, file);
								if (!string.IsNullOrWhiteSpace(file.FileName))
								{
									if (!string.IsNullOrWhiteSpace(file.FileName))
									{
										sb.AppendLine(string.Format("{0},{1},\"{2}\",\"{3}\"", file.RequestId, file.RequestGuid, file.FilePath, file.FileName));
									}
								}
							}
							File.WriteAllText(destinationFolder + "\\RequestSupporting.csv", sb.ToString());
							sb = new StringBuilder();
							sb.AppendLine("Organization Id,Organization Name Id,Organization Tax Id, Question, File Path, File Name");

							foreach (FoundationDataFileState.FileInfo file in state.OrganizationSupportingFiles)
							{
								sourcePath = string.Format("{0}\\documents\\{1}.{2}",
								                           state.ClientRootDirectory, file.DocumentId, file.FileName.Split('.').Last());
								CopyFile(sourcePath, destinationFolder, file);
								sb.AppendLine(string.Format("{0},\"{1}\",{2},\"{3}\",\"{4}\"", file.OrganizationId, file.OrganizationName,
									file.OrganizationTaxId, file.FilePath, file.FileName));
							}

							File.WriteAllText(destinationFolder + "\\Organization.csv", sb.ToString());
							foreach (FoundationDataFileState.FileInfo file in state.SharedFiles)
							{
								sourcePath = string.Format("{0}\\shareddocuments\\document.{1}", state.ClientRootDirectory, file.DocumentId);
								CopyFile(sourcePath, destinationFolder, file);
							}
							break;
						case "mergetemplates":
							foreach (FoundationDataFileState.FileInfo file in state.MergeTemplateFiles)
							{
								sourcePath = string.Format("{0}\\mergetemplates\\mergetemplate.{1}", state.ClientRootDirectory,
									file.MergeTemplateId);
								CopyFile(sourcePath, destinationFolder, file);
							}
							break;
						case "attachments":
							foreach (FoundationDataFileState.FileInfo file in state.AttachmentFiles)
							{
								sourcePath = string.Format("{0}\\attachments\\attachment.{1}", state.ClientRootDirectory, file.AttachmentId);
								CopyFile(sourcePath, destinationFolder, file);
							}
							break;
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(String.Format("Unable to copy file: {0}\n{1}", sourcePath, e.Message), "Unable to copy file", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			
		}

		private static void CopyFile(string sourcePath, string destinationFolder, FoundationDataFileState.FileInfo file)
		{
			try
			{
				var fullFileName = string.Format("{0}\\{1}", destinationFolder, file.FilePath);
				string directory = Path.GetDirectoryName(fullFileName);
				if (directory == null || !Directory.Exists(directory))
				{
					Directory.CreateDirectory(directory);
				}

				FileInfo destinationFile = new FileInfo(fullFileName);
				int fileCounter = 1;
				while (destinationFile.Exists)
				{
					string baseFileName = destinationFile.Name.Substring(0,
						(destinationFile.Name.Length - destinationFile.Extension.Length));
					int repetitionIndex = destinationFile.Name.LastIndexOf(string.Format(" ({0})", fileCounter - 1),
						StringComparison.InvariantCulture);
					if (repetitionIndex > 0)
					{
						baseFileName = destinationFile.Name.Substring(0, repetitionIndex);
					}

					destinationFile =
						new FileInfo(string.Format("{0}\\{1} ({2}){3}", destinationFile.Directory, baseFileName, fileCounter,
							destinationFile.Extension));
					fullFileName = destinationFile.FullName;
					fileCounter++;
				}
				try
				{
					File.Copy(sourcePath, fullFileName);
					Logger.Log("Copied file " + sourcePath + " to " + fullFileName, LogLevel.Info);
				}
				catch (Exception e) { }
			}
			catch (Exception eError)
			{
				Logger.Log(string.Format("Unable to copy file {0}.  Error: {1} ", sourcePath, eError.Message), LogLevel.Error);
				throw;
			}
		}

		public static void WriteToCsv(string destination, StringBuilder fileOutput)
		{
			var destinationFileInfo = new FileInfo(destination);
			if (destinationFileInfo.Exists)
			{
				destinationFileInfo.Delete();
			}

			using (FileStream outfile = destinationFileInfo.OpenWrite())
			{
				Byte[] outputData = new UTF8Encoding(true).GetBytes(fileOutput.ToString());
				outfile.Write(outputData, 0, outputData.Length);
			}
		}
	}

	public static class DocumentProcessing
	{
		private static readonly License WORDS_LICENSE = new License();
		private static readonly Aspose.Cells.License CELLS_LICENSE = new Aspose.Cells.License();
		private static readonly Aspose.Pdf.License PDF_LICENSE = new Aspose.Pdf.License();

		static DocumentProcessing()
		{
			WORDS_LICENSE.SetLicense("Aspose.Total.lic");
			CELLS_LICENSE.SetLicense("Aspose.Total.lic");
			PDF_LICENSE.SetLicense("Aspose.Total.lic");
		}

		public static List<string> GetMergeFieldIds(string mergeTemplateFilePath)
		{
			var template = new Document(mergeTemplateFilePath);
			string[] mergeFields = template.MailMerge.GetFieldNames();
			List<string> reportFieldIds = mergeFields.Where(mergefield => mergefield.StartsWith("RF_"))
				.ToList();

			return reportFieldIds;
		}

		public static string GetSha256(string text, int length = 0)
		{
			var sha256 = new SHA256Managed();

			byte[] bytes = Encoding.UTF8.GetBytes(text);
			bytes = sha256.ComputeHash(bytes);

			string hash = bytes.Aggregate(String.Empty, (current, b) => current + String.Format("{0:x2}", b));

			return length > 0 ? hash.Substring(0, length) : hash;
		}
	}
}