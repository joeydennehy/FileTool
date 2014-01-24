using System;
using System.Collections.Generic;
using System.Windows.Forms;
using API;
using UI.Controls;

namespace UI.Controls.FunctionBlockControls
{
	public partial class ClientFileExtractionControl : FunctionBlockBaseControl
	{

		#region Member Variables

		private const string APPLICANT_PROCESS_FORMAT = "Total Applicant Process IDs: {0}";
		private const string FILE_COUNT_FORMAT = "[{0} files, totaling {1:n} MB";
		private const string NO_FILE_COUNT = "[No Files Found]";
		private const string PROCESS_FOLDER_FORMAT = "Root Process Folder: {0}";
		private const string WORKING = "[Working...]";

		private FileProcessingState state;
		private ApplicantProcessQuery data;

		#endregion

		#region Constructor

		public ClientFileExtractionControl(GLMFileUtilityTool parent) : base(parent)
		{
			InitializeComponent();
			Initialize();
		}

		#endregion

		#region Properties

		public override string TitleBlockText { get { return "Extract Client Files"; } }

		#endregion
		
		#region Private Methods

		private static void BindData(ComboBox comboBox, Dictionary<string, string> source)
		{
			comboBox.DataSource = new BindingSource(source, null);
			comboBox.DisplayMember = "Key";
			comboBox.ValueMember = "Value";
		}

		private void Initialize()
		{
			state = new FileProcessingState
			{
				BaseDirectory = ParentControl.SourceLocation
			};

			data = new ApplicantProcessQuery();
			BindData(foundationIdComboBox, data.BuildFoundationDictionary());
		}

		#region Event Handlers

		private const string VALIDATION_ERROR_OUTPUT_NOT_SELECTED = "Please select an output destination before continuing.";
		private const string VALIDATION_ERROR_CAPTION = "Invalid Processing State";

		private void ButtonClick_CopyFiles(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(state.OutputDirectory))
			{
				MessageBox.Show(
					this, 
					VALIDATION_ERROR_OUTPUT_NOT_SELECTED, 
					VALIDATION_ERROR_CAPTION, 
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation
				);
				return;
			}

			Cursor = Cursors.WaitCursor;
			try
			{
				FileProcessing.CopyFilesToDestination(state);
			}
			catch (Exception eError)
			{

				throw;
			}
			finally
			{
				Cursor = Cursors.WaitCursor;
			}
		}

		private void ButtonClick_OutputDestinationBrowse(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowser = new FolderBrowserDialog
			{
				ShowNewFolderButton = true
			};

			DialogResult result = folderBrowser.ShowDialog();
			if (result == DialogResult.OK)
			{
				state.OutputDirectory = folderBrowser.SelectedPath;
				outputDestinationTextBox.Text = state.OutputDirectory;
			}
		}

		private void SelectedValueChanged_FoundationDropDown(object sender, EventArgs e)
		{
			state.FoundationUrlKey = ((KeyValuePair<string, string>)((ComboBox)sender).SelectedItem).Value;
			rootProcessingFolder.Text = state.RootProcessDirectory;
			BindData(processIdComboBox, data.BuildFoundationProcessInfoDictionary(state.FoundationUrlKey));
		}

		private void SelectedIndexChanged_ProcessIdComboBox(object sender, EventArgs e)
		{
			int foundationProcessId;
			Int32.TryParse(((KeyValuePair<string, string>)((ComboBox)sender).SelectedItem).Value, out foundationProcessId);

			Cursor = Cursors.WaitCursor;
			ApplicantProcessIdsLabel.Text = string.Format(APPLICANT_PROCESS_FORMAT, "");
			fileCountLinkLabel.Text = WORKING;
			
			state.FoundationProcessId = foundationProcessId;
			state.FoundationApplicantProcessIds = data.RetrieveApplicationProcessInfo(foundationProcessId);

			ApplicantProcessIdsLabel.Text = string.Format(APPLICANT_PROCESS_FORMAT, state.FoundationApplicantProcessIds.Count);

			if (state.FoundationApplicantProcessIds.Count > 0)
			{
				FileProcessing.SetFilelist(state);
				if (state.Files != null && state.Files.Count > 0)
				{
					fileCountLinkLabel.Text = string.Format(FILE_COUNT_FORMAT, state.Files.Count, (float)state.TotalSize / (1024 * 1024));
				}
				else
				{
					fileCountLinkLabel.Text = NO_FILE_COUNT;
				}
			}
			else
			{
				fileCountLinkLabel.Text = NO_FILE_COUNT;
			}
			Cursor = Cursors.Default;
		}

		#endregion

		#endregion

		//TODO: handle page validation
		// Includes, Do not allow run until destination folder is selected, or input
		// Includes, Validate empty state of destination folder
		//TODO: Add task completion notification
		//COMPLETED: Get count of files to copy - also added applicant process IDs
			//TODO: still needs display
		//TODO: Set up display of task output
		//TODO: NTH: display list of files to be output
			//TODO: need to add ontextchanged event handlers for textbox controls
		//TODO: add and configure log4net

	}
}
