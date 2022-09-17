using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectFixed.Config;

namespace ProjectFixed
{
    public partial class NewFolderDLG : Form
    {
        #region fields and constructor
        bool _cameraAndFolderEdit = false;
        private FolderConfiguration _possibleFolder;
        public FolderConfiguration NewFolder {get{ return _possibleFolder; } }
        public NewFolderDLG(IReadOnlyList<string> videoExtensions,IReadOnlyList<string> photoExtensions, FolderConfiguration toChange = null)
        {
            InitializeComponent();
            if (toChange==null)
            {
                _possibleFolder = new FolderConfiguration();
            }
            else
            {
                _possibleFolder = new FolderConfiguration(toChange);
            }
            _lvwAvailableVideoExtensions.View = View.Details;
            _lvwAvailableVideoExtensions.GridLines = true;
            _lvwAvailableVideoExtensions.FullRowSelect = true;
            _lvwAvailableVideoExtensions.CheckBoxes = true;
            _lvwAvailableVideoExtensions.Columns.Add("Video Extensions",172);

            _lvwAvailablePhotoExtensions.View = View.Details;
            _lvwAvailablePhotoExtensions.GridLines = true;
            _lvwAvailablePhotoExtensions.FullRowSelect = true;
            _lvwAvailablePhotoExtensions.CheckBoxes = true;
            _lvwAvailablePhotoExtensions.Columns.Add("Photo Extensions",172);

            foreach (string s in videoExtensions)
            {
                _lvwAvailableVideoExtensions.Items.Add(s);
            }
            foreach (string s in photoExtensions)
            {
                _lvwAvailablePhotoExtensions.Items.Add(s);
            }
            if(_possibleFolder.Camera.Length!=0)
            {
                foreach(ListViewItem li in _lvwAvailableVideoExtensions.Items)
                {
                    if (_possibleFolder.VideoExtensionsList.Contains(li.SubItems[0].Text))
                    {
                        li.Checked = true;
                    }
                }
                foreach (ListViewItem li in _lvwAvailablePhotoExtensions.Items)
                {
                    if (_possibleFolder.PhotoExtensionsList.Contains(li.SubItems[0].Text))
                    {
                        li.Checked = true;
                    }
                }
                _txtCameraNameInput.Text = toChange.Camera;
                _txtFolderPathInput.Text = toChange.FolderPath;
                _txtFolderPathInput.ReadOnly = true;
            }
        }
        #endregion
        #region event handlers
        private void _btnFolderBrowser_Click(object sender, EventArgs e)
        {
            try
            {
                _cameraAndFolderEdit = true;
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                DialogResult result = folderDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _txtFolderPathInput.Text = folderDialog.SelectedPath;
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with opening the browsing dialog : " + ex.ToString());
            }
        }
        private void _btnDiscard_Click(object sender, EventArgs e)
        {
            if(_possibleFolder.Camera.Length==0) //_possibleFolder.Camera.Length is used to check if a new folder will be created or an already existing one will be updated. If Length==0, a new folder will be created. In this case, because we want to discard any changes made, we set the object to null so that, when the object is returned we know that no changes were made.
            {
                _possibleFolder = null;
            }
            Close();
        }
        private void _btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_txtCameraNameInput.Text.Trim().Length == 0 || _txtFolderPathInput.Text.Length == 0)
                {
                    MessageBox.Show("Must enter camera name and path. Fields cannot be empty!", "Fields Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_possibleFolder.Camera.Length != 0)
                {
                    System.Diagnostics.Debug.Print("edit");
                    string extensionsV = "", extensionsP = "";
                    foreach (ListViewItem li in _lvwAvailableVideoExtensions.Items)
                    {
                        if (li.Checked == true)
                        {
                            extensionsV = extensionsV + li.SubItems[0].Text + ",";
                        }

                    }
                    foreach (ListViewItem li in _lvwAvailablePhotoExtensions.Items)
                    {
                        if (li.Checked == true)
                        {
                            extensionsP = extensionsP + li.SubItems[0].Text + ",";
                        }
                    }
                    _possibleFolder.VideoExtensionsString=extensionsV;
                    _possibleFolder.PhotoExtensionsString=extensionsP;
                    if (_cameraAndFolderEdit)
                    {
                        DialogResult res = MessageBox.Show("You are about to change monitoring path from:\"" + _possibleFolder.FolderPath + "\" to: \"" + _txtFolderPathInput.Text + " and camera name from: \"" + _possibleFolder.Camera + "\" to: \"" + _txtCameraNameInput.Text + "\".\n Are you sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (res == DialogResult.OK)
                        {
                            _possibleFolder.Camera=_txtCameraNameInput.Text;
                            _possibleFolder.FolderPath=_txtFolderPathInput.Text;
                        }
                    }
                    Close();
                    return;
                }
                else
                {
                    string extensionsV = "", extensionsP = "";
                    foreach (ListViewItem li in _lvwAvailableVideoExtensions.Items)
                    {
                        if (li.Checked == true)
                        {
                            extensionsV = extensionsV + li.SubItems[0].Text + ",";
                        }

                    }
                    foreach (ListViewItem li in _lvwAvailablePhotoExtensions.Items)
                    {
                        if (li.Checked == true)
                        {
                            extensionsP = extensionsP + li.SubItems[0].Text + ",";
                        }
                    }
                    _possibleFolder = new FolderConfiguration(_txtFolderPathInput.Text, _txtCameraNameInput.Text, extensionsV, extensionsP);
                    Close();
                    return;
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with saving the new/edited folder : " + ex.ToString());
            }
        }
        private void NewFolderDLG_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_possibleFolder!=null && _possibleFolder.Camera.Length == 0)
            {
                _possibleFolder = null;
            }
        }
        private void _txtCameraNameInput_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_possibleFolder.Camera == _txtCameraNameInput.Text)
                {
                    _cameraAndFolderEdit = false;
                }
                else
                {
                    _cameraAndFolderEdit = true;
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with _txtCameraNameInput_TextChanged : " + ex.ToString());
            }
        }
        #endregion
    }
}
