using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelTools;
using SeananTools;
using PokerExcel;

namespace MainLogic
{

   public  class ExcelTestLogic
    {
        public ExcelHelper excelHelper;

        public ExcelTestLogic()
        {
            excelHelper = new();            
        }
        
       public void  Star(string loadPath,string savePath)
        {
            excelHelper.ImportExcelPath=loadPath;
            excelHelper.ExportExcelPath=savePath;

            excelHelper.OpenExcel();
            excelHelper.LoadSheet();

            TableBaseClass rankingTabel = new("Test");
            excelHelper.BuildTabel(ref rankingTabel);
            //excelHelper.ImportExcelToString();

            excelHelper.CloseExcel();

            DebugClass.Log( excelHelper.resultString);
        }

    }
}
