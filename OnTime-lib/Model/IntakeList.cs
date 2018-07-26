using System.Collections.Generic;

namespace OnTime_lib.Model
{
    class IntakeList
    {
        public string WeekOf { get; set; }
        public List<string> IntakeCode { get; set; }

        public IntakeList(string weekOf, List<string> intakeCode)
        {
            WeekOf = weekOf;
            IntakeCode = intakeCode;
        }
    }
}
