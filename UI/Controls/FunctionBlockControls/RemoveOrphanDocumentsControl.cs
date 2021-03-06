﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using API.Config;
using API.Data;
using API.FileIO;
using API.Logging;

namespace UI.Controls.FunctionBlockControls
{
	public partial class RemoveOrphanDocumentsControl : FunctionBlockBaseControl
	{
		#region Member Variables

		private const string FILE_MOVE_CAPTION = "File Move";
		private const string FILE_MOVE_COMPLETED = "Operation has completed, please view the output file located at {0} for full details and statistics.";
		private const string FILE_MOVE_ERROR_FORMAT = "File move procedure gave the following error {0}.";

		private const string EVALUATE_FILE_CAPTION = "Evaluate Files";
		private const string EVALUATE_FILE_ERROR_FORMAT = "Evaluate Files procedure gave the following error {0}.";

		private const string VALIDATION_ERROR_FOLDER_NOT_FOUND_FORMAT = "{0}   WARNING!: Cannot find or access specified folder.";

		private StringBuilder fileOutput;

		private FoundationDataFileState state;

		#endregion

		#region Properties

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

		public override void Initialize()
		{
			base.Initialize();
			
			fileOutput = new StringBuilder();

			state = new FoundationDataFileState
			{
				BaseDirectory = ParentControl.SourceLocation
			};

			moveLocationTextBox.Text = ApplicationConfiguration.GetSetting(ApplicationConfiguration.OUTPOUT_PATH_KEY);

			moveFilesButton.Enabled = !string.IsNullOrWhiteSpace(moveLocationTextBox.Text) && state.SequesterFiles.Any();
			moveFilesBackButton.Enabled = false;

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

		#region Private Methods

		private void LoadStateData()
		{
			var stateData = new StringBuilder();

			stateData.AppendLine("Total files found on disk: " + state.Files.Count);
			stateData.AppendLine(string.Format("Total file size (MB): {0}", state.TotalSize / (1024 * 1024)));
			stateData.AppendLine("Total files on disk that are not in database: " + state.SequesterFiles.Count);
			stateData.AppendLine(string.Format("Total files not found on disk: {0}", state.FilesNotFound != null ? state.FilesNotFound.Count.ToString(CultureInfo.CurrentCulture) : "0"));

			stateDataTextBox.Text = stateData.ToString();

			var sequesteredFiles = new StringBuilder();
			string sourcePath = state.ClientRootDirectory;

			foreach (FileInfo sequesterFile in state.SequesterFiles)
			{
				sequesteredFiles.AppendLine(sequesterFile.FullName.Substring(sourcePath.Length));
			}

			moveFilesTextBox.Text = sequesteredFiles.ToString();

			fileOutput.AppendLine(string.Format("Client URL Key: '{0}'", state.FoundationUrlKey));
			fileOutput.AppendLine(string.Format("Source Folder: '{0}'", state.ClientRootDirectory));
			fileOutput.Append(stateData);
		}

		private void SetProcessingFolderText()
		{
			var rootDirectory = new DirectoryInfo(state.ClientRootDirectory);

			rootProcessingFolder.Text = rootDirectory.Exists
				? state.ClientRootDirectory
				: String.Format(VALIDATION_ERROR_FOLDER_NOT_FOUND_FORMAT, state.ClientRootDirectory);
			rootProcessingFolder.Update();
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
			}
		}

