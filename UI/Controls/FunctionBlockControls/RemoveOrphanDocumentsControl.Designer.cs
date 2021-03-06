﻿namespace UI.Controls.FunctionBlockControls
{
	partial class RemoveOrphanDocumentsControl
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
			this.rootProcessingFolder = new System.Windows.Forms.Label();
			this.foundationIdComboBox = new System.Windows.Forms.ComboBox();
			this.foundationIdComboBoxLabel = new System.Windows.Forms.Label();
			this.moveFilesTextBox = new System.Windows.Forms.TextBox();
			this.browseButton = new System.Windows.Forms.Button();
			this.moveLocationTextBox = new System.Windows.Forms.TextBox();
			this.sourceLabel = new System.Windows.Forms.Label();
			this.moveFilesButton = new System.Windows.Forms.Button();
			this.moveFilesBackButton = new System.Windows.Forms.Button();
			this.stateDataTextBox = new System.Windows.Forms.TextBox();
			this.fileNotFoundLinkLabel = new System.Windows.Forms.LinkLabel();
			this.EvaluateFilesButton = new System.Windows.Forms.Button();
			this.fileStatisticsLabel = new System.Windows.Forms.Label();
			this.unreferencedFilesLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// rootProcessingFolder
			// 
			this.rootProcessingFolder.AutoSize = true;
			this.rootProcessingFolder.Location = new System.Drawing.Point(19, 63);
			this.rootProcessingFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.rootProcessingFolder.Name = "rootProcessingFolder";
			this.rootProcessingFolder.Size = new System.Drawing.Size(141, 17);
			this.rootProcessingFolder.TabIndex = 5;
			this.rootProcessingFolder.Text = "Root Process Folder:";
			// 
			// foundationIdComboBox
			// 
			this.foundationIdComboBox.FormattingEnabled = true;
			this.foundationIdComboBox.Location = new System.Drawing.Point(19, 34);
			this.foundationIdComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.foundationIdComboBox.Name = "foundationIdComboBox";
			this.foundationIdComboBox.Size = new System.Drawing.Size(820, 24);
			this.foundationIdComboBox.TabIndex = 4;
			this.foundationIdComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedValueChanged_FoundationDropDown);
			this.foundationIdComboBox.Leave += new System.EventHandler(this.OnLeave_FoundationDropDown);
			this.foundationIdComboBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_comboBox);
			// 
			// foundationIdComboBoxLabel
			// 
			this.foundationIdComboBoxLabel.AutoSize = true;
			this.foundationIdComboBoxLabel.Location = new System.Drawing.Point(19, 14);
			this.foundationIdComboBoxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.foundationIdComboBoxLabel.Name = "foundationIdComboBoxLabel";
			this.foundationIdComboBoxLabel.Size = new System.Drawing.Size(100, 17);
			this.foundationIdComboBoxLabel.TabIndex = 3;
			this.foundationIdComboBoxLabel.Text = "Foundation ID:";
			// 
			// moveFilesTextBox
			// 
			this.moveFilesTextBox.Location = new System.Drawing.Point(277, 129);
			this.moveFilesTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.moveFilesTextBox.Multiline = true;
			this.moveFilesTextBox.Name = "moveFilesTextBox";
			this.moveFilesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.moveFilesTextBox.Size = new System.Drawing.Size(565, 265);
			this.moveFilesTextBox.TabIndex = 6;
			this.moveFilesTextBox.WordWrap = false;
			// 
			// browseButton
			// 
			this.browseButton.Location = new System.Drawing.Point(805, 443);
			this.browseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(36, 28);
			this.browseButton.TabIndex = 9;
			this.browseButton.Text = "...";
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.ButtonClick_OutputDestinationBrowse);
			// 
			// moveLocationTextBox
			// 
			this.moveLocationTextBox.Location = new System.Drawing.Point(19, 446);
			this.moveLocationTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.moveLocationTextBox.Name = "moveLocationTextBox";
			this.moveLocationTextBox.Size = new System.Drawing.Size(777, 22);
			this.moveLocationTextBox.TabIndex = 8;
			this.moveLocationTextBox.TextChanged += new System.EventHandler(this.TextChanged_MoveLocationTextBox);
			// 
			// sourceLabel
			// 
			this.sourceLabel.AutoSize = true;
			this.sourceLabel.Location = new System.Drawing.Point(19, 427);
			this.sourceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.sourceLabel.Name = "sourceLabel";
			this.sourceLabel.Size = new System.Drawing.Size(130, 17);
			this.sourceLabel.TabIndex = 7;
			this.sourceLabel.Text = "Move File Location:";
			// 
			// moveFilesButton
			// 
			this.moveFilesButton.Location = new System.Drawing.Point(141, 476);
			this.moveFilesButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.moveFilesButton.Name = "moveFilesButton";
			this.moveFilesButton.Size = new System.Drawing.Size(115, 28);
			this.moveFilesButton.TabIndex = 13;
			this.moveFilesButton.Text = "Move Files";
			this.moveFilesButton.UseVisualStyleBackColor = true;
			// 
			// moveFilesBackButton
			// 
			this.moveFilesBackButton.Location = new System.Drawing.Point(264, 476);
			this.moveFilesBackButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.moveFilesBackButton.Name = "moveFilesBackButton";
			this.moveFilesBackButton.Size = new System.Drawing.Size(161, 28);
			this.moveFilesBackButton.TabIndex = 14;
			this.moveFilesBackButton.Text = "Move Files Back";
			this.moveFilesBackButton.UseVisualStyleBackColor = true;
			// 
			// stateDataTextBox
			// 
			this.stateDataTextBox.Location = new System.Drawing.Point(19, 129);
			this.stateDataTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.stateDataTextBox.Multiline = true;
			this.stateDataTextBox.Name = "stateDataTextBox";
			this.stateDataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.stateDataTextBox.Size = new System.Drawing.Size(247, 265);
			this.stateDataTextBox.TabIndex = 15;
			// 
			// fileNotFoundLinkLabel
			// 
			this.fileNotFoundLinkLabel.AutoSize = true;
			this.fileNotFoundLinkLabel.Location = new System.Drawing.Point(19, 398);
			this.fileNotFoundLinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.fileNotFoundLinkLabel.Name = "fileNotFoundLinkLabel";
			this.fileNotFoundLinkLabel.Size = new System.Drawing.Size(185, 17);
			this.fileNotFoundLinkLabel.TabIndex = 16;
			this.fileNotFoundLinkLabel.TabStop = true;
			this.fileNotFoundLinkLabel.Text = "Referenced Files Not Found";
			// 
			// EvaluateFilesButton
			// 
			this.EvaluateFilesButton.Location = new System.Drawing.Point(19, 476);
			this.EvaluateFilesButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.EvaluateFilesButton.Name = "EvaluateFilesButton";
			this.EvaluateFilesButton.Size = new System.Drawing.Size(115, 28);
			this.EvaluateFilesButton.TabIndex = 17;
			this.EvaluateFilesButton.Text = "Evaluate Files";
			this.EvaluateFilesButton.UseVisualStyleBackColor = true;
			this.EvaluateFilesButton.Click += new System.EventHandler(this.ButtonClick_EvaluateFilesButton);
			// 
			// fileStatisticsLabel
			// 
			this.fileStatisticsLabel.AutoSize = true;
			this.fileStatisticsLabel.Location = new System.Drawing.Point(19, 107);
			this.fileStatisticsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.fileStatisticsLabel.Name = "fileStatisticsLabel";
			this.fileStatisticsLabel.Size = new System.Drawing.Size(94, 17);
			this.fileStatisticsLabel.TabIndex = 18;
			this.fileStatisticsLabel.Text = "File Statistics:";
			// 
			// unreferencedFilesLabel
			// 
			this.unreferencedFilesLabel.AutoSize = true;
			this.unreferencedFilesLabel.Location = new System.Drawing.Point(277, 107);
			this.unreferencedFilesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.unreferencedFilesLabel.Name = "unreferencedFilesLabel";
			this.unreferencedFilesLabel.Size = new System.Drawing.Size(132, 17);
			this.unreferencedFilesLabel.TabIndex = 19;
			this.unreferencedFilesLabel.Text = "Unreferenced Files:";
			// 
			// RemoveOrphanDocumentsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.Controls.Add(this.unreferencedFilesLabel);
			this.Controls.Add(this.fileStatisticsLabel);
			this.Controls.Add(this.EvaluateFilesButton);
			this.Controls.Add(this.fileNotFoundLinkLabel);
			this.Controls.Add(this.stateDataTextBox);
			this.Controls.Add(this.moveFilesBackButton);
			this.Controls.Add(this.moveFilesButton);
			this.Controls.Add(this.browseButton);
			this.Controls.Add(this.moveLocationTextBox);
			this.Controls.Add(this.sourceLabel);
			this.Controls.Add(this.moveFilesTextBox);
			this.Controls.Add(this.rootProcessingFolder);
			this.Controls.Add(this.foundationIdComboBox);
			this.Controls.Add(this.foundationIdComboBoxLabel);
			this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.Name = "RemoveOrphanDocumentsControl";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Label rootProcessingFolder;
        private System.Windows.Forms.ComboBox foundationIdComboBox;
        private System.Windows.Forms.Label foundationIdComboBoxLabel;
        private System.Windows.Forms.TextBox moveFilesTextBox;
        private System.Windows.Forms.Button browseButton;
        public System.Windows.Forms.TextBox moveLocationTextBox;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.Button moveFilesButton;
        private System.Windows.Forms.Button moveFilesBackButton;
        private System.Windows.Forms.TextBox stateDataTextBox;
		  private System.Windows.Forms.LinkLabel fileNotFoundLinkLabel;
		  private System.Windows.Forms.Button EvaluateFilesButton;
		  private System.Windows.Forms.Label fileStatisticsLabel;
		  private System.Windows.Forms.Label unreferencedFilesLabel;

    }
}
