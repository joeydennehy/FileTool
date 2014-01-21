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
	public partial class SourcePathBlockControl : UserControl
	{
		public SourcePathBlockControl()
		{
			InitializeComponent();
		}

		//Tasks for this control:
		//Call API to get the default location
		//Enable Folder Browse and validate the location is navigable by the app\
		//Make folder location publicly accessible.
	}
}
