namespace UI.Controls
{
	partial class GhostInspectorBlockControl
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
			this.ghostInspectorButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.apiKeyText = new System.Windows.Forms.TextBox();
			this.resultsTextBox = new System.Windows.Forms.RichTextBox();
			this.processIdComboBoxLabel = new System.Windows.Forms.Label();
			this.FolderList = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// ghostInspectorButton
			// 
			this.ghostInspectorButton.Location = new System.Drawing.Point(27, 179);
			this.ghostInspectorButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.ghostInspectorButton.Name = "ghostInspectorButton";
			this.ghostInspectorButton.Size = new System.Drawing.Size(274, 35);
			this.ghostInspectorButton.TabIndex = 15;
			this.ghostInspectorButton.Text = "Run Ghost Inspector";
			this.ghostInspectorButton.UseVisualStyleBackColor = true;
			this.ghostInspectorButton.Click += new System.EventHandler(this.GhostInspectorButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 20);
			this.label1.TabIndex = 19;
			this.label1.Text = "API Key";
			// 
			// apiKeyText
			// 
			this.apiKeyText.Location = new System.Drawing.Point(27, 57);
			this.apiKeyText.Name = "apiKeyText";
			this.apiKeyText.Size = new System.Drawing.Size(868, 26);
			this.apiKeyText.TabIndex = 20;
			this.apiKeyText.TextChanged += new System.EventHandler(this.apiKeyText_TextChanged);
			// 
			// resultsTextBox
			// 
			this.resultsTextBox.Location = new System.Drawing.Point(37, 254);
			this.resultsTextBox.Name = "resultsTextBox";
			this.resultsTextBox.Size = new System.Drawing.Size(858, 325);
			this.resultsTextBox.TabIndex = 21;
			this.resultsTextBox.Text = "";
			// 
			// processIdComboBoxLabel
			// 
			this.processIdComboBoxLabel.AutoSize = true;
			this.processIdComboBoxLabel.Location = new System.Drawing.Point(23, 101);
			this.processIdComboBoxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.processIdComboBoxLabel.Name = "processIdComboBoxLabel";
			this.processIdComboBoxLabel.Size = new System.Drawing.Size(62, 20);
			this.processIdComboBoxLabel.TabIndex = 23;
			this.processIdComboBoxLabel.Text = "Folders";
			// 
			// FolderList
			// 
			this.FolderList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.FolderList.FormattingEnabled = true;
			this.FolderList.Location = new System.Drawing.Point(27, 127);
			this.FolderList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.FolderList.Name = "FolderList";
			this.FolderList.Size = new System.Drawing.Size(868, 28);
			this.FolderList.TabIndex = 22;
			this.FolderList.SelectedIndexChanged += new System.EventHandler(this.FolderList_SelectedIndexChanged);
			// 
			// GhostInspectorBlockControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.processIdComboBoxLabel);
			this.Controls.Add(this.FolderList);
			this.Controls.Add(this.resultsTextBox);
			this.Controls.Add(this.apiKeyText);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ghostInspectorButton);
			this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.Name = "GhostInspectorBlockControl";
			this.Size = new System.Drawing.Size(968, 708);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ghostInspectorButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox apiKeyText;
		private System.Windows.Forms.RichTextBox resultsTextBox;
		private System.Windows.Forms.Label processIdComboBoxLabel;
		private System.Windows.Forms.ComboBox FolderList;
	}
}
