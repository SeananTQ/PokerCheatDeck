using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTools
{
    public class TableBaseClass
    {
        public string TableName { get; set; }
        public List<Dictionary<string, object>> dataSource;

        public string SheetName {
            get
            {
                return TableName;
            }
        }
        public TableBaseClass(string tableName)
        {
            TableName = tableName;
        }

        public virtual void BuildData(List<Dictionary<string,object>> dataList)
        {
            dataSource = dataList;
        }
    }
}
