using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectFixed.Database;

namespace ProjectFixed
{
    public partial class DatabaseConfigurationDLG : Form
    {
        #region fields and constructor
        private string serverNameIN;
        private string dbNameIN;
        private bool _newDatabase = false;
        public bool NewDatabase { get { return _newDatabase; } }
        public DatabaseConfigurationDLG()
        {
            InitializeComponent();
            try
            {
                _txtServer.Text = SQLServices.ServerName();
                _txtDatabase.Text = SQLServices.DatabaseName();
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("The file could not be opened!" + ex.ToString());
            }
            serverNameIN = _txtServer.Text;
            dbNameIN = _txtDatabase.Text;
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
                if (serverNameIN == _txtServer.Text && dbNameIN == _txtDatabase.Text)
                {
                    MessageBox.Show("You haven't made any changes!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }
                if (SQLServices.CheckDatabase(_txtServer.Text, _txtDatabase.Text))
                {
                    try
                    {
                        if (SQLServices.CheckTables(_txtServer.Text, _txtDatabase.Text))
                        {
                            MessageBox.Show("Successfuly connected to another database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            SQLServices.SetDatabaseName(_txtServer.Text, _txtDatabase.Text);
                            _newDatabase = true;
                            Close();
                        }
                        else
                        {
                            DialogResult dialogResult = MessageBox.Show("The tables do not exist in the database or they don't have the proper collumns. Do you want to create new ones? (This will create table if it doesn't exist and delete the ones that are non-functional)", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.OK)
                            {
                                SQLServices.SetDatabaseName(_txtServer.Text, _txtDatabase.Text);
                                SQLServices.CreateTables();
                                _newDatabase = true;
                                MessageBox.Show("Successfuly connected to another database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                Close();
                            }
                            else
                            {
                                Close();
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        System.Diagnostics.Debug.Print("Problem with checking the databases : " + ex.ToString());
                    }
                }
                else
                {
                    //loadForm.Close();
                    DialogResult dialogResult = MessageBox.Show("The name for the database that has been provided is not valid. A database with that name does not exist!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Cancel)
                    {
                        Close();
                    }
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with changing the database configuration : " + ex.ToString());
            }
        }

        private void _btnLocal_Click(object sender, EventArgs e)
        {
            _txtServer.Text = "localhost";
        }
        #endregion
    }
}
