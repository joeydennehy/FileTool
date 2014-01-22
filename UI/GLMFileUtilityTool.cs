using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Controls;
using UI.Controls.FunctionBlockControls;

namespace UI
{
	public partial class GLMFileUtilityTool : Form
	{
		#region Member Variables

		private Dictionary<string, FunctionBlockBaseControl> panelControls;
		private string currentControlId = string.Empty;
		private Button currentNavButton;

		#region Client Controls

		private SourcePathBlockControl sourcePathBlockControl;
		private TitleBlockControl titleBlockControl;

		private ClientFileExtractionControl clientFileExtractionControl;
		private RemoveOrphanDocumentRecordsControl removeOrphanDocumentRecordsControl;
		private RemoveOrphanDocumentsControl removeOrphanDocumentsControl;
		private RenameDirectoryControl renameDirectoryControl;
		private RenameFilesControl renameFilesControl;
		
		#endregion

		#endregion

		public GLMFileUtilityTool()
		{
			InitializeComponent();

			Initialize();
		}

		private void Initialize()
		{
			//Set up Top Panel Block controls
			sourcePathBlockControl = new SourcePathBlockControl();
			titleBlockControl = new TitleBlockControl();

			titleBlockPanel.SuspendLayout();
			titleBlockPanel.Controls.Add(titleBlockControl);
			titleBlockPanel.ResumeLayout();

			sourceBlockPanel.SuspendLayout();
			sourceBlockPanel.Controls.Add(sourcePathBlockControl);
			sourceBlockPanel.ResumeLayout();

			//Set up the functional block controls
			panelControls = new Dictionary<string, FunctionBlockBaseControl>();
			clientFileExtractionControl = new ClientFileExtractionControl();
			removeOrphanDocumentRecordsControl = new RemoveOrphanDocumentRecordsControl();
			removeOrphanDocumentsControl = new RemoveOrphanDocumentsControl();
			renameDirectoryControl = new RenameDirectoryControl();
			renameFilesControl = new RenameFilesControl();

			panelControls.Add(clientFileExtractionControl.Name, clientFileExtractionControl);
			panelControls.Add(removeOrphanDocumentRecordsControl.Name, removeOrphanDocumentRecordsControl);
			panelControls.Add(removeOrphanDocumentsControl.Name, removeOrphanDocumentsControl);
			panelControls.Add(renameDirectoryControl.Name, renameDirectoryControl);
			panelControls.Add(renameFilesControl.Name, renameFilesControl);

			//Add client ID to the associated task button on the UI (used by NavigationButtonClick Event to switch controls)
			btnNavFileExtraction.Tag = clientFileExtractionControl.Name;
			btnNavRemoveDocRecords.Tag = removeOrphanDocumentRecordsControl.Name;
			btnNavRemoveDocs.Tag = removeOrphanDocumentsControl.Name;
			btnNavRenameDirectory.Tag = renameDirectoryControl.Name;
			btnNavRenameFiles.Tag = renameFilesControl.Name;

			//Set the initial Display task
			SetDisplayTask(clientFileExtractionControl.Name);
			SetCurrentNavButton(btnNavFileExtraction);
		}

		private void SetCurrentNavButton(Button navButton)
		{
			if (currentNavButton != null)
			{
				currentNavButton.BackColor = SystemColors.Control;
				currentNavButton.ForeColor = SystemColors.ControlText;
			}

			navButton.BackColor = SystemColors.ActiveCaption;
			navButton.ForeColor = SystemColors.ActiveCaptionText;

			currentNavButton = navButton;
		}

		private void SetDisplayTask(string controlId)
		{
			functionBlockPanel.SuspendLayout();

			if (string.IsNullOrEmpty(controlId))
				return;
			if (panelControls.ContainsKey(controlId))
			{
				if (!string.IsNullOrEmpty(currentControlId) && panelControls.ContainsKey(currentControlId))
				{
					functionBlockPanel.Controls.RemoveByKey(currentControlId);
				}

				titleBlockControl.TitleText = panelControls[controlId].TitleBlockText;
				functionBlockPanel.Controls.Add(panelControls[controlId]);
				currentControlId = controlId;
			}

			functionBlockPanel.ResumeLayout();
		}

		private void NavigationButtonClick(object sender, EventArgs e)
		{
			Button btnSender = (Button)sender;
			string controlId = (string)btnSender.Tag;
			
			if (string.Compare(controlId, currentControlId, StringComparison.OrdinalIgnoreCase) == 0)
				return;

			SetDisplayTask(controlId);
			SetCurrentNavButton(btnSender);
		}

	}
}
