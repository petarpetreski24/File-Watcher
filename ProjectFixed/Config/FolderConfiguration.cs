using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ProjectFixed.Config
{
    public class FolderConfiguration
    {
        #region fields
        private List<string> _folderVideoExtensions = new List<string>();
        private List<string> _folderPhotoExtensions = new List<string>();
        private string _folderVideoExtensionsString;
        private string _folderPhotoExtensionsString;
        private string _folderPath;
        private string _folderCamera;
        public string Camera { get { return _folderCamera; } set { _folderCamera = value; } }
        public string FolderPath { get { return _folderPath; } set { _folderPath = value; } }
        public string VideoExtensionsString {
            get { return _folderVideoExtensionsString; } 
            set {
                    _folderVideoExtensions.Clear();
                    _folderVideoExtensionsString = value;
                    string[] extensionsVsplit = value.Split(',');
                    foreach (string s in extensionsVsplit)
                    {
                        if (s.Trim().Length == 0)
                            continue;
                        this.AddVideoExtension(s);
                    }
            } }
        public string PhotoExtensionsString { 
            get { return _folderPhotoExtensionsString; } 
            set {
                _folderPhotoExtensions.Clear();
                _folderPhotoExtensionsString = value;
                string[] extensionsPsplit = value.Split(',');
                foreach (string s in extensionsPsplit)
                {
                    if (s.Trim().Length == 0)
                        continue;
                    this.AddPhotoExtension(s);
                }
            } }
        public List<string> VideoExtensionsList { get { return _folderVideoExtensions; } }
        public List<string> PhotoExtensionsList { get { return _folderPhotoExtensions; } }
        #endregion
        #region constructors
        public FolderConfiguration(string folderName = null, string camera = "", string folderVideoExtensions = "", string folderPhotoExtensions = "")
        {
            this.Camera=camera;
            this.VideoExtensionsString=folderVideoExtensions;
            this.PhotoExtensionsString=folderPhotoExtensions;
            this._folderPath = folderName;
        }
        public FolderConfiguration(FolderConfiguration copy)
        {
            if(copy!=null)
            {
                _folderVideoExtensions = new List<string>(copy._folderVideoExtensions);
                _folderPhotoExtensions = new List<string>(copy._folderPhotoExtensions);
                _folderVideoExtensionsString = String.Copy(copy._folderVideoExtensionsString);
                _folderPhotoExtensionsString = String.Copy(copy._folderPhotoExtensionsString);
                _folderPath = String.Copy(copy._folderPath);
                _folderCamera = String.Copy(copy._folderCamera);
            }
            else
            {
                throw new ArgumentNullException("FolderConfiguration copy");
            }
        }
        #endregion
        #region operators overload
        public static bool operator == (FolderConfiguration m1, FolderConfiguration m2)
        {
            if((Object)m1==null)
            {
                return ((Object)m2 == null);
            }
            if((Object)m2==null)
            {
                return false;
            }
            return (m1.VideoExtensionsString == m2.VideoExtensionsString) &&(m1._folderCamera == m2._folderCamera) &&(m1._folderPath == m2._folderPath) && (m1.PhotoExtensionsString == m2.PhotoExtensionsString);
        }
        public static bool operator !=(FolderConfiguration m1,FolderConfiguration m2)
        {
            return !(m1 == m2);
        }
        public override bool Equals(object c1)
        {
            FolderConfiguration config1 = (FolderConfiguration)c1;
            return this == config1;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        #region public methods
        /// <summary>
        /// Removes the video extension at an index position.
        /// </summary>
        /// <param name="n">An index to the position of the video extension that will be removed.</param>
        public void RemoveVideoExtension(int n)
        {
            _folderVideoExtensions.RemoveAt(n);
        }
        /// <summary>
        /// Removes the photo extension at an index position.
        /// </summary>
        /// <param name="n">An index to the position of the photo extension that will be removed.</param>
        public void RemovePhotoExtension(int n)
        {
            _folderPhotoExtensions.RemoveAt(n);
        }
        /// <summary>
        /// Check if the folder contains the given extension. Return 'V' if the folder contains that extension and it is a video extension, 'P' if the folder contains that extension an
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public FileTypes HasExtension(string path)
        {
            FileInfo temp = new FileInfo(path);
            if(_folderVideoExtensions.Contains(temp.Extension))
            {
                return FileTypes.Video;
            }
            else if(_folderPhotoExtensions.Contains(temp.Extension))
            {
                return FileTypes.Photo;
            }
            else
            {
                return FileTypes.OtherType;
            }
        }
        /// <summary>
        /// Adds the extension to the folder's video extensions.
        /// </summary>
        /// <param name="s">Argument containing the video extension.</param>
        public void AddVideoExtension(string s)
        {
            _folderVideoExtensions.Add(s);
        }
        /// <summary>
        /// Adds the extension to the folder's photo extensions.
        /// </summary>
        /// <param name="s">Argument containing the photo extension.</param>
        public void AddPhotoExtension(string s)
        {
            _folderPhotoExtensions.Add(s);
        }
        #endregion
    }
}
