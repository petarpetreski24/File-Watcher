namespace ProjectFixed
{
    partial class DatabaseConfigurationDLG
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
            this._btnSave = new System.Windows.Forms.Button();
            this._btnClose = new System.Windows.Forms.Button();
            this._grpDatabase = new System.Windows.Forms.GroupBox();
            this._txtDatabase = new System.Windows.Forms.TextBox();
            this._grpServer = new System.Windows.Forms.GroupBox();
            this._txtServer = new System.Windows.Forms.TextBox();
            this._btnLocal = new System.Windows.Forms.Button();
            this._grpDatabase.SuspendLayout();
            this._grpServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(415, 172);
            this._btnSave.Margin = new System.Windows.Forms.Padding(4);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(121, 28);
            this._btnSave.TabIndex = 2;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // _btnClose
            // 
            this._btnClose.Location = new System.Drawing.Point(544, 172);
            this._btnClose.Margin = new System.Windows.Forms.Padding(4);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(121, 28);
            this._btnClose.TabIndex = 3;
            this._btnClose.Text = "Close";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this._btnClose_Click);
            // 
            // _grpDatabase
            // 
            this._grpDatabase.Controls.Add(this._txtDatabase);
            this._grpDatabase.Location = new System.Drawing.Point(24, 86);
            this._grpDatabase.Margin = new System.Windows.Forms.Padding(4);
            this._grpDatabase.Name = "_grpDatabase";
            this._grpDatabase.Padding = new System.Windows.Forms.Padding(4);
            this._grpDatabase.Size = new System.Drawing.Size(368, 52);
            this._grpDatabase.TabIndex = 4;
            this._grpDatabase.TabStop = false;
            this._grpDatabase.Text = "Database:";
            // 
            // _txtDatabase
            // 
            this._txtDatabase.Location = new System.Drawing.Point(8, 20);
            this._txtDatabase.Margin = new System.Windows.Forms.Padding(4);
            this._txtDatabase.Name = "_txtDatabase";
            this._txtDatabase.Size = new System.Drawing.Size(351, 22);
            this._txtDatabase.TabIndex = 5;
            // 
            // _grpServer
            // 
            this._grpServer.Controls.Add(this._txtServer);
            this._grpServer.Location = new System.Drawing.Point(24, 15);
            this._grpServer.Margin = new System.Windows.Forms.Padding(4);
            this._grpServer.Name = "_grpServer";
            this._grpServer.Padding = new System.Windows.Forms.Padding(4);
            this._grpServer.Size = new System.Drawing.Size(368, 52);
            this._grpServer.TabIndex = 5;
            this._grpServer.TabStop = false;
            this._grpServer.Text = "Server";
            // 
            // _txtServer
            // 
            this._txtServer.Location = new System.Drawing.Point(8, 20);
            this._txtServer.Margin = new System.Windows.Forms.Padding(4);
            this._txtServer.Name = "_txtServer";
            this._txtServer.Size = new System.Drawing.Size(351, 22);
            this._txtServer.TabIndex = 6;
            // 
            // _btnLocal
            // 
            this._btnLocal.Location = new System.Drawing.Point(400, 34);
            this._btnLocal.Margin = new System.Windows.Forms.Padding(4);
            this._btnLocal.Name = "_btnLocal";
            this._btnLocal.Size = new System.Drawing.Size(159, 25);
            this._btnLocal.TabIndex = 9;
            this._btnLocal.Text = "Default Value";
            this._btnLocal.UseVisualStyleBackColor = true;
            this._btnLocal.Click += new System.EventHandler(this._btnLocal_Click);
            // 
            // DatabaseConfigurationDLG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 213);
            this.Controls.Add(this._btnLocal);
            this.Controls.Add(this._grpServer);
            this.Controls.Add(this._grpDatabase);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnSave);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DatabaseConfigurationDLG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Server and Database Configuration";
            this._grpDatabase.ResumeLayout(false);
            this._grpDatabase.PerformLayout();
            this._grpServer.ResumeLayout(false);
            this._grpServer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Button _btnClose;
        private System.Windows.Forms.GroupBox _grpDatabase;
        private System.Windows.Forms.TextBox _txtDatabase;
        private System.Windows.Forms.GroupBox _grpServer;
        private System.Windows.Forms.TextBox _txtServer;
        private System.Windows.Forms.Button _btnLocal;
    }
}