using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectFixed.Config;

namespace ProjectFixed.Config
{
    public class Configuration
    {
        #region fields
        private ExtensionsConfiguration _extensionsConfiguration = new ExtensionsConfiguration();
        private List<FolderConfiguration> _foldersConfiguration = new List<FolderConfiguration>();
        private int _configurationID=-1;
        private DateTime _configTime = DateTime.Now;
        public int ID { get { return _configurationID; } set { _configurationID = value; } }
        public DateTime ConfigurationTime { get { return _configTime; } set { _configTime = value; } }
        public List<FolderConfiguration> FoldersConfigurations { get { return _foldersConfiguration; } }
        public ExtensionsConfiguration ExtensionConfiguration { get { return _extensionsConfiguration; } }
        #endregion
        #region constructors
        public Configuration()
        {

        }
        public Configuration(Configuration copy)
        {
            if(copy!=null)
            {
                _extensionsConfiguration = new ExtensionsConfiguration(copy.ExtensionConfiguration);
                foreach (FolderConfiguration mf in copy.FoldersConfigurations)
                {
                    _foldersConfiguration.Add(new FolderConfiguration(mf)); //kopija da se praj
                }
                _configurationID = copy.ID;
                _configTime = DateTime.Now;
            }
            else
            {
                throw new ArgumentNullException("Configuration copy");
            }
        }
        #endregion
        #region operators overload
        public static bool operator ==(Configuration c1, Configuration c2)
        { 
            if((Object)c1==null)
            {
                return (Object)c2 == null;
            }
            if((Object)c2==null)
            {
                return false;
            }
            if (c1._foldersConfiguration.Count != c2._foldersConfiguration.Count)
            {
                return false;
            }
            if (c1._extensionsConfiguration!=c2._extensionsConfiguration)
            {
                return false;
            }
            for(int i=0;i<c1._foldersConfiguration.Count;i++)
            {
                if(c1._foldersConfiguration[i]!=c2._foldersConfiguration[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static bool operator !=(Configuration c1, Configuration c2)
        {
            return !(c1 == c2);
        }
        public override bool Equals(object c1)
        {
            Configuration config1 = (Configuration)c1;
            if (config1 == null)
            {
                return false;
            }
            return this == config1;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        #region public methods
        /// <summary>
        /// Adds a folder to be monitord to the configuration. 
        /// It does not set EnableRaisingEvents to true for the added folder.
        /// </summary>
        /// <param name="folderName">String containing the folder's name</param>
        /// <param name="camera">String containing the folder's camera name</param>
        /// <param name="folderVideoExtensions">String containing the folder's video extensions, comma-seperated values</param>
        /// <param name="folderPhotoExtensions">String containing the folder's photo extensions, comma-seperated values</param>
        public void AddFolder(string folderName, string camera, string folderVideoExtensions, string folderPhotoExtensions)
        {
            _foldersConfiguration.Add(new FolderConfiguration(folderName, camera, folderVideoExtensions, folderPhotoExtensions));
        }
        /// <summary>
        /// Removes a folder at a specified index in the list.
        /// </summary>
        /// <param name="n">Index of the list</param>
        public void RemoveFolder(int n)
        {
            _foldersConfiguration.RemoveAt(n);
        }
        /// <summary>
        /// Creates a new instance for the field of the class ExtensionsConfiguration for the set configuration.
        /// </summary>
        /// <param name="photoExtensions">String containing the photo extensions, comma-seperated values.</param>
        /// <param name="videoExtensions">String containing the video extensions, comma-seperated values.</param>
        public void SetExtensionConfiguration(string photoExtensions, string videoExtensions)
        {
            _extensionsConfiguration = new ExtensionsConfiguration(photoExtensions, videoExtensions);
        }
        #endregion
    }
}
