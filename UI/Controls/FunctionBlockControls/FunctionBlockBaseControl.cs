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

		public virtual void Initialize() { }

		protected GLMFileUtilityTool ParentControl;

		protected FunctionBlockBaseControl()
		{
			InitializeComponent();
		}

		protected FunctionBlockBaseControl(GLMFileUtilityTool parent) : this()
		{
			ParentControl = parent;
			EnableSourceBlock = true;
			TitleBlockText = string.Empty;
		}

		private void FunctionBlockBaseControl_Load(object sender, EventArgs e)
		{

		}
	}
}
