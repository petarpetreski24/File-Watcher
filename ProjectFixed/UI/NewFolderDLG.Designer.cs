namespace ProjectFixed
{
    partial class NewFolderDLG
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
            this._lblCameraName = new System.Windows.Forms.Label();
            this._lblFolderName = new System.Windows.Forms.Label();
            this._txtCameraNameInput = new System.Windows.Forms.TextBox();
            this._txtFolderPathInput = new System.Windows.Forms.TextBox();
            this._btnFolderBrowser = new System.Windows.Forms.Button();
            this._grpVideoExtensions = new System.Windows.Forms.GroupBox();
            this._lvwAvailableVideoExtensions = new System.Windows.Forms.ListView();
            this._grpPhotoExtensions = new System.Windows.Forms.GroupBox();
            this._lvwAvailablePhotoExtensions = new System.Windows.Forms.ListView();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnDiscard = new System.Windows.Forms.Button();
            this._grpVideoExtensions.SuspendLayout();
            this._grpPhotoExtensions.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lblCameraName
            // 
            this._lblCameraName.AutoSize = true;
            this._lblCameraName.Location = new System.Drawing.Point(44, 36);
            this._lblCameraName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblCameraName.Name = "_lblCameraName";
            this._lblCameraName.Size = new System.Drawing.Size(61, 17);
            this._lblCameraName.TabIndex = 0;
            this._lblCameraName.Text = "Camera:";
            // 
            // _lblFolderName
            // 
            this._lblFolderName.AutoSize = true;
            this._lblFolderName.Location = new System.Drawing.Point(53, 69);
            this._lblFolderName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblFolderName.Name = "_lblFolderName";
            this._lblFolderName.Size = new System.Drawing.Size(52, 17);
            this._lblFolderName.TabIndex = 1;
            this._lblFolderName.Text = "Folder:";
            // 
            // _txtCameraNameInput
            // 
            this._txtCameraNameInput.Location = new System.Drawing.Point(113, 32);
            this._txtCameraNameInput.Margin = new System.Windows.Forms.Padding(4);
            this._txtCameraNameInput.Name = "_txtCameraNameInput";
            this._txtCameraNameInput.Size = new System.Drawing.Size(131, 22);
            this._txtCameraNameInput.TabIndex = 2;
            this._txtCameraNameInput.TextChanged += new System.EventHandler(this._txtCameraNameInput_TextChanged);
            // 
            // _txtFolderPathInput
            // 
            this._txtFolderPathInput.Location = new System.Drawing.Point(113, 65);
            this._txtFolderPathInput.Margin = new System.Windows.Forms.Padding(4);
            this._txtFolderPathInput.Name = "_txtFolderPathInput";
            this._txtFolderPathInput.ReadOnly = true;
            this._txtFolderPathInput.Size = new System.Drawing.Size(541, 22);
            this._txtFolderPathInput.TabIndex = 3;
            // 
            // _btnFolderBrowser
            // 
            this._btnFolderBrowser.Location = new System.Drawing.Point(664, 65);
            this._btnFolderBrowser.Margin = new System.Windows.Forms.Padding(4);
            this._btnFolderBrowser.Name = "_btnFolderBrowser";
            this._btnFolderBrowser.Size = new System.Drawing.Size(112, 25);
            this._btnFolderBrowser.TabIndex = 4;
            this._btnFolderBrowser.Text = "Browse";
            this._btnFolderBrowser.UseVisualStyleBackColor = true;
            this._btnFolderBrowser.Click += new System.EventHandler(this._btnFolderBrowser_Click);
            // 
            // _grpVideoExtensions
            // 
            this._grpVideoExtensions.Controls.Add(this._lvwAvailableVideoExtensions);
            this._grpVideoExtensions.Location = new System.Drawing.Point(48, 121);
            this._grpVideoExtensions.Margin = new System.Windows.Forms.Padding(4);
            this._grpVideoExtensions.Name = "_grpVideoExtensions";
            this._grpVideoExtensions.Padding = new System.Windows.Forms.Padding(4);
            this._grpVideoExtensions.Size = new System.Drawing.Size(253, 231);
            this._grpVideoExtensions.TabIndex = 5;
            this._grpVideoExtensions.TabStop = false;
            this._grpVideoExtensions.Text = "Available Video Extensions:";
            // 
            // _lvwAvailableVideoExtensions
            // 
            this._lvwAvailableVideoExtensions.HideSelection = false;
            this._lvwAvailableVideoExtensions.Location = new System.Drawing.Point(9, 21);
            this._lvwAvailableVideoExtensions.Margin = new System.Windows.Forms.Padding(4);
            this._lvwAvailableVideoExtensions.Name = "_lvwAvailableVideoExtensions";
            this._lvwAvailableVideoExtensions.Size = new System.Drawing.Size(235, 202);
            this._lvwAvailableVideoExtensions.TabIndex = 0;
            this._lvwAvailableVideoExtensions.UseCompatibleStateImageBehavior = false;
            // 
            // _grpPhotoExtensions
            // 
            this._grpPhotoExtensions.Controls.Add(this._lvwAvailablePhotoExtensions);
            this._grpPhotoExtensions.Location = new System.Drawing.Point(309, 121);
            this._grpPhotoExtensions.Margin = new System.Windows.Forms.Padding(4);
            this._grpPhotoExtensions.Name = "_grpPhotoExtensions";
            this._grpPhotoExtensions.Padding = new System.Windows.Forms.Padding(4);
            this._grpPhotoExtensions.Size = new System.Drawing.Size(253, 231);
            this._grpPhotoExtensions.TabIndex = 6;
            this._grpPhotoExtensions.TabStop = false;
            this._grpPhotoExtensions.Text = "Available Photo Extensions:";
            // 
            // _lvwAvailablePhotoExtensions
            // 
            this._lvwAvailablePhotoExtensions.HideSelection = false;
            this._lvwAvailablePhotoExtensions.Location = new System.Drawing.Point(9, 21);
            this._lvwAvailablePhotoExtensions.Margin = new System.Windows.Forms.Padding(4);
            this._lvwAvailablePhotoExtensions.Name = "_lvwAvailablePhotoExtensions";
            this._lvwAvailablePhotoExtensions.Size = new System.Drawing.Size(235, 202);
            this._lvwAvailablePhotoExtensions.TabIndex = 1;
            this._lvwAvailablePhotoExtensions.UseCompatibleStateImageBehavior = false;
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(619, 318);
            this._btnSave.Margin = new System.Windows.Forms.Padding(4);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(119, 34);
            this._btnSave.TabIndex = 7;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // _btnDiscard
            // 
            this._btnDiscard.Location = new System.Drawing.Point(745, 318);
            this._btnDiscard.Margin = new System.Windows.Forms.Padding(4);
            this._btnDiscard.Name = "_btnDiscard";
            this._btnDiscard.Size = new System.Drawing.Size(119, 34);
            this._btnDiscard.TabIndex = 8;
            this._btnDiscard.Text = "Discard";
            this._btnDiscard.UseVisualStyleBackColor = true;
            this._btnDiscard.Click += new System.EventHandler(this._btnDiscard_Click);
            // 
            // NewFolderDLG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 367);
            this.Controls.Add(this._btnDiscard);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._grpPhotoExtensions);
            this.Controls.Add(this._grpVideoExtensions);
            this.Controls.Add(this._btnFolderBrowser);
            this.Controls.Add(this._txtFolderPathInput);
            this.Controls.Add(this._txtCameraNameInput);
            this.Controls.Add(this._lblFolderName);
            this.Controls.Add(this._lblCameraName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NewFolderDLG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NewFolderDLG";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewFolderDLG_FormClosing);
            this._grpVideoExtensions.ResumeLayout(false);
            this._grpPhotoExtensions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblCameraName;
        private System.Windows.Forms.Label _lblFolderName;
        private System.Windows.Forms.TextBox _txtCameraNameInput;
        private System.Windows.Forms.TextBox _txtFolderPathInput;
        private System.Windows.Forms.Button _btnFolderBrowser;
        private System.Windows.Forms.GroupBox _grpVideoExtensions;
        private System.Windows.Forms.ListView _lvwAvailableVideoExtensions;
        private System.Windows.Forms.GroupBox _grpPhotoExtensions;
        private System.Windows.Forms.ListView _lvwAvailablePhotoExtensions;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Button _btnDiscard;
    }
}