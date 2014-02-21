﻿namespace UI.Controls.FunctionBlockControls
{
	partial class ClientFileExtractionControl
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
			this.foundationIdComboBoxLabel = new System.Windows.Forms.Label();
			this.foundationIdComboBox = new System.Windows.Forms.ComboBox();
			this.processIdComboBoxLabel = new System.Windows.Forms.Label();
			this.processIdComboBox = new System.Windows.Forms.ComboBox();
			this.outputDestinationTextBoxLabel = new System.Windows.Forms.Label();
			this.outputDestinationTextBox = new System.Windows.Forms.TextBox();
			this.outputDestinationBrowseButton = new System.Windows.Forms.Button();
			this.copyFilesButton = new System.Windows.Forms.Button();
			this.fileCountLinkLabel = new System.Windows.Forms.LinkLabel();
			this.ApplicantProcessIdsLabel = new System.Windows.Forms.Label();
			this.rootProcessingFolder = new System.Windows.Forms.Label();
			this.fileTypeComboBox = new System.Windows.Forms.ComboBox();
			this.fileTypesLabel = new System.Windows.Forms.Label();
			this.fileExclusionLinkLabel = new System.Windows.Forms.LinkLabel();
			this.secludedFileCountlinkLabel = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// foundationIdComboBoxLabel
			// 
			this.foundationIdComboBoxLabel.AutoSize = true;
			this.foundationIdComboBoxLabel.Location = new System.Drawing.Point(14, 14);
			this.foundationIdComboBoxLabel.Name = "foundationIdComboBoxLabel";
			this.foundationIdComboBoxLabel.Size = new System.Drawing.Size(77, 13);
			this.foundationIdComboBoxLabel.TabIndex = 0;
			this.foundationIdComboBoxLabel.Text = "Foundation ID:";
			// 
			// foundationIdComboBox
			// 
			this.foundationIdComboBox.FormattingEnabled = true;
			this.foundationIdComboBox.Location = new System.Drawing.Point(17, 30);
			this.foundationIdComboBox.Name = "foundationIdComboBox";
			this.foundationIdComboBox.Size = new System.Drawing.Size(616, 21);
			this.foundationIdComboBox.TabIndex = 1;
			this.foundationIdComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedValueChanged_FoundationDropDown);
			this.foundationIdComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown_comboBox);
			this.foundationIdComboBox.Leave += new System.EventHandler(this.OnLeave_FoundationDropDown);
			this.foundationIdComboBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_comboBox);
			// 
			// processIdComboBoxLabel
			// 
			this.processIdComboBoxLabel.AutoSize = true;
			this.processIdComboBoxLabel.Location = new System.Drawing.Point(14, 85);
			this.processIdComboBoxLabel.Name = "processIdComboBoxLabel";
			this.processIdComboBoxLabel.Size = new System.Drawing.Size(118, 13);
			this.processIdComboBoxLabel.TabIndex = 3;
			this.processIdComboBoxLabel.Text = "Foundation Process ID:";
			// 
			// processIdComboBox
			// 
			this.processIdComboBox.FormattingEnabled = true;
			this.processIdComboBox.Location = new System.Drawing.Point(17, 101);
			this.processIdComboBox.Name = "processIdComboBox";
			this.processIdComboBox.Size = new System.Drawing.Size(388, 21);
			this.processIdComboBox.TabIndex = 4;
			this.processIdComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged_ProcessIdComboBox);
			this.processIdComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown_comboBox);
			this.processIdComboBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_comboBox);
			// 
			// outputDestinationTextBoxLabel
			// 
			this.outputDestinationTextBoxLabel.AutoSize = true;
			this.outputDestinationTextBoxLabel.Location = new System.Drawing.Point(14, 147);
			this.outputDestinationTextBoxLabel.Name = "outputDestinationTextBoxLabel";
			this.outputDestinationTextBoxLabel.Size = new System.Drawing.Size(98, 13);
			this.outputDestinationTextBoxLabel.TabIndex = 11;
			this.outputDestinationTextBoxLabel.Text = "Output Destination:";
			// 
			// outputDestinationTextBox
			// 
			this.outputDestinationTextBox.Location = new System.Drawing.Point(17, 163);
			this.outputDestinationTextBox.Name = "outputDestinationTextBox";
			this.outputDestinationTextBox.Size = new System.Drawing.Size(580, 20);
			this.outputDestinationTextBox.TabIndex = 12;
			this.outputDestinationTextBox.TextChanged += new System.EventHandler(this.TextChanged_outputDestinationTextBox);
			// 
			// outputDestinationBrowseButton
			// 
			this.outputDestinationBrowseButton.Location = new System.Drawing.Point(604, 162);
			this.outputDestinationBrowseButton.Name = "outputDestinationBrowseButton";
			this.outputDestinationBrowseButton.Size = new System.Drawing.Size(29, 23);
			this.outputDestinationBrowseButton.TabIndex = 13;
			this.outputDestinationBrowseButton.Text = "...";
			this.outputDestinationBrowseButton.UseVisualStyleBackColor = true;
			this.outputDestinationBrowseButton.Click += new System.EventHandler(this.ButtonClick_OutputDestinationBrowse);
			// 
			// copyFilesButton
			// 
			this.copyFilesButton.Location = new System.Drawing.Point(17, 190);
			this.copyFilesButton.Name = "copyFilesButton";
			this.copyFilesButton.Size = new System.Drawing.Size(75, 23);
			this.copyFilesButton.TabIndex = 14;
			this.copyFilesButton.Text = "Copy Files";
			this.copyFilesButton.UseVisualStyleBackColor = true;
			this.copyFilesButton.Click += new System.EventHandler(this.ButtonClick_CopyFiles);
			// 
			// fileCountLinkLabel
			// 
			this.fileCountLinkLabel.AutoSize = true;
			this.fileCountLinkLabel.Location = new System.Drawing.Point(209, 125);
			this.fileCountLinkLabel.Name = "fileCountLinkLabel";
			this.fileCountLinkLabel.Size = new System.Drawing.Size(96, 13);
			this.fileCountLinkLabel.TabIndex = 8;
			this.fileCountLinkLabel.TabStop = true;
			this.fileCountLinkLabel.Text = "[No Files Selected]";
			this.fileCountLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClick_FileCountLinkLabel);
			// 
			// ApplicantProcessIdsLabel
			// 
			this.ApplicantProcessIdsLabel.AutoSize = true;
			this.ApplicantProcessIdsLabel.Location = new System.Drawing.Point(14, 125);
			this.ApplicantProcessIdsLabel.Name = "ApplicantProcessIdsLabel";
			this.ApplicantProcessIdsLabel.Size = new System.Drawing.Size(141, 13);
			this.ApplicantProcessIdsLabel.TabIndex = 7;
			this.ApplicantProcessIdsLabel.Text = "Total Applicant Process IDs:";
			// 
			// rootProcessingFolder
			// 
			this.rootProcessingFolder.AutoSize = true;
			this.rootProcessingFolder.Location = new System.Drawing.Point(14, 54);
			this.rootProcessingFolder.Name = "rootProcessingFolder";
			this.rootProcessingFolder.Size = new System.Drawing.Size(106, 13);
			this.rootProcessingFolder.TabIndex = 2;
			this.rootProcessingFolder.Text = "Root Process Folder:";
			// 
			// fileTypeComboBox
			// 
			this.fileTypeComboBox.FormattingEnabled = true;
			this.fileTypeComboBox.Location = new System.Drawing.Point(411, 101);
			this.fileTypeComboBox.Name = "fileTypeComboBox";
			this.fileTypeComboBox.Size = new System.Drawing.Size(222, 21);
			this.fileTypeComboBox.TabIndex = 6;
			this.fileTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged_FileTypeComboBox);
			// 
			// fileTypesLabel
			// 
			this.fileTypesLabel.AutoSize = true;
			this.fileTypesLabel.Location = new System.Drawing.Point(411, 85);
			this.fileTypesLabel.Name = "fileTypesLabel";
			this.fileTypesLabel.Size = new System.Drawing.Size(58, 13);
			this.fileTypesLabel.TabIndex = 5;
			this.fileTypesLabel.Text = "File Types:";
			// 
			// fileExclusionLinkLabel
			// 
			this.fileExclusionLinkLabel.AutoSize = true;
			this.fileExclusionLinkLabel.Location = new System.Drawing.Point(408, 125);
			this.fileExclusionLinkLabel.Name = "fileExclusionLinkLabel";
			this.fileExclusionLinkLabel.Size = new System.Drawing.Size(85, 13);
			this.fileExclusionLinkLabel.TabIndex = 9;
			this.fileExclusionLinkLabel.TabStop = true;
			this.fileExclusionLinkLabel.Text = "File Exclusions...";
			this.fileExclusionLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ButtonClick_FileExclusions);
			// 
			// secludedFileCountlinkLabel
			// 
			this.secludedFileCountlinkLabel.AutoSize = true;
			this.secludedFileCountlinkLabel.Location = new System.Drawing.Point(499, 125);
			this.secludedFileCountlinkLabel.Name = "secludedFileCountlinkLabel";
			this.secludedFileCountlinkLabel.Size = new System.Drawing.Size(98, 13);
			this.secludedFileCountlinkLabel.TabIndex = 10;
			this.secludedFileCountlinkLabel.TabStop = true;
			this.secludedFileCountlinkLabel.Text = "[No Files Excluded]";
			this.secludedFileCountlinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClick_SecludedFileCountlinkLabel);
			// 
			// ClientFileExtractionControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Controls.Add(this.secludedFileCountlinkLabel);
			this.Controls.Add(this.fileExclusionLinkLabel);
			this.Controls.Add(this.fileTypesLabel);
			this.Controls.Add(this.fileTypeComboBox);
			this.Controls.Add(this.rootProcessingFolder);
			this.Controls.Add(this.ApplicantProcessIdsLabel);
			this.Controls.Add(this.fileCountLinkLabel);
			this.Controls.Add(this.copyFilesButton);
			this.Controls.Add(this.outputDestinationBrowseButton);
			this.Controls.Add(this.outputDestinationTextBox);
			this.Controls.Add(this.outputDestinationTextBoxLabel);
			this.Controls.Add(this.processIdComboBox);
			this.Controls.Add(this.processIdComboBoxLabel);
			this.Controls.Add(this.foundationIdComboBox);
			this.Controls.Add(this.foundationIdComboBoxLabel);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ClientFileExtractionControl";
			this.Size = new System.Drawing.Size(662, 422);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label foundationIdComboBoxLabel;
		private System.Windows.Forms.ComboBox foundationIdComboBox;
		private System.Windows.Forms.Label processIdComboBoxLabel;
		private System.Windows.Forms.ComboBox processIdComboBox;
		private System.Windows.Forms.Label outputDestinationTextBoxLabel;
		private System.Windows.Forms.TextBox outputDestinationTextBox;
		private System.Windows.Forms.Button outputDestinationBrowseButton;
		private System.Windows.Forms.Button copyFilesButton;
		private System.Windows.Forms.LinkLabel fileCountLinkLabel;
		private System.Windows.Forms.Label ApplicantProcessIdsLabel;
		private System.Windows.Forms.Label rootProcessingFolder;
		private System.Windows.Forms.ComboBox fileTypeComboBox;
		private System.Windows.Forms.Label fileTypesLabel;
		private System.Windows.Forms.LinkLabel fileExclusionLinkLabel;
		private System.Windows.Forms.LinkLabel secludedFileCountlinkLabel;
	}
}
