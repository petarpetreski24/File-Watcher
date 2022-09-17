using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectFixed.Config;

namespace ProjectFixed.Collections
{
    public class RecordedFilesCollection
    {
        #region fields
        List<FileCreated> filesRecorded = new List<FileCreated>();
        public List<FileCreated> AllFiles { get { return filesRecorded; } }
        private object _lockedList = new object();
        #endregion
        #region constructor
        public RecordedFilesCollection()
        {

        }
        #endregion
        #region public methods
        /// <summary>
        /// Search through the list of recorded files. If a file with the same path exists, update its ChangedTime. Otherwise, create a new file, whose CreationTime will be used as a parameter to update an already existing file in the database.
        /// </summary>
        /// <param name="potentialFile">An instance of the class FileCreated, sent to be added to the list of recorded files.</param>
        public void UpdateList(FileCreated potentialFile)
        {
            lock (filesRecorded)
            {
                foreach (FileCreated fc in filesRecorded)
                {
                    if (fc.Path == potentialFile.Path)
                    {
                        fc.TimeChanged=potentialFile.TimeCreated;
                        return;
                    }
                }
                filesRecorded.Add(potentialFile);
                filesRecorded[filesRecorded.Count - 1].DoesExist=true;
                filesRecorded[filesRecorded.Count - 1].TimeChanged=DateTime.Now;
            }
        }
        /// <summary>
        /// Adds a new created file to the list of recorded files
        /// </summary>
        /// <param name="newFile"></param>
        public void AddNewFile(FileCreated newFile)
        {
            lock(_lockedList)
            {
                filesRecorded.Add(new FileCreated(newFile));
            }
        }
        /// <summary>
        /// Copies the files to another list, which is saved to the database and clears the original list.
        /// </summary>
        /// <returns></returns>
        public List<FileCreated> ExportFiles()
        {
            lock (_lockedList)
            {
                if(filesRecorded.Count==0)
                {
                    return null;
                }
                List<FileCreated> temp = new List<FileCreated>(filesRecorded.Count);
                foreach (FileCreated fc in filesRecorded)
                {
                    temp.Add(new FileCreated(fc));
                }
                filesRecorded.Clear();
                return temp;
            }
        }
        #endregion
        #region accessors
        /// <summary>
        /// Sets the list as the sent argument sent
        /// </summary>
        /// <param name="fileList">List of FileCreated which contains recorded files.</param>
        public void SetFiles(List<FileCreated> fileList)
        {
            filesRecorded = fileList;
        }
        #endregion
    }
}
