﻿namespace UI
{
	partial class GLMFileUtilityTool
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMFileUtilityTool));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.buttonPanel2 = new System.Windows.Forms.Panel();
			this.buttonPanel1 = new System.Windows.Forms.Panel();
			this.btnNavFileExtraction = new UI.Controls.CustomButton();
			this.panelControlContainer = new System.Windows.Forms.Panel();
			this.functionBlockPanel = new System.Windows.Forms.Panel();
			this.sourceBlockPanel = new System.Windows.Forms.Panel();
			this.titleBlockPanel = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.buttonPanel1.SuspendLayout();
			this.panelControlContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.buttonPanel2);
			this.splitContainer1.Panel1.Controls.Add(this.buttonPanel1);
			this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5, 5, 0, 4);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panelControlContainer);
			this.splitContainer1.Size = new System.Drawing.Size(1073, 663);
			this.splitContainer1.SplitterDistance = 202;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 0;
			// 
			// buttonPanel2
			// 
			this.buttonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonPanel2.Location = new System.Drawing.Point(5, 38);
			this.buttonPanel2.Margin = new System.Windows.Forms.Padding(4);
			this.buttonPanel2.Name = "buttonPanel2";
			this.buttonPanel2.Size = new System.Drawing.Size(197, 33);
			this.buttonPanel2.TabIndex = 6;
			// 
			// buttonPanel1
			// 
			this.buttonPanel1.Controls.Add(this.btnNavFileExtraction);
			this.buttonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonPanel1.Location = new System.Drawing.Point(5, 5);
			this.buttonPanel1.Margin = new System.Windows.Forms.Padding(4);
			this.buttonPanel1.Name = "buttonPanel1";
			this.buttonPanel1.Size = new System.Drawing.Size(197, 33);
			this.buttonPanel1.TabIndex = 5;
			// 
			// btnNavFileExtraction
			// 
			this.btnNavFileExtraction.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnNavFileExtraction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNavFileExtraction.Location = new System.Drawing.Point(0, 0);
			this.btnNavFileExtraction.Margin = new System.Windows.Forms.Padding(4);
			this.btnNavFileExtraction.Name = "btnNavFileExtraction";
			this.btnNavFileExtraction.Size = new System.Drawing.Size(197, 28);
			this.btnNavFileExtraction.TabIndex = 0;
			this.btnNavFileExtraction.Text = "Extract Files";
			this.btnNavFileExtraction.UseVisualStyleBackColor = true;
			this.btnNavFileExtraction.Click += new System.EventHandler(this.NavigationButtonClick);
			// 
			// panelControlContainer
			// 
			this.panelControlContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelControlContainer.Controls.Add(this.functionBlockPanel);
			this.panelControlContainer.Controls.Add(this.sourceBlockPanel);
			this.panelControlContainer.Controls.Add(this.titleBlockPanel);
			this.panelControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControlContainer.Location = new System.Drawing.Point(0, 0);
			this.panelControlContainer.Margin = new System.Windows.Forms.Padding(4);
			this.panelControlContainer.Name = "panelControlContainer";
			this.panelControlContainer.Size = new System.Drawing.Size(866, 663);
			this.panelControlContainer.TabIndex = 1;
			// 
			// functionBlockPanel
			// 
			this.functionBlockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.functionBlockPanel.Location = new System.Drawing.Point(0, 123);
			this.functionBlockPanel.Margin = new System.Windows.Forms.Padding(4);
			this.functionBlockPanel.Name = "functionBlockPanel";
			this.functionBlockPanel.Size = new System.Drawing.Size(864, 538);
			this.functionBlockPanel.TabIndex = 2;
			// 
			// sourceBlockPanel
			// 
			this.sourceBlockPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.sourceBlockPanel.Location = new System.Drawing.Point(0, 55);
			this.sourceBlockPanel.Margin = new System.Windows.Forms.Padding(4);
			this.sourceBlockPanel.Name = "sourceBlockPanel";
			this.sourceBlockPanel.Size = new System.Drawing.Size(864, 68);
			this.sourceBlockPanel.TabIndex = 1;
			// 
			// titleBlockPanel
			// 
			this.titleBlockPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.titleBlockPanel.Location = new System.Drawing.Point(0, 0);
			this.titleBlockPanel.Margin = new System.Windows.Forms.Padding(4);
			this.titleBlockPanel.Name = "titleBlockPanel";
			this.titleBlockPanel.Size = new System.Drawing.Size(864, 55);
			this.titleBlockPanel.TabIndex = 0;
			// 
			// GLMFileUtilityTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1073, 663);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "GLMFileUtilityTool";
			this.Text = "GLM File Utility Tool";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.buttonPanel1.ResumeLayout(false);
			this.panelControlContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private UI.Controls.CustomButton btnNavFileExtraction;
		private System.Windows.Forms.Panel panelControlContainer;
		private System.Windows.Forms.Panel titleBlockPanel;
		public System.Windows.Forms.Panel sourceBlockPanel;
		private System.Windows.Forms.Panel functionBlockPanel;
		private System.Windows.Forms.Panel buttonPanel2;
		private System.Windows.Forms.Panel buttonPanel1;
	}
}

