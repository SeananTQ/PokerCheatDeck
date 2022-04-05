using TexasHoldem;
using SeananTools;
using MainLogic;

namespace PokerTest
{
    public partial class Form1 : Form
    {
        public HandLogic handLogic;
        public Form1()
        {
            InitializeComponent();

            handLogic = new HandLogic();
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
            this.tx_filePath.Text = dlg_openFileDialog.FileName;
        }

        private void btn_savePath_Click(object sender, EventArgs e)
        {
            this.dlg_saveFileDialog.ShowDialog();
            this.tx_savePath.Text = dlg_saveFileDialog.FileName;
        }
    }
}