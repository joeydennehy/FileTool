namespace UI.Controls
{
	partial class TitleBlockControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.titleTextLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// titleTextLabel
			// 
			this.titleTextLabel.AutoSize = true;
			this.titleTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titleTextLabel.Location = new System.Drawing.Point(14, 14);
			this.titleTextLabel.Name = "titleTextLabel";
			this.titleTextLabel.Size = new System.Drawing.Size(155, 16);
			this.titleTextLabel.TabIndex = 0;
			this.titleTextLabel.Text = "[SET IN MAIN FORM]";
			// 
			// TitleBlockControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.titleTextLabel);
			this.Name = "TitleBlockControl";
			this.Size = new System.Drawing.Size(645, 45);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label titleTextLabel;
	}
}
