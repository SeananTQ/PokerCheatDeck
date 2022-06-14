using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML;
using ClosedXML.Excel;
using SeananTools;

namespace ExcelTools
{
    public  class ExcelHelper 
    {
        public static  int HeadRow= 1;
        public static  int NameRow = 2;
        public static  int TypeRow = 1;
        public static  int DataRow = 3;
        public static  int DataCol = 1;
        
        //public static  int Data_info2dCol = 3;
        //public static  int Data_nameCol = 2;


        public string? resultString = "";

        private IXLWorkbook WorkBook;
        private IXLWorksheet currentWorkSheet;
        private Dictionary<string, IXLWorksheet> workSheetDict;
        private IEnumerable<int>? skipIndexRows;
        private IEnumerable<int>? skipIndexColumns;

        public IXLWorksheet CurrentWorkSheet
        {
            get {
                return currentWorkSheet;
            }
        }


        public IXLWorksheet GetWorkSheetByIndex(int index)
        {
            index--;
            return workSheetDict.Values.ElementAt(index);
        }


        public IXLWorksheet GetWorkSheetByName(string name)
        {
            if (workSheetDict.ContainsKey(name))
            {
                return workSheetDict[name];
            }
            else
            {
                DebugClass.Logln("未找到指定名称Sheet，请确认名称输入正确");
                return null;
            }
        }


        public ExcelHelper()
        {
            //WorkBook = new XLWorkbook();
            //WorkSheet = WorkBook.Worksheets.Add("Sheet1");
        }


        public ExcelHelper(IFieldConfig config)
        {
            HeadRow = config.Index_headRow;
            NameRow = config.Index_nameRow;
            TypeRow = config.Index_typeRow;
            DataRow = config.Index_dataRow;
            DataCol = config.Index_dataCol;            
        }        
        
        public void OpenExcel(string importExcelPath)
        {
            WorkBook = new XLWorkbook(importExcelPath);
        }

        

