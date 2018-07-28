using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

            date = (string)rootObject["week"]["@for"];
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
                    intakeTimetables.Add(new IntakeTimetable(date, startTime, endTime, location, module));
                }              
            }          
            return intakeTimetables;
        }
    }
}
