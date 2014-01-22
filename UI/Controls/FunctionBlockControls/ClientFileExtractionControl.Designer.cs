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
			this.foundationIdComboBox.Size = new System.Drawing.Size(777, 24);
			this.foundationIdComboBox.TabIndex = 1;
			this.foundationIdComboBox.SelectedIndexChanged += new System.EventHandler(this.FoundationDropDown_SelectedValueChanged);
			// 
			// processIdComboBoxLabel
			// 
			this.processIdComboBoxLabel.AutoSize = true;
			this.processIdComboBoxLabel.Location = new System.Drawing.Point(19, 78);
			this.processIdComboBoxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.processIdComboBoxLabel.Name = "processIdComboBoxLabel";
			this.processIdComboBoxLabel.Size = new System.Drawing.Size(80, 17);
			this.processIdComboBoxLabel.TabIndex = 2;
			this.processIdComboBoxLabel.Text = "Process ID:";
			// 
			// processIdComboBox
			// 
			this.processIdComboBox.FormattingEnabled = true;
			this.processIdComboBox.Location = new System.Drawing.Point(23, 97);
			this.processIdComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.processIdComboBox.Name = "processIdComboBox";
			this.processIdComboBox.Size = new System.Drawing.Size(777, 24);
			this.processIdComboBox.TabIndex = 3;
			// 
			// outputDestinationTextBoxLabel
			// 
			this.outputDestinationTextBoxLabel.AutoSize = true;
			this.outputDestinationTextBoxLabel.Location = new System.Drawing.Point(19, 138);
			this.outputDestinationTextBoxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.outputDestinationTextBoxLabel.Name = "outputDestinationTextBoxLabel";
			this.outputDestinationTextBoxLabel.Size = new System.Drawing.Size(130, 17);
			this.outputDestinationTextBoxLabel.TabIndex = 4;
			this.outputDestinationTextBoxLabel.Text = "Output Destination:";
			// 
			// outputDestinationTextBox
			// 
			this.outputDestinationTextBox.Location = new System.Drawing.Point(23, 158);
			this.outputDestinationTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.outputDestinationTextBox.Name = "outputDestinationTextBox";
			this.outputDestinationTextBox.Size = new System.Drawing.Size(729, 22);
			this.outputDestinationTextBox.TabIndex = 5;
			// 
			// outputDesitinationBrowseButton
			// 
			this.outputDesitinationBrowseButton.Location = new System.Drawing.Point(761, 156);
			this.outputDesitinationBrowseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.outputDesitinationBrowseButton.Name = "outputDesitinationBrowseButton";
			this.outputDesitinationBrowseButton.Size = new System.Drawing.Size(39, 28);
			this.outputDesitinationBrowseButton.TabIndex = 6;
			this.outputDesitinationBrowseButton.Text = "...";
			this.outputDesitinationBrowseButton.UseVisualStyleBackColor = true;
			// 
			// ClientFileExtractionControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.Controls.Add(this.outputDesitinationBrowseButton);
			this.Controls.Add(this.outputDestinationTextBox);
			this.Controls.Add(this.outputDestinationTextBoxLabel);
			this.Controls.Add(this.processIdComboBox);
			this.Controls.Add(this.processIdComboBoxLabel);
			this.Controls.Add(this.foundationIdComboBox);
			this.Controls.Add(this.foundationIdComboBoxLabel);
			this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.Name = "ClientFileExtractionControl";
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
	}
}
