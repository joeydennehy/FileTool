using System;
using System.Collections.Generic;
using System.Windows.Forms;
using API;

namespace UI.Controls.FunctionBlockControls
{
	public partial class ClientFileExtractionControl : FunctionBlockBaseControl
	{

		#region Member Variables

		private const string APPLICANT_PROCESS_FORMAT = "Total Applicant Process IDs: {0}";
		private const string FILE_COUNT_FORMAT = "[{0} files found]";
		private const string NO_FILE_COUNT = "[No Files Found]";
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

		private void ButtonClick_CopyFiles(object sender, EventArgs e)
		{
			//FileProcessing.CopyFilesToDestination(
			//	ParentControl.SourceLocation, 
			//	foundationUrlKey, 
			//	new List<int> { foundationProcessId }, 
			//	outputDestination
			//);
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
			BindData(processIdComboBox, data.BuildFoundationProcessInfoDictionary(state.FoundationUrlKey));
		}

		private void SelectedIndexChanged_ProcessIdComboBox(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			ApplicantProcessIdsLabel.Text = string.Format(APPLICANT_PROCESS_FORMAT, "");
			fileCountLinkLabel.Text = WORKING;

			int foundationProcessId;
			Int32.TryParse(((KeyValuePair<string, string>)((ComboBox)sender).SelectedItem).Value, out foundationProcessId);

			state.FoundationProcessId = foundationProcessId;
			state.FoundationApplicantProcessIds = data.RetrieveApplicationProcessInfo(foundationProcessId);

			ApplicantProcessIdsLabel.Text = string.Format(APPLICANT_PROCESS_FORMAT, state.FoundationApplicantProcessIds.Count);

			if (state.FoundationApplicantProcessIds.Count > 0)
			{
				FileProcessing.SetFilelist(state);
				if (state.Files != null && state.Files.Count > 0)
					fileCountLinkLabel.Text = string.Format(FILE_COUNT_FORMAT, state.Files.Count);
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
		//TODO: Add task completion notification
		//COMPLETED: Get count of files to copy and display - also added applicant process IDs
		//TODO: Set up display of task output
		//TODO: NTH: display list of files to be output
		//TODO: need to validate the selected path
			//TODO: need to add ontextchanged event handlers for textbox controls
		//TODO: add and configure log4net

	}
}
