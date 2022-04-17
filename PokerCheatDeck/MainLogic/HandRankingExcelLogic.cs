using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using ExcelTools;

namespace MainLogic
{
    internal class HandRankingExcelLogic
    {
        private int createCount;
        private string sheetName;
        private string modelLoadPath;
        private string rankingLoadPath;
        private string rankingSavePath;

        private ExcelHelper _modelExcelHelper;
        private ExcelHelper _rankingExcelHelper;

        public HandRankingExcelLogic(string sheetName, string modelLoadPath, string rankingLoadPath, string rankingSavePath, int createCount)
        {
            this.sheetName = sheetName;
            this.modelLoadPath = modelLoadPath;
            this.rankingLoadPath = rankingLoadPath;
            this.rankingSavePath = rankingSavePath;
            this.createCount = createCount;

            MainLogic();
        }

        public void MainLogic()
        {
            _modelExcelHelper = new();
            _modelExcelHelper.OpenExcel(modelLoadPath);
            _modelExcelHelper.LoadSheet(sheetName);
            TableBaseClass modelTabel = new(sheetName);
            _modelExcelHelper.BuildTabel(ref modelTabel);
            _modelExcelHelper.CloseExcel();
            
            modelTabel.r



            

            _rankingExcelHelper = new();
            _rankingExcelHelper.OpenExcel(rankingLoadPath);
            _rankingExcelHelper.LoadSheet();
            TableBaseClass rankingTabel = new("");
            _rankingExcelHelper.BuildTabel(ref rankingTabel);
            _rankingExcelHelper.SaveExcel(rankingSavePath);

        }
    }
}
