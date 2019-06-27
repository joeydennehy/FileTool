namespace UI.Controls
{
	partial class FileExtractionBlockControl
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
			this.fileTypeComboBox = new System.Windows.Forms.ComboBox();
			this.processIdComboBox = new System.Windows.Forms.ComboBox();
			this.processIdComboBoxLabel = new System.Windows.Forms.Label();
			this.fileTypesLabel = new System.Windows.Forms.Label();
			this.fileCountLinkLabel = new System.Windows.Forms.LinkLabel();
			this.copyFilesButton = new System.Windows.Forms.Button();
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
			// fileTypeComboBox
			// 
			this.fileTypeComboBox.FormattingEnabled = true;
			this.fileTypeComboBox.Location = new System.Drawing.Point(500, 101);
			this.fileTypeComboBox.Margin = new System.Windows.Forms.Padding(4);
			this.fileTypeComboBox.Name = "fileTypeComboBox";
			this.fileTypeComboBox.Size = new System.Drawing.Size(295, 24);
			this.fileTypeComboBox.TabIndex = 7;
			this.fileTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.fileTypeComboBox_SelectedIndexChanged);
			// 
			// processIdComboBox
			// 
			this.processIdComboBox.FormattingEnabled = true;
			this.processIdComboBox.Location = new System.Drawing.Point(23, 101);
			this.processIdComboBox.Margin = new System.Windows.Forms.Padding(4);
			this.processIdComboBox.Name = "processIdComboBox";
			this.processIdComboBox.Size = new System.Drawing.Size(439, 24);
			this.processIdComboBox.TabIndex = 8;
			this.processIdComboBox.SelectedIndexChanged += new System.EventHandler(this.processIdComboBox_SelectedIndexChanged);
			// 
			// processIdComboBoxLabel
			// 
			this.processIdComboBoxLabel.AutoSize = true;
			this.processIdComboBoxLabel.Location = new System.Drawing.Point(20, 80);
			this.processIdComboBoxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.processIdComboBoxLabel.Name = "processIdComboBoxLabel";
			this.processIdComboBoxLabel.Size = new System.Drawing.Size(155, 17);
			this.processIdComboBoxLabel.TabIndex = 9;
			this.processIdComboBoxLabel.Text = "Foundation Process ID:";
			// 
			// fileTypesLabel
			// 
			this.fileTypesLabel.AutoSize = true;
			this.fileTypesLabel.Location = new System.Drawing.Point(497, 80);
			this.fileTypesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.fileTypesLabel.Name = "fileTypesLabel";
			this.fileTypesLabel.Size = new System.Drawing.Size(77, 17);
			this.fileTypesLabel.TabIndex = 10;
			this.fileTypesLabel.Text = "File Types:";
			// 
			// fileCountLinkLabel
			// 
			this.fileCountLinkLabel.AutoSize = true;
			this.fileCountLinkLabel.Location = new System.Drawing.Point(20, 129);
			this.fileCountLinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.fileCountLinkLabel.Name = "fileCountLinkLabel";
			this.fileCountLinkLabel.Size = new System.Drawing.Size(126, 17);
			this.fileCountLinkLabel.TabIndex = 11;
			this.fileCountLinkLabel.TabStop = true;
			this.fileCountLinkLabel.Text = "[No Files Selected]";
			this.fileCountLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.fileCountLinkLabel_LinkClicked);
			// 
			// copyFilesButton
			// 
			this.copyFilesButton.Location = new System.Drawing.Point(23, 168);
			this.copyFilesButton.Margin = new System.Windows.Forms.Padding(4);
			this.copyFilesButton.Name = "copyFilesButton";
			this.copyFilesButton.Size = new System.Drawing.Size(100, 28);
			this.copyFilesButton.TabIndex = 15;
			this.copyFilesButton.Text = "Copy Files";
			this.copyFilesButton.UseVisualStyleBackColor = true;
			this.copyFilesButton.Click += new System.EventHandler(this.copyFilesButton_Click);
			// 
			// FileExtractionBlockControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.copyFilesButton);
			this.Controls.Add(this.fileCountLinkLabel);
			this.Controls.Add(this.fileTypesLabel);
			this.Controls.Add(this.processIdComboBoxLabel);
			this.Controls.Add(this.processIdComboBox);
			this.Controls.Add(this.fileTypeComboBox);
			this.Controls.Add(this.browseButton);
			this.Controls.Add(this.sourceLocationText);
			this.Controls.Add(this.sourceLabel);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "FileExtractionBlockControl";
			this.Size = new System.Drawing.Size(860, 218);
			this.Load += new System.EventHandler(this.SourcePathBlockControl_Load);
			this.Leave += new System.EventHandler(this.OnLeave_SourcePathBlockControl);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label sourceLabel;
		public System.Windows.Forms.TextBox sourceLocationText;
		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.ComboBox fileTypeComboBox;
		private System.Windows.Forms.ComboBox processIdComboBox;
		private System.Windows.Forms.Label processIdComboBoxLabel;
		private System.Windows.Forms.Label fileTypesLabel;
		private System.Windows.Forms.LinkLabel fileCountLinkLabel;
		private System.Windows.Forms.Button copyFilesButton;
	}
}
