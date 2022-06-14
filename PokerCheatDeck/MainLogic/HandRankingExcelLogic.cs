using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using ExcelTools;
using PokerCheatDeck.Properties;
using SeananTools;
using PokerTable;
using TexasHoldem;

namespace MainLogic
{
    internal class HandRankingExcelLogic
    {
        private int createCount;
        private string rankingObjectSheetName;
        private string excellLoadPath;
        private string excelSavePath;

        private ExcelHelper _excelHelper;

        
        //构造方法，从Settings中加载数组，为字段赋值
        public HandRankingExcelLogic()
        {
            //从Settings中加载数组，为字段赋值
            this.excellLoadPath = Settings.Default.pokerExcelLoadPath;
            this.excelSavePath = Settings.Default.pokerExcelSavePath;
            this.createCount = Settings.Default.createCount;

        }

        public void Start()
        {
            MainLogic();
        }

        private void MainLogic()
        {
            RankingModelTable modelTabel = new RankingModelTable("");
            RankingInstanceTable instanceTable = new RankingInstanceTable("");

            _excelHelper = new ExcelHelper(modelTabel);
            _excelHelper.OpenExcel(excellLoadPath);
            _excelHelper.LoadSheet(modelTabel.SheetName);
            _excelHelper.LoadSheet(instanceTable.SheetName);

            modelTabel.BuildData(_excelHelper.BuildTabel(_excelHelper.GetWorkSheetByName(modelTabel.SheetName)));
            //instanceTable.BuildData(_excelHelper.BuildTabel(_excelHelper.GetWorkSheetByName(instanceTable.SheetName)));


            //创建作弊牌库
            CheatDeck cheatDeck = new(false);
            List<List<string>> cardCodesList = new();

            //按照createCount循环随机一个牌型
            for (int i = 0; i < createCount; i++)
            {
                var handRankTypeName = modelTabel.GetRandomRanking();
                //根据指定牌型名称随机一个牌型，将数据存入表中
                instanceTable.AddObject(handRankTypeName, cheatDeck.GetSpecificHandRankTypeCardCodes(handRankTypeName, cheatDeck.GetNextCard()), modelTabel.GetEthByRankingName(handRankTypeName));
            }

            _excelHelper.WriteTabel(instanceTable.BuildData(), instanceTable.Index_dataStartRow, _excelHelper.GetWorkSheetByName(instanceTable.SheetName));


            _excelHelper.SaveExcel(Settings.Default.pokerExcelSavePath+"\\"+Settings.Default.pokerExcelFileName);
        }
    }
}
