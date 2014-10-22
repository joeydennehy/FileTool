namespace UI.Controls.FunctionBlockControls
{
	partial class ProcessMergeFieldDocumentsControl
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
			this.copyFilesButton = new System.Windows.Forms.Button();
			this.outputDestinationBrowseButton = new System.Windows.Forms.Button();
			this.outputDestinationTextBox = new System.Windows.Forms.TextBox();
			this.outputDestinationTextBoxLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// copyFilesButton
			// 
			this.copyFilesButton.Location = new System.Drawing.Point(15, 54);
			this.copyFilesButton.Name = "copyFilesButton";
			this.copyFilesButton.Size = new System.Drawing.Size(103, 23);
			this.copyFilesButton.TabIndex = 26;
			this.copyFilesButton.Text = "Process Files";
			this.copyFilesButton.UseVisualStyleBackColor = true;
			this.copyFilesButton.Click += new System.EventHandler(this.ButtonClick_CopyFilesButton);
			// 
			// outputDestinationBrowseButton
			// 
			this.outputDestinationBrowseButton.Location = new System.Drawing.Point(602, 26);
			this.outputDestinationBrowseButton.Name = "outputDestinationBrowseButton";
			this.outputDestinationBrowseButton.Size = new System.Drawing.Size(29, 23);
			this.outputDestinationBrowseButton.TabIndex = 25;
			this.outputDestinationBrowseButton.Text = "...";
			this.outputDestinationBrowseButton.UseVisualStyleBackColor = true;
			this.outputDestinationBrowseButton.Click += new System.EventHandler(this.ButtonClick_OutputDestinationBrowse);
			// 
			// outputDestinationTextBox
			// 
			this.outputDestinationTextBox.Location = new System.Drawing.Point(15, 27);
			this.outputDestinationTextBox.Name = "outputDestinationTextBox";
			this.outputDestinationTextBox.Size = new System.Drawing.Size(580, 20);
			this.outputDestinationTextBox.TabIndex = 24;
			this.outputDestinationTextBox.TextChanged += new System.EventHandler(this.TextChanged_OutputDestinationTextBox);
			// 
			// outputDestinationTextBoxLabel
			// 
			this.outputDestinationTextBoxLabel.AutoSize = true;
			this.outputDestinationTextBoxLabel.Location = new System.Drawing.Point(12, 11);
			this.outputDestinationTextBoxLabel.Name = "outputDestinationTextBoxLabel";
			this.outputDestinationTextBoxLabel.Size = new System.Drawing.Size(98, 13);
			this.outputDestinationTextBoxLabel.TabIndex = 23;
			this.outputDestinationTextBoxLabel.Text = "Output Destination:";
			// 
			// ProcessMergeFieldDocumentsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.copyFilesButton);
			this.Controls.Add(this.outputDestinationBrowseButton);
			this.Controls.Add(this.outputDestinationTextBox);
			this.Controls.Add(this.outputDestinationTextBoxLabel);
			this.Name = "ProcessMergeFieldDocumentsControl";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button copyFilesButton;
		private System.Windows.Forms.Button outputDestinationBrowseButton;
		private System.Windows.Forms.TextBox outputDestinationTextBox;
		private System.Windows.Forms.Label outputDestinationTextBoxLabel;

	}
}
