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
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.btnNavFileExtraction = new System.Windows.Forms.Button();
			this.panelControlContainer = new System.Windows.Forms.Panel();
			this.functionBlockPanel = new System.Windows.Forms.Panel();
			this.sourceBlockPanel = new System.Windows.Forms.Panel();
			this.titleBlockPanel = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panelControlContainer.SuspendLayout();
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
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panelControlContainer);
			this.splitContainer1.Size = new System.Drawing.Size(805, 539);
			this.splitContainer1.SplitterDistance = 154;
			this.splitContainer1.TabIndex = 0;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(12, 61);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(139, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.btnNavFileExtraction_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 32);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(139, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.btnNavFileExtraction_Click);
			// 
			// btnNavFileExtraction
			// 
			this.btnNavFileExtraction.Location = new System.Drawing.Point(12, 3);
			this.btnNavFileExtraction.Name = "btnNavFileExtraction";
			this.btnNavFileExtraction.Size = new System.Drawing.Size(139, 23);
			this.btnNavFileExtraction.TabIndex = 0;
			this.btnNavFileExtraction.Text = "button1";
			this.btnNavFileExtraction.UseVisualStyleBackColor = true;
			this.btnNavFileExtraction.Click += new System.EventHandler(this.btnNavFileExtraction_Click);
			// 
			// panelControlContainer
			// 
			this.panelControlContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelControlContainer.Controls.Add(this.functionBlockPanel);
			this.panelControlContainer.Controls.Add(this.sourceBlockPanel);
			this.panelControlContainer.Controls.Add(this.titleBlockPanel);
			this.panelControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControlContainer.Location = new System.Drawing.Point(0, 0);
			this.panelControlContainer.Name = "panelControlContainer";
			this.panelControlContainer.Size = new System.Drawing.Size(647, 539);
			this.panelControlContainer.TabIndex = 1;
			// 
			// functionBlockPanel
			// 
			this.functionBlockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.functionBlockPanel.Location = new System.Drawing.Point(0, 115);
			this.functionBlockPanel.Name = "functionBlockPanel";
			this.functionBlockPanel.Size = new System.Drawing.Size(645, 422);
			this.functionBlockPanel.TabIndex = 2;
			// 
			// sourceBlockPanel
			// 
			this.sourceBlockPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.sourceBlockPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.sourceBlockPanel.Location = new System.Drawing.Point(0, 45);
			this.sourceBlockPanel.Name = "sourceBlockPanel";
			this.sourceBlockPanel.Size = new System.Drawing.Size(645, 70);
			this.sourceBlockPanel.TabIndex = 1;
			// 
			// titleBlockPanel
			// 
			this.titleBlockPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.titleBlockPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.titleBlockPanel.Location = new System.Drawing.Point(0, 0);
			this.titleBlockPanel.Name = "titleBlockPanel";
			this.titleBlockPanel.Size = new System.Drawing.Size(645, 45);
			this.titleBlockPanel.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(805, 539);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Form1";
			this.Text = "Form1";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panelControlContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button btnNavFileExtraction;
		private System.Windows.Forms.Panel panelControlContainer;
		private System.Windows.Forms.Panel titleBlockPanel;
		private System.Windows.Forms.Panel sourceBlockPanel;
		private System.Windows.Forms.Panel functionBlockPanel;
	}
}

