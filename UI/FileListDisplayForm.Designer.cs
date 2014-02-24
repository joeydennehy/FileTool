namespace UI
{
	partial class FileListDisplayForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.fileListRichText = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// fileListRichText
			// 
			this.fileListRichText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fileListRichText.Location = new System.Drawing.Point(0, 0);
			this.fileListRichText.Name = "fileListRichText";
			this.fileListRichText.ReadOnly = true;
			this.fileListRichText.Size = new System.Drawing.Size(843, 483);
			this.fileListRichText.TabIndex = 0;
			this.fileListRichText.Text = "";
			this.fileListRichText.WordWrap = false;
			// 
			// FileListDisplayForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(843, 483);
			this.Controls.Add(this.fileListRichText);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FileListDisplayForm";
			this.Text = "File List";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox fileListRichText;
	}
}