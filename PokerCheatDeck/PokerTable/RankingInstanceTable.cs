using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelTools;
namespace PokerTable
{
    class RankingInstanceTable : TableBaseClass
    {
        public List<DataObject>? dataObjectList;
        private int currentId = 1001;

        public int Index_dataStartRow;
        //id rankingName used pk1 pk2 pk3 pk4 pk5 pk6 pk7
        public int Index_idCol=2;
        public int Index_rankingNameCol=3;
        public int Index_usedCol = 4;
        public int Index_pk1Col = 5;
        public int Index_pk2Col = 6;
        public int Index_pk3Col = 7;
        public int Index_pk4Col = 8;
        public int Index_pk5Col = 9;
        public int Index_pk6Col = 10;
        public int Index_pk7Col = 11;
        public int Index_ethCol = 12;



        public RankingInstanceTable(string tableName) : base(tableName)
        {
            this.TableName = "rankingInstance";
            this.Index_dataStartRow = Index_dataRow;
        }

        //将数据词典列表转化为数据对象列表
        public override void BuildData(List<Dictionary<string, object>> dataList)
        {
            base.BuildData(dataList);
            dataObjectList = new List<DataObject>();
            foreach (Dictionary<string, object> data in dataList)
            {
                DataObject ranking = new DataObject(data);
                dataObjectList.Add(ranking);
            }
        }

        public void AddObject(string rankingName, List<string> pkCode,int eth)
        {
            if (dataObjectList == null)
            {
                dataObjectList = new List<DataObject>();
            }
            dataObjectList.Add(new DataObject(this.currentId++, rankingName, pkCode,eth));
        }

        //将数据对象列表转化为数据词典列表
        public override List<Dictionary<string, object>> BuildData()
        {
            List<Dictionary<string, object>> dataList = new List<Dictionary<string, object>>();
            foreach (DataObject data in dataObjectList)
            {
                dataList.Add(data.GetDataDictionary());
            }
            return dataList;
        }



        public class DataObject
        {
            public int id;
            public string rankingName;
            public int used;
            public string pk1;
            public string pk2;
            public string pk3;
            public string pk4;
            public string pk5;
            public string pk6;
            public string pk7;
            public int eth;

            public DataObject(int id,string rankingName,List<string> pkCode,int eth)
            {
                this.id = id;
                this.rankingName = rankingName;
                this.used = 0;
                this.pk1 = pkCode[0];
                this.pk2 = pkCode[1];
                this.pk3 = pkCode[2];
                this.pk4 = pkCode[3];
                this.pk5 = pkCode[4];
                this.pk6 = pkCode[5];
                this.pk7 = pkCode[6];
                this.eth = eth;
            }

            //将数据词典转化为数据对象
            public DataObject(Dictionary<string, object> keyValuePair)
            {
                //在词典中找到与字段名相同的key，为所有字段赋值
                foreach (KeyValuePair<string, object> kvp in keyValuePair)
                {
                    switch (kvp.Key)
                    {
                        case "id":
                            id = Convert.ToInt32(kvp.Value);
                            break;
                        case "rankingName":
                            rankingName = kvp.Value.ToString();
                            break;
                        case "used":
                            used = Convert.ToInt32(kvp.Value);
                            break;
                        case "pk1":
                            pk1 = kvp.Value.ToString();
                            break;
                        case "pk2":
                            pk2 = kvp.Value.ToString();
                            break;
                        case "pk3":
                            pk3 = kvp.Value.ToString();
                            break;
                        case "pk4":
                            pk4 = kvp.Value.ToString();
                            break;
                        case "pk5":
                            pk5 = kvp.Value.ToString();
                            break;
                        case "pk6":
                            pk6 = kvp.Value.ToString();
                            break;
                        case "pk7":
                            pk7 = kvp.Value.ToString();
                            break;
                        case "eth":
                            eth = Convert.ToInt32(kvp.Value);
                            break;
                    }
                }            
            }

            //将数据对象转化为数据词典
            public Dictionary<string, object> GetDataDictionary()
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("id", id);
                data.Add("rankingName", rankingName);
                data.Add("used", used);
                data.Add("pk1", pk1);
                data.Add("pk2", pk2);
                data.Add("pk3", pk3);
                data.Add("pk4", pk4);
                data.Add("pk5", pk5);
                data.Add("pk6", pk6);
                data.Add("pk7", pk7);
                data.Add("eth", eth);
                return data;
            }
        }
    }
}
