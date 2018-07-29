using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTime_lib.Data;
using OnTime_lib.Model;
using OnTime_lib.Network;

namespace OnTime_lib.Activity
{
    public class StartupActivity
    {
        private static Cache _cache = new Cache();
        private static bool DataValid;
        public void start()
        {
            DataValid = false;
            string folderCombine = Path.Combine(GlobalData.FileLocationBase, GlobalData.FolderName);
            string folderExportCombine = Path.Combine(folderCombine, GlobalData.ExtractFolderName);
            string cacheCombine = Path.Combine(folderCombine, GlobalData.CacheFileName);
            string htmlCombine = Path.Combine(folderExportCombine, GlobalData.HtmlFileName);

            DownloadLocalData downloadLocalData = new DownloadLocalData();
            string cacheString = downloadLocalData.ReadCacheFile(cacheCombine);

            //Parse Cache
            DataParsing dataParsing = new DataParsing();
            _cache = dataParsing.ParseCache(cacheString);

            //Verify Cache
            DataValid = downloadLocalData.ContainIntakeHtmlFile(htmlCombine, _cache.IntakeCode);

            //Load IntakeList
            IntakeListActivity intakeListActivity = new IntakeListActivity();
            intakeListActivity.GetIntakeList();
        }

        public bool getDataValid()
        {
            return DataValid;
        }

        public string getCacheIntake()
        {
            return _cache.IntakeCode;
        }
    }
}
