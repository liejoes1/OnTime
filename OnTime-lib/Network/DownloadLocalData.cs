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
    }
}
