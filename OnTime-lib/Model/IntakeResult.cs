using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime_lib.Model
{
    public class IntakeResult
    {
        public string Date { get; }

        public string Time { get; }

        public string Location { get; }

        public string Module { get; }

        public IntakeResult(string date, string time, string location, string module)
        {
            Date = date;
            Time = time;
            Location = location;
            Module = module;
        }

        public IntakeResult()
        {

        }
    }
}
