using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Data;
using API.FileIO;
using API.Logging;

namespace UI.Controls.FunctionBlockControls
{
	public partial class RenameDirectoryControl : FunctionBlockBaseControl
	{
		#region Member Variables

		private const string RENAME_FOLDER_CAPTION = "Rename Folders";
		private const string RENAME_FOLDER_ERROR_FORMAT = "Rename folder procedure gave the following error {0}.";

		private FoundationDataFileState state;

		#endregion

		#region Constructor

		public RenameDirectoryControl(GLMFileUtilityTool parent) : base(parent) { InitializeComponent(); }

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			state = new FoundationDataFileState
			{
				BaseDirectory = ParentControl.SourceLocation
			};

			try
			{
				RequestQuery.RefreshFoundationData();
				foundationIdComboBox.DataSource = RequestQuery.FoundationData;
				foundationIdComboBox.DisplayMember = "FoundationDisplayText";
				foundationIdComboBox.ValueMember = "FoundationId";
			}
			catch (Exception eError)
			{
				MessageBox.Show(this, string.Format(RENAME_FOLDER_ERROR_FORMAT, eError.Message), RENAME_FOLDER_CAPTION, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}


		public override string TitleBlockText { get { return "Rename File Directories"; } }

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}

		private void foundationIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				ChangeFoundationSelection(((DataRowView)foundationIdComboBox.SelectedItem).Row);

				RequestQuery.SELECT_MISMATCHED_REQUEST_ID_AND_CODE(state.FoundationId);
				StringBuilder sb = new StringBuilder();
				AppendMissMatchData(sb);
			}
			catch (Exception eError)
			{
				MessageBox.Show(this, string.Format(RENAME_FOLDER_ERROR_FORMAT, eError.Message), RENAME_FOLDER_CAPTION, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
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
				MessageBox.Show(this, string.Format(RENAME_FOLDER_ERROR_FORMAT, eError.Message), RENAME_FOLDER_CAPTION, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
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
			}
		}

		private void ButtonClick_RenameRecordsAndFilesButton(object sender, EventArgs e)
		{
			foreach (DataRow row in RequestQuery.RequestData.Rows)
			{
				string requestCode = row.ItemArray[1].ToString();
				int requestId = (int)row.ItemArray[0];

				try
				{

					FileProcessing.UpdateMisMatchedDirectories(state, requestCode, requestId);
					//sRequestQuery.UPDATE_MISSMATCHED_REQUEST_ID_AND_CODE(requestId);
				}
				catch (Exception eError)
				{
					Logger.Log(string.Format("Error in Renameing mismatched request code ({0}): {1}", requestCode, eError.Message), LogLevel.Error);
				}
			}

			RequestQuery.SELECT_MISMATCHED_REQUEST_ID_AND_CODE(state.FoundationId);

			if (RequestQuery.RequestData.Rows.Count == 0)
			{
				MissMatchRequestCodeTextBox.Text = "All Records Processed Successfully.";
			}
			else
			{
				StringBuilder sb = new StringBuilder();
				sb.AppendLine(string.Format("{0} were not processed:", RequestQuery.RequestData.Rows.Count));
				AppendMissMatchData(sb);
			}
			
		}

		private void AppendMissMatchData(StringBuilder sb)
		{
			foreach (DataRow row in RequestQuery.RequestData.Rows)
			{
				sb.AppendLine(row.ItemArray[2].ToString());
			}
			MissMatchRequestCodeTextBox.Text = sb.ToString();
		}

		protected override void OnEnter(EventArgs e)
		{
			state.BaseDirectory = ParentControl.SourceLocation;

			base.OnEnter(e);
		}
	}
}