		private void EvaluateFiles()
		{
			Dictionary<string, string> fileList = RequestQuery.GetFoundationFileList(state.FoundationId);
			stateDataTextBox.Text = fileList.Any() ? "Processing..." : "No Files Found";

			if (fileList.Any())
			{
				try
				{
					FileProcessing.ReconcileFileListToDatabase(state, fileList);
				}
				catch (Exception eError)
				{
					MessageBox.Show(this, string.Format(EVALUATE_FILE_ERROR_FORMAT, eError.Message), EVALUATE_FILE_CAPTION,
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				LoadStateData();
			}
		}

		#region Event Handlers

		private void ButtonClick_EvaluateFilesButton(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				EvaluateFiles();
				CheckToEnableMoveButton();
			}
			catch (Exception eError)
			{
				MessageBox.Show(this, string.Format(FILE_MOVE_ERROR_FORMAT, eError.Message), FILE_MOVE_CAPTION, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		/*private void ButtonClick_MoveFiles(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			string outputFileName = string.Empty;
			
			if (state.FilesNotFound != null && state.FilesNotFound.Count > 0)
			{
				fileOutput.AppendLine();
				fileOutput.AppendLine("Files not found on disk, but are referenced in the database:");
				fileOutput.AppendLine(string.Join("\r\n", state.FilesNotFound));
				fileOutput.AppendLine();
			}

			try
			{
				FileProcessing.MoveFilesToDestination(state, ref fileOutput, true);
				//FileProcessing.CleanUpFolders(state);
				moveFilesBackButton.Enabled = true;

				try
				{
					outputFileName = string.Format("{0}\\FileMove_{1}_{2}.txt", state.OutputDirectory, state.FoundationUrlKey, DateTime.Now.ToString("s").Replace(':', '_'));
					using (var writer = new StreamWriter(outputFileName, true))
					{
						writer.Write(fileOutput.ToString());
						writer.Flush();
					}
				}
				catch (Exception eError)
				{
					string errorMessage = string.Format("Unable to write output file: {0}", eError.Message);
					MessageBox.Show(this, errorMessage, FILE_MOVE_CAPTION,MessageBoxButtons.OK, MessageBoxIcon.Error);
					Logger.Log(errorMessage, LogLevel.Error);
				}

			}
			catch (Exception eError)
			{
				MessageBox.Show(this, string.Format(FILE_MOVE_ERROR_FORMAT, eError.Message), FILE_MOVE_CAPTION, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				Cursor = Cursors.Default;
				MessageBox.Show(this, string.Format(FILE_MOVE_COMPLETED, outputFileName), FILE_MOVE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}*/

		private void ButtonClick_OutputDestinationBrowse(object sender, EventArgs e)
		{
			var folderBrowser = new FolderBrowserDialog
			{
				ShowNewFolderButton = false
			};

			DialogResult result = folderBrowser.ShowDialog();

			if (result == DialogResult.OK)
			{
				state.OutputDirectory = folderBrowser.SelectedPath;
				moveLocationTextBox.Text = state.OutputDirectory;
			}
		}

		/*private void ButtonClick_MoveFilesBack(object sender, EventArgs e)
		{
			try
			{
				state.OutputDirectory = state.ClientRootDirectory;
				fileOutput.Clear();
				FileProcessing.MoveFilesToDestination(state, ref fileOutput);
			}
			catch (Exception eError)
			{
				MessageBox.Show(this, string.Format(EVALUATE_FILE_ERROR_FORMAT, eError.Message), EVALUATE_FILE_CAPTION,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}*/

		private void CheckToEnableMoveButton()
		{
			moveFilesButton.Enabled = !string.IsNullOrWhiteSpace(moveLocationTextBox.Text)
											  && !string.IsNullOrWhiteSpace(moveFilesTextBox.Text);
		}

		/*private void LinkClicked_FileNotFoundLinkLabel(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var fileNotFound = new FileNotFoundForm(state);
			DialogResult result = fileNotFound.ShowDialog();

			if (result == DialogResult.OK)
			{
				FileProcessing.DeleteRecords(state);
			}
		}*/

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

		private void OnLeave_FoundationDropDown(object sender, EventArgs e)
		{
			try
			{
				DataRow selectedRow = null;

				var boundData = (DataTable)foundationIdComboBox.DataSource;
				string searchExpression = string.Format("FoundationDisplayText like '%{0}%' ", foundationIdComboBox.Text);

				DataRow[] rows = boundData.Select(searchExpression);

				if (rows.Any())
				{
					selectedRow = rows[0];
				}

				ChangeFoundationSelection(selectedRow);
			}
			catch (Exception eError)
			{
				MessageBox.Show(this, string.Format(FILE_MOVE_ERROR_FORMAT, eError.Message), FILE_MOVE_CAPTION, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void SelectedValueChanged_FoundationDropDown(object sender, EventArgs e)
		{
			try
			{
				ChangeFoundationSelection(((DataRowView)foundationIdComboBox.SelectedItem).Row);

				stateDataTextBox.Clear();
				moveFilesTextBox.Clear();
				if (state.FilesNotFound != null && state.SequesterFiles != null)
				{
					state.FilesNotFound.Clear();
					state.SequesterFiles.Clear();
				}
			}
			catch (Exception eError)
			{
				MessageBox.Show(this, string.Format(FILE_MOVE_ERROR_FORMAT, eError.Message), FILE_MOVE_CAPTION, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void TextChanged_MoveLocationTextBox(object sender, EventArgs e)
		{
			state.OutputDirectory = moveLocationTextBox.Text;
			CheckToEnableMoveButton();
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

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}

		#endregion

	}
}