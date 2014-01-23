﻿using System;
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
	public partial class RenameDirectoryControl : FunctionBlockBaseControl
	{
		public RenameDirectoryControl(GLMFileUtilityTool parent) : base(parent)
		{
			InitializeComponent();
		}

		public override string TitleBlockText { get { return "Rename File Directories"; } }

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
	}
}