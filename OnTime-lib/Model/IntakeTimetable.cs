using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime_lib.Model
{
    class IntakeTimetable
    {
        public string Date { get;}

        public string StartTime { get;}

        public string EndTime { get;}

        public string Location { get;}

        public string Module { get;}


        public IntakeTimetable(string date, string startTime, string endTime, string location, string module)
        {
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            Location = location;
            Module = module;
        }

        public IntakeTimetable()
        {

        }
    }
}
