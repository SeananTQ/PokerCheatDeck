using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainLogic;
namespace PokerCheatDeck
{
    public partial class Form_Ranking : Form
    {
        public Form_Ranking()
        {
            InitializeComponent();
            LoadPath();
        }

        //加载设置为文本框赋值
        private void LoadPath()
        {
            this.TB_pokerExcelLoadPath.Text = Properties.Settings.Default.pokerExcelLoadPath;
            this.TB_rankingSheetName.Text = Properties.Settings.Default.rankingSheetName;
             this.TB_modelSheetName.Text = Properties.Settings.Default.modelSheetName;
            this.TB_pokerExcelSavePath.Text = Properties.Settings.Default.pokerExcelSavePath;
            this.Num_createCount.Value = Properties.Settings.Default.createCount;
        }

        private void BTN_modelLoadPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Model File|*.xlsx";
            openFileDialog.Title = "Select a Model File";
            openFileDialog.Multiselect = false;
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //保存路径到设置文件中
                TB_pokerExcelLoadPath.Text = openFileDialog.FileName;
                Properties.Settings.Default.pokerExcelLoadPath = TB_pokerExcelLoadPath.Text;
                Properties.Settings.Default.pokerExcelFileName = openFileDialog.SafeFileName;
                Properties.Settings.Default.Save();
             
            }
        }

        private void BTN_rankingTableLoadPath_Click(object sender, EventArgs e)
        {
           
            if (this.DLG_pokerExcelSaveFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                //保存路径到设置文件中
                TB_pokerExcelSavePath.Text = DLG_pokerExcelSaveFolderBrowser.SelectedPath;
                Properties.Settings.Default.pokerExcelSavePath = TB_pokerExcelSavePath.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void tb_modelSheetName_TextChanged(object sender, EventArgs e)
        {
            //保存到设置文件中
            Properties.Settings.Default.modelSheetName = TB_modelSheetName.Text;
            Properties.Settings.Default.Save();
        }

        private void TB_rankingSheetName_TextChanged(object sender, EventArgs e)
        {
            //保存到设置文件中
            Properties.Settings.Default.rankingSheetName = TB_rankingSheetName.Text;
            Properties.Settings.Default.Save();
        }

        private void Num_createCount_ValueChanged(object sender, EventArgs e)
        {
            //保存到设置文件中
            Properties.Settings.Default.createCount = (int)Num_createCount.Value;
            Properties.Settings.Default.Save();
        }

        private void Num_createCount_MouseClick(object sender, MouseEventArgs e)
        {
            //将所有文字选蓝
            this.Num_createCount.Select(0, this.Num_createCount.Text.Length);
        }

        private void BTN_createRankingObj_Click(object sender, EventArgs e)
        {
            HandRankingExcelLogic handRankingExcelLogic = new();
            handRankingExcelLogic.Start();
            //弹出信息框，完成
            MessageBox.Show("完成");
        }

        private void BTN_showLoadPath_Click(object sender, EventArgs e)
        {
            //截取文件所在的文件夹,并打开
            string path = Properties.Settings.Default.pokerExcelLoadPath;
            string folderPath = path.Substring(0, path.LastIndexOf("\\"));
            System.Diagnostics.Process.Start("explorer.exe", folderPath);
        }

        private void BTH_showSavePath_Click(object sender, EventArgs e)
        {
            //判断路径是否为文件,如果是截取文件所在的文件夹,并打开            
            string path = Properties.Settings.Default.pokerExcelSavePath;
            if (System.IO.File.Exists(path))
            {

                path = path.Substring(0, path.LastIndexOf("\\"));

                System.Diagnostics.Process.Start("explorer.exe", path);
            }
            else
            {

                  System.Diagnostics.Process.Start("explorer.exe", path);
            }
        }
    }
}
