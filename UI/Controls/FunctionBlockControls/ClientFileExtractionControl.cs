using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API;

namespace UI.Controls.FunctionBlockControls
{
	public partial class ClientFileExtractionControl : FunctionBlockBaseControl
	{

		public ClientFileExtractionControl(GLMFileUtilityTool parent) : base(parent)
		{
			InitializeComponent();
			Initialize();
		}

		private void Initialize()
		{
			ApplicantProcessQuery data = new ApplicantProcessQuery();
			foundationIdComboBox.DataSource = new BindingSource(data.RetrieveFoundationInformation(), null);
			foundationIdComboBox.DisplayMember = "Key";
			foundationIdComboBox.ValueMember = "Value";
		}

		public override string TitleBlockText { get { return "Extract Client Files"; } }

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}

		private void FoundationDropDown_SelectedValueChanged(object sender, EventArgs e)
		{
			ApplicantProcessQuery data = new ApplicantProcessQuery();
			var urlKey = ((KeyValuePair<string, string>)((ComboBox)sender).SelectedItem).Value;
			processIdComboBox.DataSource = new BindingSource(data.RetrieveFoundationProcessInfo(urlKey), null);
			processIdComboBox.DisplayMember = "Key";
			processIdComboBox.ValueMember = "Value";
		}

		private void CopyFilesButtonClick(object sender, EventArgs e)
		{
			//Initiate API Call here
		}
	}
}
