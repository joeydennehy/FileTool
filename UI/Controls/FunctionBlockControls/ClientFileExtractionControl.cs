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

		private string outputDestination;
		private string foundationUrlKey;
		private int foundationProcessId;

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
			ApplicantProcessQuery data = new ApplicantProcessQuery();
			BindData(foundationIdComboBox, data.BuildFoundationDictionary());
		}

		#region Event Handlers

		private void ButtonClick_CopyFiles(object sender, EventArgs e)
		{
			ApplicantProcessQuery query = new ApplicantProcessQuery();
			//Assembly.GetExecutingAssembly().Location
			FileProcessingState state = new FileProcessingState
			{
				//sourceBlockPanel.Controls.Add(sourcePathBlockControl);
				BaseDirectory = ((SourcePathBlockControl)ParentControl.sourceBlockPanel.Controls.Find("sourcePathBlockControl",true)[0]).sourceLocationText.Text,
				OutputDirectory = outputDestinationTextBox.Text,
				FoundationUrlKey = ((KeyValuePair<string, string>)foundationIdComboBox.SelectedItem).Value,
				FoundationApplicantProcessIds = query.RetrieveApplicationProcessInfo(((KeyValuePair<string, string>)processIdComboBox.SelectedItem).Value)
			};

			FileProcessing.CopyFilesToDestination(state);
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
				outputDestination = folderBrowser.SelectedPath;
				outputDestinationTextBox.Text = outputDestination;
			}
		}

		private void SelectedValueChanged_FoundationDropDown(object sender, EventArgs e)
		{
			foundationUrlKey = ((KeyValuePair<string, string>)((ComboBox)sender).SelectedItem).Value;

			ApplicantProcessQuery data = new ApplicantProcessQuery();
			BindData(processIdComboBox, data.BuildFoundationProcessInfoDictionary(foundationUrlKey));
		}

		private void SelectedIndexChanged_ProcessIdComboBox(object sender, EventArgs e)
		{
			Int32.TryParse(((KeyValuePair<string, string>)((ComboBox)sender).SelectedItem).Value, out foundationProcessId);
		}

		#endregion

		#endregion

		//TODO: handle page validation
		//TODO: Add task completion notification
		//TODO: Get count of files to copy and display
		//TODO: Set up display of task output
		//TODO: NTH: display list of files to be output
		//TODO: need to validate the selected path
			//TODO: need to add ontextchanged event handlers for textbox controls
		//TODO: add and configure log4net

	}
}
