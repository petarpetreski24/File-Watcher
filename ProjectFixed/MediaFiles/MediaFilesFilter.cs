using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectFixed.Collections;

namespace ProjectFixed.MediaFiles
{
    public class MediaFilesFilter
    {
        #region public methods
        public static List<FileHistoryItem> FilterFiles(DateTime startTime,DateTime endTime,List<FileHistoryItem> unfilteredList)
        {
            for (int i = 0; i < unfilteredList.Count; i++)
            {
                if (unfilteredList[i].TypeEnum == FileTypes.Photo && startTime <= unfilteredList[i].CreationTime && endTime >= unfilteredList[i].CreationTime)
                {
                    continue;
                }
                if (unfilteredList[i].TypeEnum == FileTypes.Photo)
                {
                    unfilteredList.RemoveAt(i);
                    i--;
                    continue;
                }
                if (unfilteredList[i].HasFinishedTime == false)
                {
                    continue;
                }
                if ((startTime > unfilteredList[i].CreationTime) && (endTime < unfilteredList[i].FinishedTime))
                {
                    continue;
                }
                if (startTime > unfilteredList[i].FinishedTime || (endTime < unfilteredList[i].CreationTime))
                {
                    unfilteredList.RemoveAt(i);
                    i--;
                }
            }
            return unfilteredList; 
        }
        #endregion
    }
}
