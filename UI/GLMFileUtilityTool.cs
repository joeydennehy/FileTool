using System;
using System.Collections.Generic;
using System.Drawing;
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

		public SourcePathBlockControl sourcePathBlockControl;
		private TitleBlockControl titleBlockControl;

		private ClientFileExtractionControl clientFileExtractionControl;
		private RemoveOrphanDocumentsControl removeOrphanDocumentsControl;
		
		#endregion

		#endregion

		public string SourceLocation { get; set; }

		public GLMFileUtilityTool()
		{
			//TODO - NTH: Center in screen, need to hand code that.
			InitializeComponent();
			ShowInTaskbar = true;
			Initialize();
		}

		private void Initialize()
		{
			//Set up Top Panel Block controls
			sourcePathBlockControl = new SourcePathBlockControl(this);
			titleBlockControl = new TitleBlockControl();

			titleBlockPanel.SuspendLayout();
			titleBlockPanel.Controls.Add(titleBlockControl);
			titleBlockPanel.ResumeLayout();

			sourceBlockPanel.SuspendLayout();
			sourceBlockPanel.Controls.Add(sourcePathBlockControl);
			sourceBlockPanel.ResumeLayout();

			//Set up the functional block controls
			panelControls = new Dictionary<string, FunctionBlockBaseControl>();
			clientFileExtractionControl = new ClientFileExtractionControl(this);
			removeOrphanDocumentsControl = new RemoveOrphanDocumentsControl(this);

			panelControls.Add(clientFileExtractionControl.Name, clientFileExtractionControl);
			panelControls.Add(removeOrphanDocumentsControl.Name, removeOrphanDocumentsControl);

			//Add client ID to the associated task button on the UI (used by NavigationButtonClick Event to switch controls)
			btnNavFileExtraction.Tag = clientFileExtractionControl.Name;
			//btnNavRemoveDocs.Tag = removeOrphanDocumentsControl.Name;

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

			if (string.IsNullOrEmpty(controlId) || panelControls[controlId] == null)
				return;

			if (panelControls.ContainsKey(controlId))
			{
				if (!string.IsNullOrEmpty(currentControlId) && panelControls.ContainsKey(currentControlId))
				{
					functionBlockPanel.Controls.RemoveByKey(currentControlId);
				}

				titleBlockControl.TitleText = panelControls[controlId].TitleBlockText;
				functionBlockPanel.Controls.Add(panelControls[controlId]);
				panelControls[controlId].Initialize();
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

		//This is preventing sourceDirectory from being set properly at startup
		//protected override void OnShown(EventArgs e)
		//{
		//	sourcePathBlockControl.Setup();
		//	base.OnShown(e);

		//}
	}
}
