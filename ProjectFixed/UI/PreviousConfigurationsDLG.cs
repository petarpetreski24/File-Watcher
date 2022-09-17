using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProjectFixed.Config;
using ProjectFixed.Database;

namespace ProjectFixed
{
    public partial class PreviousConfigurationsDLG : Form
    {
        #region fields
        private int _rowIndexConfig = -1;
        private List<Configuration> _usedConfigurations = new List<Configuration>();
        private Configuration _loadedConfiguration = null;
        private DataTable _previousConfigsDataTable = new DataTable();
        private DataTable _selectedConfigVideoExtDataTable = new DataTable();
        private DataTable _selectedConfigPhotoExtDataTable = new DataTable();
        private DataTable _selectedConfigFoldersDataTable = new DataTable();
        public Configuration LoadedConfiguration { get { return _loadedConfiguration; } }
        #endregion
        #region constructor
        public PreviousConfigurationsDLG()
        {
            InitializeComponent();

            _dgvConfigurations.ReadOnly = true;
            _dgvConfigurations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvConfigurations.MultiSelect = false;


            _dgvSelectedConfigPhotoExtensions.ReadOnly = true;
            _dgvSelectedConfigPhotoExtensions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvSelectedConfigPhotoExtensions.MultiSelect = false;


            _dgvSelectedConfigVideoExtensions.ReadOnly = true;
            _dgvSelectedConfigVideoExtensions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvSelectedConfigVideoExtensions.MultiSelect = false;

            _dgvSelectedConfigFolders.ReadOnly = true;
            _dgvSelectedConfigFolders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvSelectedConfigVideoExtensions.MultiSelect = false;

            _dtpStartDate.Format = DateTimePickerFormat.Custom;
            _dtpStartDate.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            _dtpEndDate.Format = DateTimePickerFormat.Custom;
            _dtpEndDate.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
        }
        #endregion
        #region private methods
        /// <summary>
        /// Creates and sets the parameters needed for the DataTables. Then it fills those tables with data available from the database and sets the source of the interface's DataGridViews to those tables.
        /// </summary>
        private void InitializeDataGrids()
        {
            try
            {
                _previousConfigsDataTable = new DataTable();
                _previousConfigsDataTable.Columns.Add("ID", typeof(int));
                _previousConfigsDataTable.Columns.Add("Start Time", typeof(DateTime));
                _previousConfigsDataTable.Columns.Add("End Time", typeof(DateTime));

                _selectedConfigPhotoExtDataTable = new DataTable();
                _selectedConfigPhotoExtDataTable.Columns.Add("Photo Extensions", typeof(string));

                _selectedConfigVideoExtDataTable = new DataTable();
                _selectedConfigVideoExtDataTable.Columns.Add("Video Extensions", typeof(string));

                _selectedConfigFoldersDataTable = new DataTable();
                _selectedConfigFoldersDataTable.Columns.Add("Camera", typeof(string));
                _selectedConfigFoldersDataTable.Columns.Add("Folder", typeof(string));
                _selectedConfigFoldersDataTable.Columns.Add("Folder's Video Extensions", typeof(string));
                _selectedConfigFoldersDataTable.Columns.Add("Folder's Photo Extensions", typeof(string));
                _usedConfigurations.Clear();
                _usedConfigurations = SQLServices.LoadAllPreviousConfigurations();
                if (_usedConfigurations == null)
                {
                    return;
                }
                for (int i = 0; i < _usedConfigurations.Count; i++)
                {
                    DataRow dR = _previousConfigsDataTable.NewRow();
                    dR["ID"] = _usedConfigurations[i].ID;
                    dR["Start Time"] = _usedConfigurations[i].ConfigurationTime;
                    if (i + 1 < _usedConfigurations.Count)
                    {
                        dR["End Time"] = _usedConfigurations[i + 1].ConfigurationTime;
                    }
                    else
                    {
                        dR["End Time"] = DateTime.Now;
                    }
                    _previousConfigsDataTable.Rows.Add(dR);
                }
                _dgvConfigurations.DataSource = _previousConfigsDataTable;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with initializing data grids : " + ex.ToString());
            }
        }
        /// <summary>
        /// Loads the data needed when a configuration is selected. It displays the information about the configuration.
        /// </summary>
        /// <param name="configurationLoaderIndex">Integer specifying the configuration</param>
        private void LoadConfigurationWithIndex(int configurationLoaderIndex)
        {
            try
            {
                _selectedConfigPhotoExtDataTable.Rows.Clear();
                _selectedConfigVideoExtDataTable.Rows.Clear();
                _selectedConfigFoldersDataTable.Rows.Clear();

                if (configurationLoaderIndex >= _usedConfigurations.Count)
                {
                    return;
                }
                foreach (string s in _usedConfigurations[configurationLoaderIndex].ExtensionConfiguration.VideoExtensionsList)
                {
                    DataRow dR = _selectedConfigVideoExtDataTable.NewRow();
                    dR["Video Extensions"] = s;
                    _selectedConfigVideoExtDataTable.Rows.Add(dR);
                }
                foreach (string s in _usedConfigurations[configurationLoaderIndex].ExtensionConfiguration.PhotoExtensionsList)
                {
                    DataRow dR = _selectedConfigPhotoExtDataTable.NewRow();
                    dR["Photo Extensions"] = s;
                    _selectedConfigPhotoExtDataTable.Rows.Add(dR);
                }
                foreach (FolderConfiguration mf in _usedConfigurations[configurationLoaderIndex].FoldersConfigurations)
                {
                    DataRow dR = _selectedConfigFoldersDataTable.NewRow();
                    dR["Camera"] = mf.Camera;
                    dR["Folder"] = mf.FolderPath;
                    dR["Folder's Video Extensions"] = mf.VideoExtensionsString;
                    dR["Folder's Photo Extensions"] = mf.PhotoExtensionsString;
                    _selectedConfigFoldersDataTable.Rows.Add(dR);
                }
                _dgvSelectedConfigFolders.DataSource = _selectedConfigFoldersDataTable;
                _dgvSelectedConfigVideoExtensions.DataSource = _selectedConfigVideoExtDataTable;
                _dgvSelectedConfigPhotoExtensions.DataSource = _selectedConfigPhotoExtDataTable;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with loading configuration with index : " + ex.ToString());
            }
        }
        #endregion
        #region event handlers
        private void _btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void _btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("You are about to load configuration with ID: " + _dgvConfigurations.Rows[_rowIndexConfig].Cells[0].Value.ToString() + ". Are you sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    _loadedConfiguration = SQLServices.LoadConfiguration(Convert.ToInt32(_dgvConfigurations.Rows[_rowIndexConfig].Cells[0].Value));
                    SQLServices.SaveConfigurationToDatabase(ref _loadedConfiguration);
                    Hide();
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with loading old configuration : " + ex.ToString());
            }
        }
        private void _dgvConfigurations_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (_dgvConfigurations.SelectedRows.Count == 0)
                {
                    return;
                }
                if (_rowIndexConfig != _dgvConfigurations.SelectedRows[0].Index)
                {
                    _rowIndexConfig = _dgvConfigurations.SelectedRows[0].Index;
                    LoadConfigurationWithIndex(_rowIndexConfig);
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with _dgvConfigurations_SelectionChanged : " + ex.ToString());
            }
        }

        private void _btnFilterData_Click(object sender, EventArgs e)
        {
            try
            {
                InitializeDataGrids();
                DataTable filteredData = new DataTable();
                filteredData.Columns.Add("ID", typeof(int));
                filteredData.Columns.Add("Start Time", typeof(DateTime));
                filteredData.Columns.Add("End Time", typeof(DateTime));
                DateTime startTime = Convert.ToDateTime(_dtpStartDate.Value);
                DateTime endTime = Convert.ToDateTime(_dtpEndDate.Value);
                if (endTime == startTime)
                {
                    MessageBox.Show("End Time and Start Time cannot be same");
                }
                if (endTime < startTime)
                {
                    MessageBox.Show("Please select End Time that is bigger than Start Time");
                    return;
                }
                for (int i = 0; i < _previousConfigsDataTable.Rows.Count; i++)
                {
                    if (startTime > Convert.ToDateTime(_previousConfigsDataTable.Rows[i].ItemArray[2]) || (endTime < Convert.ToDateTime(_previousConfigsDataTable.Rows[i].ItemArray[1])))
                    {
                        continue;
                    }
                    DataRow row = filteredData.NewRow();
                    row["ID"] = _previousConfigsDataTable.Rows[i].ItemArray[0];
                    row["Start Time"] = _previousConfigsDataTable.Rows[i].ItemArray[1];
                    row["End Time"] = _previousConfigsDataTable.Rows[i].ItemArray[2];
                    filteredData.Rows.Add(row);

                }
                _dgvConfigurations.DataSource = filteredData;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with filtering data : " + ex.ToString());
            }
            
        }
        private void _btnShowAll_Click(object sender, EventArgs e)
        {
            InitializeDataGrids();
        }
        #endregion
    }
}
