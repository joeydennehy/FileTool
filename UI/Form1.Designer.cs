﻿namespace UI
{
	partial class Form1
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.btnNavFileExtraction = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.button3);
			this.splitContainer1.Panel1.Controls.Add(this.button2);
			this.splitContainer1.Panel1.Controls.Add(this.btnNavFileExtraction);
			this.splitContainer1.Size = new System.Drawing.Size(805, 539);
			this.splitContainer1.SplitterDistance = 154;
			this.splitContainer1.TabIndex = 0;
			// 
			// btnNavFileExtraction
			// 
			this.btnNavFileExtraction.Location = new System.Drawing.Point(12, 3);
			this.btnNavFileExtraction.Name = "btnNavFileExtraction";
			this.btnNavFileExtraction.Size = new System.Drawing.Size(139, 23);
			this.btnNavFileExtraction.TabIndex = 0;
			this.btnNavFileExtraction.Text = "button1";
			this.btnNavFileExtraction.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 32);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(139, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(12, 61);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(139, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(805, 539);
			this.Controls.Add(this.splitContainer1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.splitContainer1.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button btnNavFileExtraction;
	}
}

