using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime_lib.Model
{
    class Cache
    {
            public string Type { get; set; }
            public string IntakeCode { get; set; }
            public string IntakeUrl { get; set; }

            public Cache(string type, string intakeCode, string intakeUrl)
            {
                Type = type;
                IntakeCode = intakeCode;
                IntakeUrl = intakeUrl;
            }

        public Cache()
        {

        }      
    }
}
