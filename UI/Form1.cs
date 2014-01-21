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

namespace UI
{
	public partial class Form1 : Form
	{
		#region Member Variables

		private Dictionary<string, UserControl> panelControls;

		#endregion

		public Form1()
		{
			InitializeComponent();

			Initialize();

		}

		private void Initialize()
		{
			panelControls = new Dictionary<string, UserControl>();
			
			var clientFileExtractionControl = new ClientFileExtractionControl();

			panelControls.Add(clientFileExtractionControl.Name, clientFileExtractionControl);

			this.splitContainer1.Panel2.SuspendLayout();

			this.splitContainer1.Panel2.Controls.Add(panelControls.Values.First());

			this.splitContainer1.Panel2.ResumeLayout();
		}
	}
}
