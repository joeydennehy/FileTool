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
			this.exclusionListPanel = new System.Windows.Forms.Panel();
			this.sequesterLocationPanel = new System.Windows.Forms.Panel();
			this.dialogControlsPanel = new System.Windows.Forms.Panel();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.browseButton = new System.Windows.Forms.Button();
			this.sequestorLocationLabel = new System.Windows.Forms.Label();
			this.dispositionChoiceGroupBox = new System.Windows.Forms.GroupBox();
			this.dispositionDoNotCopyRadio = new System.Windows.Forms.RadioButton();
			this.dispositionMoveRadio = new System.Windows.Forms.RadioButton();
			this.exclusionsTextBox = new System.Windows.Forms.RichTextBox();
			this.exclusionInstructionsLabel = new System.Windows.Forms.Label();
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
			this.instructionsPanel.Name = "instructionsPanel";
			this.instructionsPanel.Size = new System.Drawing.Size(344, 63);
			this.instructionsPanel.TabIndex = 0;
			// 
			// exclusionListPanel
			// 
			this.exclusionListPanel.Controls.Add(this.exclusionsTextBox);
			this.exclusionListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exclusionListPanel.Location = new System.Drawing.Point(0, 63);
			this.exclusionListPanel.Name = "exclusionListPanel";
			this.exclusionListPanel.Padding = new System.Windows.Forms.Padding(3);
			this.exclusionListPanel.Size = new System.Drawing.Size(344, 256);
			this.exclusionListPanel.TabIndex = 1;
			// 
			// sequesterLocationPanel
			// 
			this.sequesterLocationPanel.Controls.Add(this.cancelButton);
			this.sequesterLocationPanel.Controls.Add(this.okButton);
			this.sequesterLocationPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sequesterLocationPanel.Location = new System.Drawing.Point(0, 463);
			this.sequesterLocationPanel.Name = "sequesterLocationPanel";
			this.sequesterLocationPanel.Size = new System.Drawing.Size(344, 32);
			this.sequesterLocationPanel.TabIndex = 2;
			// 
			// dialogControlsPanel
			// 
			this.dialogControlsPanel.Controls.Add(this.dispositionChoiceGroupBox);
			this.dialogControlsPanel.Controls.Add(this.sequestorLocationLabel);
			this.dialogControlsPanel.Controls.Add(this.browseButton);
			this.dialogControlsPanel.Controls.Add(this.textBox1);
			this.dialogControlsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dialogControlsPanel.Location = new System.Drawing.Point(0, 319);
			this.dialogControlsPanel.Name = "dialogControlsPanel";
			this.dialogControlsPanel.Size = new System.Drawing.Size(344, 144);
			this.dialogControlsPanel.TabIndex = 3;
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(12, 3);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(93, 3);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(19, 103);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(270, 20);
			this.textBox1.TabIndex = 0;
			// 
			// browseButton
			// 
			this.browseButton.Location = new System.Drawing.Point(295, 100);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(30, 23);
			this.browseButton.TabIndex = 1;
			this.browseButton.Text = "...";
			this.browseButton.UseVisualStyleBackColor = true;
			// 
			// sequestorLocationLabel
			// 
			this.sequestorLocationLabel.AutoSize = true;
			this.sequestorLocationLabel.Location = new System.Drawing.Point(16, 87);
			this.sequestorLocationLabel.Name = "sequestorLocationLabel";
			this.sequestorLocationLabel.Size = new System.Drawing.Size(102, 13);
			this.sequestorLocationLabel.TabIndex = 2;
			this.sequestorLocationLabel.Text = "Sequestor Location:";
			// 
			// dispositionChoiceGroupBox
			// 
			this.dispositionChoiceGroupBox.Controls.Add(this.dispositionMoveRadio);
			this.dispositionChoiceGroupBox.Controls.Add(this.dispositionDoNotCopyRadio);
			this.dispositionChoiceGroupBox.Location = new System.Drawing.Point(12, 6);
			this.dispositionChoiceGroupBox.Name = "dispositionChoiceGroupBox";
			this.dispositionChoiceGroupBox.Size = new System.Drawing.Size(313, 69);
			this.dispositionChoiceGroupBox.TabIndex = 3;
			this.dispositionChoiceGroupBox.TabStop = false;
			this.dispositionChoiceGroupBox.Text = "File Disposition:";
			// 
			// dispositionDoNotCopyRadio
			// 
			this.dispositionDoNotCopyRadio.AutoSize = true;
			this.dispositionDoNotCopyRadio.Location = new System.Drawing.Point(7, 20);
			this.dispositionDoNotCopyRadio.Name = "dispositionDoNotCopyRadio";
			this.dispositionDoNotCopyRadio.Size = new System.Drawing.Size(86, 17);
			this.dispositionDoNotCopyRadio.TabIndex = 0;
			this.dispositionDoNotCopyRadio.TabStop = true;
			this.dispositionDoNotCopyRadio.Text = "Do Not Copy";
			this.dispositionDoNotCopyRadio.UseVisualStyleBackColor = true;
			// 
			// dispositionMoveRadio
			// 
			this.dispositionMoveRadio.AutoSize = true;
			this.dispositionMoveRadio.Location = new System.Drawing.Point(7, 44);
			this.dispositionMoveRadio.Name = "dispositionMoveRadio";
			this.dispositionMoveRadio.Size = new System.Drawing.Size(141, 17);
			this.dispositionMoveRadio.TabIndex = 1;
			this.dispositionMoveRadio.TabStop = true;
			this.dispositionMoveRadio.Text = "Move To Other Location";
			this.dispositionMoveRadio.UseVisualStyleBackColor = true;
			// 
			// exclusionsTextBox
			// 
			this.exclusionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exclusionsTextBox.Location = new System.Drawing.Point(3, 3);
			this.exclusionsTextBox.Name = "exclusionsTextBox";
			this.exclusionsTextBox.Size = new System.Drawing.Size(338, 250);
			this.exclusionsTextBox.TabIndex = 0;
			this.exclusionsTextBox.Text = "";
			// 
			// exclusionInstructionsLabel
			// 
			this.exclusionInstructionsLabel.AutoSize = true;
			this.exclusionInstructionsLabel.Location = new System.Drawing.Point(4, 4);
			this.exclusionInstructionsLabel.Name = "exclusionInstructionsLabel";
			this.exclusionInstructionsLabel.Size = new System.Drawing.Size(35, 13);
			this.exclusionInstructionsLabel.TabIndex = 0;
			this.exclusionInstructionsLabel.Text = "label1";
			// 
			// FileExclusionsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(344, 495);
			this.Controls.Add(this.exclusionListPanel);
			this.Controls.Add(this.dialogControlsPanel);
			this.Controls.Add(this.sequesterLocationPanel);
			this.Controls.Add(this.instructionsPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
		private System.Windows.Forms.TextBox textBox1;
	}
}