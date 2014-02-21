using System;
using System.Windows.Forms;
using API.FileIO;

namespace UI
{
	public partial class FileNotFoundForm : Form
	{
		#region Member Variables
		
		private const string SEQUESTER_KEYWORD_TEXT = "Files that are referenced but are not on disk.";

		private FoundationDataFileState state;
		
		#endregion

		#region Constructor

		public FileNotFoundForm(FoundationDataFileState state)
		{
			InitializeComponent();
			Initialize(state);
		}

		#endregion

		#region Properties
		#endregion

		#region Private Methods

		private void Initialize(FoundationDataFileState processingState)
		{
			state = processingState;

			if (state.FilesNotFound != null && state.FilesNotFound.Count > 0)
				notFoundTextBox.Text = string.Join("\n", state.FilesNotFound);

			deleteRecordButton.Enabled = false;
			exclusionInstructionsLabel.Text = SEQUESTER_KEYWORD_TEXT;
		}

		#region Event Handlers
		
		private void ButtonClick_Ok(object sender, EventArgs e)
		{
				DialogResult = DialogResult.OK;
				Close();
		}

		#endregion

		private void exclusionInstructionsLabel_Click(object sender, EventArgs e)
		{

		}

		#endregion

	}
}
