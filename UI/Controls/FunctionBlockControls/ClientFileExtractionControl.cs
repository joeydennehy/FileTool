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

		public ClientFileExtractionControl()
		{
			InitializeComponent();
			Initialize();
		}

		private void Initialize()
		{
			ApplicantProcessQuery data = new ApplicantProcessQuery();
			BindData(foundationIdComboBox, data.RetrieveFoundationInformation());
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
			BindData(processIdComboBox, data.RetrieveFoundationProcessInfo(urlKey));
		}

		private void BindData(ComboBox comboBox, Dictionary<string, string> source)
		{
			comboBox.DataSource = new BindingSource(source, null);
			comboBox.DisplayMember = "Key";
			comboBox.ValueMember = "Value";
		}
	}
}
