using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using API.FileIO;

namespace UI
{
	public partial class FileExclusionsForm : Form
	{
		#region Member Variables
		
		private const string SEQUESTER_PATH_VALIDATION_ERROR = "Please enter a sequester path where you would like to move the excluded files to.";
		private const string SEQUESTER_PATH_VALIDATION_CAPTION = "Sequester Path Mission";

		private const string SEQUESTER_KEYWORD_TEXT = "Enter the file name keywords you would like to exclude from the finished set of client files.  Each keyword or phrase should be on its own line.";

		private FileProcessingState state;
		private string previousFilePath;
		
		#endregion

		#region Constructor

		public FileExclusionsForm(FileProcessingState state)
		{
			InitializeComponent();
			Initialize(state);
		}

		#endregion

		#region Properties
		#endregion

		#region Private Methods

		private void Initialize(FileProcessingState processingState)
		{
			state = processingState;
			if (state.SequesterPatterns != null && state.SequesterPatterns.Count > 0)
				exclusionsTextBox.Text = string.Join("\n", state.SequesterPatterns);

			dispositionMoveRadio.Checked = !string.IsNullOrEmpty(state.SequesterPath);
			dispositionDoNotCopyRadio.Checked = string.IsNullOrEmpty(state.SequesterPath);

			sequestorLocationTextBox.Text = state.SequesterPath;

			exclusionInstructionsLabel.Text = SEQUESTER_KEYWORD_TEXT;
		}

		private void UpdateStateWithExclusions(string exclusions)
		{
			string formatedExclusions = exclusions.Replace("*", "").Replace("\n", ",");
			List<string> exclusionsList = formatedExclusions.Split(',').ToList();
			state.SequesterPatterns = exclusionsList;
		}

		#region Event Handlers
		
		private void ButtonClick_Ok(object sender, EventArgs e)
		{
			state.SequesterPath = sequestorLocationTextBox.Text;
			if (dispositionMoveRadio.Checked && string.IsNullOrEmpty(state.SequesterPath))
			{
				MessageBox.Show(this, SEQUESTER_PATH_VALIDATION_ERROR, SEQUESTER_PATH_VALIDATION_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				UpdateStateWithExclusions(exclusionsTextBox.Text);
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void ButtonClick_RadioButtonGroup(object sender, EventArgs e)
		{
			if (((RadioButton)sender).Name == dispositionDoNotCopyRadio.Name)
			{
				state.SequesterPath = "";
				previousFilePath = sequestorLocationTextBox.Text;
				sequestorLocationTextBox.Text = "";
			}
			else
			{
				sequestorLocationTextBox.Text = previousFilePath;
			}
		}

		private void ButtonClick_SequesterDestinationBrowse(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowser = new FolderBrowserDialog
			{
				ShowNewFolderButton = true
			};

			DialogResult result = folderBrowser.ShowDialog();
			if (result == DialogResult.OK)
			{
				state.OutputDirectory = folderBrowser.SelectedPath;
				sequestorLocationTextBox.Text = state.OutputDirectory;
			}
		}

		#endregion

		#endregion

	}
}
