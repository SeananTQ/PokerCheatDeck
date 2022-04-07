namespace PokerTest
{
    partial class Form1
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
            this.SuspendLayout();
            // 
            // btn_star
            // 
            this.btn_star.Location = new System.Drawing.Point(355, 397);
            this.btn_star.Name = "btn_star";
            this.btn_star.Size = new System.Drawing.Size(123, 41);
            this.btn_star.TabIndex = 1;
            this.btn_star.Text = "StarPoker";
            this.btn_star.UseVisualStyleBackColor = true;
            this.btn_star.Click += new System.EventHandler(this.btn_star_Click);
            // 
            // rtb_main
            // 
            this.rtb_main.Location = new System.Drawing.Point(12, 12);
            this.rtb_main.Name = "rtb_main";
            this.rtb_main.Size = new System.Drawing.Size(776, 256);
            this.rtb_main.TabIndex = 2;
            this.rtb_main.Text = "";
            // 
            // btn_testExcel
            // 
            this.btn_testExcel.Location = new System.Drawing.Point(503, 397);
            this.btn_testExcel.Name = "btn_testExcel";
            this.btn_testExcel.Size = new System.Drawing.Size(122, 41);
            this.btn_testExcel.TabIndex = 3;
            this.btn_testExcel.Text = "TestExcel";
            this.btn_testExcel.UseVisualStyleBackColor = true;
            this.btn_testExcel.Click += new System.EventHandler(this.btn_testExcel_Click);
            // 
            // btn_openFile
            // 
            this.btn_openFile.Location = new System.Drawing.Point(461, 294);
            this.btn_openFile.Name = "btn_openFile";
            this.btn_openFile.Size = new System.Drawing.Size(75, 23);
            this.btn_openFile.TabIndex = 4;
            this.btn_openFile.Text = "选择";
            this.btn_openFile.UseVisualStyleBackColor = true;
            this.btn_openFile.Click += new System.EventHandler(this.btn_openFile_Click);
            // 
            // tx_loadPath
            // 
            this.tx_loadPath.AutoSize = true;
            this.tx_loadPath.Location = new System.Drawing.Point(12, 297);
            this.tx_loadPath.Name = "tx_loadPath";
            this.tx_loadPath.Size = new System.Drawing.Size(97, 17);
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
            this.tx_savePath.Location = new System.Drawing.Point(12, 327);
            this.tx_savePath.Name = "tx_savePath";
            this.tx_savePath.Size = new System.Drawing.Size(92, 17);
            this.tx_savePath.TabIndex = 6;
            this.tx_savePath.Text = "请选择保存位置";
            // 
            // btn_savePath
            // 
            this.btn_savePath.Location = new System.Drawing.Point(461, 327);
            this.btn_savePath.Name = "btn_savePath";
            this.btn_savePath.Size = new System.Drawing.Size(75, 23);
            this.btn_savePath.TabIndex = 7;
            this.btn_savePath.Text = "选择";
            this.btn_savePath.UseVisualStyleBackColor = true;
            this.btn_savePath.Click += new System.EventHandler(this.btn_savePath_Click);
            // 
            // tb_loadPath
            // 
            this.tb_loadPath.Location = new System.Drawing.Point(115, 294);
            this.tb_loadPath.Name = "tb_loadPath";
            this.tb_loadPath.Size = new System.Drawing.Size(340, 23);
            this.tb_loadPath.TabIndex = 8;
            // 
            // tb_savePath
            // 
            this.tb_savePath.Location = new System.Drawing.Point(115, 327);
            this.tb_savePath.Name = "tb_savePath";
            this.tb_savePath.Size = new System.Drawing.Size(340, 23);
            this.tb_savePath.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tb_savePath);
            this.Controls.Add(this.tb_loadPath);
            this.Controls.Add(this.btn_savePath);
            this.Controls.Add(this.tx_savePath);
            this.Controls.Add(this.tx_loadPath);
            this.Controls.Add(this.btn_openFile);
            this.Controls.Add(this.btn_testExcel);
            this.Controls.Add(this.rtb_main);
            this.Controls.Add(this.btn_star);
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}