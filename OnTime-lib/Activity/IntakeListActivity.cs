using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTime_lib.Data;
using OnTime_lib.Model;
using OnTime_lib.Network;

namespace OnTime_lib.Activity
{
    public class IntakeListActivity
    {
        private static IntakeList _intakeList;
        public void GetIntakeList()
        {
            //Get Network Data
            DownloadData download = new DownloadData();
            string intakeListData = download.IntakeList();

            DataParsing dataParsing = new DataParsing();
            _intakeList = dataParsing.ParseTimeTableList(intakeListData);
        }

        public string GetWeek()
        {
            //Reformat the DateTimw

            _intakeList.WeekOf = DateTime.ParseExact(_intakeList.WeekOf, "yyyy-M-dd", CultureInfo.InvariantCulture).ToString("d MMM yyyy");
            return _intakeList.WeekOf;
        }

        public List<string> GetIntakeCode()
        {
            return _intakeList.IntakeCode;
        }
    }
}
