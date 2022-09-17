using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Media;
using System.Windows.Forms;
using ProjectFixed.Database;
using ProjectFixed.Collections;
using ProjectFixed.MediaFiles;

namespace ProjectFixed
{
    public partial class FilesHistoryDLG : Form
    {
        #region fields and constructor
        private bool _isDataFiltered = false;
        List<FileHistoryItem> _filesLoaded;

        public FilesHistoryDLG()
        {
            InitializeComponent();
            _lvwDataHistory.Clear();
            _lvwDataHistory.View = View.Details;
            _lvwDataHistory.GridLines = true;
            _lvwDataHistory.FullRowSelect = true;
            _lvwDataHistory.Columns.Add("ID", 50);
            _lvwDataHistory.Columns.Add("Camera", 60);
            _lvwDataHistory.Columns.Add("Name", 250);
            _lvwDataHistory.Columns.Add("Path", 400);
            _lvwDataHistory.Columns.Add("Type", 40);
            _lvwDataHistory.Columns.Add("Extension", 40);
            _lvwDataHistory.Columns.Add("Start Time", 120);
            _lvwDataHistory.Columns.Add("End Time", 120);
            _dtpStartDate.Format = DateTimePickerFormat.Custom;
            _dtpStartDate.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            _dtpEndDate.Format = DateTimePickerFormat.Custom;
            _dtpEndDate.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
        }
        #endregion
        #region private methods
        /// <summary>
        /// Loads the data about the previous files from the database and displays it on the interface's listview. (Inefficient method, needs improvement)
        /// </summary>
        private void LoadData()
        {
            _lvwDataHistory.Items.Clear();
            if (_filesLoaded==null)
            {
                return;
            }
            for(int i=0;i<_filesLoaded.Count;i++)
            { 
                _lvwDataHistory.Items.Add(_filesLoaded[i].ID.ToString()); //klasa za item za dodavanje
                _lvwDataHistory.Items[_lvwDataHistory.Items.Count - 1].SubItems.Add(_filesLoaded[i].Camera);
                _lvwDataHistory.Items[_lvwDataHistory.Items.Count - 1].SubItems.Add(_filesLoaded[i].Name);
                _lvwDataHistory.Items[_lvwDataHistory.Items.Count - 1].SubItems.Add(_filesLoaded[i].Path);
                _lvwDataHistory.Items[_lvwDataHistory.Items.Count - 1].SubItems.Add(_filesLoaded[i].Type);
                _lvwDataHistory.Items[_lvwDataHistory.Items.Count - 1].SubItems.Add(_filesLoaded[i].Extension);
                _lvwDataHistory.Items[_lvwDataHistory.Items.Count - 1].SubItems.Add(_filesLoaded[i].CreationTimeString.ToString());
                _lvwDataHistory.Items[_lvwDataHistory.Items.Count - 1].SubItems.Add(_filesLoaded[i].FinishedTimeString.ToString());
            }
            
        }
        /// <summary>
        /// Paints the cells corresponding to the filter.
        /// </summary>
        private void PaintCells(DateTime startTime,DateTime endTime)
        {
            for (int i = 0; i < _lvwDataHistory.Items.Count; i++)
            {
                if (_filesLoaded[i].HasFinishedTime && endTime >= _filesLoaded[i].FinishedTime)
                {
                    _lvwDataHistory.Items[i].SubItems[7].BackColor = Color.FromArgb(144, 238, 144);//green
                }
                else
                {
                    _lvwDataHistory.Items[i].SubItems[7].BackColor = Color.FromArgb(220, 20, 60);
                }
                if (!_filesLoaded[i].HasFinishedTime)
                {
                    _lvwDataHistory.Items[i].UseItemStyleForSubItems = false;
                    _lvwDataHistory.Items[i].SubItems[7].BackColor = Color.FromArgb(255, 255, 51); //yellow
                }
                if (startTime <= _filesLoaded[i].CreationTime)
                {
                    _lvwDataHistory.Items[i].UseItemStyleForSubItems = false;
                    _lvwDataHistory.Items[i].SubItems[6].BackColor = Color.FromArgb(144, 238, 144); //green
                }
                else
                {
                    _lvwDataHistory.Items[i].UseItemStyleForSubItems = false;
                    _lvwDataHistory.Items[i].SubItems[6].BackColor = Color.FromArgb(220, 20, 60); //red
                }
            }
        }
        #endregion
        #region event handlers
        private void _lvwDataHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                MediaFilePlayer mediaPlayer = new MediaFilePlayer("C:\\Program Files\\VideoLAN\\VLC\\vlc.exe");
                if (_isDataFiltered && _filesLoaded[_lvwDataHistory.FocusedItem.Index].TypeEnum==FileTypes.Video)
                {
                    mediaPlayer.PlayMediaWithParameters(Convert.ToDateTime(_dtpStartDate.Value), Convert.ToDateTime(_dtpEndDate.Value), _filesLoaded[_lvwDataHistory.FocusedItem.Index]);
                }
                else
                {
                    if (_filesLoaded[_lvwDataHistory.FocusedItem.Index].TypeEnum == FileTypes.Photo)
                    {
                        try
                        {
                            mediaPlayer.PlayMediaWithoutParameters(_filesLoaded[_lvwDataHistory.FocusedItem.Index]);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("The file you are trying to open is either deleted or renamed : " + ex.ToString());
                        }
                        return;
                    }
                    DialogResult res = MessageBox.Show("You haven't filtered the videos. Do you want to still open the video from the start? ", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (res == DialogResult.OK)
                    {
                        try
                        {
                            mediaPlayer.PlayMediaWithoutParameters(_filesLoaded[_lvwDataHistory.FocusedItem.Index]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("The file you are trying to open is either deleted or renamed : " + ex.ToString());
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.Print("Problem with opening a file : " + ex.ToString());
            }
            
        }
        private void _btnFilterData_Click(object sender, EventArgs e)
        {
            try
            {
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
                _filesLoaded=MediaFilesFilter.FilterFiles(startTime, endTime, SQLServices.LoadFilesFromDatabase());
                LoadData();
                PaintCells(startTime, endTime);
                _isDataFiltered = true;
            }
            catch(Exception ex)
            {
                Debug.Print("Problem with filtering the data :" + ex.ToString());
            }
        }
        private void _btnShowAll_Click(object sender, EventArgs e)
        {
            _filesLoaded = SQLServices.LoadFilesFromDatabase();
            LoadData();
            _isDataFiltered = false;
        }
        #endregion
    }
}
