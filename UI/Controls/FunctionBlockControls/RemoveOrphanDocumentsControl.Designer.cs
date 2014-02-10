namespace UI.Controls.FunctionBlockControls
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.moveLocationText = new System.Windows.Forms.TextBox();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.moveFilesButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
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
            this.foundationIdComboBox.Location = new System.Drawing.Point(23, 34);
            this.foundationIdComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.foundationIdComboBox.Name = "foundationIdComboBox";
            this.foundationIdComboBox.Size = new System.Drawing.Size(820, 24);
            this.foundationIdComboBox.TabIndex = 4;
            this.foundationIdComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedValueChanged_FoundationDropDown);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(23, 103);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(820, 312);
            this.textBox1.TabIndex = 6;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(805, 446);
            this.browseButton.Margin = new System.Windows.Forms.Padding(4);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(36, 28);
            this.browseButton.TabIndex = 9;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            // 
            // moveLocationText
            // 
            this.moveLocationText.Location = new System.Drawing.Point(23, 447);
            this.moveLocationText.Margin = new System.Windows.Forms.Padding(4);
            this.moveLocationText.Name = "moveLocationText";
            this.moveLocationText.Size = new System.Drawing.Size(772, 22);
            this.moveLocationText.TabIndex = 8;
            this.moveLocationText.TextChanged += new System.EventHandler(this.moveLocationText_TextChanged);
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
            this.sourceLabel.Click += new System.EventHandler(this.sourceLabel_Click);
            // 
            // moveFilesButton
            // 
            this.moveFilesButton.Location = new System.Drawing.Point(23, 477);
            this.moveFilesButton.Margin = new System.Windows.Forms.Padding(4);
            this.moveFilesButton.Name = "moveFilesButton";
            this.moveFilesButton.Size = new System.Drawing.Size(100, 28);
            this.moveFilesButton.TabIndex = 13;
            this.moveFilesButton.Text = "Move Files";
            this.moveFilesButton.UseVisualStyleBackColor = true;
            this.moveFilesButton.Click += new System.EventHandler(this.moveFilesButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(131, 477);
            this.undoButton.Margin = new System.Windows.Forms.Padding(4);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(100, 28);
            this.undoButton.TabIndex = 14;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            // 
            // RemoveOrphanDocumentsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.moveFilesButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.moveLocationText);
            this.Controls.Add(this.sourceLabel);
            this.Controls.Add(this.textBox1);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button browseButton;
        public System.Windows.Forms.TextBox moveLocationText;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.Button moveFilesButton;
        private System.Windows.Forms.Button undoButton;

    }
}
