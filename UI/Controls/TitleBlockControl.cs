using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Controls
{
	public partial class TitleBlockControl : UserControl
	{
		public TitleBlockControl()
		{
			InitializeComponent();
		}

		public string TitleText { set { titleTextLabel.Text = value; } }

	}
}
