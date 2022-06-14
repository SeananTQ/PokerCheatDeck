namespace PokerCheatDeck
{
    partial class Form_Ranking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_rankingTableLoadPath = new System.Windows.Forms.Button();
            this.btn_modelLoadPath = new System.Windows.Forms.Button();
            this.TB_pokerExcelSavePath = new System.Windows.Forms.TextBox();
            this.TB_pokerExcelLoadPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Num_createCount = new System.Windows.Forms.NumericUpDown();
            this.BTN_createRankingObj = new System.Windows.Forms.Button();
            this.TX_state = new System.Windows.Forms.Label();
            this.TB_modelSheetName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_rankingSheetName = new System.Windows.Forms.TextBox();
            this.DLG_pokerExcelSaveFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.dlg_modelOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.BTN_showLoadPath = new System.Windows.Forms.Button();
            this.BTH_showSavePath = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_createCount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_rankingTableLoadPath);
            this.groupBox1.Controls.Add(this.btn_modelLoadPath);
            this.groupBox1.Controls.Add(this.TB_pokerExcelSavePath);
            this.groupBox1.Controls.Add(this.TB_pokerExcelLoadPath);
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox1.Size = new System.Drawing.Size(621, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "表路径";
            // 
            // btn_rankingTableLoadPath
            // 
            this.btn_rankingTableLoadPath.Location = new System.Drawing.Point(549, 57);
            this.btn_rankingTableLoadPath.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btn_rankingTableLoadPath.Name = "btn_rankingTableLoadPath";
            this.btn_rankingTableLoadPath.Size = new System.Drawing.Size(68, 42);
            this.btn_rankingTableLoadPath.TabIndex = 1;
            this.btn_rankingTableLoadPath.Text = "选择";
            this.btn_rankingTableLoadPath.UseVisualStyleBackColor = true;
            this.btn_rankingTableLoadPath.Click += new System.EventHandler(this.BTN_rankingTableLoadPath_Click);
            // 
            // btn_modelLoadPath
            // 
            this.btn_modelLoadPath.Location = new System.Drawing.Point(549, 10);
            this.btn_modelLoadPath.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btn_modelLoadPath.Name = "btn_modelLoadPath";
            this.btn_modelLoadPath.Size = new System.Drawing.Size(68, 45);
            this.btn_modelLoadPath.TabIndex = 1;
            this.btn_modelLoadPath.Text = "选择";
            this.btn_modelLoadPath.UseVisualStyleBackColor = true;
            this.btn_modelLoadPath.Click += new System.EventHandler(this.BTN_modelLoadPath_Click);
            // 
            // TB_pokerExcelSavePath
            // 
            this.TB_pokerExcelSavePath.Location = new System.Drawing.Point(3, 67);
            this.TB_pokerExcelSavePath.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.TB_pokerExcelSavePath.Name = "TB_pokerExcelSavePath";
            this.TB_pokerExcelSavePath.PlaceholderText = "请选择保存路径";
            this.TB_pokerExcelSavePath.Size = new System.Drawing.Size(534, 23);
            this.TB_pokerExcelSavePath.TabIndex = 0;
            // 
            // TB_pokerExcelLoadPath
            // 
            this.TB_pokerExcelLoadPath.Location = new System.Drawing.Point(3, 25);
            this.TB_pokerExcelLoadPath.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.TB_pokerExcelLoadPath.Name = "TB_pokerExcelLoadPath";
            this.TB_pokerExcelLoadPath.PlaceholderText = "请选择模板表";
            this.TB_pokerExcelLoadPath.Size = new System.Drawing.Size(534, 23);
            this.TB_pokerExcelLoadPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(497, 259);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "生成数量";
            // 
            // Num_createCount
            // 
            this.Num_createCount.Location = new System.Drawing.Point(497, 277);
            this.Num_createCount.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Num_createCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.Num_createCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Num_createCount.Name = "Num_createCount";
            this.Num_createCount.Size = new System.Drawing.Size(54, 23);
            this.Num_createCount.TabIndex = 4;
            this.Num_createCount.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.Num_createCount.ValueChanged += new System.EventHandler(this.Num_createCount_ValueChanged);
            this.Num_createCount.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Num_createCount_MouseClick);
            // 
            // BTN_createRankingObj
            // 
            this.BTN_createRankingObj.Location = new System.Drawing.Point(497, 304);
            this.BTN_createRankingObj.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.BTN_createRankingObj.Name = "BTN_createRankingObj";
            this.BTN_createRankingObj.Size = new System.Drawing.Size(54, 32);
            this.BTN_createRankingObj.TabIndex = 5;
            this.BTN_createRankingObj.Text = "生成";
            this.BTN_createRankingObj.UseVisualStyleBackColor = true;
            this.BTN_createRankingObj.Click += new System.EventHandler(this.BTN_createRankingObj_Click);
            // 
            // TX_state
            // 
            this.TX_state.AutoSize = true;
            this.TX_state.Location = new System.Drawing.Point(571, 318);
            this.TX_state.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TX_state.Name = "TX_state";
            this.TX_state.Size = new System.Drawing.Size(56, 17);
            this.TX_state.TabIndex = 6;
            this.TX_state.Text = "当前状态";
            // 
            // TB_modelSheetName
            // 
            this.TB_modelSheetName.Location = new System.Drawing.Point(81, 248);
            this.TB_modelSheetName.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.TB_modelSheetName.Name = "TB_modelSheetName";
            this.TB_modelSheetName.Size = new System.Drawing.Size(121, 23);
            this.TB_modelSheetName.TabIndex = 8;
            this.TB_modelSheetName.Text = "pokerHandRanking";
            this.TB_modelSheetName.TextChanged += new System.EventHandler(this.tb_modelSheetName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 250);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "模型Sheet";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 281);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "牌型Sheet";
            // 
            // TB_rankingSheetName
            // 
            this.TB_rankingSheetName.Location = new System.Drawing.Point(81, 277);
            this.TB_rankingSheetName.Margin = new System.Windows.Forms.Padding(2);
            this.TB_rankingSheetName.Name = "TB_rankingSheetName";
            this.TB_rankingSheetName.Size = new System.Drawing.Size(121, 23);
            this.TB_rankingSheetName.TabIndex = 11;
            this.TB_rankingSheetName.TextChanged += new System.EventHandler(this.TB_rankingSheetName_TextChanged);
            // 
            // dlg_modelOpenFile
            // 
            this.dlg_modelOpenFile.FileName = "openFileDialog1";
            // 
            // BTN_showLoadPath
            // 
            this.BTN_showLoadPath.Location = new System.Drawing.Point(6, 171);
            this.BTN_showLoadPath.Name = "BTN_showLoadPath";
            this.BTN_showLoadPath.Size = new System.Drawing.Size(114, 23);
            this.BTN_showLoadPath.TabIndex = 12;
            this.BTN_showLoadPath.Text = "查看输入文件夹";
            this.BTN_showLoadPath.UseVisualStyleBackColor = true;
            this.BTN_showLoadPath.Click += new System.EventHandler(this.BTN_showLoadPath_Click);
            // 
            // BTH_showSavePath
            // 
            this.BTH_showSavePath.Location = new System.Drawing.Point(9, 200);
            this.BTH_showSavePath.Name = "BTH_showSavePath";
            this.BTH_showSavePath.Size = new System.Drawing.Size(111, 23);
            this.BTH_showSavePath.TabIndex = 13;
            this.BTH_showSavePath.Text = "查看输出文件夹";
            this.BTH_showSavePath.UseVisualStyleBackColor = true;
            this.BTH_showSavePath.Click += new System.EventHandler(this.BTH_showSavePath_Click);
            // 
            // Form_Ranking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 341);
            this.Controls.Add(this.BTH_showSavePath);
            this.Controls.Add(this.BTN_showLoadPath);
            this.Controls.Add(this.TB_rankingSheetName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_modelSheetName);
            this.Controls.Add(this.TX_state);
            this.Controls.Add(this.BTN_createRankingObj);
            this.Controls.Add(this.Num_createCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "Form_Ranking";
            this.Text = "生成牌型表";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_createCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Button btn_modelLoadPath;
        private TextBox TB_pokerExcelLoadPath;
        private Label label1;
        private NumericUpDown Num_createCount;
        private Button BTN_createRankingObj;
        private Label TX_state;
        private Button btn_rankingTableLoadPath;
        private TextBox TB_pokerExcelSavePath;
        private TextBox TB_modelSheetName;
        private Label label2;
        private Label label3;
        private TextBox TB_rankingSheetName;
        private FolderBrowserDialog DLG_pokerExcelSaveFolderBrowser;
        private OpenFileDialog dlg_modelOpenFile;
        private Button BTN_showLoadPath;
        private Button BTH_showSavePath;
    }
}