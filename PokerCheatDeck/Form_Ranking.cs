using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerCheatDeck
{
    public partial class Form_Ranking : Form
    {
        public Form_Ranking()
        {
            InitializeComponent();
            loadSettings();
        }

        //加载设置为文本框赋值
        private void loadSettings()
        {
            this.tb_modelLoadPath.Text = Properties.Settings.Default.modelLoadPath;
            this.tb_rankingTableLoadPath.Text = Properties.Settings.Default.rankingTableLoadPath;
            this.tb_rankingTableSavePath.Text = Properties.Settings.Default.rankingTableSavePath;
            this.tb_modelSheetName.Text = Properties.Settings.Default.modelSheetName;
        }

        private void btn_modelLoadPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Model File|*.xlsx";
            openFileDialog.Title = "Select a Model File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //保存路径到设置文件中
                tb_modelLoadPath.Text = openFileDialog.FileName;
                Properties.Settings.Default.modelLoadPath = tb_modelLoadPath.Text;
                Properties.Settings.Default.Save();
             
            }

            

        }

        private void btn_rankingTableLoadPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "|rankingObjectTable.xlsx";
            openFileDialog.Title = "Select a Ranking Table File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //保存路径到设置文件中
                tb_rankingTableLoadPath.Text = openFileDialog.FileName;
                Properties.Settings.Default.rankingTableLoadPath = tb_rankingTableLoadPath.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void tb_modelSheetName_TextChanged(object sender, EventArgs e)
        {
            //保存到设置文件中
            Properties.Settings.Default.modelSheetName = tb_modelSheetName.Text;
            Properties.Settings.Default.Save();
        }
    }
}
