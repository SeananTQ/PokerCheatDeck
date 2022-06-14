using System;
using System.Collections.Generic;
using System.Linq;
using ExcelTools;
using SeananTools;


namespace PokerTable
{
    public class RankingModelTable : TableBaseClass
    {   
        

        private List<HandRankingObject> _rankingList;
        private int _totalWeight = 0;

        

        public RankingModelTable(string tableName) : base(tableName)
        {
            TableName = "rankingModel";
        }



        public override void BuildData(List<Dictionary<string, object>> dataList)
        {
            base.BuildData(dataList);
            DebugClass.Log("RankingTable BuildData");

            _rankingList = new List<HandRankingObject>();
            foreach (Dictionary<string, object> data in dataList)
            {
                HandRankingObject ranking = new HandRankingObject(data);
                _rankingList.Add(ranking);
            }

            foreach (HandRankingObject ranking in _rankingList)
            {
                _totalWeight += ranking.weight;
            }
        }

        //在rankingList中进行权重随机，得到一项
        public string? GetRandomRanking()
        {
            int randomWeight = SeananTools.RandomProvider.NextInt(0, _totalWeight);
            int currentWeight = 0;
            foreach (HandRankingObject ranking in _rankingList)
            {
                currentWeight += ranking.weight;
                if (randomWeight < currentWeight)
                {
                    return ranking.eunm;
                }
            }
            return null;
        }

        //根据牌型名称，返回其对应的eth
        public int GetEthByRankingName(string name)
        {
            foreach (HandRankingObject ranking in _rankingList)
            {
                if (ranking.eunm == name)
                {
                    return ranking.eth;
                }
            }
            return 0;
        }


        private class HandRankingObject
        {
            public int id;
            public int ranking;
            public string name;
            public int weight;
            public string eunm;
            public int eth;
    

            public HandRankingObject(int id, int ranking, string name, int weight, string eunm,int eth)
            {
                this.id = id;
                this.ranking = ranking;
                this.name = name;
                this.weight = weight;
                this.eunm = eunm;

            }

            //将数据词典转化为数据对象
            public HandRankingObject(Dictionary<string,object> keyValuePair)
            {
                //在词典中找到与字段名相同的key，为所有字段赋值
                foreach (KeyValuePair<string, object> kvp in keyValuePair)
                {
                    switch (kvp.Key)
                    {
                        case "id":
                            id = Convert.ToInt32(kvp.Value);
                            break;
                        case "ranking":
                            ranking = Convert.ToInt32(kvp.Value);
                            break;
                        case "name":
                            name = kvp.Value.ToString();
                            break;
                        case "weight":
                            weight = Convert.ToInt32(kvp.Value);
                            break;
                        case "eunm":
                            eunm = kvp.Value.ToString();
                            break;
                        case "eth":
                            eth = Convert.ToInt32(kvp.Value);
                            break;
                    }
                }
            }
        }
    }
}
