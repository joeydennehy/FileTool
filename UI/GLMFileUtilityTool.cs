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

		private FileExtractionBlockControl fileExtractionBlockControl;
		private GhostInspectorBlockControl ghostInspectorBlockControl;
		private TitleBlockControl titleBlockControl;
		
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
			fileExtractionBlockControl = new FileExtractionBlockControl(this);
			ghostInspectorBlockControl = new GhostInspectorBlockControl(this);

			titleBlockControl = new TitleBlockControl();

			titleBlockPanel.SuspendLayout();
			titleBlockPanel.Controls.Add(titleBlockControl);
			titleBlockPanel.ResumeLayout();

			sourceBlockPanel.SuspendLayout();
			sourceBlockPanel.Controls.Add(fileExtractionBlockControl);
			sourceBlockPanel.ResumeLayout();

			//Set up the functional block controls
			panelControls = new Dictionary<string, FunctionBlockBaseControl>();
			panelControls.Add(fileExtractionBlockControl.Name, fileExtractionBlockControl);
			panelControls.Add(ghostInspectorBlockControl.Name, ghostInspectorBlockControl);

			//Add client ID to the associated task button on the UI (used by NavigationButtonClick Event to switch controls)
			btnNavFileExtraction.Tag = fileExtractionBlockControl.Name;
			btnNavGhostInspector.Tag = ghostInspectorBlockControl.Name;

			//Set the initial Display task
			SetCurrentNavButton(btnNavFileExtraction);
			SetDisplayTask(fileExtractionBlockControl.Name);
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
			sourceBlockPanel.SuspendLayout();

			if (string.IsNullOrEmpty(controlId) || panelControls[controlId] == null)
				return;

			if (panelControls.ContainsKey(controlId))
			{
				if (!string.IsNullOrEmpty(currentControlId) && panelControls.ContainsKey(currentControlId))
				{
					sourceBlockPanel.Controls.RemoveByKey(currentControlId);
				}

				titleBlockControl.TitleText = panelControls[controlId].TitleBlockText;
				sourceBlockPanel.Controls.Add(panelControls[controlId]);
				panelControls[controlId].Initialize();
				currentControlId = controlId;
			}

			sourceBlockPanel.ResumeLayout();
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

		private void sourceBlockPanel_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
