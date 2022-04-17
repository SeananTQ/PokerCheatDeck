using TexasHoldem;
using SeananTools;
using MainLogic;
using PokerCheatDeck.Properties;
using PokerCheatDeck;

namespace PokerTest
{
    public partial class Form_Main : Form
    {
        public HandLogic handLogic;

        public ExcelTestLogic excelTestLogic;
        public Form_Main()
        {
            InitializeComponent();

             loadSettings();
            handLogic = new ();
            excelTestLogic = new();
        }

        //��������,Ϊ�ı���ֵ
        private void loadSettings()
        {
            this.tb_loadPath.Text = Settings.Default.loadPath;
            this.tb_savePath.Text = Settings.Default.savePath;
        }

        
        private void btn_star_Click(object sender, EventArgs e)
        {
            rtb_main.Clear();
            
            handLogic.Show();
            rtb_main.AppendText("=====Start======\r\n"+DebugClass.Text);

            rtb_main.ScrollToCaret();
        }

        private void btn_openFile_Click(object sender, EventArgs e)
        {
            this.dlg_openFileDialog.ShowDialog();
            //����·���������ļ���
            Settings.Default.loadPath = dlg_openFileDialog.FileName;
            Settings.Default.Save();
            this.tb_loadPath.Text = Settings.Default.loadPath;
           }

        private void btn_savePath_Click(object sender, EventArgs e)
        {
            this.dlg_saveFileDialog.ShowDialog();
            //����·���������ļ���
            Settings.Default.savePath = dlg_saveFileDialog.FileName;
            Settings.Default.Save();
            this.tb_savePath.Text = Settings.Default.savePath;
        }

        private void btn_testExcel_Click(object sender, EventArgs e)
        {
            rtb_main.Clear();

            
            excelTestLogic.Star(this.tb_loadPath.Text,this.tb_savePath.Text);
            rtb_main.AppendText("=====Start======\r\n" + DebugClass.Text);

            rtb_main.ScrollToCaret();
        }

        private void tbtn_openAboutForm_Click(object sender, EventArgs e)
        {
            //����Form_About��������Ϊ�Ӵ�����ʾ����������
            Form_About form_about = new Form_About();
            //�ı����꣬�����������
            form_about.StartPosition = FormStartPosition.CenterParent;
            //��ʾ����
            form_about.ShowDialog();     

        }

        private void tbtn_openRankingForm_Click(object sender, EventArgs e)
        {
            //����Form_Ranking��������Ϊ�Ӵ�����ʾ����������
            Form_Ranking form_ranking = new Form_Ranking();
            //�ı����꣬�����������
            form_ranking.StartPosition = FormStartPosition.CenterParent;
            //��ʾ����
            form_ranking.ShowDialog();
        }
    }
}