using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using API;
using API.Config;
using API.Data;
using API.FileIO;
using UI.Controls;

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
		private const string FILE_COUNT_FORMAT = "[{0} files, totaling {1:n} MB";
		private const string NO_FILE_COUNT = "[No Files Found]";
		private const string VALIDATION_ERROR_CAPTION = "Invalid Processing State";
		private const string VALIDATION_ERROR_FOLDER_NOT_FOUND_FORMAT = "{0}   WARNING!: Cannot find or access specified folder.";
		private const string VALIDATION_ERROR_FOLDER_NOT_EMPTY = "Warning: All files in the destination folder will be removed, do you wish to proceed?";
		private const string VALIDATION_ERROR_OUTPUT_NOT_SELECTED = "Please select an output destination before continuing.";
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

		private static void BindData(ComboBox comboBox, IReadOnlyCollection<KeyValuePair<string, string>> source)
		{
			if (source.Count > 0)
			{
				comboBox.DataSource = new BindingSource(source, null);
				comboBox.DisplayMember = "Key";
				comboBox.ValueMember = "Value";
			}
			else
			{
				comboBox.DataSource = null;
			}
		}

		private void Initialize()
		{
			state = new FileProcessingState
			{
				BaseDirectory = ParentControl.SourceLocation
			};

			data = new ApplicantProcessQuery();
			BindData(foundationIdComboBox, data.BuildFoundationDictionary());
			BindData(fileTypeComboBox, ApplicationConfiguration.FileMaskSettings);
		}
		
		private void SetProcessingFolderText()
		{
			DirectoryInfo rootDirectory = new DirectoryInfo(state.RootProcessDirectory);
			rootProcessingFolder.Text = rootDirectory.Exists 
				? state.RootProcessDirectory 
				: String.Format(VALIDATION_ERROR_FOLDER_NOT_FOUND_FORMAT, state.RootProcessDirectory)
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
				DirectoryInfo outputDirectory = new DirectoryInfo(state.OutputDirectory);
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

				FileProcessing.CopyFilesToDestination(state);

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

		private void MouseClick_comboBox(object sender, MouseEventArgs e)
		{
			ComboBox control = sender as ComboBox;
			if (control != null)
			{
				if (control.DroppedDown)
					return;
				control.DroppedDown = true;
			}
		}

		private void OnKeyDown_comboBox(object sender, KeyEventArgs e)
		{
			ComboBox control = sender as ComboBox;
			if (control != null)
			{
				if (control.DroppedDown || e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
					return;
				control.DroppedDown = true;
			}
		}

		private void OnLeave_FoundationDropDown(object sender, EventArgs e)
		{
			ComboBox control = (ComboBox)sender;

			string selectedUrlKey = string.Empty;
			if (control.SelectedItem != null)
			{
				selectedUrlKey = ((KeyValuePair<string, string>)control.SelectedItem).Value;
			}

			if (!string.IsNullOrEmpty(control.Text))
			{
				BindingSource boundData = (BindingSource)control.DataSource;
				KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)boundData[control.FindString(control.Text)];
				selectedUrlKey = keyValuePair.Value;
			}
			
			if (string.Compare(state.FoundationUrlKey, selectedUrlKey, StringComparison.InvariantCultureIgnoreCase) != 0)
			{
				state.FoundationUrlKey = selectedUrlKey;
				SetProcessingFolderText();
				BindData(processIdComboBox, data.BuildFoundationProcessInfoDictionary(state.FoundationUrlKey));
			}
		}

		private void SelectedValueChanged_FoundationDropDown(object sender, EventArgs e)
		{
			string selectedUrlKey = ((KeyValuePair<string, string>)((ComboBox)sender).SelectedItem).Value;
			System.Diagnostics.Debug.Print(selectedUrlKey);
			if (string.Compare(state.FoundationUrlKey, selectedUrlKey, StringComparison.InvariantCultureIgnoreCase) != 0)
			{
				state.FoundationUrlKey = selectedUrlKey;
				SetProcessingFolderText();
				BindData(processIdComboBox, data.BuildFoundationProcessInfoDictionary(state.FoundationUrlKey));
			}
		}

		private void SelectedIndexChanged_ProcessIdComboBox(object sender, EventArgs e)
		{
			int foundationProcessId = -1;

			if (((ComboBox)sender).SelectedItem != null)
			{
				KeyValuePair<string, string> keyPair = ((KeyValuePair<string, string>)((ComboBox)sender).SelectedItem);
					if (keyPair.Value != null)
						Int32.TryParse(keyPair.Value, out foundationProcessId);
			}
			try
			{
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


		private void SelectedIndexChanged_FileTypeComboBox(object sender, EventArgs e)
		{
			string selectedFilePattern = ((KeyValuePair<string, string>)((ComboBox)sender).SelectedItem).Value;
			if (string.Compare(state.FileMask, selectedFilePattern, StringComparison.InvariantCultureIgnoreCase) != 0)
			{
				state.FileMask = selectedFilePattern;
				SelectedIndexChanged_ProcessIdComboBox(processIdComboBox, new EventArgs());
			}
		}

		//Completed: handle page validation
		// Completed - Includes, Do not allow run until destination folder is selected, or input
		//TODO: Add task completion notification
		//COMPLETED: Get count of files to copy - also added applicant process IDs
			//TODO: still needs display
		//TODO: Set up display of task output
		//TODO: NTH: display list of files to be output
			//TODO: need to add ontextchanged event handlers for textbox controls
		//TODO: add and configure log4net

	}
}
