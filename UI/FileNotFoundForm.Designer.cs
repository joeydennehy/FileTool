namespace UI
{
	partial class FileNotFoundForm
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
			System.Windows.Forms.Button deleteRecordButton;
			this.instructionsPanel = new System.Windows.Forms.Panel();
			this.exclusionInstructionsLabel = new System.Windows.Forms.Label();
			this.exclusionListPanel = new System.Windows.Forms.Panel();
			this.notFoundTextBox = new System.Windows.Forms.RichTextBox();
			this.sequesterLocationPanel = new System.Windows.Forms.Panel();
			this.cancelButton = new System.Windows.Forms.Button();
			deleteRecordButton = new System.Windows.Forms.Button();
			this.instructionsPanel.SuspendLayout();
			this.exclusionListPanel.SuspendLayout();
			this.sequesterLocationPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// instructionsPanel
			// 
			this.instructionsPanel.Controls.Add(this.exclusionInstructionsLabel);
			this.instructionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.instructionsPanel.Location = new System.Drawing.Point(0, 0);
			this.instructionsPanel.Margin = new System.Windows.Forms.Padding(4);
			this.instructionsPanel.Name = "instructionsPanel";
			this.instructionsPanel.Size = new System.Drawing.Size(1012, 32);
			this.instructionsPanel.TabIndex = 0;
			// 
			// exclusionInstructionsLabel
			// 
			this.exclusionInstructionsLabel.AutoSize = true;
			this.exclusionInstructionsLabel.Cursor = System.Windows.Forms.Cursors.Default;
			this.exclusionInstructionsLabel.Location = new System.Drawing.Point(5, 5);
			this.exclusionInstructionsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.exclusionInstructionsLabel.MaximumSize = new System.Drawing.Size(451, 0);
			this.exclusionInstructionsLabel.Name = "exclusionInstructionsLabel";
			this.exclusionInstructionsLabel.Size = new System.Drawing.Size(38, 17);
			this.exclusionInstructionsLabel.TabIndex = 0;
			this.exclusionInstructionsLabel.Text = "[text]";
			// 
			// exclusionListPanel
			// 
			this.exclusionListPanel.Controls.Add(this.notFoundTextBox);
			this.exclusionListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exclusionListPanel.Location = new System.Drawing.Point(0, 32);
			this.exclusionListPanel.Margin = new System.Windows.Forms.Padding(4);
			this.exclusionListPanel.Name = "exclusionListPanel";
			this.exclusionListPanel.Padding = new System.Windows.Forms.Padding(4);
			this.exclusionListPanel.Size = new System.Drawing.Size(1012, 281);
			this.exclusionListPanel.TabIndex = 1;
			// 
			// notFoundTextBox
			// 
			this.notFoundTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.notFoundTextBox.Location = new System.Drawing.Point(4, 4);
			this.notFoundTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.notFoundTextBox.Name = "notFoundTextBox";
			this.notFoundTextBox.Size = new System.Drawing.Size(1004, 273);
			this.notFoundTextBox.TabIndex = 0;
			this.notFoundTextBox.Text = "";
			// 
			// sequesterLocationPanel
			// 
			this.sequesterLocationPanel.Controls.Add(this.cancelButton);
			this.sequesterLocationPanel.Controls.Add(deleteRecordButton);
			this.sequesterLocationPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sequesterLocationPanel.Location = new System.Drawing.Point(0, 313);
			this.sequesterLocationPanel.Margin = new System.Windows.Forms.Padding(4);
			this.sequesterLocationPanel.Name = "sequesterLocationPanel";
			this.sequesterLocationPanel.Size = new System.Drawing.Size(1012, 39);
			this.sequesterLocationPanel.TabIndex = 2;
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(191, 4);
			this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(100, 28);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// deleteRecordButton
			// 
			deleteRecordButton.Location = new System.Drawing.Point(16, 4);
			deleteRecordButton.Margin = new System.Windows.Forms.Padding(4);
			deleteRecordButton.Name = "deleteRecordButton";
			deleteRecordButton.Size = new System.Drawing.Size(167, 28);
			deleteRecordButton.TabIndex = 0;
			deleteRecordButton.Text = "Delete Records";
			deleteRecordButton.UseVisualStyleBackColor = true;
			deleteRecordButton.Click += new System.EventHandler(this.ButtonClick_Ok);
			// 
			// FileNotFoundForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(1012, 352);
			this.Controls.Add(this.exclusionListPanel);
			this.Controls.Add(this.sequesterLocationPanel);
			this.Controls.Add(this.instructionsPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FileNotFoundForm";
			this.Text = "Files Not Found";
			this.instructionsPanel.ResumeLayout(false);
			this.instructionsPanel.PerformLayout();
			this.exclusionListPanel.ResumeLayout(false);
			this.sequesterLocationPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel instructionsPanel;
		private System.Windows.Forms.Panel exclusionListPanel;
		private System.Windows.Forms.Panel sequesterLocationPanel;
		private System.Windows.Forms.Label exclusionInstructionsLabel;
		private System.Windows.Forms.RichTextBox notFoundTextBox;
		private System.Windows.Forms.Button cancelButton;
	}
}