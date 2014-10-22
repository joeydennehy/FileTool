namespace UI
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
			this.btnNavProcessMergeTemplates = new UI.Controls.CustomButton();
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
			this.buttonPanel2.SuspendLayout();
			this.buttonPanel1.SuspendLayout();
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
			this.splitContainer1.Panel1.Controls.Add(this.buttonPanel2);
			this.splitContainer1.Panel1.Controls.Add(this.buttonPanel1);
			this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4, 4, 0, 3);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panelControlContainer);
			this.splitContainer1.Size = new System.Drawing.Size(805, 539);
			this.splitContainer1.SplitterDistance = 151;
			this.splitContainer1.TabIndex = 0;
			// 
			// buttonPanel2
			// 
			this.buttonPanel2.Controls.Add(this.btnNavProcessMergeTemplates);
			this.buttonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonPanel2.Location = new System.Drawing.Point(4, 31);
			this.buttonPanel2.Name = "buttonPanel2";
			this.buttonPanel2.Size = new System.Drawing.Size(147, 27);
			this.buttonPanel2.TabIndex = 6;
			// 
			// btnNavProcessMergeTemplates
			// 
			this.btnNavProcessMergeTemplates.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnNavProcessMergeTemplates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNavProcessMergeTemplates.Location = new System.Drawing.Point(0, 0);
			this.btnNavProcessMergeTemplates.Name = "btnNavProcessMergeTemplates";
			this.btnNavProcessMergeTemplates.Size = new System.Drawing.Size(147, 23);
			this.btnNavProcessMergeTemplates.TabIndex = 1;
			this.btnNavProcessMergeTemplates.Text = "Process Merge Templates";
			this.btnNavProcessMergeTemplates.UseVisualStyleBackColor = true;
			this.btnNavProcessMergeTemplates.Click += new System.EventHandler(this.NavigationButtonClick);
			// 
			// buttonPanel1
			// 
			this.buttonPanel1.Controls.Add(this.btnNavFileExtraction);
			this.buttonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonPanel1.Location = new System.Drawing.Point(4, 4);
			this.buttonPanel1.Name = "buttonPanel1";
			this.buttonPanel1.Size = new System.Drawing.Size(147, 27);
			this.buttonPanel1.TabIndex = 5;
			// 
			// btnNavFileExtraction
			// 
			this.btnNavFileExtraction.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnNavFileExtraction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNavFileExtraction.Location = new System.Drawing.Point(0, 0);
			this.btnNavFileExtraction.Name = "btnNavFileExtraction";
			this.btnNavFileExtraction.Size = new System.Drawing.Size(147, 23);
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
			this.panelControlContainer.Name = "panelControlContainer";
			this.panelControlContainer.Size = new System.Drawing.Size(650, 539);
			this.panelControlContainer.TabIndex = 1;
			// 
			// functionBlockPanel
			// 
			this.functionBlockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.functionBlockPanel.Location = new System.Drawing.Point(0, 100);
			this.functionBlockPanel.Name = "functionBlockPanel";
			this.functionBlockPanel.Size = new System.Drawing.Size(648, 437);
			this.functionBlockPanel.TabIndex = 2;
			// 
			// sourceBlockPanel
			// 
			this.sourceBlockPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.sourceBlockPanel.Location = new System.Drawing.Point(0, 45);
			this.sourceBlockPanel.Name = "sourceBlockPanel";
			this.sourceBlockPanel.Size = new System.Drawing.Size(648, 55);
			this.sourceBlockPanel.TabIndex = 1;
			// 
			// titleBlockPanel
			// 
			this.titleBlockPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.titleBlockPanel.Location = new System.Drawing.Point(0, 0);
			this.titleBlockPanel.Name = "titleBlockPanel";
			this.titleBlockPanel.Size = new System.Drawing.Size(648, 45);
			this.titleBlockPanel.TabIndex = 0;
			// 
			// GLMFileUtilityTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(805, 539);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "GLMFileUtilityTool";
			this.Text = "GLM File Utility Tool";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.buttonPanel2.ResumeLayout(false);
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
		private Controls.CustomButton btnNavProcessMergeTemplates;
	}
}

