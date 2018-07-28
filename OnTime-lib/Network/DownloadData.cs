using System;
using System.Net;
using System.Reflection.Emit;

namespace OnTime_lib.Network
{
    class DownloadData
    {

        public string IntakeList()
        {
            string result = "";
            using (WebClient client = new WebClient())
            {
                result = client.DownloadString(GlobalData.IntakeListUrl);
            }
            return result;
        }

        public string IntakeInfoCheck(string intakeCode)
        {
            string result = "";
            using (WebClient client = new WebClient())
            {
                result = client.DownloadString(GlobalData.IntakeInfoCheckUrl + intakeCode);
            }
            return result;
        }

        public void IntakeTimeTable(string url, string location)
        {
            using (var client = new WebClient())
            {

                client.DownloadFile(url, location);
            }
        }
    }
}