        public void LoadSheet(string? sheetName="")
        {
            if (WorkBook == null) return;
            if (workSheetDict == null) workSheetDict = new Dictionary<string, IXLWorksheet>();
            if (sheetName == "")
            {
                currentWorkSheet = WorkBook.Worksheet(1);
                workSheetDict.Add(CurrentWorkSheet.Name, CurrentWorkSheet);
            }
            else
            {
                if (workSheetDict.ContainsKey(sheetName))
                {
                    currentWorkSheet = workSheetDict[sheetName];
                }
                else
                {
                    currentWorkSheet = WorkBook.Worksheet(sheetName);
                    workSheetDict.Add(sheetName, CurrentWorkSheet);
                }
            }
            MarkSkipRowCol(currentWorkSheet);
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

            var rowCount = CurrentWorkSheet.RowsUsed().Count();
            var colCount = CurrentWorkSheet.ColumnsUsed().Count();
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
                    tempName = CurrentWorkSheet.Cell(NameRow, j).Value.ToString() ?? "";
                    tempObject = CurrentWorkSheet.Cell(i, j).Value;
                    keyValues.Add(tempName, tempObject);
                }
                keyValuePairsList.Add(keyValues);
            }
            table.BuildData(keyValuePairsList);
        }


        //将workSheet内容转化为数据词典列表
        public List<Dictionary<string, object>>  BuildTabel(IXLWorksheet worksheet =null)
        {
            if (worksheet == null) worksheet = CurrentWorkSheet;

            List<Dictionary<string, object>> keyValuePairsList;
            keyValuePairsList = new List<Dictionary<string, object>>();

            var rowCount = worksheet.RowsUsed().Count();
            var colCount = worksheet.ColumnsUsed().Count();
            string tempName;
            object tempObject;
            for (int i = DataRow; i <= rowCount; i++)
            {
                if (skipIndexRows != null && skipIndexRows.Contains(i)) continue;
                Dictionary<string, object>? keyValues = new();

                for (int j = DataCol; j <= colCount; j++)
                {
                    if (skipIndexColumns != null && skipIndexColumns.Contains(j))
                    {
                        continue;
                    }
                    tempName = worksheet.Cell(NameRow, j).Value.ToString() ?? "";
                    tempObject = worksheet.Cell(i, j).Value;
                    keyValues.Add(tempName, tempObject);
                }
                keyValuePairsList.Add(keyValues);
            }
            return keyValuePairsList;
        }

        //根据数据词典列表中key找到其在workSheet中的列,并将value写入到单元格中
        public void WriteTabel(List<Dictionary<string, object>> dataDictList, int startRow, IXLWorksheet worksheet = null)
        {
            if (worksheet == null) worksheet = CurrentWorkSheet;
            var rowCount = dataDictList.Count+ startRow;
            var colCount = worksheet.ColumnsUsed().Count();
            string tempName;
            object tempObject;
            for (int i = startRow; i < rowCount; i++)
            {
                if (skipIndexRows != null && skipIndexRows.Contains(i)) continue;
                for (int j = DataCol; j <= colCount; j++)
                {
                    if (skipIndexColumns != null && skipIndexColumns.Contains(j))
                    {
                        continue;
                    }
                    tempName = worksheet.Cell(NameRow, j).Value.ToString() ?? "";
                    tempObject = dataDictList[i - startRow][tempName];
                    worksheet.Cell(i, j).Value = tempObject;
                }
            }
        }


        public void SaveCopyAsExcelFile(string exportExcelPath,string fileName)
        {
            if (WorkBook == null) return;
            WorkBook.SaveAs(exportExcelPath +"\\"+ fileName);
            CloseExcel();
        }

        public void SaveExcel(string exportExcelPath)
        {
            if (WorkBook == null) return;
            WorkBook.SaveAs(exportExcelPath);
            CloseExcel();
        }

        public void CloseExcel()
        {
            if (WorkBook == null) return;
            WorkBook.Dispose();
        }
           
        /*---------------------搜索部分---------------------*/
        

        //在一列中搜索指定字符串，找到后返回其所在的行数
        public int SearchStringInColumn(string searchString, int columnIndex, IXLWorksheet workSheet=null)
        {
            if (workSheet == null) workSheet = CurrentWorkSheet;
            var rowCount = workSheet.RowsUsed().Count();
            for (int i = DataRow; i <= rowCount; i++)
            {
                if (skipIndexRows != null && skipIndexRows.Contains(i)) continue;
                if (workSheet.Cell(i, columnIndex).Value.ToString() == searchString)
                {
                    return i;
                }
            }
            return -1;
        }


        //在一列中搜索指定字符串，将找到的行数放入到一个列表中返回
        public List<int> SearchStringInColumn(string searchString, int columnIndex, bool isContain,IXLWorksheet worksheet=null)
        {
            if (worksheet == null) worksheet = CurrentWorkSheet;
            var rowCount = CurrentWorkSheet.RowsUsed().Count();
            List<int> result = new();
            for (int i = DataRow; i <= rowCount; i++)
            {
                if (skipIndexRows != null && skipIndexRows.Contains(i)) continue;
                if (isContain)
                {
                    if (CurrentWorkSheet.Cell(i, columnIndex).Value.ToString().Contains(searchString))
                    {
                        result.Add(i);
                    }
                }
                else
                {
                    if (CurrentWorkSheet.Cell(i, columnIndex).Value.ToString() == searchString)
                    {
                        result.Add(i);
                    }
                }
            }
            return result;
        }

            //根据searchColumnIndex列在workSheet中搜索参数字符串searchString，找到包含该字符串的单元格，将该单元格所在的行数与dataColumnIndex所在单元格的值生成列表
            public Dictionary<string,int> SearchContainStringInColumn(string searchString, int searchColumnIndex, int dataColumnIndex, bool isContain,  IXLWorksheet worksheet = null)
        {

            if (worksheet == null) worksheet = CurrentWorkSheet;
            var rowCount = CurrentWorkSheet.RowsUsed().Count();

            var searchColumn = worksheet.Column(searchColumnIndex);

            Dictionary<string, int> result = new();
           var cellList =  searchColumn.Search(searchString);
            var count = cellList.Count();
            foreach (var curCell in cellList)
            {
                int rowIndex = curCell.WorksheetRow().RowNumber();
                string tempString = worksheet.Cell(rowIndex, dataColumnIndex).Value.ToString();
                //DebugClass.Logln("tempString = " + tempString);
                if (tempString != null)
                {
                    result.Add(tempString, rowIndex);
                }                
            }
            return result;
        }






        /*---------------------赋值部分---------------------*/

        //为指定的单元格赋值,判断该单元格是否已存在值,如果存在则根据参数选择为改写/合并
        public void SetCellValue(int rowIndex, int columnIndex, object value, bool isOverwrite = true, IXLWorksheet worksheet = null)
        {
            if (worksheet == null) worksheet = CurrentWorkSheet;
            if (worksheet.Cell(rowIndex, columnIndex).Value != null)
            {
                if (isOverwrite)
                {
                    worksheet.Cell(rowIndex, columnIndex).Value = value;
                }
                else
                {
                    worksheet.Cell(rowIndex, columnIndex).Value = worksheet.Cell(rowIndex, columnIndex).Value.ToString() + value.ToString();
                }
            }
            else
            {
                worksheet.Cell(rowIndex, columnIndex).Value = value;
            }
        }



        //根据一个列表中的行与指定列获取单元格的值，将值放入到一个列表中返回
        public List<string> GetCellValueInList(List<int> rowList  , int columnIndex, IXLWorksheet worksheet = null)
        {
            if (worksheet == null) worksheet = CurrentWorkSheet;
            List<string> result = new();
            foreach (var row in rowList)
            {
                result.Add(CurrentWorkSheet.Cell(row, columnIndex).Value.ToString());
            }
            return result;
        }

        //根据一个列表中的行与指定列得到单元格的值，依次将一个字符串填入到该单元格
        public void SetRowValueInList(List<int> rowList, int columnIndex, string value, IXLWorksheet worksheet = null, bool isFormulaA1 = false)
        {
            if (worksheet == null) worksheet = CurrentWorkSheet;
            foreach (var row in rowList)
            {
                if (isFormulaA1)
                {
                    worksheet.Cell(row, columnIndex).FormulaA1 = value;
                }
                else
                {
                    worksheet.Cell(row, columnIndex).Value = value;
                }
            }
        }

        //根据参数得到指定的列与起始行，将一个列表依次填入到单元格中
        public void SetCellValueInStringList(int columnIndex, int startRow, List<string> valueList, IXLWorksheet worksheet = null)
        {
            if (worksheet == null) worksheet = CurrentWorkSheet;
            for (int i = 0; i < valueList.Count; i++)
            {
                worksheet.Cell(startRow + i, columnIndex).Value = valueList[i];
            }
        }

        //根据参数得到指定的列与起始行，终止行为最后一个已使用行，将一个字符串依次填入到这些单元格中
        public void SetCellValueInString(int columnIndex, int startRow, string value, IXLWorksheet worksheet = null, int formulaA1Type =0)
        {            
            if (worksheet == null) worksheet = CurrentWorkSheet;
            for (int i = startRow; i <= worksheet.RowsUsed().Count(); i++)
            {
                switch (formulaA1Type)
                {
                    case 0://0代表输入的值不是公式
                        worksheet.Cell(i, columnIndex).Value = value;
                        break;
                    case 1://1代表输入的值是公式
                        worksheet.Cell(i, columnIndex).FormulaA1 = value;
                        break;
                    case 2://2代表输入的值是公式，但是写入的内容为该公式计算后的值
                        worksheet.Cell(i, columnIndex).FormulaA1 = value;
                        worksheet.Cell(i, columnIndex).Value = worksheet.Cell(i, columnIndex).Value.ToString();
                        break;
                    default:
                        break; 
                }
            }
        }


        



        /*---------------------读取部分---------------------*/


        //根据参数在指定行中的已使用列中，得到从起始列到最后一个已使用列的单元格，将这些单元格的值存入一个列表中
        public List<string> GetCellValueInStringList(int rowIndex, int startColumn, IXLWorksheet worksheet = null)
        {
            if (worksheet == null) worksheet = CurrentWorkSheet;
            List<string> result = new();

            var tempRow = worksheet.Row(rowIndex);
            var colCount = tempRow.CellsUsed().Count();
            for (int i = startColumn; i <= colCount; i++)
            {
                if (skipIndexColumns != null && skipIndexColumns.Contains(i)) continue;
                result.Add(worksheet.Cell(rowIndex, i).Value.ToString());
            }
            return result;
        }


        //得到指定workSheet的使用列数
        public int GetUsedColumnCount(IXLWorksheet worksheet = null)
        {
            if (worksheet == null) worksheet = CurrentWorkSheet;
            var colCount = worksheet.ColumnsUsed().Count();
            return colCount;
        }

        //得到指定workSheet的使用行数
        public int GetUsedRowCount(IXLWorksheet worksheet = null)
        {
            if (worksheet == null) worksheet = CurrentWorkSheet;
            var rowCount = worksheet.RowsUsed().Count();
            return rowCount;
        }



        public void ImportExcelToString(IXLWorksheet worksheet = null)
        {
            if (worksheet == null) worksheet = CurrentWorkSheet;
            var rowCount = CurrentWorkSheet.RowsUsed().Count();
            var colCount = CurrentWorkSheet.ColumnsUsed().Count();
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    resultString += CurrentWorkSheet.Cell(i, j).Value.ToString() + "|";
                }
                resultString += "\n";
            }
        }

        /*---------------------工具部分---------------*/

        //将列表内容用分号隔开组成一个字符串，最后不加分号
        public string ListToString(List<string> list)
        {
            string result = "";
            foreach (var item in list)
            {
                result += item + ";";
            }
            result = result.Substring(0, result.Length - 1);
            return result;
        }

        //从指定行开始，删除下面所有行
        public void DeleteRows(int startRowIndex, IXLWorksheet worksheet = null)
        {
            if (worksheet == null) worksheet = CurrentWorkSheet;
            var rowCount = worksheet.RowsUsed().Count();
            for (int i = rowCount; i >= startRowIndex; i--)
            {
                worksheet.Row(i).Delete();
            }
        }

        //读取一行数据,将每个单元格的值与其列号存成键值对
        public Dictionary<string, int > ReadRowToDict(int rowIndex, IXLWorksheet worksheet = null)
        {
            if (worksheet == null) worksheet = CurrentWorkSheet;
            var row = worksheet.Row(rowIndex);
            var colCount = row.CellsUsed().Count();
            Dictionary<string, int> result = new();
            for (int i = 1; i <= colCount; i++)
            {
                if (skipIndexColumns != null && skipIndexColumns.Contains(i)) continue;
                result.Add( worksheet.Cell(rowIndex, i).Value.ToString(),i);
            }
            return result;
        }
    }
}
