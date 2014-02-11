using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using API.Data;
using API.FileIO;

namespace UI.Controls.FunctionBlockControls
{
	public partial class RemoveOrphanDocumentsControl : FunctionBlockBaseControl
    {
        #region member variables

        private const string FILE_COPY_CAPTION = "File Copy";
        private const string FILE_COPY_ERROR_FORMAT = "File copy procedure gave the following error {0}.";
        private const string VALIDATION_ERROR_FOLDER_NOT_FOUND_FORMAT = "{0}   WARNING!: Cannot find or access specified folder.";

        private FileProcessingState state;
        private ApplicantProcessQuery data;

        #endregion


        #region properties

        public override string TitleBlockText { get { return "Search and Remove Orphaned Documents"; } }

        #endregion

        #region Constructor

        public RemoveOrphanDocumentsControl(GLMFileUtilityTool parent) : base(parent)
		{
			InitializeComponent();
            Initialize();
		}

        #endregion

        #region private methods

        private void Initialize()
	    {
	        state = new FileProcessingState
	        {
	            BaseDirectory = ParentControl.SourceLocation
	        };

            moveFilesButton.Enabled = !string.IsNullOrWhiteSpace(moveLocationText.Text);
	        undoButton.Enabled = false;

            data = new ApplicantProcessQuery();
            try
            {
                BindFoundationData(foundationIdComboBox, data.BuildFoundationDictionary());
            }
            catch (Exception eError)
            {
                MessageBox.Show(this, string.Format(FILE_COPY_ERROR_FORMAT, eError.Message), FILE_COPY_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
	    }

        

        private static void BindFoundationData(ComboBox comboBox, IReadOnlyCollection<KeyValuePair<string, List<string>>> source)
        {
            if (source.Count > 0)
            {
                comboBox.DataSource = new BindingSource(source, null);
                comboBox.DisplayMember = "Key";
            }
            else
            {
                comboBox.DataSource = null;
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog
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

        private void moveFilesButton_Click(object sender, EventArgs e)
        {
            undoButton.Enabled = true;
        }

        private void moveLocationText_TextChanged(object sender, EventArgs e)
        {
            state.OutputDirectory = moveLocationText.Text;
            moveFilesButton.Enabled = !string.IsNullOrWhiteSpace(moveLocationText.Text);
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
                state.FoundationId = selectedFoundationId;
                SetProcessingFolderText();
            }
        }

        private void SetProcessingFolderText()
        {
            DirectoryInfo rootDirectory = new DirectoryInfo(state.RootProcessDirectory);
            rootProcessingFolder.Text = rootDirectory.Exists
                ? state.RootProcessDirectory
                : String.Format(VALIDATION_ERROR_FOLDER_NOT_FOUND_FORMAT, state.RootProcessDirectory);
        }

        #endregion

        #region protect methods

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
