using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using ProjectFixed.Collections;

namespace ProjectFixed.MediaFiles
{
    public class MediaFilePlayer
    {
        #region fields and constructor
        private string _videoPlayerPath;
        public MediaFilePlayer(string playerSelect)
        {
            _videoPlayerPath = playerSelect;
        }
        #endregion
        #region public methods
        public void PlayMediaWithParameters(DateTime startTimeFilter,DateTime endTimeFilter,FileHistoryItem playItem)
        {
            try
            {
                double diffInSecondsVideo = (endTimeFilter - startTimeFilter).TotalSeconds;
                double diffInSecondsStart = (startTimeFilter - playItem.CreationTime).TotalSeconds;
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = _videoPlayerPath;
                if (diffInSecondsStart < 0)
                {
                    if (endTimeFilter > playItem.FinishedTime)
                    {
                        double diffInSecondsEnd = (playItem.FinishedTime - playItem.CreationTime).TotalSeconds;
                        startInfo.Arguments = "\"" + playItem.Path + "\"" + " --start-paused --run-time " + Convert.ToInt32(diffInSecondsEnd);
                    }
                    else
                    {
                        startInfo.Arguments = "\"" + playItem.Path + "\"" + " --start-paused --run-time " + Convert.ToInt32((endTimeFilter - playItem.CreationTime).TotalSeconds);
                    }
                }
                else
                {
                    if (playItem.FinishedTime > endTimeFilter)
                    {
                        startInfo.Arguments = "\"" + playItem.Path + "\"" + " --start-paused --start-time " + Convert.ToInt32(diffInSecondsStart) + " --run-time " + Convert.ToInt32((endTimeFilter - startTimeFilter).TotalSeconds);
                    }
                    else
                    {
                        startInfo.Arguments = "\"" + playItem.Path + "\"" + " --start-paused --start-time " + Convert.ToInt32(diffInSecondsStart) + " --run-time " + Convert.ToInt32((playItem.FinishedTime - startTimeFilter).TotalSeconds);
                    }
                }
                process.StartInfo = startInfo;
                process.Start();
            }
            catch(Exception ex)
            {
                Debug.Print("Problem with opening the video : " + ex.ToString());
            }
        }
        public void PlayMediaWithoutParameters(FileHistoryItem playItem)
        {//todo anchor postavi
            try
            {
                Process.Start(playItem.Path);
            }
            catch
            {
                throw new Exception("File not found");
            }
        }
        #endregion
    }
}
