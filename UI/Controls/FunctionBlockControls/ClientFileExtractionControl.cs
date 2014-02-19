using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using API.Config;
using API.Data;
using API.FileIO;

namespace UI.Controls.FunctionBlockControls
{
	public partial class ClientFileExtractionControl : FunctionBlockBaseControl
	{
		#region Member Variables

		private const string APPLICANT_PROCESS_FORMAT = "Total Applicant Process IDs: {0}";
		private const string FILE_COPY_CAPTION = "File Copy";
		private const string FILE_COPY_COMPLETE = "File copy has completed.";
		private const string FILE_COPY_ERROR_FORMAT = "File copy procedure gave the following error {0}.";
		private const string FILE_DELETE_ERROR_FORMAT = "Unable to remove file: {0} due to the following error: {1}. /r/n The copy process will abort.";
		private const string FILE_COUNT_FORMAT = "[{0} files, totaling {1:n} MB]";
		private const string FILE_EXCLUDED_COUNT_FORMAT = "[{0} files]";
		private const string NO_FILE_COUNT = "[No Files Found]";
		private const string NO_FILE_EXCLUSIONS = "[No Files Excluded]";
		private const string VALIDATION_ERROR_CAPTION = "Invalid Processing State";
		private const string VALIDATION_ERROR_FOLDER_NOT_FOUND_FORMAT = "{0}   WARNING!: Cannot find or access specified folder.";
		private const string VALIDATION_ERROR_FOLDER_NOT_EMPTY = "Warning: All files in the destination folder will be removed, do you wish to proceed?";
		private const string VALIDATION_ERROR_OUTPUT_NOT_SELECTED = "Please select an output destination before continuing.";
		private const string WORKING = "[Working...]";
	
		private FoundationDataFileState state;

		#endregion

		#region Constructor

		public ClientFileExtractionControl(GLMFileUtilityTool parent) : base(parent)
		{
			InitializeComponent();
		}

		#endregion

		#region Properties

		public override string TitleBlockText { get { return "Extract Client Files"; } }

		#endregion
		
		#region Private Methods

