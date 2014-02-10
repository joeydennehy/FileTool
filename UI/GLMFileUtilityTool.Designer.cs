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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNavRenameFiles = new UI.Controls.CustomButton();
            this.buttonPanel4 = new System.Windows.Forms.Panel();
            this.btnNavRenameDirectory = new UI.Controls.CustomButton();
            this.buttonPanel3 = new System.Windows.Forms.Panel();
            this.btnNavRemoveDocRecords = new UI.Controls.CustomButton();
            this.buttonPanel2 = new System.Windows.Forms.Panel();
            this.btnNavRemoveDocs = new UI.Controls.CustomButton();
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
            this.panel1.SuspendLayout();
            this.buttonPanel4.SuspendLayout();
            this.buttonPanel3.SuspendLayout();
            this.buttonPanel2.SuspendLayout();
            this.buttonPanel1.SuspendLayout();
            this.panelControlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.buttonPanel4);
            this.splitContainer1.Panel1.Controls.Add(this.buttonPanel3);
            this.splitContainer1.Panel1.Controls.Add(this.buttonPanel2);
            this.splitContainer1.Panel1.Controls.Add(this.buttonPanel1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5, 5, 0, 4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelControlContainer);
            this.splitContainer1.Size = new System.Drawing.Size(1073, 663);
            this.splitContainer1.SplitterDistance = 205;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNavRenameFiles);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 137);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 33);
            this.panel1.TabIndex = 9;
            // 
            // btnNavRenameFiles
            // 
            this.btnNavRenameFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavRenameFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavRenameFiles.Location = new System.Drawing.Point(0, 0);
            this.btnNavRenameFiles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNavRenameFiles.Name = "btnNavRenameFiles";
            this.btnNavRenameFiles.Size = new System.Drawing.Size(200, 28);
            this.btnNavRenameFiles.TabIndex = 4;
            this.btnNavRenameFiles.Text = "Rename Files";
            this.btnNavRenameFiles.UseVisualStyleBackColor = true;
            this.btnNavRenameFiles.Click += new System.EventHandler(this.NavigationButtonClick);
            // 
            // buttonPanel4
            // 
            this.buttonPanel4.Controls.Add(this.btnNavRenameDirectory);
            this.buttonPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPanel4.Location = new System.Drawing.Point(5, 104);
            this.buttonPanel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPanel4.Name = "buttonPanel4";
            this.buttonPanel4.Size = new System.Drawing.Size(200, 33);
            this.buttonPanel4.TabIndex = 8;
            // 
            // btnNavRenameDirectory
            // 
            this.btnNavRenameDirectory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavRenameDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavRenameDirectory.Location = new System.Drawing.Point(0, 0);
            this.btnNavRenameDirectory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNavRenameDirectory.Name = "btnNavRenameDirectory";
            this.btnNavRenameDirectory.Size = new System.Drawing.Size(200, 28);
            this.btnNavRenameDirectory.TabIndex = 3;
            this.btnNavRenameDirectory.Text = "Rename Directories";
            this.btnNavRenameDirectory.UseVisualStyleBackColor = true;
            this.btnNavRenameDirectory.Click += new System.EventHandler(this.NavigationButtonClick);
            // 
            // buttonPanel3
            // 
            this.buttonPanel3.Controls.Add(this.btnNavRemoveDocRecords);
            this.buttonPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPanel3.Location = new System.Drawing.Point(5, 71);
            this.buttonPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPanel3.Name = "buttonPanel3";
            this.buttonPanel3.Size = new System.Drawing.Size(200, 33);
            this.buttonPanel3.TabIndex = 7;
            // 
            // btnNavRemoveDocRecords
            // 
            this.btnNavRemoveDocRecords.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavRemoveDocRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavRemoveDocRecords.Location = new System.Drawing.Point(0, 0);
            this.btnNavRemoveDocRecords.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNavRemoveDocRecords.Name = "btnNavRemoveDocRecords";
            this.btnNavRemoveDocRecords.Size = new System.Drawing.Size(200, 28);
            this.btnNavRemoveDocRecords.TabIndex = 2;
            this.btnNavRemoveDocRecords.Text = "Delete Orphan File Records";
            this.btnNavRemoveDocRecords.UseVisualStyleBackColor = true;
            this.btnNavRemoveDocRecords.Click += new System.EventHandler(this.NavigationButtonClick);
            // 
            // buttonPanel2
            // 
            this.buttonPanel2.Controls.Add(this.btnNavRemoveDocs);
            this.buttonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPanel2.Location = new System.Drawing.Point(5, 38);
            this.buttonPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPanel2.Name = "buttonPanel2";
            this.buttonPanel2.Size = new System.Drawing.Size(200, 33);
            this.buttonPanel2.TabIndex = 6;
            // 
            // btnNavRemoveDocs
            // 
            this.btnNavRemoveDocs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavRemoveDocs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavRemoveDocs.Location = new System.Drawing.Point(0, 0);
            this.btnNavRemoveDocs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNavRemoveDocs.Name = "btnNavRemoveDocs";
            this.btnNavRemoveDocs.Size = new System.Drawing.Size(200, 28);
            this.btnNavRemoveDocs.TabIndex = 1;
            this.btnNavRemoveDocs.Text = "Remove Old Files";
            this.btnNavRemoveDocs.UseVisualStyleBackColor = true;
            this.btnNavRemoveDocs.Click += new System.EventHandler(this.NavigationButtonClick);
            // 
            // buttonPanel1
            // 
            this.buttonPanel1.Controls.Add(this.btnNavFileExtraction);
            this.buttonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPanel1.Location = new System.Drawing.Point(5, 5);
            this.buttonPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPanel1.Name = "buttonPanel1";
            this.buttonPanel1.Size = new System.Drawing.Size(200, 33);
            this.buttonPanel1.TabIndex = 5;
            // 
            // btnNavFileExtraction
            // 
            this.btnNavFileExtraction.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavFileExtraction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavFileExtraction.Location = new System.Drawing.Point(0, 0);
            this.btnNavFileExtraction.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNavFileExtraction.Name = "btnNavFileExtraction";
            this.btnNavFileExtraction.Size = new System.Drawing.Size(200, 28);
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
            this.panelControlContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControlContainer.Name = "panelControlContainer";
            this.panelControlContainer.Size = new System.Drawing.Size(863, 663);
            this.panelControlContainer.TabIndex = 1;
            // 
            // functionBlockPanel
            // 
            this.functionBlockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.functionBlockPanel.Location = new System.Drawing.Point(0, 123);
            this.functionBlockPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.functionBlockPanel.Name = "functionBlockPanel";
            this.functionBlockPanel.Size = new System.Drawing.Size(861, 538);
            this.functionBlockPanel.TabIndex = 2;
            // 
            // sourceBlockPanel
            // 
            this.sourceBlockPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.sourceBlockPanel.Location = new System.Drawing.Point(0, 55);
            this.sourceBlockPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sourceBlockPanel.Name = "sourceBlockPanel";
            this.sourceBlockPanel.Size = new System.Drawing.Size(861, 68);
            this.sourceBlockPanel.TabIndex = 1;
            // 
            // titleBlockPanel
            // 
            this.titleBlockPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBlockPanel.Location = new System.Drawing.Point(0, 0);
            this.titleBlockPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.titleBlockPanel.Name = "titleBlockPanel";
            this.titleBlockPanel.Size = new System.Drawing.Size(861, 55);
            this.titleBlockPanel.TabIndex = 0;
            // 
            // GLMFileUtilityTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 663);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GLMFileUtilityTool";
            this.Text = "GLM File Utility Tool";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.buttonPanel4.ResumeLayout(false);
            this.buttonPanel3.ResumeLayout(false);
            this.buttonPanel2.ResumeLayout(false);
            this.buttonPanel1.ResumeLayout(false);
            this.panelControlContainer.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private UI.Controls.CustomButton btnNavRenameFiles;
		private UI.Controls.CustomButton btnNavRenameDirectory;
		private UI.Controls.CustomButton btnNavRemoveDocRecords;
		private UI.Controls.CustomButton btnNavRemoveDocs;
		private UI.Controls.CustomButton btnNavFileExtraction;
		private System.Windows.Forms.Panel panelControlContainer;
		private System.Windows.Forms.Panel titleBlockPanel;
		public System.Windows.Forms.Panel sourceBlockPanel;
		private System.Windows.Forms.Panel functionBlockPanel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel buttonPanel4;
		private System.Windows.Forms.Panel buttonPanel3;
		private System.Windows.Forms.Panel buttonPanel2;
		private System.Windows.Forms.Panel buttonPanel1;
	}
}

