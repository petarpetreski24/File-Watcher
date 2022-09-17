using System;
using System.IO;

namespace ProjectFixed.Collections
{
    public class FileCreated
    {
        #region fields
        private DateTime _timeCreated;
        private DateTime _timeChanged;
        private FileTypes _typeEnum;
        private string _name;
        private string _extension;
        private string _camera;
        private string _path;
        private bool _doesExist;
        public DateTime TimeChanged { get { return _timeChanged; } set { _timeChanged = value; } }
        public DateTime TimeCreated { get { return _timeCreated; } }
        public int EnumType { get { return Convert.ToInt32(_typeEnum); } }
        public bool DoesExist { get { return _doesExist; } set { _doesExist = value; } }
        public string Extension { get { return _extension; } }
        public string Camera { get { return _camera; } }
        public string Name { get { return _name; } }
        public string Path { get { return _path; } }
        #endregion
        #region constructors
        public FileCreated(string path,FileTypes type,string camera)
        {
            FileInfo tempFile = new FileInfo(path);
            _timeCreated = DateTime.Now;
            _timeChanged = DateTime.Now;
            _typeEnum = type;
            _name = tempFile.Name;
            _extension = tempFile.Extension;
            _camera = camera;
            _path = path;
            _doesExist = false;
        }
        public FileCreated(FileCreated copy)
        {
            if(copy!=null)
            {
                _timeCreated = copy._timeCreated;
                _timeChanged = copy._timeChanged;
                _typeEnum = copy._typeEnum;
                _name = String.Copy(copy._name);
                _extension = String.Copy(copy._extension);
                _camera = String.Copy(copy._camera);
                _path = String.Copy(copy._path);
                _doesExist = copy._doesExist;
            }
            else
            {
                throw new ArgumentNullException("FileCreated copy");
            }
        }
        #endregion
    }
}
