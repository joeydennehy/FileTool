using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using API.FileIO;
using DataProvider.MySQL;
using MySql.Data.MySqlClient;

namespace API.Data
{
	public static class RequestQuery
	{
		/// <summary>
		/// Name/Index structure for this DataTable:
		/// FoundationId:[0]; UrlKey:[1]; Name:[2]; FoundationDisplayText:[3]
		/// </summary>
		public static DataTable FoundationData { get; private set; }

		/// <summary>
		/// Name/Index structure for this DataTable:
		/// FoundationProcessId:[0]; Name:[1]; ProcessDisplayText:[2]
		/// </summary>
		public static DataTable FoundationProcessData { get; private set; }

		/// <summary>
		/// Name/Index structure for this DataTable:
		/// RequestProcessId:[0]; RequestProcessCode:[1]; RequestDisplayText:[2]
		/// </summary>
		public static DataTable RequestData { get; private set; }

		public static void RefreshFoundationData()
		{
			FoundationData = new DataTable();

			var command = new Command
			{
				SqlStatementId = "SELECT_ALL_URL_KEYS_AND_NAMES"
			};
			var access = new DataAccess();
			using (MySqlDataReader reader = access.GetReader(command))
			{
				FoundationData.Load(reader);
				reader.Close();
			}
		}

		public static void RefreshFoundationProcessData(int foundationId)
		{
			FoundationProcessData = new DataTable();

			if (foundationId <= 0)
			{
				return;
			}

			var parameters = new ParameterSet();
			parameters.Add(DbType.Int32, "FOUNDATION_ID", foundationId);
			var command = new Command
			{
				SqlStatementId = "SELECT_FOUNDATION_PROCESS_INFO",
				ParameterCollection = parameters
			};
			var access = new DataAccess();

			using (MySqlDataReader reader = access.GetReader(command))
			{
				

				FoundationProcessData.Load(reader);

				DataRow row = FoundationProcessData.NewRow();
				row["ProcessDisplayText"] = "All";
				row["FoundationProcessId"] = -999;

				FoundationProcessData.Rows.InsertAt(row, 0);

				reader.Close();
			}
		}

		public static Dictionary<string, string> GetFoundationFileList(int foundationId)
		{
			var fileList = new Dictionary<string, string>();

			var queryIds = new List<string>
			{
				"SELECT_SHARED_FILES_BY_FOUNDATION_ID",
				"SELECT_ORG_SUPPORTING_DOCUMENTS_BY_FOUNDATION_ID",
				"SELECT_REQUEST_SUPPORTING_DOCUMENTS_BY_FOUNDATION_ID",
				"SELECT_REQUEST_FILES_BY_FOUNDATION_ID",
			};

			var parameters = new ParameterSet();
			parameters.Add(DbType.String, "FOUNDATION_ID", foundationId);
			var access = new DataAccess();

			foreach (string queryId in queryIds)
			{
				var command = new Command
				{
					SqlStatementId = queryId,
					ParameterCollection = parameters
				};

				using (MySqlDataReader reader = access.GetReader(command))
				{
					while (reader.Read())
					{
						if (!reader.IsDBNull(0))
						{
							string filePath = reader.GetString(0);
							string fileName = (!reader.IsDBNull(1) ? reader.GetString(1) : "")
								.Split(new[] {"[:|:]"}, StringSplitOptions.None)[0];
							

							if (!string.IsNullOrEmpty(fileName) && !fileList.Keys.Contains(filePath))
							{
								fileList.Add(filePath, fileName);
							}
						}
					}
				}
			}

			return fileList;
		}

		public static List<FoundationDataFileState.FileInfo> RetrieveRequestInfo(int foundationProcess)
		{
			var parameters = new ParameterSet();
			parameters.Add(DbType.Int32, "FOUNDATION_PROCESS", foundationProcess);
			var command = new Command
			{
				SqlStatementId = "SELECT_REQUEST_INFO",
				ParameterCollection = parameters
			};

			var access = new DataAccess();

			var requestSupporitngFiles = new List<FoundationDataFileState.FileInfo>();

			using (MySqlDataReader reader = access.GetReader(command))
			{
				while (reader.Read())
				{
					if (!reader.IsDBNull(0))
					{
						var fileIds = new FoundationDataFileState.FileInfo
						{
							AnswerId = reader.GetInt32(0),
							SubmissionId = reader.IsDBNull(1) ? -1 : reader.GetInt32(1),
							RequestId = reader.IsDBNull(2) ? -1 : reader.GetInt32(2),
							FileName = reader.IsDBNull(3) ? "" : reader.GetString(3).Split(new string[] { "[:|:]" }, StringSplitOptions.None)[0],
							Question = reader.IsDBNull(5) ? "" : reader.GetString(5)
						};
						fileIds.FilePath = "Requests\\Submissions\\" + fileIds.RequestId + "_" + fileIds.SubmissionId + "_"
												 + fileIds.FileName;
						requestSupporitngFiles.Add(fileIds);
					}
				}
			}

			return requestSupporitngFiles;
		}

