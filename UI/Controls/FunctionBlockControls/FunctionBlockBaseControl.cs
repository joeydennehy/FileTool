using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Controls.FunctionBlockControls
{
	public partial class FunctionBlockBaseControl : UserControl
	{
		public virtual bool EnableSourceBlock { get; private set; }
		public virtual string TitleBlockText { get; private set; }

		protected FunctionBlockBaseControl()
		{
			InitializeComponent();

			EnableSourceBlock = true;
			TitleBlockText = string.Empty;
		}
	}
}
