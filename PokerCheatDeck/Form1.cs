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
    }
}