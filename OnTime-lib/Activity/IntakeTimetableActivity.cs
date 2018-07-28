using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OnTime_lib.Network;

namespace OnTime_lib.Activity
{
    public class IntakeTimetableActivity
    {
        public async void GetIntakeTimetable()
        {
            //Before Download, create the directory first, if not exist
            //If Exist just leave it alone

            string folderCombine = Path.Combine(GlobalData.FileLocationBase, GlobalData.FolderName);           
            Directory.CreateDirectory(Path.Combine(folderCombine));

            //Delete everything on that folder
            ClearFolder(folderCombine);

            //Download the File
            string fileCombine = Path.Combine(folderCombine, Path.GetFileName(GlobalData.FileName));
            DownloadData download = new DownloadData();
            download.IntakeTimeTable(GlobalData.IntakeCodeUrl, fileCombine);
            string folderExportCombine = Path.Combine(folderCombine, GlobalData.ExtractFolderName);
            
            ZipFile.ExtractToDirectory(fileCombine, folderExportCombine);
        }

        private void ClearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.IsReadOnly = false;
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                ClearFolder(di.FullName);
                di.Delete();
            }
        }
    }
}
