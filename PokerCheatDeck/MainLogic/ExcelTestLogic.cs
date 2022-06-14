using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelTools;
using SeananTools;

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

            excelHelper.OpenExcel(loadPath);
            excelHelper.LoadSheet();

            TableBaseClass rankingTabel = new("Test");
            excelHelper.BuildTabel(ref rankingTabel);
            //excelHelper.ImportExcelToString();

            excelHelper.SaveExcel(savePath);

            DebugClass.Log( excelHelper.resultString);
        }

    }
}
