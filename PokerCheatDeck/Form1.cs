using TexasHoldem;
using SeananTools;
using MainLogic;

namespace PokerTest
{
    public partial class Form1 : Form
    {
        public HandLogic handLogic;

        public ExcelTestLogic excelTestLogic;
        public Form1()
        {
            InitializeComponent();

            handLogic = new ();
            excelTestLogic = new();
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
            this.tb_loadPath.Text = dlg_openFileDialog.FileName;
            
        }

        private void btn_savePath_Click(object sender, EventArgs e)
        {
            this.dlg_saveFileDialog.ShowDialog();
            this.tb_savePath.Text = dlg_saveFileDialog.FileName;
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