using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Controls.FunctionBlockControls
{
	public partial class RemoveOrphanDocumentsControl : FunctionBlockBaseControl
	{
		public RemoveOrphanDocumentsControl(GLMFileUtilityTool parent) : base(parent)
		{
			InitializeComponent();
		}

		public override string TitleBlockText { get { return "Search and Remove Orphaned Documents"; } }

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
	}
}