		public static List<FoundationDataFileState.FileInfo> RetrieveAllRequestInfo(int foundationId)
		{
			var parameters = new ParameterSet();
			parameters.Add(DbType.Int32, "FOUNDATION_ID", foundationId);
			var command = new Command
			{
				SqlStatementId = "SELECT_ALL_REQUEST_INFO",
				ParameterCollection = parameters
			};

			var access = new DataAccess();

			var requestSupporitngFiles = new List<FoundationDataFileState.FileInfo>();

			using (MySqlDataReader reader = access.GetReader(command))
			{
				while (reader.Read())
				{
					if (!reader.IsDBNull(0))
					{
						var fileIds = new FoundationDataFileState.FileInfo
						{
							AnswerId = reader.GetInt32(0),
							SubmissionId = reader.IsDBNull(1) ? -1 : reader.GetInt32(1),
							RequestId = reader.IsDBNull(2) ? -1 : reader.GetInt32(2),
							FileName = reader.IsDBNull(3) ? "" : reader.GetString(3).Split(new string[] { "[:|:]" }, StringSplitOptions.None)[0]
						};
						fileIds.FilePath = "Requests\\Submissions\\" + fileIds.RequestId + "_" + fileIds.SubmissionId + "_"
						                   + fileIds.FileName;
						requestSupporitngFiles.Add(fileIds);
					}
				}
			}

			return requestSupporitngFiles;
		}

		public static List<FoundationDataFileState.FileInfo> RetrieveRequestSupportingInfo(int foundationProcess)
		{
			var parameters = new ParameterSet();
			parameters.Add(DbType.Int32, "FOUNDATION_PROCESS", foundationProcess);
			var command = new Command
			{
				SqlStatementId = "SELECT_REQUEST_SUPPORTING_INFO",
				ParameterCollection = parameters
			};

			var access = new DataAccess();

			var requestSupporitngFiles = new List<FoundationDataFileState.FileInfo>();

			using (MySqlDataReader reader = access.GetReader(command))
			{
				while (reader.Read())
				{
					if (!reader.IsDBNull(0))
					{
						var fileIds = new FoundationDataFileState.FileInfo
						{
							RequestId = reader.GetInt32(0),
							DocumentId = reader.IsDBNull(1) ? -1 : reader.GetInt32(1),
							FileName = reader.IsDBNull(2) ? "" : reader.GetString(2)
						};
						fileIds.FilePath = "\\Requests\\Supporting\\" + fileIds.RequestId + "_RS_" + fileIds.FileName;
						requestSupporitngFiles.Add(fileIds);
					}
				}
			}

			return requestSupporitngFiles;
		}

		public static List<FoundationDataFileState.FileInfo> RetrieveAllRequestSupportingInfo(int foundationId)
		{
			var parameters = new ParameterSet();
			parameters.Add(DbType.Int32, "FOUNDATION_ID", foundationId);
			var command = new Command
			{
				SqlStatementId = "SELECT_ALL_REQUEST_SUPPORTING_INFO",
				ParameterCollection = parameters
			};

			var access = new DataAccess();

			var requestSupporitngFiles = new List<FoundationDataFileState.FileInfo>();

			using (MySqlDataReader reader = access.GetReader(command))
			{
				while (reader.Read())
				{
					if (!reader.IsDBNull(0))
					{
						var fileIds = new FoundationDataFileState.FileInfo
						{
							RequestId = reader.GetInt32(0),
							DocumentId = reader.IsDBNull(1) ? -1 : reader.GetInt32(1),
							FileName = reader.IsDBNull(2) ? "" : reader.GetString(2)
						};
						fileIds.FilePath = "\\Requests\\Supporting\\" + fileIds.RequestId + "_RS_" + fileIds.FileName;
						requestSupporitngFiles.Add(fileIds);
					}
				}
			}

			return requestSupporitngFiles;
		}

