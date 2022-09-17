using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ProjectFixed.Config;
using ProjectFixed.Database;

namespace ProjectFixed
{
    public partial class ConfigurationDLG : Form
    {
        #region fields and constructor
        private int _rowIndex = 0;
        private DataTable _videoDataTable = new DataTable();
        private DataTable _photoDataTable = new DataTable();
        private Configuration _potentialConfiguration;
        private Configuration _originalConfiguration;
        public Configuration newConfiguration { get { return _potentialConfiguration; } }
        
        public ConfigurationDLG(Configuration temp)
        {
            InitializeComponent();
            this.ControlBox = false;
            _originalConfiguration = new Configuration(temp);
            _potentialConfiguration = new Configuration(temp);
            _dgvVideoExtensions.ReadOnly = false;
            _dgvPhotoExtensions.ReadOnly = false;
            _dgvVideoExtensions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvPhotoExtensions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ExecuteConfigurationDLG();
            ExecuteDataGrid();
        }
        #endregion
        #region private methods
        /// <summary>
        /// Sets the interface's listview parameters for showing the needed information and displays the active folders of the configuration on the listview.
        /// </summary>
        private void ExecuteConfigurationDLG()
        {
            try
            {
                _lvwActiveFolders.Clear();
                _lvwActiveFolders.View = View.Details;
                _lvwActiveFolders.GridLines = true;
                _lvwActiveFolders.FullRowSelect = true;
                _lvwActiveFolders.Columns.Add("Camera", 150);
                _lvwActiveFolders.Columns.Add("FolderName", 300);
                _lvwActiveFolders.Columns.Add("Folder's Video Extensions", 100);
                _lvwActiveFolders.Columns.Add("Folder's Photo Extensions", 100);
                _lvwActiveFolders.Items.Clear();
                foreach (FolderConfiguration mf in _potentialConfiguration.FoldersConfigurations)
                {
                    _lvwActiveFolders.Items.Add(mf.Camera);
                    _lvwActiveFolders.Items[_lvwActiveFolders.Items.Count - 1].SubItems.Add(mf.FolderPath);
                    _lvwActiveFolders.Items[_lvwActiveFolders.Items.Count - 1].SubItems.Add(mf.VideoExtensionsString);
                    _lvwActiveFolders.Items[_lvwActiveFolders.Items.Count - 1].SubItems.Add(mf.PhotoExtensionsString);
                }
            }
            catch (Exception ex)
            {
                Debug.Print("Problem with executing configuration dialog : " + ex.ToString());
            }
        }
        /// <summary>
        /// Creates Data Tables for the interface's DataGridViews containing the information about the configuration's video and photo extensions.
        /// </summary>
        private void ExecuteDataGrid()
        {
            try
            {
                _videoDataTable = new DataTable();
                _photoDataTable = new DataTable();
                _videoDataTable.Columns.Add("Video Extension", typeof(string));
                _photoDataTable.Columns.Add("Photo Extension", typeof(string));
                foreach (string s in _potentialConfiguration.ExtensionConfiguration.VideoExtensionsList)
                {
                    DataRow dR = _videoDataTable.NewRow();
                    dR["Video Extension"] = s;
                    _videoDataTable.Rows.Add(dR);
                }
                foreach (string s in _potentialConfiguration.ExtensionConfiguration.PhotoExtensionsList)
                {
                    DataRow dR = _photoDataTable.NewRow();
                    dR["Photo Extension"] = s;
                    _photoDataTable.Rows.Add(dR);
                }
                _dgvVideoExtensions.DataSource = _videoDataTable;
                _dgvPhotoExtensions.DataSource = _photoDataTable;
            }
            catch (Exception ex)
            {
                Debug.Print("Problem with executing data grid : " + ex.ToString());
            }
        }
        /// <summary>
        /// Updates the video and photo extensions, prior cheking if the inserted or updated extensions fall under certain conditions.
        /// </summary>
        private void UpdateExtensionsWithGrid()
        {
            try
            {
                string extensionsV = "", extensionsP = "";
                for (int i = 0; i < _dgvVideoExtensions.Rows.Count - 1; i++)
                {
                    if (_dgvVideoExtensions.Rows[i].Cells[0].Value.ToString()[0] != '.')
                    {
                        MessageBox.Show("The extension " + _dgvVideoExtensions.Rows[i].Cells[0].Value.ToString() + " will not be activated because it violated the rule: \"Every extension must start with a dot(.example)");
                        _dgvVideoExtensions.Rows.RemoveAt(i);
                        i--;
                        continue;
                    }
                    extensionsV = extensionsV + _dgvVideoExtensions.Rows[i].Cells[0].Value.ToString() + ",";
                }
                for (int i = 0; i < _dgvPhotoExtensions.Rows.Count - 1; i++)
                {
                    if (_dgvPhotoExtensions.Rows[i].Cells[0].Value.ToString()[0] != '.')
                    {
                        MessageBox.Show("The extension " + _dgvPhotoExtensions.Rows[i].Cells[0].Value.ToString() + " will not be activated because it violated the rule: \"Every extension must start with a dot(.example)");
                        _dgvPhotoExtensions.Rows.RemoveAt(i);
                        i--;
                        continue;
                    }
                    extensionsP = extensionsP + _dgvPhotoExtensions.Rows[i].Cells[0].Value.ToString() + ",";
                }
                _potentialConfiguration.ExtensionConfiguration.PhotoExtensionsString=extensionsP;
                _potentialConfiguration.ExtensionConfiguration.VideoExtensionsString=extensionsV;
            }
            catch (Exception ex)
            {
                Debug.Print("Problem with updating extensions with grid : " + ex.ToString());
            }
        }
        /// <summary>
        /// Checks if the changes made to the video and photo extensions, deleted any extension that an active folder contained. If that statement is satisfied, it removes that extension from the folder's configuration.
        /// </summary>
        private void ValidateExtensions()
        {
            try
            {
                for (int i = 0; i < _potentialConfiguration.FoldersConfigurations.Count; i++)
                {
                    for (int j = 0; j < _potentialConfiguration.FoldersConfigurations[i].VideoExtensionsList.Count; j++)
                    {
                        string potentialExtensionRemoval = _potentialConfiguration.FoldersConfigurations[i].VideoExtensionsList[j];
                        string potentialFolderExtensionRemoval = _potentialConfiguration.FoldersConfigurations[i].FolderPath;
                        bool checkIf = String.IsNullOrEmpty(_potentialConfiguration.ExtensionConfiguration.VideoExtensionsList.FirstOrDefault(name => name == potentialExtensionRemoval));
                        if (checkIf)
                        {
                            MessageBox.Show("The extensions " + potentialExtensionRemoval + 
                                " of folder " + potentialFolderExtensionRemoval + 
                                " will be removed because it has been removed from the application's extensions list");
                            _potentialConfiguration.FoldersConfigurations[i].RemoveVideoExtension(j);
                            j--;
                        }
                    }
                }
                for (int i = 0; i < _potentialConfiguration.FoldersConfigurations.Count; i++)
                {
                    for (int j = 0; j < _potentialConfiguration.FoldersConfigurations[i].PhotoExtensionsList.Count; j++)
                    {
                        string potentialExtensionRemoval = _potentialConfiguration.FoldersConfigurations[i].PhotoExtensionsList[j];
                        string potentialFolderExtensionRemoval = _potentialConfiguration.FoldersConfigurations[i].FolderPath;
                        bool checkIf = String.IsNullOrEmpty(_potentialConfiguration.ExtensionConfiguration.PhotoExtensionsList.FirstOrDefault(name => name == potentialExtensionRemoval));
                        if (checkIf)
                        {
                            MessageBox.Show("The extensions " + potentialExtensionRemoval + 
                                " of folder " + potentialFolderExtensionRemoval + 
                                " will be removed because it has been removed from the application's extensions list");
                            _potentialConfiguration.FoldersConfigurations[i].RemovePhotoExtension(j);
                            j--;
                        }
                    }
                }
                ExecuteConfigurationDLG();
            }
            catch(Exception ex)
            {
                Debug.Print("Problem with validating extensions : " + ex.ToString());
            }
        }
        /// <summary>
        /// Checks whether a folder with an existing camera name or folder path exists. It is used when we want to add a folder or change the information about the folder.
        /// </summary>
        /// <param name="folderCamera">String containing folder's camera name</param>
        /// <param name="folderPath">String containing folder's full path</param>
        /// <returns></returns>
        private bool DoesNotExist(string folderCamera, string folderPath)
        {
            for (int i = 0; i < _potentialConfiguration.FoldersConfigurations.Count; i++)
            {
                if (folderCamera == _potentialConfiguration.FoldersConfigurations[i].Camera)
                {
                    MessageBox.Show("The camera you are trying to input is already active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            for (int i = 0; i < _potentialConfiguration.FoldersConfigurations.Count; i++)
            {
                if (folderPath == _potentialConfiguration.FoldersConfigurations[i].FolderPath)
                {
                    MessageBox.Show("The camera you are trying to input is already active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        #endregion
        #region event handlers
        private void _lvwActiveFolders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _btnEdit.PerformClick();
        }
        private void _btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateExtensionsWithGrid();
                NewFolderDLG NewFolderForm = new NewFolderDLG(_potentialConfiguration.ExtensionConfiguration.VideoExtensionsList, _potentialConfiguration.ExtensionConfiguration.PhotoExtensionsList, null);
                NewFolderForm.ShowDialog();
                if (NewFolderForm.NewFolder != null && DoesNotExist(NewFolderForm.NewFolder.Camera, NewFolderForm.NewFolder.FolderPath))
                {
                    _potentialConfiguration.FoldersConfigurations.Add(new FolderConfiguration(NewFolderForm.NewFolder));
                }
                _lvwActiveFolders.Items.Clear();
                foreach (FolderConfiguration mf in _potentialConfiguration.FoldersConfigurations)
                {
                    _lvwActiveFolders.Items.Add(mf.Camera);
                    _lvwActiveFolders.Items[_lvwActiveFolders.Items.Count - 1].SubItems.Add(mf.FolderPath);
                    _lvwActiveFolders.Items[_lvwActiveFolders.Items.Count - 1].SubItems.Add(mf.VideoExtensionsString);
                    _lvwActiveFolders.Items[_lvwActiveFolders.Items.Count - 1].SubItems.Add(mf.PhotoExtensionsString);
                }
            }
            catch(Exception ex)
            {
                Debug.Print("Problem with adding a folder : " + ex.ToString());
            }
        }
        private void _btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateExtensionsWithGrid();
                if (_lvwActiveFolders.Items.Count == 0 && _dgvVideoExtensions.Rows.Count == 1 && _dgvPhotoExtensions.Rows.Count == 1)
                {
                    MessageBox.Show("You can't save a blank configuration. The configuration will stay the same!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _potentialConfiguration = null;
                    Close();
                    return;
                }
                if (_potentialConfiguration == _originalConfiguration)
                {
                    _potentialConfiguration = null;
                    Close();
                    return;
                }
                SQLServices.SaveConfigurationToDatabase(ref _potentialConfiguration);
                Close();
                _lvwActiveFolders.FocusedItem = null;
                _lvwActiveFolders.SelectedItems.Clear();
            }
            catch(Exception ex)
            {
                Debug.Print("There was a problem with saving the new configuration! : " + ex.ToString());
            }
        }
        private void _btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_lvwActiveFolders.SelectedItems.Count != 0)
                {
                    int indeks = _lvwActiveFolders.FocusedItem.Index;
                    _lvwActiveFolders.Items.RemoveAt(indeks);
                    _potentialConfiguration.RemoveFolder(indeks);
                }
                else
                {
                    MessageBox.Show("You don't have a folder selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception ex)
            {
                Debug.Print("There was a problem with deleting a folder : " + ex.ToString());
            }
        }
        private void _btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                _potentialConfiguration.FoldersConfigurations.Clear();
                _lvwActiveFolders.Items.Clear();
            }
            catch(Exception ex)
            {
                Debug.Print("There was a problem with clearing the list of folders! : " + ex.ToString());
            }
        }
        private void _btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void _dgvVideoExtensions_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    _dgvPhotoExtensions.ClearSelection();
                    if (e.RowIndex < 0)
                    {
                        return;
                    }
                    _dgvVideoExtensions.Rows[e.RowIndex].Selected = true;
                    _rowIndex = e.RowIndex;
                    _dgvVideoExtensions.CurrentCell = _dgvVideoExtensions.Rows[e.RowIndex].Cells[0];
                    _mnsDelete.Show(_dgvVideoExtensions, e.Location);
                    _mnsDelete.Show(Cursor.Position);
                }
            }
            catch (Exception ex)
            {
                Debug.Print("Problem with  _dgvVideoExtensions_CellMouseUp : " + ex.ToString());
            }
        }
        private void _dgvPhotoExtensions_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    _dgvVideoExtensions.ClearSelection();
                    if (e.RowIndex < 0)
                    {
                        return;
                    }
                    _dgvPhotoExtensions.Rows[e.RowIndex].Selected = true;
                    _rowIndex = e.RowIndex;
                    _dgvPhotoExtensions.CurrentCell = _dgvPhotoExtensions.Rows[e.RowIndex].Cells[0];
                    _mnsDelete.Show(_dgvPhotoExtensions, e.Location);
                    _mnsDelete.Show(Cursor.Position);
                }
            }
            catch (Exception ex)
            {
                Debug.Print("Problem with  _dgvPhotoExtensions_CellMouseUp : " + ex.ToString());
            }
        }
        private void _mnsDelete_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (!_dgvVideoExtensions.Rows[_rowIndex].IsNewRow && _dgvVideoExtensions.SelectedRows.Count > 0)
                    {
                        _dgvVideoExtensions.Rows.RemoveAt(_rowIndex);
                    }
                }
                catch(Exception ex)
                {
                    Debug.Print("Problem with  Indexing _dgvVideoExtensions.Rows : " + ex.ToString());
                }
                try
                {
                    if (!_dgvPhotoExtensions.Rows[_rowIndex].IsNewRow && _dgvPhotoExtensions.SelectedRows.Count > 0)
                    {
                        _dgvPhotoExtensions.Rows.RemoveAt(_rowIndex);
                    }
                }
                catch (Exception ex)
                {
                    Debug.Print("Problem with  Indexing _dgvPhotoExtensions.Rows : " + ex.ToString());
                }
                UpdateExtensionsWithGrid();
                ValidateExtensions();
            }
            catch (Exception ex)
            {
                Debug.Print("Problem with  _mnsDelete_Click : " + ex.ToString());
            }
        }
        private void _btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_lvwActiveFolders.SelectedItems.Count > 0)
                {
                    UpdateExtensionsWithGrid();
                    NewFolderDLG EditFolderForm = new NewFolderDLG(_potentialConfiguration.ExtensionConfiguration.VideoExtensionsList, _potentialConfiguration.ExtensionConfiguration.PhotoExtensionsList, _potentialConfiguration.FoldersConfigurations[_lvwActiveFolders.FocusedItem.Index]);
                    EditFolderForm.ShowDialog();
                    if (_potentialConfiguration.FoldersConfigurations[_lvwActiveFolders.FocusedItem.Index] != EditFolderForm.NewFolder)
                    {
                        for (int i = 0; i < _potentialConfiguration.FoldersConfigurations.Count; i++)
                        {
                            if (i == _lvwActiveFolders.FocusedItem.Index)
                            {
                                continue;
                            }
                            if (EditFolderForm.NewFolder.Camera == _potentialConfiguration.FoldersConfigurations[i].Camera || EditFolderForm.NewFolder.FolderPath == _potentialConfiguration.FoldersConfigurations[i].FolderPath)
                            {
                                MessageBox.Show("The folder you are trying to input has the same folder path or the same camera name of an existing folder!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        _potentialConfiguration.FoldersConfigurations[_lvwActiveFolders.FocusedItem.Index] = new FolderConfiguration(EditFolderForm.NewFolder);
                        ExecuteConfigurationDLG();
                    }
                }
                else
                {
                    MessageBox.Show("You don't have any folders selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                Debug.Print("There was a problem with editing a folder! : "+ex.ToString());
            }
            
        }
        #endregion
    }

}
