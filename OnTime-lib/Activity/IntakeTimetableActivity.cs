using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using OnTime_lib.Data;
using OnTime_lib.Model;
using OnTime_lib.Network;

namespace OnTime_lib.Activity
{
    public class IntakeTimetableActivity
    {
        private static List<IntakeTimetable> _intakeTimetable;
        public async void GetIntakeTimetable()
        {
            string folderCombine = Path.Combine(GlobalData.FileLocationBase, GlobalData.FolderName);
            string fileCombine = Path.Combine(folderCombine, Path.GetFileName(GlobalData.FileName));
            string folderExportCombine = Path.Combine(folderCombine, GlobalData.ExtractFolderName);
            string xmlfileCombine = Path.Combine(folderExportCombine, GlobalData.XmlFileName);
            //Before Download, create the directory first, if not exist
            //If Exist just leave it alone
            Directory.CreateDirectory(Path.Combine(folderCombine));

            //Delete everything on that folder
            ClearFolder(folderCombine);

            //Download the File
            
            DownloadData download = new DownloadData();
            download.IntakeTimeTable(GlobalData.IntakeCodeUrl, fileCombine);
            
            //Extract the File
            ZipFile.ExtractToDirectory(fileCombine, folderExportCombine);

            //Read XML File and Convert to List of TimeTable
            _intakeTimetable = new DataParsing().ParseTimeTable(new DownloadLocalData().XmlFile(xmlfileCombine));

            string loc = _intakeTimetable[0].Location;



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
