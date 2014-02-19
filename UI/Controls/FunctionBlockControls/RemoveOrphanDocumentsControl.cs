using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using API.Data;
using API.FileIO;

namespace UI.Controls.FunctionBlockControls
{
	public partial class RemoveOrphanDocumentsControl : FunctionBlockBaseControl
	{
		#region member variables

		private const string FILE_MOVE_CAPTION = "File Move";
		private const string FILE_MOVE_ERROR_FORMAT = "File move procedure gave the following error {0}.";

		private const string VALIDATION_ERROR_FOLDER_NOT_FOUND_FORMAT =
			"{0}   WARNING!: Cannot find or access specified folder.";

		private FoundationDataFileState state;

		#endregion

		#region properties

		public override string TitleBlockText
		{
			get { return "Search and Remove Orphaned Documents"; }
		}

		#endregion

		#region Constructor

		public RemoveOrphanDocumentsControl(GLMFileUtilityTool parent) : base(parent)
		{
			InitializeComponent();
		}

		#endregion

		#region private methods

		public override void Initialize()
		{
			base.Initialize();
			state = new FoundationDataFileState
			{
				BaseDirectory = ParentControl.SourceLocation
			};

			moveFilesButton.Enabled = !string.IsNullOrWhiteSpace(moveLocationText.Text) && state.SequesterFiles.Any();
			undoButton.Enabled = false;

			try
			{
				RequestQuery.RefreshFoundationData();
				foundationIdComboBox.DataSource = RequestQuery.FoundationData;
				foundationIdComboBox.DisplayMember = "FoundationDisplayText";
				foundationIdComboBox.ValueMember = "FoundationId";
			}
			catch (Exception eError)
			{
				MessageBox.Show(this, string.Format(FILE_MOVE_ERROR_FORMAT, eError.Message), FILE_MOVE_CAPTION, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			var folderBrowser = new FolderBrowserDialog
			{
				ShowNewFolderButton = false
			};

			DialogResult result = folderBrowser.ShowDialog();
			if (result == DialogResult.OK)
			{
				state.OutputDirectory = folderBrowser.SelectedPath;
				moveLocationText.Text = state.OutputDirectory;
			}
		}

		private void LoadStateData()
		{
			var stateData = new StringBuilder();
			stateData.AppendLine("Total Files Processed: " + state.Files.Count);
			stateData.AppendLine("Total Sequestered Files: " + state.SequesterFiles.Count);
			stateData.AppendLine(string.Format("Total Files Not Found: {0}",  state.FilesNotFound != null ? state.FilesNotFound.Count.ToString() : "0"));
			stateDataTextBox.Text = stateData.ToString();
			var sequesteredFiles = new StringBuilder();
			string sourcePath = state.ClientRootDirectory;
			foreach (FileInfo sequesterFile in state.SequesterFiles)
			{
				sequesteredFiles.AppendLine(sequesterFile.FullName.Substring(sourcePath.Length));
			}
			moveFilesTextBox.Text = sequesteredFiles.ToString();
		}

		private void LoadInitialStateData(bool hasFiles)
		{
			string stateData = hasFiles ? "Processing..." : "No Files Found";
			stateDataTextBox.Text = stateData;
			stateDataTextBox.Update();
		}

		private void moveFilesButton_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				FileProcessing.MoveFilesToDestination(state.SequesterFiles, moveLocationText.Text, state.ClientRootDirectory);
				state.MovedToDirectory = moveLocationText.Text;
				state.MovedFromDirectory = state.ClientRootDirectory;
				undoButton.Enabled = true;
			}
			catch (Exception eError)
			{
				MessageBox.Show(this, string.Format(FILE_MOVE_ERROR_FORMAT, eError.Message), FILE_MOVE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void moveLocationText_TextChanged(object sender, EventArgs e)
		{
			state.OutputDirectory = moveLocationText.Text;
			moveFilesButton.Enabled = !string.IsNullOrWhiteSpace(moveLocationText.Text) && !string.IsNullOrWhiteSpace(moveFilesTextBox.Text);
		}

		private void MouseClick_comboBox(object sender, MouseEventArgs e)
		{
			var control = sender as ComboBox;
			if (control != null)
			{
				if (control.DroppedDown)
				{
					return;
				}
				control.DroppedDown = true;
			}
		}

		private void SelectedValueChanged_FoundationDropDown(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				HandleFoundationSelectionChanged(((DataRowView)foundationIdComboBox.SelectedItem).Row);
				EvaluateFiles();
			}
			catch (Exception eError)
			{
				MessageBox.Show(this, string.Format(FILE_MOVE_ERROR_FORMAT, eError.Message), FILE_MOVE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void SetProcessingFolderText()
		{
			var rootDirectory = new DirectoryInfo(state.ClientRootDirectory);
			rootProcessingFolder.Text = rootDirectory.Exists
				? state.ClientRootDirectory
				: String.Format(VALIDATION_ERROR_FOLDER_NOT_FOUND_FORMAT, state.ClientRootDirectory);
			rootProcessingFolder.Update();
		}

		private void HandleFoundationSelectionChanged(DataRow selectedRow)
		{
			var selectedFoundationId = (int)selectedRow[0];
			var selectedUrlKey = (string)selectedRow[1];

			if (state.FoundationId != selectedFoundationId)
			{
				state.FoundationId = selectedFoundationId;
				state.FoundationUrlKey = selectedUrlKey;

				SetProcessingFolderText();
			}
		}

		private void OnLeave_FoundationDropDown(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				DataRow selectedRow = null;

				var boundData = (DataTable)foundationIdComboBox.DataSource;

				string searchExpression = string.Format("FoundationDisplayText like '%{0}%' ", foundationIdComboBox.Text);

				var rows = boundData.Select(searchExpression);

				if (rows.Any())
					selectedRow = rows[0];

				HandleFoundationSelectionChanged(selectedRow);
				EvaluateFiles();
			}
			catch (Exception eError)
			{
				MessageBox.Show(this, string.Format(FILE_MOVE_ERROR_FORMAT, eError.Message), FILE_MOVE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cursor = Cursors.Default;
				moveFilesButton.Select();
			}
		}

		private void EvaluateFiles()
		{
			List<string> fileList = RequestQuery.GetFoundationFileList(state.FoundationId);
			LoadInitialStateData(fileList.Any());

			if (fileList.Any())
			{
				FileProcessing.ReconcileFileListToDatabase(state, fileList);
				LoadStateData();
			}
		}

		#endregion

		#region protect methods

		protected override void OnEnter(EventArgs e)
		{
			state.BaseDirectory = ParentControl.SourceLocation;
			SetProcessingFolderText();

			base.OnEnter(e);
		}

		protected override void OnPaint(PaintEventArgs pe) { base.OnPaint(pe); }

		private void undoButton_Click(object sender, EventArgs e) { FileProcessing.Undo(state); }

		#endregion

		private void fileNotFoundLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var fileNotFound = new FileNotFoundForm(state);
			DialogResult result = fileNotFound.ShowDialog();
			if (result == DialogResult.OK)
			{
				DeleteRecords();
			}
		}

		private void DeleteRecords()
		{
			List<string> fileList = state.FilesNotFound;
			foreach (var file in fileList)
			{
				string[] splitPath = file.Split('\\');
				if (splitPath[1] == "supportingdocuments")
				{
					DeleteSupportingRecords(splitPath);
				}
				else if (splitPath[0].Contains("shared"))
				{
					DeleteSharedRecords(splitPath);
				}
				else
				{
					DeleteRequestRecords(splitPath);
				}
			}
		}

		private void DeleteSupportingRecords(string [] splitPath)
		{
			if (splitPath[0].Contains("ORG-"))
			{
				int organizationId = Int32.Parse(splitPath[0].Substring(4));
				string fileName = splitPath[splitPath.Length - 1];
				RequestQuery.DeleteOrganizationSupportingRecords(organizationId, fileName);
			}
			else
			{
				int requestId = Int32.Parse(splitPath[0]);
				string fileName = splitPath[splitPath.Length - 1];
				RequestQuery.DeleteRequestSupportingRecords(requestId, fileName);
			}
		}

		private void DeleteSharedRecords(string [] splitPath)
		{
			string fileName = splitPath[splitPath.Length - 1];
			RequestQuery.DeleteSharedRecords(fileName);
		}

		private void DeleteRequestRecords(string[] splitPath)
		{
			string requestProcessCode = splitPath[0];
			string stageName = splitPath[1];
			string fileName = splitPath[splitPath.Length - 1];
			RequestQuery.DeleteRequestRecords(state.FoundationId, requestProcessCode, stageName, fileName);
		}
	}
}