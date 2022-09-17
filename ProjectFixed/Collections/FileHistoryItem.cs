using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFixed.Collections
{
    public class FileHistoryItem
    {
        #region fields
        private int _fileID;
        private string _fileCamera;
        private string _fileName;
        private string _filePath;
        private FileTypes _fileTypeEnum;
        private string _fileType;
        private string _fileExtension;
        private DateTime _fileCreationTime;
        private string _fileCreationTimeString;
        private DateTime _fileFinishedTime;
        private string _fileFinishedTimeString;
        private bool _hasFinishedTime=true;
        public int ID { get { return _fileID; } }
        public string Camera { get { return _fileCamera; } }
        public string Name { get { return _fileName; } }
        public string Path { get { return _filePath; } }
        public FileTypes TypeEnum { get { return _fileTypeEnum; } }
        public string Type { get { return _fileType; } }
        public string Extension { get { return _fileExtension; } }
        public string CreationTimeString { get { return _fileCreationTimeString; } }
        public DateTime CreationTime { get { return _fileCreationTime; } }
        public string FinishedTimeString { get { return _fileFinishedTimeString; } }
        public DateTime FinishedTime { get { return _fileFinishedTime; } }
        public bool HasFinishedTime { get { return _hasFinishedTime; } }
        #endregion
        public FileHistoryItem(int fileID,string fileCamera,string fileName,string filePath,FileTypes fileTypeEnum,string fileType,string fileExtension,string fileCreationTime,string fileFinishedTime)
        {
            _fileID = fileID;
            _fileCamera = String.Copy(fileCamera);
            _fileName = String.Copy(fileName);
            _filePath = String.Copy(filePath);
            _fileTypeEnum = fileTypeEnum;
            _fileType = String.Copy(fileType);
            _fileExtension = String.Copy(fileExtension);
            _fileCreationTimeString = String.Copy(fileCreationTime);
            _fileCreationTime = DateTime.Parse(_fileCreationTimeString);
            if(fileFinishedTime==null || fileFinishedTime.Length==0)
            {
                _fileFinishedTimeString = "N/A";
                _hasFinishedTime = false;
                _fileFinishedTime = DateTime.MinValue;
            }
            else
            {
                _fileFinishedTimeString = String.Copy(fileFinishedTime);
                _fileFinishedTime = DateTime.Parse(_fileFinishedTimeString);
            }
        }
    }
}
