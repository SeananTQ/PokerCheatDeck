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

        public void OpenExcel(string path)
        {
            workbook = new XLWorkbook(path);
            worksheet = workbook.Worksheet(1);
        }

        public void CloseExcel()
        {
            workbook.SaveAs(ExportExcelPath);
            workbook.Dispose();
        }

        public void ImportExcel()
        {
            var rowCount = worksheet.RowCount();
            var colCount = worksheet.ColumnCount();
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    resultString += worksheet.Cell(i, j).Value.ToString() + " ";
                }
                resultString += "\n";
            }
        }       
        


    }
}
