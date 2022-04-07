using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML;
using ClosedXML.Excel;

namespace ExcelTools
{
    public  class ExcelHelper
    {
        public string resultString = "";
        private string importExcelPath = "E:\\import.xlsx";
        private string exportExcelPath = "E:\\export.xlsx";

        public string ImportExcelPath
        {
            get { return importExcelPath; }
            set { importExcelPath = value; }
        }

        public string ExportExcelPath
        {
            get { return exportExcelPath; }
            set { exportExcelPath = value; }
        }

        private IXLWorkbook workbook;
        private IXLWorksheet worksheet;
        

        public ExcelHelper()
        { 
        
        }

        public void OpenExcel()
        {
            workbook = new XLWorkbook(importExcelPath);
            worksheet = workbook.Worksheet(1);
        }

        public void CloseExcel()
        {
            workbook.SaveAs(exportExcelPath);
            workbook.Dispose();
        }

        public void ImportExcel()
        {
            var rowCount = worksheet.RowsUsed().Count();
            var colCount = worksheet.ColumnsUsed().Count();
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    resultString += worksheet.Cell(i, j).Value.ToString() + "|";
                }
                resultString += "\n";
            }
        }       
        


    }
}
