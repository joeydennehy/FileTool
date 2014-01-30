using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.FileIO;

namespace UI
{
	public partial class FileExclusionsForm : Form
	{
		private FileProcessingState state;
        private string previousFilePath;

		public FileExclusionsForm(FileProcessingState state)
		{
			InitializeComponent();
			Initialize(state);
		}

		private void Initialize(FileProcessingState state)
		{
			this.state = state;
			exclusionsTextBox.Text = string.Join("\n", state.SequesterPatterns);
            dispositionMoveRadio.Checked = !string.IsNullOrEmpty(state.SequesterPath);
            dispositionDoNotCopyRadio.Checked = string.IsNullOrEmpty(state.SequesterPath);
			sequestorLocationTextBox.Text = state.SequesterPath;
		}

		private void UpdateStateWithExclusions(string exclusions)
		{
			string formatedExclusions = exclusions.Replace("*", "")
			                                       .Replace(".", "")
			                                       .Replace("\n", ",");
			List<string> exclusionsList = formatedExclusions.Split(',').ToList();
			state.SequesterPatterns = exclusionsList;
		}

		private void UpdateStateWithExclusionAction(object sender)
		{
			if (sender == dispositionDoNotCopyRadio)
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

		private void UpdateStateWithSequestorLocation(string sequestorPath) { state.SequesterPath = sequestorPath; }


		private void okButton_Click(object sender, EventArgs e)
		{
			UpdateStateWithSequestorLocation(sequestorLocationTextBox.Text);
            if (dispositionMoveRadio.Checked && string.IsNullOrEmpty(state.SequesterPath))
			{
				MessageBox.Show(this, "Please enter a sequester path where you would like to move the excluded files to.", "Sequester Path Mission", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				UpdateStateWithExclusions(exclusionsTextBox.Text);
				Close();
			}
		}

		private void RadioButton_Click(object sender, EventArgs e) { UpdateStateWithExclusionAction(sender); }

		private void cancelButton_Click(object sender, EventArgs e) { Close(); }

        private void browseButton_Click(object sender, EventArgs e)
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
	}
}
