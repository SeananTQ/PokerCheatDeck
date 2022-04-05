using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML;
using ClosedXML.Excel;

namespace ExcelHelper
{
    public  class ExcelHelper
    {
        string resultString = "";
        string importExcelPath = "E:\\import.xlsx";
        string exportExcelPath = "E:\\export.xlsx";

        public ExcelHelper()
        { 
        
        }

        private void ExcelTest()
        {

            var workbook = new XLWorkbook(importExcelPath);

            IXLWorksheet sheet = workbook.Worksheet(1);//这个库也是从1开始
                                                       //设置第一行第一列值,更多方法请参考官方Demo
                                                       //sheet.Cell(1, 1).Value = "test";//该方法也是从1开始，非0

            resultString = "" + sheet.Cell(1, 3).GetValue<int>();
            workbook.SaveAs(exportExcelPath);
        }

    }
}