		private void BindFoundationProcessData()
		{
			try
			{
				RequestQuery.RefreshFoundationProcessData(state.FoundationId);

				if (RequestQuery.FoundationProcessData.Rows.Count == 0)
				{
					processIdComboBox.DataSource = null;
					return;
				}

				processIdComboBox.DataSource = RequestQuery.FoundationProcessData;
				processIdComboBox.DisplayMember = "ProcessDisplayText";
				processIdComboBox.ValueMember = "FoundationProcessId";
			}
			catch (Exception eError)
			{
				MessageBox.Show(this, string.Format(FILE_COPY_ERROR_FORMAT, eError.Message), FILE_COPY_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ChangeFoundationSelection(DataRow selectedRow)
		{
			var selectedFoundationId = (int)selectedRow[0];
			var selectedUrlKey = (string)selectedRow[1];

			if (state.FoundationId != selectedFoundationId)
			{
				state.FoundationId = selectedFoundationId;
				state.FoundationUrlKey = selectedUrlKey;

				SetProcessingFolderText();
				BindFoundationProcessData();
			}
		}

		public override void Initialize()
		{
			base.Initialize();

			state = new FoundationDataFileState
			{
				BaseDirectory = ParentControl.SourceLocation
			};

			try
			{
				//Bind Foundation List
				RequestQuery.RefreshFoundationData();
				foundationIdComboBox.DataSource = RequestQuery.FoundationData;
				foundationIdComboBox.DisplayMember = "FoundationDisplayText";
				foundationIdComboBox.ValueMember = "FoundationId";

				//Bind File Types
				fileTypeComboBox.DataSource = new BindingSource(ApplicationConfiguration.FileMaskSettings, null);
				fileTypeComboBox.DisplayMember = "Key";
				fileTypeComboBox.ValueMember = "Value";
			}
			catch (Exception eError)
			{
				MessageBox.Show(this, string.Format(FILE_COPY_ERROR_FORMAT, eError.Message), FILE_COPY_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void SetProcessingFolderText()
		{
			var rootDirectory = new DirectoryInfo(state.ClientRootDirectory);
			rootProcessingFolder.Text = rootDirectory.Exists 
				? state.ClientRootDirectory 
				: String.Format(VALIDATION_ERROR_FOLDER_NOT_FOUND_FORMAT, state.ClientRootDirectory)
			;
		}

		#region Event Handlers

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
				var outputDirectory = new DirectoryInfo(state.OutputDirectory);
				if (outputDirectory.Exists && outputDirectory.GetFiles().Any())
				{
					DialogResult prompt = MessageBox.Show(this, VALIDATION_ERROR_FOLDER_NOT_EMPTY, FILE_COPY_CAPTION, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
					if (prompt == DialogResult.Yes)
					{
						foreach (FileInfo fileInfo in outputDirectory.GetFiles())
						{
							try
							{
								File.Delete(fileInfo.FullName);
							}
							catch (Exception eError)
							{
								MessageBox.Show(this, string.Format(FILE_DELETE_ERROR_FORMAT, fileInfo.Name, eError.Message), FILE_COPY_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}
						}
					}
					else
					{
						return;
					}
				}

				FileProcessing.CopyApplicationProcessFiles(state);

				MessageBox.Show(this, FILE_COPY_COMPLETE, FILE_COPY_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception eError)
			{
				MessageBox.Show(this, string.Format(FILE_COPY_ERROR_FORMAT, eError.Message), FILE_COPY_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}
		
		private void ButtonClick_FileExclusions(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var fileExclusions = new FileExclusionsForm(state);
			DialogResult result =fileExclusions.ShowDialog();
			if (result == DialogResult.OK)
			{
				SelectedIndexChanged_ProcessIdComboBox(processIdComboBox, new EventArgs());
			}

			if (state.SequesterFiles != null && state.SequesterFiles.Count > 0)
			{
				secludedFileCountlinkLabel.Text = string.Format(FILE_EXCLUDED_COUNT_FORMAT, state.SequesterFiles.Count);
			}
			else
			{
				secludedFileCountlinkLabel.Text = NO_FILE_EXCLUSIONS;
			}
			
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
				state.OutputDirectory = folderBrowser.SelectedPath;
				outputDestinationTextBox.Text = state.OutputDirectory;
			}
		}

		private void LinkClick_FileCountLinkLabel(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var fileListDisplay = new FileListDisplayForm(state.Files);
			fileListDisplay.ShowDialog(this);
		}

		private void LinkClick_SecludedFileCountlinkLabel(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var fileListDisplay = new FileListDisplayForm(state.SequesterFiles);
			fileListDisplay.ShowDialog(this);
		}

		private void MouseClick_comboBox(object sender, MouseEventArgs e)
		{
			var control = sender as ComboBox;
			if (control != null)
			{
				if (control.DroppedDown)
					return;
				control.DroppedDown = true;
			}
		}

		private void OnKeyDown_comboBox(object sender, KeyEventArgs e)
		{
			var control = sender as ComboBox;
			if (control != null)
			{
				if (control.DroppedDown || e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
					return;
				control.DroppedDown = true;
			}
		}

		private void OnLeave_FoundationDropDown(object sender, EventArgs e)
		{
			DataRow selectedRow = null;
			if (foundationIdComboBox.SelectedValue != null)
			{
				selectedRow = ((DataRowView)foundationIdComboBox.SelectedValue).Row;
			}
			else if (!string.IsNullOrEmpty(foundationIdComboBox.Text))
			{
				var boundData = (DataTable)foundationIdComboBox.DataSource;
				string searchExpression = string.Format("FoundationDisplayText like '%{0}%' ", foundationIdComboBox.Text);
				var rows = boundData.Select(searchExpression);
				if(rows.Any())
					selectedRow = rows[0];
			}

			ChangeFoundationSelection(selectedRow);
		}

		private void SelectedIndexChanged_FileTypeComboBox(object sender, EventArgs e)
		{
			string selectedFilePattern = ((KeyValuePair<string, string>)((ComboBox)sender).SelectedItem).Value;
			if (string.Compare(state.FileMask, selectedFilePattern, StringComparison.InvariantCultureIgnoreCase) != 0)
			{
				state.FileMask = selectedFilePattern;
				SelectedIndexChanged_ProcessIdComboBox(processIdComboBox, new EventArgs());
			}
		}

		private void SelectedValueChanged_FoundationDropDown(object sender, EventArgs e)
		{
			ChangeFoundationSelection(((DataRowView)foundationIdComboBox.SelectedItem).Row);
		}

		private void SelectedIndexChanged_ProcessIdComboBox(object sender, EventArgs e)
		{
			int foundationProcessId = -1;

			if (((ComboBox)sender).SelectedItem != null)
			{
				var selectedRow = ((DataRowView)((ComboBox)sender).SelectedItem).Row;
				foundationProcessId = (int)selectedRow[0];
			}
			try
			{
				Cursor = Cursors.WaitCursor;
				ApplicantProcessIdsLabel.Text = string.Format(APPLICANT_PROCESS_FORMAT, "");
				fileCountLinkLabel.Text = WORKING;

				state.FoundationProcessId = foundationProcessId;
				try
				{
					state.FoundationApplicantProcessCodes = RequestQuery.RetrieveApplicationProcessInfo(foundationProcessId);
				}
				catch (Exception eError)
				{
					MessageBox.Show(this, string.Format(FILE_COPY_ERROR_FORMAT, eError.Message), FILE_COPY_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				ApplicantProcessIdsLabel.Text = string.Format(APPLICANT_PROCESS_FORMAT, state.FoundationApplicantProcessCodes.Count);

				if (state.FoundationApplicantProcessCodes.Count > 0)
				{
					FileProcessing.SetFileList(state);
					if (state.Files != null && state.Files.Count > 0)
					{
						fileCountLinkLabel.Text = string.Format(FILE_COUNT_FORMAT, state.Files.Count,
							(float)state.TotalSize / (1024 * 1024));
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
			}
			catch (Exception eError)
			{
				MessageBox.Show(this, string.Format(FILE_COPY_ERROR_FORMAT, eError.Message), FILE_COPY_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void TextChanged_outputDestinationTextBox(object sender, EventArgs e)
		{
			state.OutputDirectory = outputDestinationTextBox.Text;
		}

		#endregion

		#endregion

		#region Protected Methods

		protected override void OnEnter(EventArgs e)
		{
			state.BaseDirectory = ParentControl.SourceLocation;
			SetProcessingFolderText();

			base.OnEnter(e);
		}

		#endregion
	}
}
