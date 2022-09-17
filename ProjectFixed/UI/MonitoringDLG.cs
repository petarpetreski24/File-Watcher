using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProjectFixed.Config;
using ProjectFixed.Collections;
using ProjectFixed.Database;
using ProjectFixed.Manage;

namespace ProjectFixed
{
    public partial class MonitoringDLG : Form
    {
        #region fields and constructor
        private FolderWatcherManager _folderWatcher;
        public MonitoringDLG()
        {
            _folderWatcher = new FolderWatcherManager(SQLServices.LoadConfiguration());
            if(!SQLServices.IsDataInvalid && _folderWatcher.WatcherConfiguration==null)
            {
                MessageBox.Show("There was a problem with loading the latest configuration in the database! The application won't start. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("Unable to load configuration!");
            }
            InitializeComponent();
            EnableFolderMonitoring();
            _lvwRecordedFiles.View = View.Details;
            _lvwRecordedFiles.GridLines = true;
            _lvwRecordedFiles.FullRowSelect = true;
            _lvwRecordedFiles.Columns.Add("No.", 30);
            _lvwRecordedFiles.Columns.Add("Camera", 100);
            _lvwRecordedFiles.Columns.Add("Name", 150);
            _lvwRecordedFiles.Columns.Add("Path", 300);
            _lvwRecordedFiles.Columns.Add("Type", 40);
            _lvwRecordedFiles.Columns.Add("Extension", 40);
            _folderWatcher.ListOfInsertedFiles += SentList;
            
        }
        #endregion
        #region private methods
        /// <summary>
        /// Checks if there are any folders to monitor, if so starts the folders, enables them to monitor. 
        /// </summary>
        private void EnableFolderMonitoring() //A method used to enable raising events for the FileSystemWatchers
        {
            if (SQLServices.IsDataInvalid)
            {
                MessageBox.Show("The application won't work properly because there is a problem with the connection data! Please click on \"Server and Database Configuration\" and enter proper data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_folderWatcher.WatcherConfiguration.FoldersConfigurations.Count == 0)
            {
                _lblStatus.Text = "Status: Folders not selected";
                MessageBox.Show(this,"You don't have folders selected for the application to monitor. Please consider adding folders and the application will start automatically ", "Warninh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                _folderWatcher.RefreshMonitoredFolders();
                _folderWatcher.EnableFoldersToMonitor();
                _lblStatus.Text = "Status: Active";
            }
        }
        /// <summary>
        /// Updates the interface's listview with a new file, once it is created. (Inefficient method, needs improvement)
        /// </summary>
        /// <param name="fileInput">An instance of the class FileCreated, for insertion in the listview</param>
        private void InsertIntoListView(FileCreated fileInput) // A method used to update the listview and the database when a file is created (todo {Can be improved})
        {
            if (_lvwRecordedFiles.InvokeRequired)
            {
                _lvwRecordedFiles.Invoke((MethodInvoker)delegate ()
                {
                    for (int i = 0; i < _lvwRecordedFiles.Items.Count; i++)
                    {
                        if (_lvwRecordedFiles.Items[i].SubItems[3].Text == fileInput.Path)
                        {
                            return;
                        }
                    }
                    _lvwRecordedFiles.Items.Add((_lvwRecordedFiles.Items.Count+1).ToString());
                    _lvwRecordedFiles.Items[_lvwRecordedFiles.Items.Count - 1].SubItems.Add(fileInput.Camera);
                    _lvwRecordedFiles.Items[_lvwRecordedFiles.Items.Count - 1].SubItems.Add(fileInput.Name);
                    _lvwRecordedFiles.Items[_lvwRecordedFiles.Items.Count - 1].SubItems.Add(fileInput.Path);
                    _lvwRecordedFiles.Items[_lvwRecordedFiles.Items.Count - 1].SubItems.Add(fileInput.EnumType.ToString());
                    _lvwRecordedFiles.Items[_lvwRecordedFiles.Items.Count - 1].SubItems.Add(fileInput.Extension);
                });
            }
        }
        /// <summary>
        /// Checks if there are any new items to be added to the interface's list view.
        /// </summary>
        /// <param name="newItems"></param>
        private void SentList(List<FileCreated> newItems)
        {
            if (newItems == null)
            {
                return;
            }
            foreach (FileCreated fc in newItems)
            {
                InsertIntoListView(fc);
            }
        }
        #endregion
        #region event handlers
        void _lvwRecordedFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Process.Start(_lvwRecordedFiles.FocusedItem.SubItems[3].Text);
            }
            catch(Exception ex)
            {
                Debug.Print("Problem with opening file: " + _lvwRecordedFiles.FocusedItem.SubItems[3].Text +" : " + ex.ToString());
            }
        }
        private void _btnStart_Click(object sender, EventArgs e)
        {
            EnableFolderMonitoring();
        }
        private void _btnConfigure_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigurationDLG form = new ConfigurationDLG(_folderWatcher.WatcherConfiguration);
                form.ShowDialog();
                if (form.newConfiguration != null)
                {
                    _folderWatcher.DisposeAllFolders();
                    _folderWatcher.WatcherConfiguration=form.newConfiguration;
                    EnableFolderMonitoring();
                }
                else
                {
                    MessageBox.Show("No changes were made. The same configuration is running!");
                }
            }
            catch (Exception ex)
            {
                Debug.Print("Problem with loading the changed configuration! :  " + ex.ToString());
            }
        }
        private void _btnStop_Click(object sender, EventArgs e)
        {
            _lblStatus.Text = "Status: Paused";
            _folderWatcher.DisableFoldersToMonitor();
        }
        private void _btnHistory_Click(object sender, EventArgs e)
        {
            FilesHistoryDLG history = new FilesHistoryDLG();
            history.Show();
        }
        private void _btnPreviousConfigs_Click(object sender, EventArgs e)
        {
            try
            {
                PreviousConfigurationsDLG UsedConfigurations = new PreviousConfigurationsDLG();
                UsedConfigurations.ShowDialog();
                if (UsedConfigurations.LoadedConfiguration != null)
                {
                    _folderWatcher.DisableFoldersToMonitor();
                    _folderWatcher.WatcherConfiguration=UsedConfigurations.LoadedConfiguration;
                }
                EnableFolderMonitoring();
            }
            catch (Exception ex)
            {
                Debug.Print("Problem with loading the changed configuration! :  " +ex.ToString());
            }
        }
        private void MonitoringDLG_FormClosing(object sender, FormClosingEventArgs e)
        {
            _folderWatcher.StopThread(true, 5000);
        }
        private void _btnDatabaseConfig_Click(object sender, EventArgs e)
        {
            DatabaseConfigurationDLG databaseForm = new DatabaseConfigurationDLG();
            databaseForm.ShowDialog();
            if (databaseForm.NewDatabase)
            {
                _folderWatcher.DisposeAllFolders();
                _folderWatcher.StopThread(true, 5000);
                _folderWatcher = new FolderWatcherManager(SQLServices.LoadConfiguration());
                EnableFolderMonitoring();
                _folderWatcher.ListOfInsertedFiles += SentList;
                _lvwRecordedFiles.Items.Clear();
            }
        }
        #endregion
    }
}
