using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OnTime_lib.Network
{
    class DownloadLocalData
    {
        public string XmlFile(string path)
        {
            //Obtain XML File
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            return doc.OuterXml;
        }

        public bool ContainIntakeHtmlFile(string path, string intake)
        {
            return System.IO.File.ReadAllText(path).Contains(intake);
        }

        public string ReadCacheFile(string path)
        {
            return System.IO.File.ReadAllText(path);
        }

    }
}
