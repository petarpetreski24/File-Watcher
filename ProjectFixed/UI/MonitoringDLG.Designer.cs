namespace ProjectFixed
{
    partial class MonitoringDLG
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
            this._lvwRecordedFiles = new System.Windows.Forms.ListView();
            this._btnStart = new System.Windows.Forms.Button();
            this._btnStop = new System.Windows.Forms.Button();
            this._lblStatus = new System.Windows.Forms.Label();
            this._btnConfigure = new System.Windows.Forms.Button();
            this._btnHistory = new System.Windows.Forms.Button();
            this._grpStartControls = new System.Windows.Forms.GroupBox();
            this._grpInterfaceList = new System.Windows.Forms.GroupBox();
            this._btnPreviousConfigs = new System.Windows.Forms.Button();
            this._btnDatabaseConfig = new System.Windows.Forms.Button();
            this._grpStartControls.SuspendLayout();
            this._grpInterfaceList.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lvwRecordedFiles
            // 
            this._lvwRecordedFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._lvwRecordedFiles.HideSelection = false;
            this._lvwRecordedFiles.Location = new System.Drawing.Point(11, 18);
            this._lvwRecordedFiles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._lvwRecordedFiles.Name = "_lvwRecordedFiles";
            this._lvwRecordedFiles.Size = new System.Drawing.Size(707, 258);
            this._lvwRecordedFiles.TabIndex = 0;
            this._lvwRecordedFiles.UseCompatibleStateImageBehavior = false;
            this._lvwRecordedFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._lvwRecordedFiles_MouseDoubleClick);
            // 
            // _btnStart
            // 
            this._btnStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._btnStart.Location = new System.Drawing.Point(20, 18);
            this._btnStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(65, 19);
            this._btnStart.TabIndex = 1;
            this._btnStart.Text = "Start";
            this._btnStart.UseVisualStyleBackColor = true;
            this._btnStart.Click += new System.EventHandler(this._btnStart_Click);
            // 
            // _btnStop
            // 
            this._btnStop.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._btnStop.Location = new System.Drawing.Point(20, 41);
            this._btnStop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._btnStop.Name = "_btnStop";
            this._btnStop.Size = new System.Drawing.Size(65, 19);
            this._btnStop.TabIndex = 2;
            this._btnStop.Text = "Stop";
            this._btnStop.UseVisualStyleBackColor = true;
            this._btnStop.Click += new System.EventHandler(this._btnStop_Click);
            // 
            // _lblStatus
            // 
            this._lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._lblStatus.AutoSize = true;
            this._lblStatus.BackColor = System.Drawing.SystemColors.ControlLight;
            this._lblStatus.ForeColor = System.Drawing.Color.Red;
            this._lblStatus.Location = new System.Drawing.Point(17, 68);
            this._lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(79, 13);
            this._lblStatus.TabIndex = 3;
            this._lblStatus.Text = "Status: Paused";
            this._lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _btnConfigure
            // 
            this._btnConfigure.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._btnConfigure.Location = new System.Drawing.Point(619, 15);
            this._btnConfigure.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._btnConfigure.Name = "_btnConfigure";
            this._btnConfigure.Size = new System.Drawing.Size(125, 37);
            this._btnConfigure.TabIndex = 4;
            this._btnConfigure.Text = "Configure Monitored Folders";
            this._btnConfigure.UseVisualStyleBackColor = true;
            this._btnConfigure.Click += new System.EventHandler(this._btnConfigure_Click);
            // 
            // _btnHistory
            // 
            this._btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnHistory.Location = new System.Drawing.Point(621, 430);
            this._btnHistory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._btnHistory.Name = "_btnHistory";
            this._btnHistory.Size = new System.Drawing.Size(124, 27);
            this._btnHistory.TabIndex = 5;
            this._btnHistory.Text = "Monitoring History";
            this._btnHistory.UseVisualStyleBackColor = true;
            this._btnHistory.Click += new System.EventHandler(this._btnHistory_Click);
            // 
            // _grpStartControls
            // 
            this._grpStartControls.Controls.Add(this._btnStop);
            this._grpStartControls.Controls.Add(this._btnStart);
            this._grpStartControls.Controls.Add(this._lblStatus);
            this._grpStartControls.Location = new System.Drawing.Point(32, 15);
            this._grpStartControls.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._grpStartControls.Name = "_grpStartControls";
            this._grpStartControls.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._grpStartControls.Size = new System.Drawing.Size(177, 95);
            this._grpStartControls.TabIndex = 6;
            this._grpStartControls.TabStop = false;
            this._grpStartControls.Text = "Activation";
            // 
            // _grpInterfaceList
            // 
            this._grpInterfaceList.BackColor = System.Drawing.SystemColors.ControlLight;
            this._grpInterfaceList.Controls.Add(this._lvwRecordedFiles);
            this._grpInterfaceList.Location = new System.Drawing.Point(17, 140);
            this._grpInterfaceList.Name = "_grpInterfaceList";
            this._grpInterfaceList.Size = new System.Drawing.Size(728, 285);
            this._grpInterfaceList.TabIndex = 7;
            this._grpInterfaceList.TabStop = false;
            this._grpInterfaceList.Text = "Files that have been recorded since the program has started:";
            // 
            // _btnPreviousConfigs
            // 
            this._btnPreviousConfigs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._btnPreviousConfigs.Location = new System.Drawing.Point(619, 55);
            this._btnPreviousConfigs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._btnPreviousConfigs.Name = "_btnPreviousConfigs";
            this._btnPreviousConfigs.Size = new System.Drawing.Size(125, 37);
            this._btnPreviousConfigs.TabIndex = 8;
            this._btnPreviousConfigs.Text = "Configurations Loader";
            this._btnPreviousConfigs.UseVisualStyleBackColor = true;
            this._btnPreviousConfigs.Click += new System.EventHandler(this._btnPreviousConfigs_Click);
            // 
            // _btnDatabaseConfig
            // 
            this._btnDatabaseConfig.Location = new System.Drawing.Point(619, 97);
            this._btnDatabaseConfig.Name = "_btnDatabaseConfig";
            this._btnDatabaseConfig.Size = new System.Drawing.Size(126, 25);
            this._btnDatabaseConfig.TabIndex = 9;
            this._btnDatabaseConfig.Text = "Database Configuration";
            this._btnDatabaseConfig.UseVisualStyleBackColor = true;
            this._btnDatabaseConfig.Click += new System.EventHandler(this._btnDatabaseConfig_Click);
            // 
            // MonitoringDLG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 462);
            this.Controls.Add(this._btnDatabaseConfig);
            this.Controls.Add(this._btnPreviousConfigs);
            this.Controls.Add(this._grpInterfaceList);
            this.Controls.Add(this._grpStartControls);
            this.Controls.Add(this._btnHistory);
            this.Controls.Add(this._btnConfigure);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MonitoringDLG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitoring Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MonitoringDLG_FormClosing);
            this._grpStartControls.ResumeLayout(false);
            this._grpStartControls.PerformLayout();
            this._grpInterfaceList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _lvwRecordedFiles;
        private System.Windows.Forms.Button _btnStart;
        private System.Windows.Forms.Button _btnStop;
        private System.Windows.Forms.Label _lblStatus;
        private System.Windows.Forms.Button _btnConfigure;
        private System.Windows.Forms.Button _btnHistory;
        private System.Windows.Forms.GroupBox _grpStartControls;
        private System.Windows.Forms.GroupBox _grpInterfaceList;
        private System.Windows.Forms.Button _btnPreviousConfigs;
        private System.Windows.Forms.Button _btnDatabaseConfig;
    }
}

