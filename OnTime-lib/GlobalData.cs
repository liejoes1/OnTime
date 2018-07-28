using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime_lib
{
    class GlobalData
    {
        public const string IntakeListUrl = "https://webspace.apiit.edu.my/intake-timetable/TimetableIntakeList/TimetableIntakeList.xml";

        public const string IntakeInfoCheckUrl = "https://webspace.apiit.edu.my/intake-timetable/replyLink.php?stid=";

        public const string NoClassIntakeError = "Time table for the current week is not available for this intake code.";

    }
}
