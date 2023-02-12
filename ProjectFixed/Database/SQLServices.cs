using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Serialization;
using ProjectFixed.Config;
using ProjectFixed.Collections;


namespace ProjectFixed.Database
{
    public class SQLServices
    {
        static ConnectionParameters connectionParameters;
        #region fields
        private static bool s_invalidData=false;
        private static string s_fileName = "ConnectionParameters.xml";
        public static bool IsDataInvalid { get { return s_invalidData; } }
        #endregion
        static SQLServices()
        {
            if(!File.Exists(s_fileName)) //todo konstantno ime
            {
                ConnectionParameters temp = new ConnectionParameters();
                var serializer = new XmlSerializer(typeof(ConnectionParameters));
                using (var writer = new StreamWriter(s_fileName))
                {
                    serializer.Serialize(writer, temp);
                }
            }
            try
            {
                //ConnectionParameters temp = new ConnectionParameters("localhost\\SQLEXPRESS", "Changes");
                //var serializer = new XmlSerializer(typeof(ConnectionParameters));
                //using (var writer = new StreamWriter("ConnectionParameters.xml"))
                //{
                //    serializer.Serialize(writer, temp);
                //}
                XmlSerializer serializer = new XmlSerializer(typeof(ConnectionParameters));
                using(StreamReader sr = new StreamReader(s_fileName))
                {
                    connectionParameters = (ConnectionParameters)serializer.Deserialize(sr);
                }
                System.Diagnostics.Debug.Print(connectionParameters.DatabaseName + " : " + connectionParameters.ServerName);
                if (!CheckDatabase(connectionParameters.ServerName,connectionParameters.DatabaseName))
                {
                    s_invalidData = true;
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.ToString());
            }
            //try
            //{
            //    using (StreamReader sr = new StreamReader(@".\DatabaseInfo.txt"))//todo sho ako nema nisto zapisano vo text datotekata i ne mozi da procita server i databaza (dali da mu se pojavi dijalogo za da vnesi server i databaza?)
            //    {
            //        s_serverName = sr.ReadLine();
            //        s_dbName = sr.ReadLine();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.Print("File not found! Creating one... : " + ex.ToString());
            //    using(StreamWriter sw = File.CreateText(@".\DatabaseInfo.txt"))
            //    {

            //    }
            //}
            if(connectionParameters.ServerName==null || connectionParameters.ServerName.Length==0 || connectionParameters.DatabaseName == null || connectionParameters.DatabaseName.Length == 0)
            {
                s_invalidData = true;
            }
        } 
        /// <summary>
        /// Method used for loading a configuration from the database. When the application is opened, it loads the last saved configuration. When the user wants to load a previous configuration, it loads that configuration through the selected ID from the interface. 
        /// </summary>
        /// <param name="configID"> ID used to find and load the configuration from the database </param>
        /// <returns></returns>
        public static Configuration LoadConfiguration(int configID = -1)
        {
            SqlConnection sqlConnection = new SqlConnection("Server= " + connectionParameters.ServerName + "; Database= " + connectionParameters.DatabaseName + "; Integrated Security=True;");
            try
            {
                sqlConnection.Open();
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with opening the connection : "+ex.ToString());
                return null;
            }
            try
            {
                string sqlQuery;
                SqlCommand sqlCmd;
                Configuration setConfig = new Configuration();
                if (configID == -1)
                {
                    sqlQuery = "SELECT TOP(1) * FROM Configurations ORDER BY ID DESC";
                    sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                }
                else
                {
                    sqlQuery = "SELECT * FROM Configurations WHERE ID=@value";
                    sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCmd.Parameters.Clear();
                    sqlCmd.Parameters.AddWithValue("@value", configID);
                }
                SqlDataReader dataReader = sqlCmd.ExecuteReader();
                if (dataReader.Read())
                {
                    setConfig.ID=Convert.ToInt32(dataReader["ID"]);
                    setConfig.ConfigurationTime=Convert.ToDateTime(dataReader["Time"]);
                }
                dataReader.Close();
                sqlQuery = "SELECT VideoExtensions,PhotoExtensions FROM Extensions WHERE ConfigurationID= @value;";
                sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                sqlCmd.Parameters.AddWithValue("@value", setConfig.ID);
                dataReader = sqlCmd.ExecuteReader();
                if (dataReader.Read())
                {
                    setConfig.SetExtensionConfiguration(dataReader["PhotoExtensions"].ToString(), dataReader["VideoExtensions"].ToString());
                }
                dataReader.Close();
                sqlQuery = "SELECT Camera,FolderName,VideoExt, PhotoExt FROM Folders WHERE ConfigurationID= @value;";
                sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                sqlCmd.Parameters.Clear();
                sqlCmd.Parameters.AddWithValue("@value", setConfig.ID);
                dataReader = sqlCmd.ExecuteReader();
                while (dataReader.Read())
                {
                    setConfig.AddFolder(dataReader["FolderName"].ToString(), dataReader["Camera"].ToString(), dataReader["VideoExt"].ToString(), dataReader["PhotoExt"].ToString());
                }
                dataReader.Close();
                try
                {
                    sqlConnection.Close();
                }
                catch (Exception exTwo)
                {
                    System.Diagnostics.Debug.Print("Problem with closing the connection : " + exTwo.ToString());
                }
                return setConfig;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with loading configuration from database!" + ex.ToString());
                try
                {
                    sqlConnection.Close();
                }
                catch(Exception exTwo)
                {
                    System.Diagnostics.Debug.Print("Problem with closing the connection : " + exTwo.ToString());
                }
                return null;
            }
            
        }
        /// <summary>
        /// Method used for creating DataTables in the database.
        /// </summary>
        public static void CreateTables() 
        {
            SqlConnection sqlConnection = new SqlConnection("Server= " + connectionParameters.ServerName + "; Database= " + connectionParameters.DatabaseName + "; Integrated Security=True;");
            try
            {
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with opening the connection : " + ex.ToString());
                return;
            }
            string sqlQuery;
            SqlCommand sqlCmd;
            try
            {
                sqlQuery = "CREATE TABLE Configurations" +
 "(ID INTEGER IDENTITY PRIMARY KEY,Time DATETIME)";
                sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("The table: Configurations; already exists in the database : ...Deleting the datatable and creating a new one..." + ex.ToString());
                try
                {
                    sqlQuery = "DROP TABLE Configurations";
                    sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCmd.ExecuteNonQuery();
                    sqlQuery = "CREATE TABLE Configurations" +
     "(ID INTEGER IDENTITY PRIMARY KEY,Time DATETIME)";
                    sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCmd.ExecuteNonQuery();
                }
                catch(Exception exTwo)
                {
                    System.Diagnostics.Debug.Print("Problem deleting the table Configurations and creating a new one! : " + exTwo.ToString());
                }
            }
            try
            {
                sqlQuery = "CREATE TABLE FilesChanges" +
 "(ID INTEGER IDENTITY PRIMARY KEY,Camera NVARCHAR(100),Name NVARCHAR(100),Path NVARCHAR(100),Type INT,Extension NVARCHAR(5),StartTime DATETIME,EndTime DATETIME)";
                sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("The table: FilesChanges; already exists in the database : " + ex.ToString());
                try
                {
                    sqlQuery = "DROP TABLE FilesChanges";
                    sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCmd.ExecuteNonQuery();
                    sqlQuery = "CREATE TABLE FilesChanges" +
 "(ID INTEGER IDENTITY PRIMARY KEY,Camera NVARCHAR(100),Name NVARCHAR(100),Path NVARCHAR(100),Type INT,Extension NVARCHAR(5),StartTime DATETIME,EndTime DATETIME)";
                    sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCmd.ExecuteNonQuery();
                }
                catch (Exception exTwo)
                {
                    System.Diagnostics.Debug.Print("Problem deleting the table FilesChanges and creating a new one! : " + exTwo.ToString());
                }
            }
            try
            {
                sqlQuery = "CREATE TABLE Folders" +
 "(ID INTEGER IDENTITY PRIMARY KEY,Camera NVARCHAR(100),FolderName NVARCHAR(100),VideoExt NVARCHAR(255),PhotoExt NVARCHAR(255),ConfigurationID INT)";
                sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("The table: Folders; already exists in the database : " + ex.ToString());
                try
                {
                    sqlQuery = "DROP TABLE Folders";
                    sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCmd.ExecuteNonQuery();
                    sqlQuery = "CREATE TABLE Folders" +
 "(ID INTEGER IDENTITY PRIMARY KEY,Camera NVARCHAR(100),FolderName NVARCHAR(100),VideoExt NVARCHAR(255),PhotoExt NVARCHAR(255),ConfigurationID INT)";
                    sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCmd.ExecuteNonQuery();
                }
                catch (Exception exTwo)
                {
                    System.Diagnostics.Debug.Print("Problem deleting the table Folders and creating a new one! : " + exTwo.ToString());
                }
            }
            try
            {
                sqlQuery = "CREATE TABLE Extensions" +
 "(ID INTEGER IDENTITY PRIMARY KEY,PhotoExtensions NVARCHAR(255),VideoExtensions NVARCHAR(255),ConfigurationID INT)";
                sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("The table: Extensions; already exists in the database : "+ex.ToString());
                try
                {
                    sqlQuery = "DROP TABLE Extensions";
                    sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCmd.ExecuteNonQuery();
                    sqlQuery = "CREATE TABLE Extensions" +
 "(ID INTEGER IDENTITY PRIMARY KEY,PhotoExtensions NVARCHAR(255),VideoExtensions NVARCHAR(255),ConfigurationID INT)";
                    sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCmd.ExecuteNonQuery();
                }
                catch (Exception exTwo)
                {
                    System.Diagnostics.Debug.Print("Problem deleting the table Folders and creating a new one! : " + exTwo.ToString());
                }
            }
            try
            {
                sqlQuery = "CREATE TABLE FileTypeEnum" +
 "(TypeID INT,FileType NVARCHAR(50))";
                sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                sqlCmd.ExecuteNonQuery();
                sqlQuery = "INSERT INTO FileTypeEnum(TypeID, FileType) VALUES(@typeid,@filetype)";
                sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                sqlCmd.Parameters.Clear();
                sqlCmd.Parameters.AddWithValue("@typeid", 1);
                sqlCmd.Parameters.AddWithValue("@filetype", "Video");
                sqlCmd.ExecuteNonQuery();
                sqlQuery = "INSERT INTO FileTypeEnum(TypeID, FileType) VALUES(@typeid,@filetype)";
                sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                sqlCmd.Parameters.Clear();
                sqlCmd.Parameters.AddWithValue("@typeid", 2);
                sqlCmd.Parameters.AddWithValue("@filetype", "Photo");
                sqlCmd.ExecuteNonQuery();
                sqlQuery = "INSERT INTO FileTypeEnum(TypeID, FileType) VALUES(@typeid,@filetype)";
                sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                sqlCmd.Parameters.Clear();
                sqlCmd.Parameters.AddWithValue("@typeid", 3);
                sqlCmd.Parameters.AddWithValue("@filetype", "Other");
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("The table: FileTypeEnum; already exists in the database : ...Deleting the datatable and creating a new one..." + ex.ToString());
                try
                {
                    sqlQuery = "DROP TABLE FileTypeEnum";
                    sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCmd.ExecuteNonQuery();
                    sqlQuery = "CREATE TABLE FileTypeEnum" +
 "(TypeID INT,FileType NVARCHAR(50))";
                    sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCmd.ExecuteNonQuery();
                    sqlQuery = "INSERT INTO FileTypeEnum(TypeID, FileType) VALUES(@typeid,@filetype)";
                    sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCmd.Parameters.Clear();
                    sqlCmd.Parameters.AddWithValue("@typeid", 1);
                    sqlCmd.Parameters.AddWithValue("@filetype", "Video");
                    sqlCmd.ExecuteNonQuery();
                    sqlQuery = "INSERT INTO FileTypeEnum(TypeID, FileType) VALUES(@typeid,@filetype)";
                    sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCmd.Parameters.Clear();
                    sqlCmd.Parameters.AddWithValue("@typeid", 2);
                    sqlCmd.Parameters.AddWithValue("@filetype", "Photo");
                    sqlCmd.ExecuteNonQuery();
                    sqlQuery = "INSERT INTO FileTypeEnum(TypeID, FileType) VALUES(@typeid,@filetype)";
                    sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCmd.Parameters.Clear();
                    sqlCmd.Parameters.AddWithValue("@typeid", 3);
                    sqlCmd.Parameters.AddWithValue("@filetype", "Other");
                    sqlCmd.ExecuteNonQuery();
                }
                catch (Exception exTwo)
                {
                    System.Diagnostics.Debug.Print("Problem deleting the table FileTypeEnum and creating a new one! : " + exTwo.ToString());
                }
            }
            try
            {
                sqlConnection.Close();
            }
            catch (Exception exTwo)
            {
                System.Diagnostics.Debug.Print("Problem with closing the connection : " + exTwo.ToString());
            }
        }
        /// <summary>
        /// Method for saving the recorded files to the database. First, it saves those who are created for the first time and then, with the boolean variable, it checks those who only need to be updated in the database.
        /// </summary>
        /// <param name="filesToInsert">An instance of the class RecordedFilesConfiguration, which is used to read all the files that have been recorded.</param>
        /// <returns></returns>
        public static List<FileCreated> InsertFilesCreated(RecordedFilesCollection filesToInsert) 
        {
            SqlConnection sqlConnection = new SqlConnection("Server= " + connectionParameters.ServerName + "; Database= " + connectionParameters.DatabaseName + "; Integrated Security=True;");
            try
            {
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with opening the connection : " + ex.ToString());
                return null;
            }
            string sqlQuery;
            SqlCommand sqlCmd;
            List<FileCreated> newItems = new List<FileCreated>();
            if(filesToInsert.AllFiles == null)
            {
                return null;
            }
            for (int i = 0; i < filesToInsert.AllFiles.Count; i++)
            {
                if (filesToInsert.AllFiles[i].DoesExist == true)
                {
                    continue;
                }
                FileCreated fc = filesToInsert.AllFiles[i];
                if (fc.EnumType == 0)
                {
                    try
                    {
                        sqlQuery = "INSERT INTO FilesChanges(Camera, Name, Path, Type, Extension, StartTime, Endtime) VALUES(@camera, @name, @path, @type, @extension, @starttime, @endtime)";
                        sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                        sqlCmd.Parameters.Clear();
                        sqlCmd.Parameters.AddWithValue("@camera", fc.Camera);
                        sqlCmd.Parameters.AddWithValue("@name", fc.Name);
                        sqlCmd.Parameters.AddWithValue("@path", fc.Path);
                        sqlCmd.Parameters.AddWithValue("@type", fc.EnumType);
                        sqlCmd.Parameters.AddWithValue("@extension", fc.Extension);
                        sqlCmd.Parameters.AddWithValue("@starttime", fc.TimeCreated);
                        sqlCmd.Parameters.AddWithValue("@endtime", fc.TimeChanged);
                        sqlCmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.Print("Problem with Inserting video file in the database : "+ex.ToString());
                    }
                    newItems.Add(new FileCreated(fc));
                }
                else
                {
                    try
                    {
                        sqlQuery = "INSERT INTO FilesChanges(Camera, Name, Path, Type, Extension, StartTime) VALUES(@camera, @name, @path, @type, @extension, @starttime)";
                        sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                        sqlCmd.Parameters.Clear();
                        sqlCmd.Parameters.AddWithValue("@camera", fc.Camera);
                        sqlCmd.Parameters.AddWithValue("@name", fc.Name);
                        sqlCmd.Parameters.AddWithValue("@path", fc.Path);
                        sqlCmd.Parameters.AddWithValue("@type", fc.EnumType);
                        sqlCmd.Parameters.AddWithValue("@extension", fc.Extension);
                        sqlCmd.Parameters.AddWithValue("@starttime", fc.TimeCreated);
                        sqlCmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        System.Diagnostics.Debug.Print("Problem with Inserting photo file in the database : "+ex.ToString());
                    }
                    newItems.Add(new FileCreated(fc));
                }
                filesToInsert.AllFiles.RemoveAt(i);
                i--;
            }
            if (filesToInsert.AllFiles.Count > 0)
            {
                for (int i = 0; i < filesToInsert.AllFiles.Count; i++)
                {
                    try
                    {
                        sqlQuery = "UPDATE FilesChanges SET EndTime = @et WHERE Path = @pathf";
                        sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                        sqlCmd.Parameters.Clear();
                        sqlCmd.Parameters.AddWithValue("@pathf", filesToInsert.AllFiles[i].Path);
                        sqlCmd.Parameters.AddWithValue("@et", filesToInsert.AllFiles[i].TimeChanged);
                        int checkRows = sqlCmd.ExecuteNonQuery();
                        if (checkRows == 0)
                        {
                            System.Diagnostics.Debug.Print("DOESNT EXIST IN A DATABASE");
                            System.Diagnostics.Debug.Print(sqlConnection.State.ToString());
                            sqlQuery = "INSERT INTO FilesChanges(Camera, Name, Path, Type, Extension, StartTime, EndTime) VALUES(@camera, @name, @path, @type, @extension, @starttime,@endtime)";
                            sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                            sqlCmd.Parameters.Clear();
                            sqlCmd.Parameters.AddWithValue("@camera", filesToInsert.AllFiles[i].Camera);
                            sqlCmd.Parameters.AddWithValue("@name", filesToInsert.AllFiles[i].Name);
                            sqlCmd.Parameters.AddWithValue("@path", filesToInsert.AllFiles[i].Path);
                            sqlCmd.Parameters.AddWithValue("@type", filesToInsert.AllFiles[i].EnumType);
                            sqlCmd.Parameters.AddWithValue("@extension", filesToInsert.AllFiles[i].Extension);
                            sqlCmd.Parameters.AddWithValue("@starttime", File.GetCreationTime(filesToInsert.AllFiles[i].Path));
                            sqlCmd.Parameters.AddWithValue("@endtime", filesToInsert.AllFiles[i].TimeChanged);
                            sqlCmd.ExecuteNonQuery();
                        }
                    }
                    catch(Exception ex)
                    {
                        System.Diagnostics.Debug.Print("Problem with updating data in the database : " + ex.ToString());
                    }
                    newItems.Add(new FileCreated(filesToInsert.AllFiles[i]));
                }
            }
            try
            {
                sqlConnection.Close();
            }
            catch (Exception exTwo)
            {
                System.Diagnostics.Debug.Print("Problem with closing the connection : " + exTwo.ToString());
            }
            return newItems;  
        }
        /// <summary>
        /// A method used for saving the configuration, if changes have been made to the previous one. It also saves all the folders, extensions and folder preferences to the database.
        /// </summary>
        /// <param name="toSave">An instance of the class Configuration, used to read from and save the application configuration to the database</param>
        public static void SaveConfigurationToDatabase(ref Configuration toSave) 
        {
            SqlConnection sqlConnection = new SqlConnection("Server= " + connectionParameters.ServerName + "; Database= " + connectionParameters.DatabaseName + "; Integrated Security=True;");
            try
            {
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with opening the connection : " + ex.ToString());
                return ;
            }
            try
            {
                string sqlQuery;
                SqlCommand sqlCmd;
                int saveID = 1;
                DateTime dateWritten = DateTime.Now;
                sqlQuery = "INSERT INTO Configurations(Time) VALUES(@time)";
                sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                sqlCmd.Parameters.Clear();
                sqlCmd.Parameters.AddWithValue("@time", dateWritten);
                sqlCmd.ExecuteNonQuery();
                sqlQuery = "SELECT ID FROM Configurations WHERE ID=(SELECT max(ID) FROM Configurations);";
                sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                sqlCmd.Parameters.Clear();
                SqlDataReader dataReader = sqlCmd.ExecuteReader();
                try
                {
                    dataReader.Read();
                    saveID = Convert.ToInt32(dataReader["ID"]);
                }
                catch
                {
                }
                toSave.ID=saveID;
                toSave.ConfigurationTime=dateWritten;
                dataReader.Close();
                for (int i = 0; i < toSave.FoldersConfigurations.Count; i++)
                {
                    sqlCmd.Parameters.Clear();
                    sqlCmd.CommandText = @"INSERT INTO Folders(Camera,FolderName,VideoExt,PhotoExt,ConfigurationID) VALUES(@camera,@foldername,@videoext,@photoext,@confid)";
                    sqlCmd.Parameters.AddWithValue("@camera", toSave.FoldersConfigurations[i].Camera);
                    sqlCmd.Parameters.AddWithValue("@foldername", toSave.FoldersConfigurations[i].FolderPath);
                    sqlCmd.Parameters.AddWithValue("@videoext", toSave.FoldersConfigurations[i].VideoExtensionsString);
                    sqlCmd.Parameters.AddWithValue("@photoext", toSave.FoldersConfigurations[i].PhotoExtensionsString);
                    sqlCmd.Parameters.AddWithValue("@confid", saveID);
                    sqlCmd.ExecuteNonQuery();
                }
                sqlQuery = "INSERT INTO Extensions(PhotoExtensions,VideoExtensions,ConfigurationID) VALUES(@pe,@ve,@confid)";
                sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                sqlCmd.Parameters.Clear();
                sqlCmd.Parameters.AddWithValue("@pe", toSave.ExtensionConfiguration.PhotoExtensionsString);
                sqlCmd.Parameters.AddWithValue("@ve", toSave.ExtensionConfiguration.VideoExtensionsString);
                sqlCmd.Parameters.AddWithValue("@confid", saveID);
                sqlCmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with saving the configuration to the database : " + ex.ToString());
            }
            try
            {
                sqlConnection.Close();
            }
            catch (Exception exTwo)
            {
                System.Diagnostics.Debug.Print("Problem with closing the connection : " + exTwo.ToString());
            }
        }
        /// <summary>
        /// Method used for loading all the existing files in the database, used for displaying history of files and filtering them within some given parameters.
        /// </summary>
        /// <returns></returns>
        public static List<FileHistoryItem> LoadFilesFromDatabase()
        {
            SqlConnection sqlConnection = new SqlConnection("Server= " + connectionParameters.ServerName + "; Database= " + connectionParameters.DatabaseName + "; Integrated Security=True;");
            try
            {
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with opening the connection : " + ex.ToString());
                return null;
            }
            try
            {
                string sqlQuery;
                SqlCommand sqlCmd;
                List<FileHistoryItem> filesFromBase = new List<FileHistoryItem>();
                sqlQuery = "SELECT * FROM FilesChanges JOIN FileTypeEnum ON FilesChanges.Type=FileTypeEnum.TypeID";
                sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                SqlDataReader dataReader = sqlCmd.ExecuteReader();
                while (dataReader.Read())
                {
                    filesFromBase.Add(new FileHistoryItem(Convert.ToInt32(dataReader.GetValue(0)), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), dataReader.GetValue(3).ToString(), (FileTypes)Convert.ToInt32(dataReader.GetValue(4)), dataReader.GetValue(9).ToString(), dataReader.GetValue(5).ToString(), dataReader.GetValue(6).ToString(), dataReader.GetValue(7).ToString()));
                }
                dataReader.Close();
                try
                {
                    sqlConnection.Close();
                }
                catch (Exception exTwo)
                {
                    System.Diagnostics.Debug.Print("Problem with closing the connection : " + exTwo.ToString());
                }
                return filesFromBase;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with loading all the existing files from the database : " + ex.ToString());
                try
                {
                    sqlConnection.Close();
                }
                catch (Exception exTwo)
                {
                    System.Diagnostics.Debug.Print("Problem with closing the connection : " + exTwo.ToString());
                }
                return null;
            }
        }
        /// <summary>
        /// Method used for loading all the existing configurations in the database, so that the user can choose which previous configuration they want to load.
        /// </summary>
        /// <returns></returns>
        public static List<Configuration> LoadAllPreviousConfigurations()
        {
            SqlConnection sqlConnection = new SqlConnection("Server= " + connectionParameters.ServerName + "; Database= " + connectionParameters.DatabaseName + "; Integrated Security=True;");
            try
            {
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with opening the connection : " + ex.ToString());
                return null;
            }
            try
            {
                string sqlQuery;
                SqlCommand sqlCmd;
                List<Configuration> allConfigurations = new List<Configuration>();
                sqlQuery = "SELECT * FROM Configurations";
                sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                SqlDataReader dataReader = sqlCmd.ExecuteReader();
                while (dataReader.Read())
                {
                    allConfigurations.Add(LoadConfiguration(Convert.ToInt32(dataReader["ID"])));
                }
                dataReader.Close();
                try
                {
                    sqlConnection.Close();
                }
                catch (Exception exTwo)
                {
                    System.Diagnostics.Debug.Print("Problem with closing the connection : " + exTwo.ToString());
                }
                return allConfigurations;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with loading saved configurations from database : "+ex.ToString());
                try
                {
                    sqlConnection.Close();
                }
                catch (Exception exTwo)
                {
                    System.Diagnostics.Debug.Print("Problem with closing the connection : " + exTwo.ToString());
                }
                return null;
            }
            
        }
        /// <summary>
        /// Sets the database's name for accessing the server.
        /// </summary>
        /// <param name="serverName">String containing the server's name</param>
        /// <param name="dbName">String containing the database's name</param>
        public static void SetDatabaseName(string serverName,string dbName)
        {
            connectionParameters.ServerName = String.Copy(serverName);
            connectionParameters.DatabaseName = String.Copy(dbName);
            //using(StreamWriter sr = new StreamWriter(@".\DatabaseInfo.txt"))
            //{
            //    sr.WriteLine(serverName);
            //    sr.WriteLine(dbName);
            //}
            s_invalidData = false;
            ConnectionParameters temp = new ConnectionParameters(dbName, serverName);
            var serializer = new XmlSerializer(typeof(ConnectionParameters));
            using (var writer = new StreamWriter(s_fileName))
            {
                serializer.Serialize(writer, temp);
            }
        }
        /// <summary>
        /// Checks if the input for server and datebase names, contains the right tables for the app to work
        /// </summary>
        /// <param name="serverName">String containing the server's name</param>
        /// <param name="dbName">String containing the database's name</param>
        /// <returns></returns>
        public static bool CheckTables(string serverName=null,string dbName=null) 
        {
            SqlConnection sqlConnection = new SqlConnection("Server= " + connectionParameters.ServerName + "; Database= " + connectionParameters.DatabaseName + "; Integrated Security=True;");
            SqlConnection conTemp;
            if (dbName==null || serverName==null)
            {
                conTemp = sqlConnection;
            }
            else
            {
                conTemp = new SqlConnection("Server= "+serverName+"; Database= " + dbName + "; Integrated Security=True;");
            }
            conTemp.Open();
            try
            {
                string sqlQuery = "SELECT TOP(1) ID,Time FROM Configurations";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conTemp);
                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("A column is either missing, or misspelled (TABLE NAME: Configurations) : " + ex.ToString());
                conTemp.Close();
                return false;
            }
            try
            {
                string sqlQuery = "SELECT TOP(1) ID,PhotoExtensions,VideoExtensions,ConfigurationID FROM Extensions";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conTemp);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("A column is either missing, or misspelled (TABLE NAME: Extensions) : " + ex.ToString());
                conTemp.Close();
                return false;
            }
            try
            {
                string sqlQuery = "SELECT TOP(1) ID,Camera,Name,Path,Type,Extension,StartTime,EndTime FROM FilesChanges";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conTemp);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("A column is either missing, or misspelled (TABLE NAME: FilesChanges) : " + ex.ToString());
                conTemp.Close();
                return false;
            }
            try
            {
                string sqlQuery = "SELECT TOP(1) ID,Camera,FolderName,VideoExt,ConfigurationID FROM Folders";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conTemp);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("A column is either missing, or misspelled (TABLE NAME: Folders) : " + ex.ToString());
                conTemp.Close();
                return false;
            }
            conTemp.Close();
            return true;
            
        }
        /// <summary>
        /// Checks if the database exists on the server
        /// </summary>
        /// <param name="serverName">String containing the server's name</param>
        /// <param name="dbName">String containing the database's name</param>
        /// <returns></returns>
        public static bool CheckDatabase(string serverName,string dbName)
        {

            try
            {
                string sqlConnectionString = "Server= "+serverName+"; Database= "+ dbName +"; Integrated Security=True;";
                SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
                sqlConnection.Open();
                sqlConnection.Close();
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("The database name doesnt exist !" + ex.ToString());
                return false;
            }
            return true;
        }
        /// <summary>
        /// Return the name of the database that is currently in use.
        /// </summary>
        /// <returns>String containing the database's name</returns>
        public static string DatabaseName()
        {
            return connectionParameters.DatabaseName;
        }
        /// <summary>
        /// Returns the name of the server that is currently in use.
        /// </summary>
        /// <returns>String containing the server's name</returns>
        public static string ServerName()
        {
            return connectionParameters.ServerName;
        }
    }
}
