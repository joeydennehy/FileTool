using System.Drawing;
using System.Windows.Forms;

namespace UI.Controls
{
	public class CustomButton : Button
	{
		public CustomButton()
		{
			FlatAppearance.BorderSize = 0;
			FlatStyle = FlatStyle.Flat;
		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			base.OnPaint(pevent);

			Pen pen = new Pen(FlatAppearance.BorderColor, 1);
			Rectangle rectangle = new Rectangle(0,0, Size.Width -1, Size.Height -1);
			pevent.Graphics.DrawRectangle(pen, rectangle);
		}

		protected override bool ShowFocusCues
		{
			get { return false; }
		}
	}
}