		public static List<FoundationDataFileState.FileInfo> RetrieveAllOrganizationSupportingInfo(int foundationId)
		{
			var parameters = new ParameterSet();
			parameters.Add(DbType.Int32, "FOUNDATION_ID", foundationId);
			var command = new Command
			{
				SqlStatementId = "SELECT_ALL_ORGANIZATION_SUPPORTING_INFO",
				ParameterCollection = parameters
			};

			var access = new DataAccess();

			var requestSupporitngFiles = new List<FoundationDataFileState.FileInfo>();

			using (MySqlDataReader reader = access.GetReader(command))
			{
				while (reader.Read())
				{
					if (!reader.IsDBNull(0))
					{
						var fileIds = new FoundationDataFileState.FileInfo
						{
							OrganizationId = reader.IsDBNull(0) ? -1 : reader.GetInt32(0),
							DocumentId = reader.IsDBNull(1) ? -1 : reader.GetInt32(1),
							FileName = reader.IsDBNull(2) ? "" : reader.GetString(2)
						};
						fileIds.FilePath = "\\Organizations\\" + fileIds.OrganizationId + "_OS_" + fileIds.FileName;
						requestSupporitngFiles.Add(fileIds);
					}
				}
			}

			return requestSupporitngFiles;
		}

		public static List<FoundationDataFileState.FileInfo> RetrieveAllAttachmentInfo(int foundationId)
		{
			var parameters = new ParameterSet();
			parameters.Add(DbType.Int32, "FOUNDATION_ID", foundationId);
			var command = new Command
			{
				SqlStatementId = "SELECT_ALL_ATTACHMENT_INFO",
				ParameterCollection = parameters
			};

			var access = new DataAccess();

			var requestSupporitngFiles = new List<FoundationDataFileState.FileInfo>();

			using (MySqlDataReader reader = access.GetReader(command))
			{
				while (reader.Read())
				{
					if (!reader.IsDBNull(0))
					{
						var fileIds = new FoundationDataFileState.FileInfo
						{
							AttachmentId = reader.IsDBNull(0) ? -1 : reader.GetInt32(0),
							FileName = reader.IsDBNull(1) ? "" : reader.GetString(1)
						};
						fileIds.FilePath = "\\Attachments\\" + fileIds.AttachmentId + "_" + fileIds.FileName;
						requestSupporitngFiles.Add(fileIds);
					}
				}
			}

			return requestSupporitngFiles;
		}

		public static List<FoundationDataFileState.FileInfo> RetrieveAllMergeTemplateInfo(int foundationId)
		{
			var parameters = new ParameterSet();
			parameters.Add(DbType.Int32, "FOUNDATION_ID", foundationId);
			var command = new Command
			{
				SqlStatementId = "SELECT_ALL_MERGE_TEMPLATE_INFO",
				ParameterCollection = parameters
			};

			var access = new DataAccess();

			var requestSupporitngFiles = new List<FoundationDataFileState.FileInfo>();

			using (MySqlDataReader reader = access.GetReader(command))
			{
				while (reader.Read())
				{
					if (!reader.IsDBNull(0))
					{
						var fileIds = new FoundationDataFileState.FileInfo
						{
							MergeTemplateId = reader.IsDBNull(0) ? -1 : reader.GetInt32(0),
							FileName = reader.IsDBNull(1) ? "" : reader.GetString(1)
						};
						fileIds.FilePath = "\\Merge_Templates\\" + fileIds.MergeTemplateId + "_" + fileIds.FileName;
						requestSupporitngFiles.Add(fileIds);
					}
				}
			}

			return requestSupporitngFiles;
		}

