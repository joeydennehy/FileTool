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
			this.browseButton = new System.Windows.Forms.Button();
			this.sourceLocationText = new System.Windows.Forms.TextBox();
			this.sourceLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.apiKeyText = new System.Windows.Forms.TextBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
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
			// browseButton
			// 
			this.browseButton.Location = new System.Drawing.Point(907, 49);
			this.browseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(40, 35);
			this.browseButton.TabIndex = 18;
			this.browseButton.Text = "...";
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
			// 
			// sourceLocationText
			// 
			this.sourceLocationText.Location = new System.Drawing.Point(27, 50);
			this.sourceLocationText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.sourceLocationText.Name = "sourceLocationText";
			this.sourceLocationText.Size = new System.Drawing.Size(868, 26);
			this.sourceLocationText.TabIndex = 17;
			// 
			// sourceLabel
			// 
			this.sourceLabel.AutoSize = true;
			this.sourceLabel.Location = new System.Drawing.Point(22, 25);
			this.sourceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.sourceLabel.Name = "sourceLabel";
			this.sourceLabel.Size = new System.Drawing.Size(72, 20);
			this.sourceLabel.TabIndex = 16;
			this.sourceLabel.Text = "Suite Ids";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 105);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 20);
			this.label1.TabIndex = 19;
			this.label1.Text = "API Key";
			// 
			// apiKeyText
			// 
			this.apiKeyText.Location = new System.Drawing.Point(27, 128);
			this.apiKeyText.Name = "apiKeyText";
			this.apiKeyText.Size = new System.Drawing.Size(868, 26);
			this.apiKeyText.TabIndex = 20;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(37, 254);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(858, 325);
			this.richTextBox1.TabIndex = 21;
			this.richTextBox1.Text = "";
			// 
			// GhostInspectorBlockControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.apiKeyText);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.browseButton);
			this.Controls.Add(this.sourceLocationText);
			this.Controls.Add(this.sourceLabel);
			this.Controls.Add(this.ghostInspectorButton);
			this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.Name = "GhostInspectorBlockControl";
			this.Size = new System.Drawing.Size(968, 708);
			this.Load += new System.EventHandler(this.SourcePathBlockControl_Load);
			this.Leave += new System.EventHandler(this.OnLeave_SourcePathBlockControl);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ghostInspectorButton;
		private System.Windows.Forms.Button browseButton;
		public System.Windows.Forms.TextBox sourceLocationText;
		private System.Windows.Forms.Label sourceLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox apiKeyText;
		private System.Windows.Forms.RichTextBox richTextBox1;
	}
}
