using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using OnTime_lib.Data;
using OnTime_lib.Model;
using OnTime_lib.Network;

namespace OnTime_lib.Activity
{
    public class IntakeTimetableActivity
    {
        private static List<IntakeTimetable> _intakeTimetable;
        public void GetIntakeTimetable()
        {
            string folderCombine = Path.Combine(GlobalData.FileLocationBase, GlobalData.FolderName);
            string fileCombine = Path.Combine(folderCombine, Path.GetFileName(GlobalData.FileName));
            string folderExportCombine = Path.Combine(folderCombine, GlobalData.ExtractFolderName);
            string xmlfileCombine = Path.Combine(folderExportCombine, GlobalData.XmlFileName);
            string cacheCombine = Path.Combine(folderCombine, GlobalData.CacheFileName);
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

            //Store Cache File
            DataParsing dataParsing = new DataParsing();
            dataParsing.SerializingCache(cacheCombine, new Cache("Cache", GlobalData.IntakeCode, GlobalData.IntakeCodeUrl));

            //Read XML File and Convert to List of TimeTable
            _intakeTimetable = new DataParsing().ParseTimeTable(new DownloadLocalData().XmlFile(xmlfileCombine));

            DataParsing.ParseTimeTableByDay(_intakeTimetable);
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

        public List<IntakeResult> GetTimetableDay(string day)
        {
            List<IntakeResult> listResult = new List<IntakeResult>();


            List<TimetableDayClass> timetableDayClasses = new List<TimetableDayClass>();

            timetableDayClasses.Add(new TimetableDayClass("MON", GlobalData.MondayTimetables));
            timetableDayClasses.Add(new TimetableDayClass("TUE", GlobalData.TuesdayTimetables));
            timetableDayClasses.Add(new TimetableDayClass("WED", GlobalData.WednesdayTimetables));
            timetableDayClasses.Add(new TimetableDayClass("THU", GlobalData.ThursdayTimetables));
            timetableDayClasses.Add(new TimetableDayClass("FRI", GlobalData.FridayTimetables));

            foreach (var i in timetableDayClasses)
            {
                if (!day.ToUpper().Equals(i.WeekDay)) continue;
                foreach (var j in i.IntakeTimetables)
                {
                    string date = DateTime.ParseExact(j.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("dd MMM");
                    string time = j.StartTime.Substring(11, 5) + " - " + j.EndTime.Substring(11, 5);
                    string location = j.Location;
                    string module = j.Module;
                    listResult.Add(new IntakeResult(date, time, location, module));
                }
            }
            return listResult;
        }

        public void GetSavedTimetable()
        {
            string folderCombine = Path.Combine(GlobalData.FileLocationBase, GlobalData.FolderName);
            string folderExportCombine = Path.Combine(folderCombine, GlobalData.ExtractFolderName);
            string xmlfileCombine = Path.Combine(folderExportCombine, GlobalData.XmlFileName);
            //Read XML File and Convert to List of TimeTable
            _intakeTimetable = new DataParsing().ParseTimeTable(new DownloadLocalData().XmlFile(xmlfileCombine));

            DataParsing.ParseTimeTableByDay(_intakeTimetable);
        }

        public class TimetableDayClass
        {
            public string WeekDay { get; set; }

            public List<IntakeTimetable> IntakeTimetables { get; set; }

            public TimetableDayClass(string weekDay, List<IntakeTimetable> intakeTimetables)
            {
                WeekDay = weekDay;
                IntakeTimetables = intakeTimetables;
            }
        }

    }
}
