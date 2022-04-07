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
            excelHelper = new ExcelHelper();            
        }
        
       public void  Star(string loadPath,string savePath)
        {
            excelHelper.ImportExcelPath=loadPath;
            excelHelper.ExportExcelPath=savePath;

            excelHelper.OpenExcel();

            excelHelper.ImportExcel();

            excelHelper.CloseExcel();

            DebugClass.Log( excelHelper.resultString);
        }

    }
}
