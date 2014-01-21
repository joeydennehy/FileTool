using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using UI.Controls;
using UI.Controls;
using UI.Controls.FunctionBlockControls;

namespace UI
{
	public partial class Form1 : Form
	{
		#region Member Variables

		private Dictionary<string, UserControl> panelControls;

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

		public Form1()
		{
			InitializeComponent();

			Initialize();

		}

		private void Initialize()
		{
			titleBlockControl = new TitleBlockControl();
			sourcePathBlockControl = new SourcePathBlockControl();
			
			titleBlockPanel.SuspendLayout();
			titleBlockPanel.Controls.Add(titleBlockControl);
			titleBlockPanel.ResumeLayout();

			sourceBlockPanel.SuspendLayout();
			sourceBlockPanel.Controls.Add(sourcePathBlockControl);
			sourceBlockPanel.ResumeLayout();

			panelControls = new Dictionary<string, UserControl>();

			clientFileExtractionControl = new ClientFileExtractionControl();
			removeOrphanDocumentRecordsControl = new RemoveOrphanDocumentRecordsControl();
			removeOrphanDocumentsControl = new RemoveOrphanDocumentsControl();
			renameDirectoryControl = new RenameDirectoryControl();
			renameFilesControl = new RenameFilesControl();

			panelControls.Add(clientFileExtractionControl.Name, clientFileExtractionControl);
			//panelControls.Add(removeOrphanDocumentRecordsControl.Name, removeOrphanDocumentRecordsControl);
			//panelControls.Add(removeOrphanDocumentsControl.Name, removeOrphanDocumentsControl);
			//panelControls.Add(renameDirectoryControl.Name, renameDirectoryControl);
			//panelControls.Add(renameFilesControl.Name, renameFilesControl);

			functionBlockPanel.SuspendLayout();
			titleBlockControl.TitleText = clientFileExtractionControl.TitleBlockText;
			functionBlockPanel.Controls.Add(clientFileExtractionControl);
			functionBlockPanel.ResumeLayout();
			

			//panelControls.Add(clientFileExtractionControl.Name, clientFileExtractionControl);

			//this.splitContainer1.Panel2.SuspendLayout();
			//panelControlContainer
			//this.splitContainer1.Panel2.Controls.Add(panelControls.Values.First());

			//this.splitContainer1.Panel2.ResumeLayout();
		}

		private void btnNavFileExtraction_Click(object sender, EventArgs e)
		{
			//functionBlockPanel.SuspendLayout();

			//functionBlockPanel.Controls.RemoveByKey(clientFileExtractionControl.Name);

			//titleBlockControl.TitleText = removeOrphanDocumentRecordsControl.TitleBlockText;
			//functionBlockPanel.Controls.Add(removeOrphanDocumentRecordsControl);

			//functionBlockPanel.ResumeLayout();
		}
	}
}
