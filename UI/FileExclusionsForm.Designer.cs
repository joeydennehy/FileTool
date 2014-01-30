namespace UI
{
	partial class FileExclusionsForm
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
            this.instructionsPanel = new System.Windows.Forms.Panel();
            this.exclusionInstructionsLabel = new System.Windows.Forms.Label();
            this.exclusionListPanel = new System.Windows.Forms.Panel();
            this.exclusionsTextBox = new System.Windows.Forms.RichTextBox();
            this.sequesterLocationPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.dialogControlsPanel = new System.Windows.Forms.Panel();
            this.dispositionChoiceGroupBox = new System.Windows.Forms.GroupBox();
            this.dispositionMoveRadio = new System.Windows.Forms.RadioButton();
            this.dispositionDoNotCopyRadio = new System.Windows.Forms.RadioButton();
            this.sequestorLocationLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.sequestorLocationTextBox = new System.Windows.Forms.TextBox();
            this.instructionsPanel.SuspendLayout();
            this.exclusionListPanel.SuspendLayout();
            this.sequesterLocationPanel.SuspendLayout();
            this.dialogControlsPanel.SuspendLayout();
            this.dispositionChoiceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // instructionsPanel
            // 
            this.instructionsPanel.Controls.Add(this.exclusionInstructionsLabel);
            this.instructionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.instructionsPanel.Location = new System.Drawing.Point(0, 0);
            this.instructionsPanel.Margin = new System.Windows.Forms.Padding(4);
            this.instructionsPanel.Name = "instructionsPanel";
            this.instructionsPanel.Size = new System.Drawing.Size(459, 78);
            this.instructionsPanel.TabIndex = 0;
            // 
            // exclusionInstructionsLabel
            // 
            this.exclusionInstructionsLabel.AutoSize = true;
            this.exclusionInstructionsLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.exclusionInstructionsLabel.Location = new System.Drawing.Point(5, 5);
            this.exclusionInstructionsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.exclusionInstructionsLabel.MaximumSize = new System.Drawing.Size(450, 0);
            this.exclusionInstructionsLabel.Name = "exclusionInstructionsLabel";
            this.exclusionInstructionsLabel.Size = new System.Drawing.Size(426, 34);
            this.exclusionInstructionsLabel.TabIndex = 0;
            this.exclusionInstructionsLabel.Text = "Enter the extensions you would like to exclude from copying. Each extension shoul" +
    "d be on its own line without \'*\' or  \'.\'.";
            // 
            // exclusionListPanel
            // 
            this.exclusionListPanel.Controls.Add(this.exclusionsTextBox);
            this.exclusionListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exclusionListPanel.Location = new System.Drawing.Point(0, 78);
            this.exclusionListPanel.Margin = new System.Windows.Forms.Padding(4);
            this.exclusionListPanel.Name = "exclusionListPanel";
            this.exclusionListPanel.Padding = new System.Windows.Forms.Padding(4);
            this.exclusionListPanel.Size = new System.Drawing.Size(459, 315);
            this.exclusionListPanel.TabIndex = 1;
            // 
            // exclusionsTextBox
            // 
            this.exclusionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exclusionsTextBox.Location = new System.Drawing.Point(4, 4);
            this.exclusionsTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.exclusionsTextBox.Name = "exclusionsTextBox";
            this.exclusionsTextBox.Size = new System.Drawing.Size(451, 307);
            this.exclusionsTextBox.TabIndex = 0;
            this.exclusionsTextBox.Text = "";
            // 
            // sequesterLocationPanel
            // 
            this.sequesterLocationPanel.Controls.Add(this.cancelButton);
            this.sequesterLocationPanel.Controls.Add(this.okButton);
            this.sequesterLocationPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sequesterLocationPanel.Location = new System.Drawing.Point(0, 570);
            this.sequesterLocationPanel.Margin = new System.Windows.Forms.Padding(4);
            this.sequesterLocationPanel.Name = "sequesterLocationPanel";
            this.sequesterLocationPanel.Size = new System.Drawing.Size(459, 39);
            this.sequesterLocationPanel.TabIndex = 2;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(124, 4);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(16, 4);
            this.okButton.Margin = new System.Windows.Forms.Padding(4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 28);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // dialogControlsPanel
            // 
            this.dialogControlsPanel.Controls.Add(this.dispositionChoiceGroupBox);
            this.dialogControlsPanel.Controls.Add(this.sequestorLocationLabel);
            this.dialogControlsPanel.Controls.Add(this.browseButton);
            this.dialogControlsPanel.Controls.Add(this.sequestorLocationTextBox);
            this.dialogControlsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dialogControlsPanel.Location = new System.Drawing.Point(0, 393);
            this.dialogControlsPanel.Margin = new System.Windows.Forms.Padding(4);
            this.dialogControlsPanel.Name = "dialogControlsPanel";
            this.dialogControlsPanel.Size = new System.Drawing.Size(459, 177);
            this.dialogControlsPanel.TabIndex = 3;
            // 
            // dispositionChoiceGroupBox
            // 
            this.dispositionChoiceGroupBox.Controls.Add(this.dispositionMoveRadio);
            this.dispositionChoiceGroupBox.Controls.Add(this.dispositionDoNotCopyRadio);
            this.dispositionChoiceGroupBox.Location = new System.Drawing.Point(16, 7);
            this.dispositionChoiceGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.dispositionChoiceGroupBox.Name = "dispositionChoiceGroupBox";
            this.dispositionChoiceGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.dispositionChoiceGroupBox.Size = new System.Drawing.Size(417, 85);
            this.dispositionChoiceGroupBox.TabIndex = 3;
            this.dispositionChoiceGroupBox.TabStop = false;
            this.dispositionChoiceGroupBox.Text = "File Disposition:";
            // 
            // dispositionMoveRadio
            // 
            this.dispositionMoveRadio.AutoSize = true;
            this.dispositionMoveRadio.Location = new System.Drawing.Point(9, 54);
            this.dispositionMoveRadio.Margin = new System.Windows.Forms.Padding(4);
            this.dispositionMoveRadio.Name = "dispositionMoveRadio";
            this.dispositionMoveRadio.Size = new System.Drawing.Size(182, 21);
            this.dispositionMoveRadio.TabIndex = 1;
            this.dispositionMoveRadio.TabStop = true;
            this.dispositionMoveRadio.Text = "Move To Other Location";
            this.dispositionMoveRadio.UseVisualStyleBackColor = true;
            this.dispositionMoveRadio.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // dispositionDoNotCopyRadio
            // 
            this.dispositionDoNotCopyRadio.AutoSize = true;
            this.dispositionDoNotCopyRadio.Location = new System.Drawing.Point(9, 25);
            this.dispositionDoNotCopyRadio.Margin = new System.Windows.Forms.Padding(4);
            this.dispositionDoNotCopyRadio.Name = "dispositionDoNotCopyRadio";
            this.dispositionDoNotCopyRadio.Size = new System.Drawing.Size(109, 21);
            this.dispositionDoNotCopyRadio.TabIndex = 0;
            this.dispositionDoNotCopyRadio.TabStop = true;
            this.dispositionDoNotCopyRadio.Text = "Do Not Copy";
            this.dispositionDoNotCopyRadio.UseVisualStyleBackColor = true;
            this.dispositionDoNotCopyRadio.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // sequestorLocationLabel
            // 
            this.sequestorLocationLabel.AutoSize = true;
            this.sequestorLocationLabel.Location = new System.Drawing.Point(21, 107);
            this.sequestorLocationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sequestorLocationLabel.Name = "sequestorLocationLabel";
            this.sequestorLocationLabel.Size = new System.Drawing.Size(135, 17);
            this.sequestorLocationLabel.TabIndex = 2;
            this.sequestorLocationLabel.Text = "Sequestor Location:";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(393, 123);
            this.browseButton.Margin = new System.Windows.Forms.Padding(4);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(40, 28);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // sequestorLocationTextBox
            // 
            this.sequestorLocationTextBox.Location = new System.Drawing.Point(25, 127);
            this.sequestorLocationTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.sequestorLocationTextBox.Name = "sequestorLocationTextBox";
            this.sequestorLocationTextBox.Size = new System.Drawing.Size(359, 22);
            this.sequestorLocationTextBox.TabIndex = 0;
            // 
            // FileExclusionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(459, 609);
            this.Controls.Add(this.exclusionListPanel);
            this.Controls.Add(this.dialogControlsPanel);
            this.Controls.Add(this.sequesterLocationPanel);
            this.Controls.Add(this.instructionsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileExclusionsForm";
            this.Text = "File Exclusions";
            this.instructionsPanel.ResumeLayout(false);
            this.instructionsPanel.PerformLayout();
            this.exclusionListPanel.ResumeLayout(false);
            this.sequesterLocationPanel.ResumeLayout(false);
            this.dialogControlsPanel.ResumeLayout(false);
            this.dialogControlsPanel.PerformLayout();
            this.dispositionChoiceGroupBox.ResumeLayout(false);
            this.dispositionChoiceGroupBox.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel instructionsPanel;
		private System.Windows.Forms.Panel exclusionListPanel;
		private System.Windows.Forms.Panel sequesterLocationPanel;
		private System.Windows.Forms.Panel dialogControlsPanel;
		private System.Windows.Forms.Label exclusionInstructionsLabel;
		private System.Windows.Forms.RichTextBox exclusionsTextBox;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.GroupBox dispositionChoiceGroupBox;
		private System.Windows.Forms.RadioButton dispositionMoveRadio;
		private System.Windows.Forms.RadioButton dispositionDoNotCopyRadio;
		private System.Windows.Forms.Label sequestorLocationLabel;
		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.TextBox sequestorLocationTextBox;
	}
}