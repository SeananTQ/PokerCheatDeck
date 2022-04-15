using TexasHoldem;
using SeananTools;
using MainLogic;
using PokerCheatDeck.Properties;

namespace PokerTest
{
    public partial class Form1 : Form
    {
        public HandLogic handLogic;

        public ExcelTestLogic excelTestLogic;
        public Form1()
        {
            InitializeComponent();

             loadSettings();
            handLogic = new ();
            excelTestLogic = new();
        }

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
            Settings.Default.loadPath = dlg_openFileDialog.FileName;
            Settings.Default.Save();
            this.tb_loadPath.Text = Settings.Default.loadPath;
           }

        private void btn_savePath_Click(object sender, EventArgs e)
        {
            this.dlg_saveFileDialog.ShowDialog();
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
    }
}