		public static List<FoundationDataFileState.FileInfo> RetrieveAllSharedInfo(int foundationId)
		{
			var parameters = new ParameterSet();
			parameters.Add(DbType.Int32, "FOUNDATION_ID", foundationId);
			var command = new Command
			{
				SqlStatementId = "SELECT_ALL_SHARED_INFO",
				ParameterCollection = parameters
			};

			var access = new DataAccess();

			var requestSupporitngFiles = new List<FoundationDataFileState.FileInfo>();

			using (MySqlDataReader reader = access.GetReader(command))
			{
				while (reader.Read())
				{
					if (!reader.IsDBNull(0))
					{
						var fileIds = new FoundationDataFileState.FileInfo
						{
							DocumentId = reader.IsDBNull(0) ? -1 : reader.GetInt32(0),
							FileName = reader.IsDBNull(1) ? "" : reader.GetString(1)

						};
						fileIds.FilePath = "\\Shared_Documents\\" + fileIds.FileName;
						requestSupporitngFiles.Add(fileIds);
					}
				}
			}

			return requestSupporitngFiles;
		}

		public static void DeleteRequestRecords(int foundationId, string requestCode, string stageName, string fileName)
		{
			var parameters = new ParameterSet();
			parameters.Add(DbType.Int32, "FOUNDATION_ID", foundationId);
			parameters.Add(DbType.String, "REQUEST_PROCESS_CODE", requestCode);
			parameters.Add(DbType.String, "STAGE_NAME", stageName);
			parameters.Add(DbType.String, "FILE_NAME", fileName);
			var command = new Command
			{
				SqlStatementId = "SELECT_REQEST_ANSWER_ID",
				ParameterCollection = parameters
			};

			var access = new DataAccess();

			using (MySqlDataReader reader = access.GetReader(command))
			{
				while (reader.Read())
				{
					if (!reader.IsDBNull(0))
					{
						DeleteAnswer(reader.GetInt32(0));
					}
				}
			}
		}

		public static void DeleteRequestSupportingRecords(int requestId, string fileName)
		{
			var parameters = new ParameterSet();
			parameters.Add(DbType.Int32, "REQUEST_ID", requestId);
			parameters.Add(DbType.String, "FILE_NAME", fileName);
			var command = new Command
			{
				SqlStatementId = "SELECT_REQUEST_DOCUMENT_ID",
				ParameterCollection = parameters
			};

			ExecuteDeleteCommand(command);
		}

		public static void DeleteOrganizationSupportingRecords(int organizationId, string fileName)
		{
			var parameters = new ParameterSet();
			parameters.Add(DbType.Int32, "ORGANIZATION_ID", organizationId);
			parameters.Add(DbType.String, "FILE_NAME", fileName);
			var command = new Command
			{
				SqlStatementId = "SELECT_ORGANIZATION_DOCUMENT_ID",
				ParameterCollection = parameters
			};

			ExecuteDeleteCommand(command);
		}

		public static void DeleteSharedRecords(string fileName)
		{
			var parameters = new ParameterSet();
			parameters.Add(DbType.String, "FILE_NAME", fileName);
			var command = new Command
			{
				SqlStatementId = "SELECT_SHARED_DOCUMENT_ID",
				ParameterCollection = parameters
			};

			ExecuteDeleteCommand(command);
		}

		private static void DeleteDocument(int documentId)
		{
			var parameters = new ParameterSet();
			parameters.Add(DbType.Int32, "DOCUMENT_ID", documentId);
			var command = new Command
			{
				SqlStatementId = "DELETE_DOCUMENT_ROLE",
				ParameterCollection = parameters
			};

			var access = new DataAccess();

			access.GetReader(command);
		}

		private static void DeleteDocumentRole(int documentId)
		{
			var parameters = new ParameterSet();
			parameters.Add(DbType.Int32, "DOCUMENT_ID", documentId);
			var command = new Command
			{
				SqlStatementId = "DELETE_DOCUMENT_ROLE",
				ParameterCollection = parameters
			};

			var access = new DataAccess();

			access.GetReader(command);
		}

		private static void DeleteAnswer(int answerId)
		{
			var parameters = new ParameterSet();
			parameters.Add(DbType.Int32, "ANSWER_ID", answerId);
			var command = new Command
			{
				SqlStatementId = "DELETE_REQEST_DOCUMENT_RECORD",
				ParameterCollection = parameters
			};

			var access = new DataAccess();

			access.GetReader(command);
		}

		private static void ExecuteDeleteCommand(Command command)
		{
			var access = new DataAccess();

			using (MySqlDataReader reader = access.GetReader(command))
			{
				while (reader.Read())
				{
					if (!reader.IsDBNull(0))
					{
						DeleteDocumentRole(reader.GetInt32(0));
						DeleteDocument(reader.GetInt32(0));
					}
				}
			}
		}
	}
}