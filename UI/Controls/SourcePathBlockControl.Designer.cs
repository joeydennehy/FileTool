﻿namespace UI.Controls
{
	partial class SourcePathBlockControl
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
            this.sourceLabel = new System.Windows.Forms.Label();
            this.sourceLocationText = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(19, 17);
            this.sourceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(115, 17);
            this.sourceLabel.TabIndex = 0;
            this.sourceLabel.Text = "Source Location:";
            this.sourceLabel.Click += new System.EventHandler(this.sourceLabel_Click);
            // 
            // sourceLocationText
            // 
            this.sourceLocationText.Location = new System.Drawing.Point(23, 37);
            this.sourceLocationText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sourceLocationText.Name = "sourceLocationText";
            this.sourceLocationText.Size = new System.Drawing.Size(772, 22);
            this.sourceLocationText.TabIndex = 1;
            this.sourceLocationText.TextChanged += new System.EventHandler(this.TextChanged_SourceFolder);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(805, 36);
            this.browseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(36, 28);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.ButtonClick_BrowseFolders);
            // 
            // SourcePathBlockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.sourceLocationText);
            this.Controls.Add(this.sourceLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SourcePathBlockControl";
            this.Size = new System.Drawing.Size(860, 86);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label sourceLabel;
		public System.Windows.Forms.TextBox sourceLocationText;
		private System.Windows.Forms.Button browseButton;
	}
}
