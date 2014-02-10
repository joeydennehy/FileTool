namespace UI.Controls.FunctionBlockControls
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
            this.outputDesitinationBrowseButton = new System.Windows.Forms.Button();
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
            this.foundationIdComboBoxLabel.Location = new System.Drawing.Point(19, 17);
            this.foundationIdComboBoxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.foundationIdComboBoxLabel.Name = "foundationIdComboBoxLabel";
            this.foundationIdComboBoxLabel.Size = new System.Drawing.Size(100, 17);
            this.foundationIdComboBoxLabel.TabIndex = 0;
            this.foundationIdComboBoxLabel.Text = "Foundation ID:";
            // 
            // foundationIdComboBox
            // 
            this.foundationIdComboBox.FormattingEnabled = true;
            this.foundationIdComboBox.Location = new System.Drawing.Point(23, 37);
            this.foundationIdComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.foundationIdComboBox.Name = "foundationIdComboBox";
            this.foundationIdComboBox.Size = new System.Drawing.Size(820, 24);
            this.foundationIdComboBox.TabIndex = 1;
            this.foundationIdComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedValueChanged_FoundationDropDown);
            this.foundationIdComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown_comboBox);
            this.foundationIdComboBox.Leave += new System.EventHandler(this.OnLeave_FoundationDropDown);
            this.foundationIdComboBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_comboBox);
            // 
            // processIdComboBoxLabel
            // 
            this.processIdComboBoxLabel.AutoSize = true;
            this.processIdComboBoxLabel.Location = new System.Drawing.Point(19, 105);
            this.processIdComboBoxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.processIdComboBoxLabel.Name = "processIdComboBoxLabel";
            this.processIdComboBoxLabel.Size = new System.Drawing.Size(80, 17);
            this.processIdComboBoxLabel.TabIndex = 3;
            this.processIdComboBoxLabel.Text = "Process ID:";
            // 
            // processIdComboBox
            // 
            this.processIdComboBox.FormattingEnabled = true;
            this.processIdComboBox.Location = new System.Drawing.Point(23, 124);
            this.processIdComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.processIdComboBox.Name = "processIdComboBox";
            this.processIdComboBox.Size = new System.Drawing.Size(516, 24);
            this.processIdComboBox.TabIndex = 4;
            this.processIdComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged_ProcessIdComboBox);
            this.processIdComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown_comboBox);
            this.processIdComboBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_comboBox);
            // 
            // outputDestinationTextBoxLabel
            // 
            this.outputDestinationTextBoxLabel.AutoSize = true;
            this.outputDestinationTextBoxLabel.Location = new System.Drawing.Point(19, 181);
            this.outputDestinationTextBoxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.outputDestinationTextBoxLabel.Name = "outputDestinationTextBoxLabel";
            this.outputDestinationTextBoxLabel.Size = new System.Drawing.Size(130, 17);
            this.outputDestinationTextBoxLabel.TabIndex = 9;
            this.outputDestinationTextBoxLabel.Text = "Output Destination:";
            // 
            // outputDestinationTextBox
            // 
            this.outputDestinationTextBox.Location = new System.Drawing.Point(23, 201);
            this.outputDestinationTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.outputDestinationTextBox.Name = "outputDestinationTextBox";
            this.outputDestinationTextBox.Size = new System.Drawing.Size(772, 22);
            this.outputDestinationTextBox.TabIndex = 10;
            this.outputDestinationTextBox.TextChanged += new System.EventHandler(this.TextChanged_outputDestinationTextBox);
            // 
            // outputDesitinationBrowseButton
            // 
            this.outputDesitinationBrowseButton.Location = new System.Drawing.Point(805, 199);
            this.outputDesitinationBrowseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.outputDesitinationBrowseButton.Name = "outputDesitinationBrowseButton";
            this.outputDesitinationBrowseButton.Size = new System.Drawing.Size(39, 28);
            this.outputDesitinationBrowseButton.TabIndex = 11;
            this.outputDesitinationBrowseButton.Text = "...";
            this.outputDesitinationBrowseButton.UseVisualStyleBackColor = true;
            this.outputDesitinationBrowseButton.Click += new System.EventHandler(this.ButtonClick_OutputDestinationBrowse);
            // 
            // copyFilesButton
            // 
            this.copyFilesButton.Location = new System.Drawing.Point(23, 234);
            this.copyFilesButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.copyFilesButton.Name = "copyFilesButton";
            this.copyFilesButton.Size = new System.Drawing.Size(100, 28);
            this.copyFilesButton.TabIndex = 12;
            this.copyFilesButton.Text = "Copy Files";
            this.copyFilesButton.UseVisualStyleBackColor = true;
            this.copyFilesButton.Click += new System.EventHandler(this.ButtonClick_CopyFiles);
            // 
            // fileCountLinkLabel
            // 
            this.fileCountLinkLabel.AutoSize = true;
            this.fileCountLinkLabel.Location = new System.Drawing.Point(279, 154);
            this.fileCountLinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileCountLinkLabel.Name = "fileCountLinkLabel";
            this.fileCountLinkLabel.Size = new System.Drawing.Size(126, 17);
            this.fileCountLinkLabel.TabIndex = 8;
            this.fileCountLinkLabel.TabStop = true;
            this.fileCountLinkLabel.Text = "[No Files Selected]";
            this.fileCountLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClick_FileCountLinkLabel);
            // 
            // ApplicantProcessIdsLabel
            // 
            this.ApplicantProcessIdsLabel.AutoSize = true;
            this.ApplicantProcessIdsLabel.Location = new System.Drawing.Point(19, 154);
            this.ApplicantProcessIdsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ApplicantProcessIdsLabel.Name = "ApplicantProcessIdsLabel";
            this.ApplicantProcessIdsLabel.Size = new System.Drawing.Size(185, 17);
            this.ApplicantProcessIdsLabel.TabIndex = 7;
            this.ApplicantProcessIdsLabel.Text = "Total Applicant Process IDs:";
            // 
            // rootProcessingFolder
            // 
            this.rootProcessingFolder.AutoSize = true;
            this.rootProcessingFolder.Location = new System.Drawing.Point(19, 66);
            this.rootProcessingFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rootProcessingFolder.Name = "rootProcessingFolder";
            this.rootProcessingFolder.Size = new System.Drawing.Size(141, 17);
            this.rootProcessingFolder.TabIndex = 2;
            this.rootProcessingFolder.Text = "Root Process Folder:";
            // 
            // fileTypeComboBox
            // 
            this.fileTypeComboBox.FormattingEnabled = true;
            this.fileTypeComboBox.Location = new System.Drawing.Point(548, 124);
            this.fileTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fileTypeComboBox.Name = "fileTypeComboBox";
            this.fileTypeComboBox.Size = new System.Drawing.Size(295, 24);
            this.fileTypeComboBox.TabIndex = 6;
            this.fileTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged_FileTypeComboBox);
            // 
            // fileTypesLabel
            // 
            this.fileTypesLabel.AutoSize = true;
            this.fileTypesLabel.Location = new System.Drawing.Point(584, 105);
            this.fileTypesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileTypesLabel.Name = "fileTypesLabel";
            this.fileTypesLabel.Size = new System.Drawing.Size(77, 17);
            this.fileTypesLabel.TabIndex = 5;
            this.fileTypesLabel.Text = "File Types:";
            // 
            // fileExclusionLinkLabel
            // 
            this.fileExclusionLinkLabel.AutoSize = true;
            this.fileExclusionLinkLabel.Location = new System.Drawing.Point(544, 154);
            this.fileExclusionLinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileExclusionLinkLabel.Name = "fileExclusionLinkLabel";
            this.fileExclusionLinkLabel.Size = new System.Drawing.Size(112, 17);
            this.fileExclusionLinkLabel.TabIndex = 13;
            this.fileExclusionLinkLabel.TabStop = true;
            this.fileExclusionLinkLabel.Text = "File Exclusions...";
            this.fileExclusionLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ButtonClick_FileExclusions);
            // 
            // secludedFileCountlinkLabel
            // 
            this.secludedFileCountlinkLabel.AutoSize = true;
            this.secludedFileCountlinkLabel.Location = new System.Drawing.Point(665, 154);
            this.secludedFileCountlinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.secludedFileCountlinkLabel.Name = "secludedFileCountlinkLabel";
            this.secludedFileCountlinkLabel.Size = new System.Drawing.Size(128, 17);
            this.secludedFileCountlinkLabel.TabIndex = 14;
            this.secludedFileCountlinkLabel.TabStop = true;
            this.secludedFileCountlinkLabel.Text = "[No Files Excluded]";
            this.secludedFileCountlinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClick_SecludedFileCountlinkLabel);
            // 
            // ClientFileExtractionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.Controls.Add(this.secludedFileCountlinkLabel);
            this.Controls.Add(this.fileExclusionLinkLabel);
            this.Controls.Add(this.fileTypesLabel);
            this.Controls.Add(this.fileTypeComboBox);
            this.Controls.Add(this.rootProcessingFolder);
            this.Controls.Add(this.ApplicantProcessIdsLabel);
            this.Controls.Add(this.fileCountLinkLabel);
            this.Controls.Add(this.copyFilesButton);
            this.Controls.Add(this.outputDesitinationBrowseButton);
            this.Controls.Add(this.outputDestinationTextBox);
            this.Controls.Add(this.outputDestinationTextBoxLabel);
            this.Controls.Add(this.processIdComboBox);
            this.Controls.Add(this.processIdComboBoxLabel);
            this.Controls.Add(this.foundationIdComboBox);
            this.Controls.Add(this.foundationIdComboBoxLabel);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ClientFileExtractionControl";
            this.Size = new System.Drawing.Size(883, 519);
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
		private System.Windows.Forms.Button outputDesitinationBrowseButton;
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
