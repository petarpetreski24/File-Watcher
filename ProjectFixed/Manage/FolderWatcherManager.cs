using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using ProjectFixed.Collections;
using ProjectFixed.Config;
using ProjectFixed.Database;

namespace ProjectFixed.Manage
{
    public class FolderWatcherManager
    {
        #region fields
        private bool _lastAttemptToWrite = false;
        private List<FileSystemWatcher> _folderWatchers = new List<FileSystemWatcher>();
        private Configuration _appConfiguration;
        private RecordedFilesCollection _recordedFiles = new RecordedFilesCollection();
        public delegate void ListOfInsertedFilesEventHandler(List<FileCreated> FilesToShow);
        public event ListOfInsertedFilesEventHandler ListOfInsertedFiles;
        public Configuration WatcherConfiguration { get { return _appConfiguration; } set { _appConfiguration = new Configuration(value); } }
        #endregion
        #region threads
        Thread BackgroundWriter;
        #endregion
        #region constructor
        public FolderWatcherManager(Configuration loaded)
        {
            if(loaded==null)
            {
                return;
            }
            BackgroundWriter = new Thread(SaveList);
            _appConfiguration = new Configuration(loaded);
            BackgroundWriter.Name = "Database Saver Thread";
            BackgroundWriter.Start();
        }
        #endregion
        #region public and private methods
        /// <summary>
        /// Disables all active FileSystemWatchers and then, it fetches the new folders from the class Configuration and creates FileSystemWatchers for those folders. It does not set EnableRaisingEvents property to true. It only creates the new Watchers.
        /// </summary>
        public void RefreshMonitoredFolders()
        {
            foreach (FileSystemWatcher fs in _folderWatchers)
            {
                fs.EnableRaisingEvents = false;
                fs.Dispose();
            }
            _folderWatchers.Clear();
            foreach (FolderConfiguration mf in _appConfiguration.FoldersConfigurations)
            {
                _folderWatchers.Add(new FileSystemWatcher(mf.FolderPath));
                _folderWatchers[_folderWatchers.Count - 1].IncludeSubdirectories = true;
                _folderWatchers[_folderWatchers.Count - 1].Created += new FileSystemEventHandler(WatcherCreated);
                _folderWatchers[_folderWatchers.Count - 1].Changed += new FileSystemEventHandler(WatcherChanged);
                _folderWatchers[_folderWatchers.Count - 1].NotifyFilter = 
                                  NotifyFilters.FileName
                                 | NotifyFilters.Size;
            }
        }
        /// <summary>
        /// Method used by the thread that runs constantly and saves the files every 2 seconds.
        /// </summary>
        private void SaveList()
        {
            while(true)
            {
                System.Diagnostics.Debug.Print("Trying to save the files...");
                RecordedFilesCollection temp = new RecordedFilesCollection();
                temp.SetFiles(_recordedFiles.ExportFiles());
                if (temp.AllFiles!=null)
                {
                    System.Diagnostics.Debug.Print("Saving files... (Not Empty)");
                    ListOfInsertedFiles?.Invoke(SQLServices.InsertFilesCreated(temp));
                }
                else
                {
                    Thread.Sleep(2000);
                    System.Diagnostics.Debug.Print("Empty list...");
                }
                if (_lastAttemptToWrite)
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Sets the EnableRaisingEvents property to true and IncludeSubdirectories to false.
        /// </summary>
        public void EnableFoldersToMonitor()
        {
            foreach (FileSystemWatcher fs in _folderWatchers)
            {
                fs.EnableRaisingEvents = true;
            }
        }
        /// <summary>
        /// Sets the EnableRaisingEvents property to false, thus disabling the FileSystemWatchers.
        /// </summary>
        public void DisableFoldersToMonitor()
        {
            foreach (FileSystemWatcher fs in _folderWatchers)
            {
                fs.EnableRaisingEvents = false;
            }
        }
        /// <summary>
        /// Sets the EnableRaisingEvents property to false and disposes all the FileSystemWatchers. It also clears the list of FileSystemWatchers.
        /// </summary>
        public void DisposeAllFolders()
        {
            foreach (FileSystemWatcher fs in _folderWatchers)
            {
                fs.EnableRaisingEvents = false;
                fs.Dispose();
            }
            _folderWatchers.Clear();
        }
        /// <summary>
        /// Same functionality as UpdateList method in the class RecordedFilesConfiguration.
        /// </summary>
        /// <param name="potentialFile"></param>
        private void UpdatePotentialFile(FileCreated potentialFile)
        {
            _recordedFiles.UpdateList(potentialFile);
        }
        public void StopThread(bool wait,int waitTime)
        {
            int elapsed = 0;
            _lastAttemptToWrite = true;
            if(wait && BackgroundWriter!=null)
            {
                while(BackgroundWriter.IsAlive)
                {
                    Thread.Sleep(500);
                    elapsed += 500;
                    if(elapsed>=waitTime)
                    {
                        DialogResult dialogResult = MessageBox.Show("Due to an internal error, the thread that saves the information cannot be aborted. Do you want to stop the thread forcefully(Click OK) or wait again(Click Cancel)?", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        if(dialogResult==DialogResult.OK)
                        {
                            BackgroundWriter.Abort();
                        }
                        else
                        {
                            elapsed = 0;
                        }
                    }
                }
            }
        }
        #endregion
        #region events and events handlers
        /// <summary>
        /// A method called when a file is created.
        /// </summary>
        /// <param name="fullPath">Parameter containing the full path of the file created.</param>
        protected virtual void OnFileCreatedInput(string fullPath)
        {
            string camera="";
            FileTypes type;
            int folderCreatedIndex = -1;
            FileInfo tempFile = new FileInfo(fullPath);
            for (int i = 0; i < _appConfiguration.FoldersConfigurations.Count; i++)
            {
                if (_appConfiguration.FoldersConfigurations[i].FolderPath == tempFile.Directory.ToString())
                {
                    camera= _appConfiguration.FoldersConfigurations[i].Camera;
                    folderCreatedIndex = i;
                    break;
                }
            }
            if(folderCreatedIndex==-1)
            {
                return;
            }
            type = _appConfiguration.FoldersConfigurations[folderCreatedIndex].HasExtension(fullPath);
            if(type==FileTypes.OtherType)
            {
                return;
            }
            FileCreated newFile = new FileCreated(fullPath, type, camera);
            _recordedFiles.AddNewFile(newFile);
            //FileCreatedInput?.Invoke(this, newFile);
        }
        /// <summary>
        /// A method called when a file is changes.
        /// </summary>
        /// <param name="fullPath">Parameter containing the full path of the changed file.</param>
        protected virtual void OnFileChangedInput(string fullPath)
        {
            string camera = "";
            FileTypes type;
            int folderChangedIndex = -1;
            FileInfo tempFile = new FileInfo(fullPath);
            for (int i = 0; i < _appConfiguration.FoldersConfigurations.Count; i++)
            {
                if (_appConfiguration.FoldersConfigurations[i].FolderPath == tempFile.Directory.ToString())
                {
                    camera = _appConfiguration.FoldersConfigurations[i].Camera;
                    folderChangedIndex = i;
                    break;
                }
            }
            if(folderChangedIndex==-1)
            {
                return;
            }
            type = _appConfiguration.FoldersConfigurations[folderChangedIndex].HasExtension(fullPath);
            if (type == FileTypes.OtherType)
            {
                return;
            }
            FileCreated newFile = new FileCreated(fullPath, type, camera);
            UpdatePotentialFile(newFile);
            //FileChangedInput?.Invoke(this, new FileCreated(newFile));
        }
        /// <summary>
        /// An event handler for the event raised by FileSystemWatcher when a file is created.
        /// </summary>
        /// <param name="source">Object source.</param>
        /// <param name="e">An instance of the class FileSystemEventArgs containing information about the file.</param>
        protected void WatcherCreated(object source, FileSystemEventArgs e)
        {
            System.Diagnostics.Debug.Print("CREATED  "+e.FullPath);
            if (e.FullPath.EndsWith("TMP") || e.FullPath.EndsWith("tmp"))
            {
                return;
            }
            OnFileCreatedInput(e.FullPath);
        }
        /// <summary>
        ///  An event handler for the event raised by FileSystemWatcher when a file is changed.
        /// </summary>
        /// <param name="source">Object source.</param>
        /// <param name="e">An instance of the class FileSystemEventArgs containing information about the file.</param>
        protected void WatcherChanged(object source, FileSystemEventArgs e)
        {
            
            System.Diagnostics.Debug.Print("Changed  " + e.FullPath+ "-size: "+new FileInfo(e.FullPath).LastWriteTime);
            if (e.FullPath.EndsWith("TMP") || e.FullPath.EndsWith("tmp"))
            {
                return;
            }
            OnFileChangedInput(e.FullPath);
        }
        #endregion
    }
}
