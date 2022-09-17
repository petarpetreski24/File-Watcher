using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFixed.Config
{
    public class ExtensionsConfiguration
    {
        #region fields
        private List<string> _photoExtensions = new List<string>();
        private List<string> _videoExtensions = new List<string>();
        private string _photoExtensionsString;
        private string _videoExtensionsString;
        public string PhotoExtensionsString { 
            get { return _photoExtensionsString; } 
            set {
                    _photoExtensionsString = value;
                    _photoExtensions.Clear();
                    string[] extensionsPsplit = value.Split(',');
                    foreach (string s in extensionsPsplit)
                    {
                        if (s.Trim().Length == 0)
                            continue;
                        _photoExtensions.Add(s.Trim());
                    }
                } }
        public string VideoExtensionsString { 
            get { return _videoExtensionsString; }
            set {
                    _videoExtensionsString = value;
                    _videoExtensions.Clear();
                    string[] extensionsVsplit = value.Split(',');
                    foreach (string s in extensionsVsplit)
                    {
                        if (s.Trim().Length == 0)
                            continue;
                        _videoExtensions.Add(s.Trim());
                    }
                } }

        public IReadOnlyList<string> PhotoExtensionsList { get { return _photoExtensions; } }
        public IReadOnlyList<string> VideoExtensionsList { get { return _videoExtensions; } }
        #endregion
        #region constructors
        public ExtensionsConfiguration(ExtensionsConfiguration copyConfiguration)
        {
            if (copyConfiguration != null)
            {
                _videoExtensions = new List<string>(copyConfiguration._videoExtensions);
                _photoExtensions = new List<string>(copyConfiguration._photoExtensions);
                _videoExtensionsString = String.Copy(copyConfiguration._videoExtensionsString);
                _photoExtensionsString = String.Copy(copyConfiguration._photoExtensionsString);
            }
            else
            {
                throw new ArgumentNullException("ExtensionsConfiguration copyConfiguration");
            }
}
        public ExtensionsConfiguration(string p = "", string v = "")
        {
            _photoExtensionsString = p;
            _videoExtensionsString = v;
            string[] extensionsVsplit = v.Split(',');
            string[] extensionsPsplit = p.Split(',');
            foreach (string s in extensionsVsplit)
            {
                if (s.Trim().Length == 0)
                    continue;
                _videoExtensions.Add(s.Trim());
            }
            foreach (string s in extensionsPsplit)
            {
                if (s.Trim().Length == 0)
                    continue;
                _photoExtensions.Add(s.Trim());
            }
        }
        #endregion
        #region operators overload
        public static bool operator ==(ExtensionsConfiguration e1,ExtensionsConfiguration e2)
        {
            if((Object)e1==null)
            {
                return (Object)e2 == null;
            }
            if((Object)e2==null)
            {
                return false;
            }
            return (e1._photoExtensionsString == e2._photoExtensionsString) && (e1._videoExtensionsString == e2._videoExtensionsString);
        }
        public static bool operator !=(ExtensionsConfiguration e1, ExtensionsConfiguration e2)
        {
            return !(e1==e2);
        }
        public override bool Equals(object c1)
        {
            ExtensionsConfiguration config1 = (ExtensionsConfiguration)c1;
            return this == config1;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
