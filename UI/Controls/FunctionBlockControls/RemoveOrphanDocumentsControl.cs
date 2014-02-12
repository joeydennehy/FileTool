using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.FileIO;

namespace UI.Controls.FunctionBlockControls
{
	public partial class RemoveOrphanDocumentsControl : FunctionBlockBaseControl
	{
        private const string VALIDATION_ERROR_FOLDER_NOT_FOUND_FORMAT = "{0}   WARNING!: Cannot find or access specified folder.";

        private FoundationDataFileState state;

		public RemoveOrphanDocumentsControl(GLMFileUtilityTool parent) : base(parent)
		{
			InitializeComponent();
		}

		public override void Initialize()
		{
			base.Initialize();

			state = new FoundationDataFileState
			{
				BaseDirectory = ParentControl.SourceLocation
			};

			moveFilesButton.Enabled = !string.IsNullOrWhiteSpace(moveLocationText.Text);
			undoButton.Enabled = false;
		}

	    public override string TitleBlockText { get { return "Search and Remove Orphaned Documents"; } }

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}

        private void sourceLabel_Click(object sender, EventArgs e)
        {

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

        private void SelectedValueChanged_FoundationDropDown(object sender, EventArgs e)
        {
            string selectedFoundationId = ((KeyValuePair<string, List<string>>)((ComboBox)sender).SelectedItem).Value.ToList()[0];
            string selectedUrlKey = ((KeyValuePair<string, List<string>>)((ComboBox)sender).SelectedItem).Value.ToList()[1];

            if (string.Compare(state.FoundationUrlKey, selectedUrlKey, StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                state.FoundationUrlKey = selectedUrlKey;
                //state.FoundationId = selectedFoundationId;
                SetProcessingFolderText();
                
            }
        }

        private void SetProcessingFolderText()
        {
            DirectoryInfo rootDirectory = new DirectoryInfo(state.ClientRootDirectory);
            rootProcessingFolder.Text = rootDirectory.Exists
					 ? state.ClientRootDirectory
					 : String.Format(VALIDATION_ERROR_FOLDER_NOT_FOUND_FORMAT, state.ClientRootDirectory)
            ;
        }

        private void moveLocationText_TextChanged(object sender, EventArgs e)
        {
            moveFilesButton.Enabled = !string.IsNullOrWhiteSpace(moveLocationText.Text);
        }

	    private void moveFilesButton_Click(object sender, EventArgs e)
	    {
	        undoButton.Enabled = true;
	    }
	}
}
