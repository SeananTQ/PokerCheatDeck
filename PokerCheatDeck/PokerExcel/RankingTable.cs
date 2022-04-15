using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelTools;
using SeananTools;

namespace PokerExcel
{
    public class RankingTable : TableBaseClass
    {
        public RankingTable(string tableName) : base(tableName)
        {
        }

        public override void BuildData(List<Dictionary<string, object>> dataList)
        {
            base.BuildData(dataList);
            DebugClass.Log("RankingTable BuildData");
            //DebugClass.Log
        }
    }
}
