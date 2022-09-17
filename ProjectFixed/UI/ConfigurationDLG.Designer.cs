namespace ProjectFixed
{
    partial class ConfigurationDLG
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationDLG));
            this._btnAdd = new System.Windows.Forms.Button();
            this._btnDelete = new System.Windows.Forms.Button();
            this._btnClear = new System.Windows.Forms.Button();
            this._lvwActiveFolders = new System.Windows.Forms.ListView();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnClose = new System.Windows.Forms.Button();
            this._lblInfo = new System.Windows.Forms.Label();
            this._grpFolders = new System.Windows.Forms.GroupBox();
            this._picInfo = new System.Windows.Forms.PictureBox();
            this._dgvVideoExtensions = new System.Windows.Forms.DataGridView();
            this._dgvPhotoExtensions = new System.Windows.Forms.DataGridView();
            this._mnsDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._grpExtensions = new System.Windows.Forms.GroupBox();
            this._btnEdit = new System.Windows.Forms.Button();
            this._grpFolders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvVideoExtensions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvPhotoExtensions)).BeginInit();
            this._mnsDelete.SuspendLayout();
            this._grpExtensions.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnAdd
            // 
            this._btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._btnAdd.Location = new System.Drawing.Point(257, 560);
            this._btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(185, 25);
            this._btnAdd.TabIndex = 2;
            this._btnAdd.Text = "Add a new folder";
            this._btnAdd.UseVisualStyleBackColor = true;
            this._btnAdd.Click += new System.EventHandler(this._btnAdd_Click);
            // 
            // _btnDelete
            // 
            this._btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._btnDelete.Location = new System.Drawing.Point(639, 560);
            this._btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(185, 25);
            this._btnDelete.TabIndex = 3;
            this._btnDelete.Text = "Delete the selected folder";
            this._btnDelete.UseVisualStyleBackColor = true;
            this._btnDelete.Click += new System.EventHandler(this._btnDelete_Click);
            // 
            // _btnClear
            // 
            this._btnClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._btnClear.Location = new System.Drawing.Point(448, 560);
            this._btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._btnClear.Name = "_btnClear";
            this._btnClear.Size = new System.Drawing.Size(185, 25);
            this._btnClear.TabIndex = 4;
            this._btnClear.Text = "Clear Monitored Folders";
            this._btnClear.UseVisualStyleBackColor = true;
            this._btnClear.Click += new System.EventHandler(this._btnClear_Click);
            // 
            // _lvwActiveFolders
            // 
            this._lvwActiveFolders.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._lvwActiveFolders.HideSelection = false;
            this._lvwActiveFolders.Location = new System.Drawing.Point(8, 25);
            this._lvwActiveFolders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._lvwActiveFolders.MultiSelect = false;
            this._lvwActiveFolders.Name = "_lvwActiveFolders";
            this._lvwActiveFolders.Size = new System.Drawing.Size(540, 490);
            this._lvwActiveFolders.TabIndex = 5;
            this._lvwActiveFolders.UseCompatibleStateImageBehavior = false;
            this._lvwActiveFolders.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._lvwActiveFolders_MouseDoubleClick);
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._btnSave.Location = new System.Drawing.Point(516, 635);
            this._btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(148, 42);
            this._btnSave.TabIndex = 6;
            this._btnSave.Text = "OK";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._btnClose.Location = new System.Drawing.Point(673, 635);
            this._btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(148, 42);
            this._btnClose.TabIndex = 9;
            this._btnClose.Text = "Close";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this._btnClose_Click);
            // 
            // _lblInfo
            // 
            this._lblInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._lblInfo.AutoSize = true;
            this._lblInfo.Location = new System.Drawing.Point(40, 518);
            this._lblInfo.Name = "_lblInfo";
            this._lblInfo.Size = new System.Drawing.Size(263, 17);
            this._lblInfo.TabIndex = 16;
            this._lblInfo.Text = "If you want to edit a folder, double click it";
            // 
            // _grpFolders
            // 
            this._grpFolders.BackColor = System.Drawing.SystemColors.ControlLight;
            this._grpFolders.Controls.Add(this._picInfo);
            this._grpFolders.Controls.Add(this._lblInfo);
            this._grpFolders.Controls.Add(this._lvwActiveFolders);
            this._grpFolders.Location = new System.Drawing.Point(15, 14);
            this._grpFolders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._grpFolders.Name = "_grpFolders";
            this._grpFolders.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._grpFolders.Size = new System.Drawing.Size(559, 542);
            this._grpFolders.TabIndex = 19;
            this._grpFolders.TabStop = false;
            this._grpFolders.Text = "Currently monitored folders";
            // 
            // _picInfo
            // 
            this._picInfo.Image = ((System.Drawing.Image)(resources.GetObject("_picInfo.Image")));
            this._picInfo.Location = new System.Drawing.Point(8, 517);
            this._picInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._picInfo.Name = "_picInfo";
            this._picInfo.Size = new System.Drawing.Size(27, 21);
            this._picInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._picInfo.TabIndex = 17;
            this._picInfo.TabStop = false;
            // 
            // _dgvVideoExtensions
            // 
            this._dgvVideoExtensions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._dgvVideoExtensions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvVideoExtensions.Location = new System.Drawing.Point(24, 25);
            this._dgvVideoExtensions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._dgvVideoExtensions.Name = "_dgvVideoExtensions";
            this._dgvVideoExtensions.RowHeadersWidth = 51;
            this._dgvVideoExtensions.RowTemplate.Height = 24;
            this._dgvVideoExtensions.Size = new System.Drawing.Size(197, 223);
            this._dgvVideoExtensions.TabIndex = 23;
            this._dgvVideoExtensions.VirtualMode = true;
            this._dgvVideoExtensions.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._dgvVideoExtensions_CellMouseUp);
            // 
            // _dgvPhotoExtensions
            // 
            this._dgvPhotoExtensions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._dgvPhotoExtensions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvPhotoExtensions.Location = new System.Drawing.Point(24, 293);
            this._dgvPhotoExtensions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._dgvPhotoExtensions.Name = "_dgvPhotoExtensions";
            this._dgvPhotoExtensions.RowHeadersWidth = 51;
            this._dgvPhotoExtensions.RowTemplate.Height = 24;
            this._dgvPhotoExtensions.Size = new System.Drawing.Size(197, 223);
            this._dgvPhotoExtensions.TabIndex = 24;
            this._dgvPhotoExtensions.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._dgvPhotoExtensions_CellMouseUp);
            // 
            // _mnsDelete
            // 
            this._mnsDelete.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._mnsDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this._mnsDelete.Name = "deleteMenuStrip";
            this._mnsDelete.Size = new System.Drawing.Size(211, 56);
            this._mnsDelete.Click += new System.EventHandler(this._mnsDelete_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // _grpExtensions
            // 
            this._grpExtensions.BackColor = System.Drawing.SystemColors.ControlLight;
            this._grpExtensions.Controls.Add(this._dgvPhotoExtensions);
            this._grpExtensions.Controls.Add(this._dgvVideoExtensions);
            this._grpExtensions.Location = new System.Drawing.Point(581, 14);
            this._grpExtensions.Margin = new System.Windows.Forms.Padding(4);
            this._grpExtensions.Name = "_grpExtensions";
            this._grpExtensions.Padding = new System.Windows.Forms.Padding(4);
            this._grpExtensions.Size = new System.Drawing.Size(240, 540);
            this._grpExtensions.TabIndex = 25;
            this._grpExtensions.TabStop = false;
            this._grpExtensions.Text = "Current extensions in use";
            // 
            // _btnEdit
            // 
            this._btnEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._btnEdit.Location = new System.Drawing.Point(67, 560);
            this._btnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._btnEdit.Name = "_btnEdit";
            this._btnEdit.Size = new System.Drawing.Size(185, 25);
            this._btnEdit.TabIndex = 28;
            this._btnEdit.Text = "Edit selected folder";
            this._btnEdit.UseVisualStyleBackColor = true;
            this._btnEdit.Click += new System.EventHandler(this._btnEdit_Click);
            // 
            // ConfigurationDLG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 690);
            this.Controls.Add(this._btnEdit);
            this.Controls.Add(this._btnClear);
            this.Controls.Add(this._btnDelete);
            this.Controls.Add(this._btnAdd);
            this.Controls.Add(this._grpExtensions);
            this.Controls.Add(this._grpFolders);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._btnClose);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ConfigurationDLG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this._grpFolders.ResumeLayout(false);
            this._grpFolders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvVideoExtensions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvPhotoExtensions)).EndInit();
            this._mnsDelete.ResumeLayout(false);
            this._grpExtensions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _btnAdd;
        private System.Windows.Forms.Button _btnDelete;
        private System.Windows.Forms.Button _btnClear;
        private System.Windows.Forms.ListView _lvwActiveFolders;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Button _btnClose;
        private System.Windows.Forms.Label _lblInfo;
        private System.Windows.Forms.GroupBox _grpFolders;
        private System.Windows.Forms.PictureBox _picInfo;
        private System.Windows.Forms.DataGridView _dgvVideoExtensions;
        private System.Windows.Forms.DataGridView _dgvPhotoExtensions;
        private System.Windows.Forms.ContextMenuStrip _mnsDelete;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.GroupBox _grpExtensions;
        private System.Windows.Forms.Button _btnEdit;
    }
}