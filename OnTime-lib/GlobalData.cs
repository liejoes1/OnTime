﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OnTime_lib.Model;

namespace OnTime_lib
{
    public class GlobalData
    {
        public const string IntakeListUrl = "https://webspace.apiit.edu.my/intake-timetable/TimetableIntakeList/TimetableIntakeList.xml";
        public const string IntakeInfoCheckUrl = "https://webspace.apiit.edu.my/intake-timetable/replyLink.php?stid=";
        public const string NoClassIntakeError = "Time table for the current week is not available for this intake code.";

        // File Act
        public static readonly string FileLocationBase = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public const string FolderName = "OnTime";
        public const string FileName = "Timetable.zip";
        public const string ExtractFolderName = "Extract";
        public const string XmlFileName = "timetable.xml";
        public const string CacheFileName = "cache.json";
        public const string HtmlFileName = "timetable.html";

        // Shared Variable
        public static string IntakeCodeUrl;
        public static string IntakeCode;

        // Shared Variable - Timetable based on Day
        public static List<IntakeTimetable> MondayTimetables = new List<IntakeTimetable>();
        public static List<IntakeTimetable> TuesdayTimetables = new List<IntakeTimetable>();
        public static List<IntakeTimetable> WednesdayTimetables = new List<IntakeTimetable>();
        public static List<IntakeTimetable> ThursdayTimetables = new List<IntakeTimetable>();
        public static List<IntakeTimetable> FridayTimetables = new List<IntakeTimetable>();
    }
}
