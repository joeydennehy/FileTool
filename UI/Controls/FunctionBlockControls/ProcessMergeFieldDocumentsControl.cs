using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using API.Data;
using API.FileIO;

namespace UI.Controls.FunctionBlockControls
{
	public partial class ProcessMergeFieldDocumentsControl : FunctionBlockBaseControl
	{

		#region Member Variables

		private readonly FoundationDataFileState state;
		private readonly StringBuilder reportFieldOutput;

		#endregion // Member Variables

		#region Constructor

		public ProcessMergeFieldDocumentsControl(GLMFileUtilityTool parent)
			: base(parent)
		{
			InitializeComponent();

			state = new FoundationDataFileState
			{
				BaseDirectory = parent.SourceLocation
			};

			copyFilesButton.Enabled = false;
			reportFieldOutput = new StringBuilder();
			
			//Initial Report Header:
			reportFieldOutput.AppendLine("Document Name, Document Path, Report Field Count, Report Field Hashed ID, Report Field ID, Report Field Label");
		}

		#endregion // Constructor

		#region Properties

		public override string TitleBlockText { get { return "Process Merge Templates"; } }

		#endregion // Properties

		#region Private Methods

		#region Event Handlers

		private void ButtonClick_CopyFilesButton(object sender, EventArgs e)
		{
			IEnumerable<FileInfo> filesToProcess = BuildFileInfoListToProcess();
			ProcessFileInfoList(filesToProcess);
		}

		private void ButtonClick_OutputDestinationBrowse(object sender, EventArgs e)
		{
			var folderBrowser = new FolderBrowserDialog
			{
				ShowNewFolderButton = true
			};

			DialogResult result = folderBrowser.ShowDialog();

			if (result == DialogResult.OK)
			{
				string selectedPath = folderBrowser.SelectedPath;
				if (!selectedPath.EndsWith("\\"))
					selectedPath = string.Format("{0}\\", selectedPath);

				state.OutputDirectory = selectedPath;
				outputDestinationTextBox.Text = selectedPath;
			}

		}

		private void TextChanged_OutputDestinationTextBox(object sender, EventArgs e)
		{
			copyFilesButton.Enabled = !string.IsNullOrWhiteSpace(outputDestinationTextBox.Text);
		}

		#endregion // Event Handlers

		private IEnumerable<FileInfo> BuildFileInfoListToProcess()
		{
			RequestQuery.RefreshMergeTemplateData();
			IEnumerable<FileInfo> mergeTemplateInfo = FileProcessing.BuildMergeTemplateFileInfo(RequestQuery.MergeTemplateData, state.BaseDirectory);
			RequestQuery.RefreshCustomPrintPacketData();
			IEnumerable<FileInfo> customPrintPacketInfo = FileProcessing.BuildCustomPrintPacketInfo(RequestQuery.CustomPrintPacketData, state.BaseDirectory);

			var fileProcessingList = mergeTemplateInfo.Where(fileInfo => fileInfo.Exists).ToList();
			fileProcessingList.AddRange(customPrintPacketInfo.Where(fileInfo => fileInfo.Exists));

			return fileProcessingList;
		}

		private void ProcessFileInfoList(IEnumerable<FileInfo> filesToProcess)
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				RequestQuery.RefreshReportFieldData();

				foreach (var fileInfo in filesToProcess)
				{
					var fileNameSegments = fileInfo.Name.Split(new[] { '.' });

					bool isMergeTemplate = fileNameSegments[0] == "mergetemplate";

					int fileId;
					Int32.TryParse(fileNameSegments[1], out fileId);

					string actualFileName = isMergeTemplate
						? RequestQuery.GetMergeTemplateFileName(fileId)
						: RequestQuery.GetCustomPrintPacketFileName(fileId);

					List<string> reportFields = DocumentProcessing.GetMergeFieldIds(fileInfo.FullName);

					int reportFieldCount = 0;
					var processedFieldOutput = new StringBuilder();

					if (reportFields.Any())
					{
						foreach (string reportField in reportFields)
						{
							if (reportField.Contains("RF_"))
							{
								reportFieldCount++;
								var reportFieldInfo = RequestQuery.ReportFieldData.Rows.Find(reportField);
								processedFieldOutput.AppendLine(reportFieldInfo != null
									? string.Format(",,,{0},{1},{2}", reportFieldInfo["ReportFieldTemplateIdHash"], reportFieldInfo["ReportFieldTemplateId"], reportFieldInfo["ReportFieldTemplateName"])
									: string.Format(",,,{0},NA,NA", reportField));
							}
						}
					}

					reportFieldOutput.AppendLine(string.Format("{0},{1},{2}", actualFileName, fileInfo.FullName, reportFieldCount));
					reportFieldOutput.Append(processedFieldOutput);
					reportFieldOutput.AppendLine();
				}
			}
			finally
			{
				Cursor = Cursors.Default;
			}

			try
			{
				string outputFileWritePath = string.Format("{0}{1}", outputDestinationTextBox.Text, "ReportFields.csv");
				FileProcessing.WriteToCsv( outputFileWritePath, reportFieldOutput);
				MessageBox.Show(this, string.Format("Report Generated and written to: {0}", outputFileWritePath), "Report Completed", MessageBoxButtons.OK);
			}
			catch (Exception eError)
			{
				MessageBox.Show(this, eError.Message, "Could not complete action:", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion // Private Methods

		#region  Protected Methods

		#endregion // Protected Methods
	}
}
