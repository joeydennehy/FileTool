namespace UI.Controls.FunctionBlockControls
{
	partial class RenameDirectoryControl
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
			this.foundationIdComboBox = new System.Windows.Forms.ComboBox();
			this.foundationIdComboBoxLabel = new System.Windows.Forms.Label();
			this.MissMatchRequestCodeTextBox = new System.Windows.Forms.TextBox();
			this.EvaluateFilesButton = new System.Windows.Forms.Button();
			this.instructionLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// foundationIdComboBox
			// 
			this.foundationIdComboBox.FormattingEnabled = true;
			this.foundationIdComboBox.Location = new System.Drawing.Point(25, 46);
			this.foundationIdComboBox.Margin = new System.Windows.Forms.Padding(4);
			this.foundationIdComboBox.Name = "foundationIdComboBox";
			this.foundationIdComboBox.Size = new System.Drawing.Size(820, 24);
			this.foundationIdComboBox.TabIndex = 3;
			this.foundationIdComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged_FoundationIdComboBox);
			this.foundationIdComboBox.DragLeave += new System.EventHandler(this.OnLeave_FoundationDropDown);
			this.foundationIdComboBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_comboBox);
			// 
			// foundationIdComboBoxLabel
			// 
			this.foundationIdComboBoxLabel.AutoSize = true;
			this.foundationIdComboBoxLabel.Location = new System.Drawing.Point(21, 26);
			this.foundationIdComboBoxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.foundationIdComboBoxLabel.Name = "foundationIdComboBoxLabel";
			this.foundationIdComboBoxLabel.Size = new System.Drawing.Size(100, 17);
			this.foundationIdComboBoxLabel.TabIndex = 2;
			this.foundationIdComboBoxLabel.Text = "Foundation ID:";
			// 
			// MissMatchRequestCodeTextBox
			// 
			this.MissMatchRequestCodeTextBox.Location = new System.Drawing.Point(25, 93);
			this.MissMatchRequestCodeTextBox.Multiline = true;
			this.MissMatchRequestCodeTextBox.Name = "MissMatchRequestCodeTextBox";
			this.MissMatchRequestCodeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.MissMatchRequestCodeTextBox.Size = new System.Drawing.Size(820, 330);
			this.MissMatchRequestCodeTextBox.TabIndex = 7;
			this.MissMatchRequestCodeTextBox.WordWrap = false;
			// 
			// EvaluateFilesButton
			// 
			this.EvaluateFilesButton.Location = new System.Drawing.Point(25, 472);
			this.EvaluateFilesButton.Margin = new System.Windows.Forms.Padding(4);
			this.EvaluateFilesButton.Name = "EvaluateFilesButton";
			this.EvaluateFilesButton.Size = new System.Drawing.Size(96, 28);
			this.EvaluateFilesButton.TabIndex = 18;
			this.EvaluateFilesButton.Text = "Rename";
			this.EvaluateFilesButton.UseVisualStyleBackColor = true;
			this.EvaluateFilesButton.Click += new System.EventHandler(this.ButtonClick_RenameRecordsAndFilesButton);
			// 
			// instructionLabel
			// 
			this.instructionLabel.AutoSize = true;
			this.instructionLabel.Location = new System.Drawing.Point(22, 436);
			this.instructionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.instructionLabel.Name = "instructionLabel";
			this.instructionLabel.Size = new System.Drawing.Size(38, 17);
			this.instructionLabel.TabIndex = 19;
			this.instructionLabel.Text = "[text]";
			// 
			// RenameDirectoryControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.Controls.Add(this.instructionLabel);
			this.Controls.Add(this.EvaluateFilesButton);
			this.Controls.Add(this.MissMatchRequestCodeTextBox);
			this.Controls.Add(this.foundationIdComboBox);
			this.Controls.Add(this.foundationIdComboBoxLabel);
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "RenameDirectoryControl";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox foundationIdComboBox;
		private System.Windows.Forms.Label foundationIdComboBoxLabel;
		private System.Windows.Forms.TextBox MissMatchRequestCodeTextBox;
		private System.Windows.Forms.Button EvaluateFilesButton;
		private System.Windows.Forms.Label instructionLabel;

	}
}
