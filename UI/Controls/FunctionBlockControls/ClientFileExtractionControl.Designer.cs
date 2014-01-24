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
			// 
			// processIdComboBoxLabel
			// 
			this.processIdComboBoxLabel.AutoSize = true;
			this.processIdComboBoxLabel.Location = new System.Drawing.Point(14, 63);
			this.processIdComboBoxLabel.Name = "processIdComboBoxLabel";
			this.processIdComboBoxLabel.Size = new System.Drawing.Size(62, 13);
			this.processIdComboBoxLabel.TabIndex = 2;
			this.processIdComboBoxLabel.Text = "Process ID:";
			// 
			// processIdComboBox
			// 
			this.processIdComboBox.FormattingEnabled = true;
			this.processIdComboBox.Location = new System.Drawing.Point(17, 79);
			this.processIdComboBox.Name = "processIdComboBox";
			this.processIdComboBox.Size = new System.Drawing.Size(616, 21);
			this.processIdComboBox.TabIndex = 3;
			this.processIdComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged_ProcessIdComboBox);
			// 
			// outputDestinationTextBoxLabel
			// 
			this.outputDestinationTextBoxLabel.AutoSize = true;
			this.outputDestinationTextBoxLabel.Location = new System.Drawing.Point(14, 134);
			this.outputDestinationTextBoxLabel.Name = "outputDestinationTextBoxLabel";
			this.outputDestinationTextBoxLabel.Size = new System.Drawing.Size(98, 13);
			this.outputDestinationTextBoxLabel.TabIndex = 4;
			this.outputDestinationTextBoxLabel.Text = "Output Destination:";
			// 
			// outputDestinationTextBox
			// 
			this.outputDestinationTextBox.Location = new System.Drawing.Point(17, 150);
			this.outputDestinationTextBox.Name = "outputDestinationTextBox";
			this.outputDestinationTextBox.Size = new System.Drawing.Size(580, 20);
			this.outputDestinationTextBox.TabIndex = 5;
			// 
			// outputDesitinationBrowseButton
			// 
			this.outputDesitinationBrowseButton.Location = new System.Drawing.Point(604, 149);
			this.outputDesitinationBrowseButton.Name = "outputDesitinationBrowseButton";
			this.outputDesitinationBrowseButton.Size = new System.Drawing.Size(29, 23);
			this.outputDesitinationBrowseButton.TabIndex = 6;
			this.outputDesitinationBrowseButton.Text = "...";
			this.outputDesitinationBrowseButton.UseVisualStyleBackColor = true;
			this.outputDesitinationBrowseButton.Click += new System.EventHandler(this.ButtonClick_OutputDestinationBrowse);
			// 
			// copyFilesButton
			// 
			this.copyFilesButton.Location = new System.Drawing.Point(17, 177);
			this.copyFilesButton.Name = "copyFilesButton";
			this.copyFilesButton.Size = new System.Drawing.Size(75, 23);
			this.copyFilesButton.TabIndex = 7;
			this.copyFilesButton.Text = "Copy Files";
			this.copyFilesButton.UseVisualStyleBackColor = true;
			this.copyFilesButton.Click += new System.EventHandler(this.ButtonClick_CopyFiles);
			// 
			// fileCountLinkLabel
			// 
			this.fileCountLinkLabel.AutoSize = true;
			this.fileCountLinkLabel.Location = new System.Drawing.Point(214, 103);
			this.fileCountLinkLabel.Name = "fileCountLinkLabel";
			this.fileCountLinkLabel.Size = new System.Drawing.Size(96, 13);
			this.fileCountLinkLabel.TabIndex = 8;
			this.fileCountLinkLabel.TabStop = true;
			this.fileCountLinkLabel.Text = "[No Files Selected]";
			// 
			// ApplicantProcessIdsLabel
			// 
			this.ApplicantProcessIdsLabel.AutoSize = true;
			this.ApplicantProcessIdsLabel.Location = new System.Drawing.Point(17, 103);
			this.ApplicantProcessIdsLabel.Name = "ApplicantProcessIdsLabel";
			this.ApplicantProcessIdsLabel.Size = new System.Drawing.Size(141, 13);
			this.ApplicantProcessIdsLabel.TabIndex = 9;
			this.ApplicantProcessIdsLabel.Text = "Total Applicant Process IDs:";
			// 
			// ClientFileExtractionControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
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
		private System.Windows.Forms.Button outputDesitinationBrowseButton;
		private System.Windows.Forms.Button copyFilesButton;
		private System.Windows.Forms.LinkLabel fileCountLinkLabel;
		private System.Windows.Forms.Label ApplicantProcessIdsLabel;
	}
}
