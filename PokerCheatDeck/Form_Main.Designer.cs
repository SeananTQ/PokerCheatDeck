namespace PokerTest
{
    partial class Form_Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.btn_star = new System.Windows.Forms.Button();
            this.rtb_main = new System.Windows.Forms.RichTextBox();
            this.btn_testExcel = new System.Windows.Forms.Button();
            this.btn_openFile = new System.Windows.Forms.Button();
            this.tx_loadPath = new System.Windows.Forms.Label();
            this.dlg_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tx_savePath = new System.Windows.Forms.Label();
            this.btn_savePath = new System.Windows.Forms.Button();
            this.dlg_saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tb_loadPath = new System.Windows.Forms.TextBox();
            this.tb_savePath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtn_openRankingForm = new System.Windows.Forms.ToolStripButton();
            this.tbtn_openAboutForm = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_star
            // 
            this.btn_star.Location = new System.Drawing.Point(659, 701);
            this.btn_star.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_star.Name = "btn_star";
            this.btn_star.Size = new System.Drawing.Size(228, 72);
            this.btn_star.TabIndex = 1;
            this.btn_star.Text = "StarPoker";
            this.btn_star.UseVisualStyleBackColor = true;
            this.btn_star.Click += new System.EventHandler(this.btn_star_Click);
            // 
            // rtb_main
            // 
            this.rtb_main.Location = new System.Drawing.Point(15, 81);
            this.rtb_main.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.rtb_main.Name = "rtb_main";
            this.rtb_main.Size = new System.Drawing.Size(1637, 117);
            this.rtb_main.TabIndex = 2;
            this.rtb_main.Text = "";
            // 
            // btn_testExcel
            // 
            this.btn_testExcel.Location = new System.Drawing.Point(934, 701);
            this.btn_testExcel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_testExcel.Name = "btn_testExcel";
            this.btn_testExcel.Size = new System.Drawing.Size(227, 72);
            this.btn_testExcel.TabIndex = 3;
            this.btn_testExcel.Text = "TestExcel";
            this.btn_testExcel.UseVisualStyleBackColor = true;
            this.btn_testExcel.Click += new System.EventHandler(this.btn_testExcel_Click);
            // 
            // btn_openFile
            // 
            this.btn_openFile.Location = new System.Drawing.Point(856, 519);
            this.btn_openFile.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_openFile.Name = "btn_openFile";
            this.btn_openFile.Size = new System.Drawing.Size(139, 41);
            this.btn_openFile.TabIndex = 4;
            this.btn_openFile.Text = "选择";
            this.btn_openFile.UseVisualStyleBackColor = true;
            this.btn_openFile.Click += new System.EventHandler(this.btn_openFile_Click);
            // 
            // tx_loadPath
            // 
            this.tx_loadPath.AutoSize = true;
            this.tx_loadPath.Location = new System.Drawing.Point(22, 524);
            this.tx_loadPath.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.tx_loadPath.Name = "tx_loadPath";
            this.tx_loadPath.Size = new System.Drawing.Size(175, 30);
            this.tx_loadPath.TabIndex = 5;
            this.tx_loadPath.Text = "请选择载入Excel";
            // 
            // dlg_openFileDialog
            // 
            this.dlg_openFileDialog.FileName = "openFileDialog1";
            // 
            // tx_savePath
            // 
            this.tx_savePath.AutoSize = true;
            this.tx_savePath.Location = new System.Drawing.Point(22, 577);
            this.tx_savePath.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.tx_savePath.Name = "tx_savePath";
            this.tx_savePath.Size = new System.Drawing.Size(167, 30);
            this.tx_savePath.TabIndex = 6;
            this.tx_savePath.Text = "请选择保存位置";
            // 
            // btn_savePath
            // 
            this.btn_savePath.Location = new System.Drawing.Point(856, 577);
            this.btn_savePath.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_savePath.Name = "btn_savePath";
            this.btn_savePath.Size = new System.Drawing.Size(139, 41);
            this.btn_savePath.TabIndex = 7;
            this.btn_savePath.Text = "选择";
            this.btn_savePath.UseVisualStyleBackColor = true;
            this.btn_savePath.Click += new System.EventHandler(this.btn_savePath_Click);
            // 
            // tb_loadPath
            // 
            this.tb_loadPath.Location = new System.Drawing.Point(214, 519);
            this.tb_loadPath.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tb_loadPath.Name = "tb_loadPath";
            this.tb_loadPath.Size = new System.Drawing.Size(628, 35);
            this.tb_loadPath.TabIndex = 8;
            // 
            // tb_savePath
            // 
            this.tb_savePath.Location = new System.Drawing.Point(214, 577);
            this.tb_savePath.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tb_savePath.Name = "tb_savePath";
            this.tb_savePath.Size = new System.Drawing.Size(628, 35);
            this.tb_savePath.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1179, 526);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 34);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtn_openRankingForm,
            this.tbtn_openAboutForm});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1674, 39);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtn_openRankingForm
            // 
            this.tbtn_openRankingForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtn_openRankingForm.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_openRankingForm.Image")));
            this.tbtn_openRankingForm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_openRankingForm.Name = "tbtn_openRankingForm";
            this.tbtn_openRankingForm.Size = new System.Drawing.Size(105, 34);
            this.tbtn_openRankingForm.Text = "生成牌型";
            this.tbtn_openRankingForm.Click += new System.EventHandler(this.tbtn_openRankingForm_Click);
            // 
            // tbtn_openAboutForm
            // 
            this.tbtn_openAboutForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtn_openAboutForm.Image = ((System.Drawing.Image)(resources.GetObject("tbtn_openAboutForm.Image")));
            this.tbtn_openAboutForm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtn_openAboutForm.Name = "tbtn_openAboutForm";
            this.tbtn_openAboutForm.Size = new System.Drawing.Size(61, 34);
            this.tbtn_openAboutForm.Text = "关于";
            this.tbtn_openAboutForm.Click += new System.EventHandler(this.tbtn_openAboutForm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1674, 792);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_savePath);
            this.Controls.Add(this.tb_loadPath);
            this.Controls.Add(this.btn_savePath);
            this.Controls.Add(this.tx_savePath);
            this.Controls.Add(this.tx_loadPath);
            this.Controls.Add(this.btn_openFile);
            this.Controls.Add(this.btn_testExcel);
            this.Controls.Add(this.rtb_main);
            this.Controls.Add(this.btn_star);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_star;
        private RichTextBox rtb_main;
        private Button btn_testExcel;
        private Button btn_openFile;
        private Label tx_loadPath;
        private OpenFileDialog dlg_openFileDialog;
        private Label tx_savePath;
        private Button btn_savePath;
        private SaveFileDialog dlg_saveFileDialog;
        private TextBox tb_loadPath;
        private TextBox tb_savePath;
        private Button button1;
        private ToolStrip toolStrip1;
        private ToolStripButton tbtn_openRankingForm;
        private ToolStripButton tbtn_openAboutForm;
    }
}