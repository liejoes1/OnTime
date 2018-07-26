using System.Net;

namespace OnTime_lib.Network
{
    class DownloadData
    {

        public string IntakeList()
        {
            string result = "";
            using (WebClient client = new WebClient())
            {
                result = client.DownloadString(GlobalData.INTAKE_LIST_URL);
            }
            return result;
        }
    }
}
