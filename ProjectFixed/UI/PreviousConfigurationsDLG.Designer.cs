namespace ProjectFixed
{
    partial class PreviousConfigurationsDLG
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
            this._btnClose = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this._grpFilteredConfigurations = new System.Windows.Forms.GroupBox();
            this._dgvConfigurations = new System.Windows.Forms.DataGridView();
            this._grpVideoExtensions = new System.Windows.Forms.GroupBox();
            this._dgvSelectedConfigVideoExtensions = new System.Windows.Forms.DataGridView();
            this._grpFolders = new System.Windows.Forms.GroupBox();
            this._dgvSelectedConfigFolders = new System.Windows.Forms.DataGridView();
            this._grpFilterParameters = new System.Windows.Forms.GroupBox();
            this._btnFilterData = new System.Windows.Forms.Button();
            this._btnShowAll = new System.Windows.Forms.Button();
            this._lblEndDate = new System.Windows.Forms.Label();
            this._dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this._lblStartDate = new System.Windows.Forms.Label();
            this._dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this._grpPhotoExtensions = new System.Windows.Forms.GroupBox();
            this._dgvSelectedConfigPhotoExtensions = new System.Windows.Forms.DataGridView();
            this._grpFilteredConfigurations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvConfigurations)).BeginInit();
            this._grpVideoExtensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSelectedConfigVideoExtensions)).BeginInit();
            this._grpFolders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSelectedConfigFolders)).BeginInit();
            this._grpFilterParameters.SuspendLayout();
            this._grpPhotoExtensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSelectedConfigPhotoExtensions)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnClose
            // 
            this._btnClose.Location = new System.Drawing.Point(1621, 729);
            this._btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(133, 37);
            this._btnClose.TabIndex = 0;
            this._btnClose.Text = "Close";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this._btnClose_Click);
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(465, 729);
            this._btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(209, 37);
            this._btnSave.TabIndex = 1;
            this._btnSave.Text = "Load selected Configuration";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // _grpFilteredConfigurations
            // 
            this._grpFilteredConfigurations.Controls.Add(this._dgvConfigurations);
            this._grpFilteredConfigurations.Location = new System.Drawing.Point(16, 119);
            this._grpFilteredConfigurations.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._grpFilteredConfigurations.Name = "_grpFilteredConfigurations";
            this._grpFilteredConfigurations.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._grpFilteredConfigurations.Size = new System.Drawing.Size(659, 602);
            this._grpFilteredConfigurations.TabIndex = 3;
            this._grpFilteredConfigurations.TabStop = false;
            this._grpFilteredConfigurations.Text = "Previously used configurations:";
            // 
            // _dgvConfigurations
            // 
            this._dgvConfigurations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvConfigurations.Location = new System.Drawing.Point(8, 30);
            this._dgvConfigurations.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._dgvConfigurations.Name = "_dgvConfigurations";
            this._dgvConfigurations.RowHeadersWidth = 51;
            this._dgvConfigurations.Size = new System.Drawing.Size(643, 565);
            this._dgvConfigurations.TabIndex = 0;
            this._dgvConfigurations.SelectionChanged += new System.EventHandler(this._dgvConfigurations_SelectionChanged);
            // 
            // _grpVideoExtensions
            // 
            this._grpVideoExtensions.Controls.Add(this._dgvSelectedConfigVideoExtensions);
            this._grpVideoExtensions.Location = new System.Drawing.Point(683, 15);
            this._grpVideoExtensions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._grpVideoExtensions.Name = "_grpVideoExtensions";
            this._grpVideoExtensions.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._grpVideoExtensions.Size = new System.Drawing.Size(335, 315);
            this._grpVideoExtensions.TabIndex = 5;
            this._grpVideoExtensions.TabStop = false;
            this._grpVideoExtensions.Text = "Selected configuration\'s active video extensions";
            // 
            // _dgvSelectedConfigVideoExtensions
            // 
            this._dgvSelectedConfigVideoExtensions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvSelectedConfigVideoExtensions.Location = new System.Drawing.Point(7, 30);
            this._dgvSelectedConfigVideoExtensions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._dgvSelectedConfigVideoExtensions.Name = "_dgvSelectedConfigVideoExtensions";
            this._dgvSelectedConfigVideoExtensions.RowHeadersWidth = 51;
            this._dgvSelectedConfigVideoExtensions.Size = new System.Drawing.Size(320, 278);
            this._dgvSelectedConfigVideoExtensions.TabIndex = 0;
            // 
            // _grpFolders
            // 
            this._grpFolders.Controls.Add(this._dgvSelectedConfigFolders);
            this._grpFolders.Location = new System.Drawing.Point(1033, 15);
            this._grpFolders.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._grpFolders.Name = "_grpFolders";
            this._grpFolders.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._grpFolders.Size = new System.Drawing.Size(721, 706);
            this._grpFolders.TabIndex = 6;
            this._grpFolders.TabStop = false;
            this._grpFolders.Text = "Selected configuration\'s monitored folders:";
            // 
            // _dgvSelectedConfigFolders
            // 
            this._dgvSelectedConfigFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvSelectedConfigFolders.Location = new System.Drawing.Point(8, 23);
            this._dgvSelectedConfigFolders.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._dgvSelectedConfigFolders.Name = "_dgvSelectedConfigFolders";
            this._dgvSelectedConfigFolders.RowHeadersWidth = 51;
            this._dgvSelectedConfigFolders.Size = new System.Drawing.Size(705, 676);
            this._dgvSelectedConfigFolders.TabIndex = 0;
            // 
            // _grpFilterParameters
            // 
            this._grpFilterParameters.Controls.Add(this._btnFilterData);
            this._grpFilterParameters.Controls.Add(this._btnShowAll);
            this._grpFilterParameters.Controls.Add(this._lblEndDate);
            this._grpFilterParameters.Controls.Add(this._dtpEndDate);
            this._grpFilterParameters.Controls.Add(this._lblStartDate);
            this._grpFilterParameters.Controls.Add(this._dtpStartDate);
            this._grpFilterParameters.Location = new System.Drawing.Point(16, 15);
            this._grpFilterParameters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._grpFilterParameters.Name = "_grpFilterParameters";
            this._grpFilterParameters.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._grpFilterParameters.Size = new System.Drawing.Size(425, 96);
            this._grpFilterParameters.TabIndex = 8;
            this._grpFilterParameters.TabStop = false;
            this._grpFilterParameters.Text = "Filter Configurations";
            // 
            // _btnFilterData
            // 
            this._btnFilterData.Location = new System.Drawing.Point(312, 55);
            this._btnFilterData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._btnFilterData.Name = "_btnFilterData";
            this._btnFilterData.Size = new System.Drawing.Size(105, 23);
            this._btnFilterData.TabIndex = 5;
            this._btnFilterData.Text = "Filter Button";
            this._btnFilterData.UseVisualStyleBackColor = true;
            this._btnFilterData.Click += new System.EventHandler(this._btnFilterData_Click);
            // 
            // _btnShowAll
            // 
            this._btnShowAll.Location = new System.Drawing.Point(312, 23);
            this._btnShowAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._btnShowAll.Name = "_btnShowAll";
            this._btnShowAll.Size = new System.Drawing.Size(105, 23);
            this._btnShowAll.TabIndex = 4;
            this._btnShowAll.Text = "Show All";
            this._btnShowAll.UseVisualStyleBackColor = true;
            this._btnShowAll.Click += new System.EventHandler(this._btnShowAll_Click);
            // 
            // _lblEndDate
            // 
            this._lblEndDate.AutoSize = true;
            this._lblEndDate.Location = new System.Drawing.Point(8, 61);
            this._lblEndDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblEndDate.Name = "_lblEndDate";
            this._lblEndDate.Size = new System.Drawing.Size(29, 17);
            this._lblEndDate.TabIndex = 3;
            this._lblEndDate.Text = "To:";
            // 
            // _dtpEndDate
            // 
            this._dtpEndDate.Location = new System.Drawing.Point(59, 55);
            this._dtpEndDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._dtpEndDate.Name = "_dtpEndDate";
            this._dtpEndDate.Size = new System.Drawing.Size(244, 22);
            this._dtpEndDate.TabIndex = 2;
            // 
            // _lblStartDate
            // 
            this._lblStartDate.AutoSize = true;
            this._lblStartDate.Location = new System.Drawing.Point(8, 29);
            this._lblStartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblStartDate.Name = "_lblStartDate";
            this._lblStartDate.Size = new System.Drawing.Size(44, 17);
            this._lblStartDate.TabIndex = 1;
            this._lblStartDate.Text = "From:";
            // 
            // _dtpStartDate
            // 
            this._dtpStartDate.Location = new System.Drawing.Point(59, 23);
            this._dtpStartDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._dtpStartDate.Name = "_dtpStartDate";
            this._dtpStartDate.Size = new System.Drawing.Size(244, 22);
            this._dtpStartDate.TabIndex = 0;
            // 
            // _grpPhotoExtensions
            // 
            this._grpPhotoExtensions.Controls.Add(this._dgvSelectedConfigPhotoExtensions);
            this._grpPhotoExtensions.Location = new System.Drawing.Point(683, 337);
            this._grpPhotoExtensions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._grpPhotoExtensions.Name = "_grpPhotoExtensions";
            this._grpPhotoExtensions.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._grpPhotoExtensions.Size = new System.Drawing.Size(335, 384);
            this._grpPhotoExtensions.TabIndex = 6;
            this._grpPhotoExtensions.TabStop = false;
            this._grpPhotoExtensions.Text = "Selected configuration\'s active photo extensions";
            // 
            // _dgvSelectedConfigPhotoExtensions
            // 
            this._dgvSelectedConfigPhotoExtensions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvSelectedConfigPhotoExtensions.Location = new System.Drawing.Point(7, 30);
            this._dgvSelectedConfigPhotoExtensions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._dgvSelectedConfigPhotoExtensions.Name = "_dgvSelectedConfigPhotoExtensions";
            this._dgvSelectedConfigPhotoExtensions.RowHeadersWidth = 51;
            this._dgvSelectedConfigPhotoExtensions.Size = new System.Drawing.Size(320, 347);
            this._dgvSelectedConfigPhotoExtensions.TabIndex = 0;
            // 
            // PreviousConfigurationsDLG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1771, 780);
            this.Controls.Add(this._grpPhotoExtensions);
            this.Controls.Add(this._grpFilterParameters);
            this.Controls.Add(this._grpFolders);
            this.Controls.Add(this._grpVideoExtensions);
            this.Controls.Add(this._grpFilteredConfigurations);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._btnClose);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PreviousConfigurationsDLG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Previous Configurations Loader";
            this._grpFilteredConfigurations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvConfigurations)).EndInit();
            this._grpVideoExtensions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvSelectedConfigVideoExtensions)).EndInit();
            this._grpFolders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvSelectedConfigFolders)).EndInit();
            this._grpFilterParameters.ResumeLayout(false);
            this._grpFilterParameters.PerformLayout();
            this._grpPhotoExtensions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvSelectedConfigPhotoExtensions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnClose;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.GroupBox _grpFilteredConfigurations;
        private System.Windows.Forms.GroupBox _grpVideoExtensions;
        private System.Windows.Forms.GroupBox _grpFolders;
        private System.Windows.Forms.DataGridView _dgvConfigurations;
        private System.Windows.Forms.GroupBox _grpFilterParameters;
        private System.Windows.Forms.Button _btnFilterData;
        private System.Windows.Forms.Button _btnShowAll;
        private System.Windows.Forms.Label _lblEndDate;
        private System.Windows.Forms.DateTimePicker _dtpEndDate;
        private System.Windows.Forms.Label _lblStartDate;
        private System.Windows.Forms.DateTimePicker _dtpStartDate;
        private System.Windows.Forms.DataGridView _dgvSelectedConfigVideoExtensions;
        private System.Windows.Forms.GroupBox _grpPhotoExtensions;
        private System.Windows.Forms.DataGridView _dgvSelectedConfigPhotoExtensions;
        private System.Windows.Forms.DataGridView _dgvSelectedConfigFolders;
    }
}