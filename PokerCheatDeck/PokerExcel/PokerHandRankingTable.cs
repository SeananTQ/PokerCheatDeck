using System;
using System.Collections.Generic;
using System.Linq;
using ExcelTools;
using SeananTools;


namespace PokerExcel
{
    public class PokerHandRankingTable : TableBaseClass
    {


        private List<HandRankingObject> _rankingList;
        private int _totalWeight = 0;

        public PokerHandRankingTable(string tableName) : base(tableName)
        {
            this.TableName = "pokerHandRanking";
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



        private class HandRankingObject
        {
            public int id;
            public int ranking;
            public string name;
            public int weight;
            public string eunm;
            public string remarks;

            public HandRankingObject(int id, int ranking, string name, int weight, string eunm, string remarks)
            {
                this.id = id;
                this.ranking = ranking;
                this.name = name;
                this.weight = weight;
                this.eunm = eunm;
                this.remarks = remarks;
            }          
            
            public HandRankingObject(Dictionary<string,object> keyValuePair)
            {
                this.id = (int)keyValuePair["id"];
                this.ranking = (int)keyValuePair["ranking"];
                this.name = (string)keyValuePair["name"];
                this.weight = (int)keyValuePair["weight"];
                this.eunm = (string)keyValuePair["eunm"];
                this.remarks = (string)keyValuePair["remarks"];
            }



        }
    }
}
