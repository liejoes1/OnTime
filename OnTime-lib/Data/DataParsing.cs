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
        public IntakeList ParseTimeTableList(string result)
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
    }
}
