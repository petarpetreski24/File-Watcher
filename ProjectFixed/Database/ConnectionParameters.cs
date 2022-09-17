using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFixed.Database
{
    public class ConnectionParameters
    {
        #region fields
        private string _dbName;
        private string _serverName;
        public string DatabaseName { get { return _dbName; } set { _dbName = value; } }
        public string ServerName { get { return _serverName; }set { _serverName = value; } }
        #endregion
        #region constructors
        public ConnectionParameters()
        {
            _dbName = "";
            _serverName = "";
        }
        public ConnectionParameters(string dbName,string serverName)
        {
            _dbName = dbName;
            _serverName = serverName;
        }
        #endregion
    }
}
