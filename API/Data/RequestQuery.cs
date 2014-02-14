using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
				reader.Close();
			}
		}

		public static List<string> GetFoundationFileList(int foundationId)
		{
			var fileList = new List<string>();

			var queryIds = new List<string>
			{
				"SELECT_SHARED_FILES_BY_FOUNDATION_ID",
				"SELECT_ORG_SUPPORTING_DOCUMENTS_BY_FOUNDATION_ID",
				"SELECT_APPLICATION_SUPPORTING_DOCUMENTS_BY_FOUNDATION_ID",
				"SELECT_REQUEST_FILES_BY_URL_KEY",
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
							string partialFileName = reader.GetString(0)
								.Split(new[] {"[:|:]"}, StringSplitOptions.None)[0];
							string fileName = Path.GetFileName(partialFileName);

							if (!string.IsNullOrEmpty(fileName) && !fileList.Contains(partialFileName))
							{
								fileList.Add(partialFileName.ToLower());
							}
						}
					}
				}
			}

			return fileList;
		}

		public static List<int> RetrieveApplicationProcessInfo(int foundationProcess)
		{
			var parameters = new ParameterSet();
			parameters.Add(DbType.Int32, "FOUNDATION_PROCESS", foundationProcess);
			var command = new Command
			{
				SqlStatementId = "SELECT_APPLICATION_PROCESS_INFO",
				ParameterCollection = parameters
			};

			var access = new DataAccess();

			var foundationProcesses = new List<int>();

			using (MySqlDataReader reader = access.GetReader(command))
			{
				while (reader.Read())
				{
					if (!reader.IsDBNull(0))
					{
						foundationProcesses.Add(reader.GetInt32(0));
					}
				}
			}

			return foundationProcesses;
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