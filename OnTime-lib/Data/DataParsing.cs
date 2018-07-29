using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OnTime_lib.Activity;
using OnTime_lib.Model;

namespace OnTime_lib.Data
{
    class DataParsing
    {
        public IntakeList ParseIntakeList(string result)
        {
            var intakeList = new List<string>();
            var doc = new XmlDocument();
            doc.LoadXml(result);

            var jsonResult = JsonConvert.SerializeXmlNode(doc);

            var rootObject = JObject.Parse(jsonResult);

            var weekOf = (string)rootObject["weekof"]["@week"];

            var size = ((JArray)rootObject["weekof"]["intake"]).Count;

            for (var i = 0; i < size; i++)
            {
                intakeList.Add((string)rootObject["weekof"]["intake"][i]["@name"]);
            }
            return new IntakeList(weekOf, intakeList);
        }

        public List<IntakeTimetable> ParseTimeTable(string result)
        {
            string date = string.Empty;
            string startTime = string.Empty;
            string endTime = string.Empty;
            string location = string.Empty;
            string module = string.Empty;
            List<IntakeTimetable> intakeTimetables = new List<IntakeTimetable>();

            var doc = new XmlDocument();
            doc.LoadXml(result);

            var jsonResult = JsonConvert.SerializeXmlNode(doc);

            var rootObject = JObject.Parse(jsonResult);
          
            var weeksize = ((JArray)rootObject["week"]["day"]).Count;

            for (var i = 0; i < weeksize; i++)
            {            
                var classsize = ((JArray)rootObject["week"]["day"][i]["class"]).Count;
                for (var j = 0; j < classsize; j++)
                {
                    module = (string)rootObject["week"]["day"][i]["class"][j]["subject"];
                    location = (string)rootObject["week"]["day"][i]["class"][j]["location"];
                    startTime = (string)rootObject["week"]["day"][i]["class"][j]["start"];
                    endTime = (string)rootObject["week"]["day"][i]["class"][j]["end"];
                    date = startTime.Substring(0, 10);
                    intakeTimetables.Add(new IntakeTimetable(date, startTime, endTime, location, module));
                }              
            }          
            return intakeTimetables;
        }


        public static void ParseTimeTableByDay(List<IntakeTimetable> intakeTimetables)
        {
            //Clear Data
            GlobalData.MondayTimetables.Clear();
            GlobalData.TuesdayTimetables.Clear();
            GlobalData.WednesdayTimetables.Clear();
            GlobalData.ThursdayTimetables.Clear();
            GlobalData.FridayTimetables.Clear();

            foreach (var t in intakeTimetables)
            {
                string dayOfWeek = DateTime.ParseExact(t.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("ddd").ToUpper();

                switch (dayOfWeek)
                {
                    case "MON":
                        GlobalData.MondayTimetables.Add(t);
                        break;
                    case "TUE":
                        GlobalData.TuesdayTimetables.Add(t);
                        break;
                    case "WED":
                        GlobalData.WednesdayTimetables.Add(t);
                        break;
                    case "THU":
                        GlobalData.ThursdayTimetables.Add(t);
                        break;
                    case "FRI":
                        GlobalData.FridayTimetables.Add(t);
                        break;
                }
            }
        }

        public void SerializingCache(string path, Cache obj)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, obj);
            }
        }

        public Cache ParseCache(string result)
        {
            var rootObject = JObject.Parse(result);

            var type = (string) rootObject["Type"];
            var intakeCode = (string) rootObject["IntakeCode"];
            var intakeUrl = (string) rootObject["IntakeUrl"];

            return new Cache(type, intakeCode, intakeUrl);
        }
    }
}
