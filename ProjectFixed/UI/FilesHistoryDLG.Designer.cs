using System.Windows.Forms;

namespace ProjectFixed
{
    partial class FilesHistoryDLG
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
            this._lvwDataHistory = new System.Windows.Forms.ListView();
            this._dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this._dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this._btnFilterData = new System.Windows.Forms.Button();
            this._lblStartDate = new System.Windows.Forms.Label();
            this._lblEndDate = new System.Windows.Forms.Label();
            this._grpTimeConfiguration = new System.Windows.Forms.GroupBox();
            this._btnShowAll = new System.Windows.Forms.Button();
            this._grpTimeConfiguration.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lvwDataHistory
            // 
            this._lvwDataHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lvwDataHistory.HideSelection = false;
            this._lvwDataHistory.Location = new System.Drawing.Point(19, 106);
            this._lvwDataHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._lvwDataHistory.Name = "_lvwDataHistory";
            this._lvwDataHistory.Size = new System.Drawing.Size(999, 403);
            this._lvwDataHistory.TabIndex = 0;
            this._lvwDataHistory.UseCompatibleStateImageBehavior = false;
            this._lvwDataHistory.MouseDoubleClick += new MouseEventHandler(_lvwDataHistory_MouseDoubleClick);
            // 
            // _dtpStartDate
            // 
            this._dtpStartDate.Location = new System.Drawing.Point(165, 23);
            this._dtpStartDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._dtpStartDate.Name = "_dtpStartDate";
            this._dtpStartDate.Size = new System.Drawing.Size(223, 22);
            this._dtpStartDate.TabIndex = 1;
            // 
            // _dtpEndDate
            // 
            this._dtpEndDate.Location = new System.Drawing.Point(165, 50);
            this._dtpEndDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._dtpEndDate.Name = "_dtpEndDate";
            this._dtpEndDate.Size = new System.Drawing.Size(223, 22);
            this._dtpEndDate.TabIndex = 2;
            // 
            // _btnFilterData
            // 
            this._btnFilterData.Location = new System.Drawing.Point(19, 47);
            this._btnFilterData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._btnFilterData.Name = "_btnFilterData";
            this._btnFilterData.Size = new System.Drawing.Size(147, 53);
            this._btnFilterData.TabIndex = 3;
            this._btnFilterData.Text = "Filter Data";
            this._btnFilterData.UseVisualStyleBackColor = true;
            this._btnFilterData.Click += new System.EventHandler(this._btnFilterData_Click);
            // 
            // _lblStartDate
            // 
            this._lblStartDate.AutoSize = true;
            this._lblStartDate.Location = new System.Drawing.Point(84, 23);
            this._lblStartDate.Name = "_lblStartDate";
            this._lblStartDate.Size = new System.Drawing.Size(76, 17);
            this._lblStartDate.TabIndex = 4;
            this._lblStartDate.Text = "Start Date:";
            // 
            // _lblEndDate
            // 
            this._lblEndDate.AutoSize = true;
            this._lblEndDate.Location = new System.Drawing.Point(88, 54);
            this._lblEndDate.Name = "_lblEndDate";
            this._lblEndDate.Size = new System.Drawing.Size(71, 17);
            this._lblEndDate.TabIndex = 5;
            this._lblEndDate.Text = "End Date:";
            // 
            // _grpTimeConfiguration
            // 
            this._grpTimeConfiguration.Controls.Add(this._lblEndDate);
            this._grpTimeConfiguration.Controls.Add(this._lblStartDate);
            this._grpTimeConfiguration.Controls.Add(this._dtpEndDate);
            this._grpTimeConfiguration.Controls.Add(this._dtpStartDate);
            this._grpTimeConfiguration.Location = new System.Drawing.Point(613, 14);
            this._grpTimeConfiguration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._grpTimeConfiguration.Name = "_grpTimeConfiguration";
            this._grpTimeConfiguration.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._grpTimeConfiguration.Size = new System.Drawing.Size(403, 86);
            this._grpTimeConfiguration.TabIndex = 6;
            this._grpTimeConfiguration.TabStop = false;
            this._grpTimeConfiguration.Text = "Time configuration";
            // 
            // _btnShowAll
            // 
            this._btnShowAll.Location = new System.Drawing.Point(19, 16);
            this._btnShowAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._btnShowAll.Name = "_btnShowAll";
            this._btnShowAll.Size = new System.Drawing.Size(147, 25);
            this._btnShowAll.TabIndex = 7;
            this._btnShowAll.Text = "Show All";
            this._btnShowAll.UseVisualStyleBackColor = true;
            this._btnShowAll.Click += new System.EventHandler(this._btnShowAll_Click);
            // 
            // FilesHistoryDLG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 540);
            this.Controls.Add(this._btnShowAll);
            this.Controls.Add(this._grpTimeConfiguration);
            this.Controls.Add(this._btnFilterData);
            this.Controls.Add(this._lvwDataHistory);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FilesHistoryDLG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Files History";
            this._grpTimeConfiguration.ResumeLayout(false);
            this._grpTimeConfiguration.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _lvwDataHistory;
        private System.Windows.Forms.DateTimePicker _dtpStartDate;
        private System.Windows.Forms.DateTimePicker _dtpEndDate;
        private System.Windows.Forms.Button _btnFilterData;
        private System.Windows.Forms.Label _lblStartDate;
        private System.Windows.Forms.Label _lblEndDate;
        private System.Windows.Forms.GroupBox _grpTimeConfiguration;
        private System.Windows.Forms.Button _btnShowAll;
    }
}