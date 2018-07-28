using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTime_lib.Network;

namespace OnTime_lib.Activity
{
    public class IntakeCheckActivity
    {
        public bool GetIntakeCheck(string intakeCode)
        {
            //This funciton will check does the intake data exist

            //Get Network Data
            DownloadData download = new DownloadData();
            string intakeInfoData = download.IntakeInfoCheck(intakeCode);

            if (intakeInfoData.Equals(GlobalData.NoClassIntakeError))
            {
                //If No Class, return error
                return false;
            }
            return true;
        }

    }
}
