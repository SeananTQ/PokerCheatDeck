using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTools
{
    public class TableBaseClass : IFieldConfig
    {
        public string TableName { get; set; }
        public List<Dictionary<string, object>>? dataSource;


        public virtual int Index_headRow { get { return 1; } }
        public virtual int Index_nameRow { get { return 2; } }
        public virtual int Index_typeRow { get { return 3; } }
        public virtual int Index_dataRow { get { return 4; } }
        public virtual int Index_dataCol { get { return 2; } }


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

        public virtual List<Dictionary<string, object>> BuildData()
        {
            return dataSource;
        }
    }
}
