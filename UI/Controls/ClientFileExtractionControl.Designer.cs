namespace UI.Controls
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
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.FoundationProcessDropDown = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.FoundationDropDown = new System.Windows.Forms.ComboBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(24, 151);
			this.textBox2.Margin = new System.Windows.Forms.Padding(4);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(392, 22);
			this.textBox2.TabIndex = 17;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(24, 117);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(115, 17);
			this.label4.TabIndex = 16;
			this.label4.Text = "Source Location:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(32, 316);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(99, 17);
			this.label3.TabIndex = 15;
			this.label3.Text = "Output Folder:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(435, 335);
			this.button1.Margin = new System.Windows.Forms.Padding(4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 28);
			this.button1.TabIndex = 14;
			this.button1.Text = "...";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(28, 251);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 17);
			this.label2.TabIndex = 13;
			this.label2.Text = "Process ID:";
			// 
			// FoundationProcessDropDown
			// 
			this.FoundationProcessDropDown.FormattingEnabled = true;
			this.FoundationProcessDropDown.Location = new System.Drawing.Point(28, 274);
			this.FoundationProcessDropDown.Margin = new System.Windows.Forms.Padding(4);
			this.FoundationProcessDropDown.Name = "FoundationProcessDropDown";
			this.FoundationProcessDropDown.Size = new System.Drawing.Size(396, 24);
			this.FoundationProcessDropDown.TabIndex = 12;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 180);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 17);
			this.label1.TabIndex = 11;
			this.label1.Text = "Foundation ID:";
			// 
			// FoundationDropDown
			// 
			this.FoundationDropDown.FormattingEnabled = true;
			this.FoundationDropDown.Location = new System.Drawing.Point(24, 203);
			this.FoundationDropDown.Margin = new System.Windows.Forms.Padding(4);
			this.FoundationDropDown.Name = "FoundationDropDown";
			this.FoundationDropDown.Size = new System.Drawing.Size(400, 24);
			this.FoundationDropDown.TabIndex = 10;
			this.FoundationDropDown.SelectedValueChanged += new System.EventHandler(this.FoundationDropDown_SelectedValueChanged);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(24, 340);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(400, 22);
			this.textBox1.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(36, 22);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(202, 17);
			this.label5.TabIndex = 18;
			this.label5.Text = "Copy Foundation Support Files";
			// 
			// ClientFileExtractionControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.FoundationProcessDropDown);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.FoundationDropDown);
			this.Controls.Add(this.textBox1);
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "ClientFileExtractionControl";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox FoundationProcessDropDown;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox FoundationDropDown;
		private System.Windows.Forms.TextBox textBox1;
		public System.Windows.Forms.Label label5;
	}
}
