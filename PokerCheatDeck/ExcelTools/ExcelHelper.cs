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
        public static  readonly int HeadRow= 1;
        public static readonly int NameRow = 2;
        public static readonly int TypeRow = 3;
        public static readonly int DataRow = 4;
        public static readonly int DataCol = 2;

        public string? resultString = "";
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

        private IXLWorkbook WorkBook;
        private IXLWorksheet WorkSheet;
        private IEnumerable<int>? skipIndexRows;
        private IEnumerable<int>? skipIndexColumns;

        public ExcelHelper()
        {
            //WorkBook = new XLWorkbook();
            //WorkSheet = WorkBook.Worksheets.Add("Sheet1");
        }

        public void OpenExcel()
        {
            WorkBook = new XLWorkbook(importExcelPath);
        }

        public void LoadSheet(string? sheetName="")
        {
            if (WorkBook == null) return;
            
            if (sheetName == "")
            {
                WorkSheet = WorkBook.Worksheet(1);
            }
            else
            {
                WorkSheet = WorkBook.Worksheet(sheetName);
            }

            MarkSkipRowCol(WorkSheet);
        }

        private void MarkSkipRowCol(IXLWorksheet workSheet)
        {
            skipIndexRows =   workSheet.Column(HeadRow).Search("*").Select(x => x.WorksheetRow().RowNumber());
            skipIndexColumns = workSheet.Row(HeadRow).Search("*").Select(x => x.WorksheetColumn().ColumnNumber());            
        }


        public void BuildTabel(ref  TableBaseClass table)
        {
            List<Dictionary<string, object>> keyValuePairsList;
            keyValuePairsList = new List<Dictionary<string, object>>();

            var rowCount = WorkSheet.RowsUsed().Count();
            var colCount = WorkSheet.ColumnsUsed().Count();
            string tempName;
            object tempObject; 
            for (int i = DataRow; i <= rowCount; i++)
            {
                if (skipIndexRows !=null  && skipIndexRows.Contains(i))  continue;
                Dictionary<string, object>? keyValues = new();

                for (int j = DataCol; j <= colCount; j++)
                {
                    if (skipIndexColumns !=null &&   skipIndexColumns.Contains(j))
                    {
                        continue;
                    }
                    tempName = WorkSheet.Cell(NameRow, j).Value.ToString() ?? "";
                    tempObject = WorkSheet.Cell(i, j).Value;
                    keyValues.Add(tempName, tempObject);
                }
                keyValuePairsList.Add(keyValues);
            }
            table.BuildData(keyValuePairsList);
        }


        public void CloseExcel()
        {
            WorkBook.SaveAs(exportExcelPath);
            WorkBook.Dispose();
        }

        public void ImportExcelToString()
        {
            var rowCount = WorkSheet.RowsUsed().Count();
            var colCount = WorkSheet.ColumnsUsed().Count();
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    resultString += WorkSheet.Cell(i, j).Value.ToString() + "|";
                }
                resultString += "\n";
            }
        }       
        


    }
}
