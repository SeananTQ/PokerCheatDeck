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
            this.btn_modelLoadPath = new System.Windows.Forms.Button();
            this.tb_modelLoadPath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_rankingTableSavePath = new System.Windows.Forms.Button();
            this.tb_rankingTableSavePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.num_createCount = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.lb_state = new System.Windows.Forms.Label();
            this.dlg_rankingTableSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.dlg_modelOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_rankingTableLoadPath = new System.Windows.Forms.Button();
            this.tb_rankingTableLoadPath = new System.Windows.Forms.TextBox();
            this.tb_modelSheetName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_createCount)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_modelLoadPath);
            this.groupBox1.Controls.Add(this.tb_modelLoadPath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1154, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "模板表输入路径";
            // 
            // btn_modelLoadPath
            // 
            this.btn_modelLoadPath.Location = new System.Drawing.Point(1022, 44);
            this.btn_modelLoadPath.Name = "btn_modelLoadPath";
            this.btn_modelLoadPath.Size = new System.Drawing.Size(112, 34);
            this.btn_modelLoadPath.TabIndex = 1;
            this.btn_modelLoadPath.Text = "选择";
            this.btn_modelLoadPath.UseVisualStyleBackColor = true;
            this.btn_modelLoadPath.Click += new System.EventHandler(this.btn_modelLoadPath_Click);
            // 
            // tb_modelLoadPath
            // 
            this.tb_modelLoadPath.Location = new System.Drawing.Point(6, 44);
            this.tb_modelLoadPath.Name = "tb_modelLoadPath";
            this.tb_modelLoadPath.PlaceholderText = "请选择模板表";
            this.tb_modelLoadPath.Size = new System.Drawing.Size(988, 35);
            this.tb_modelLoadPath.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_rankingTableSavePath);
            this.groupBox2.Controls.Add(this.tb_rankingTableSavePath);
            this.groupBox2.Location = new System.Drawing.Point(18, 299);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1154, 96);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "牌型表输出路径";
            // 
            // btn_rankingTableSavePath
            // 
            this.btn_rankingTableSavePath.Location = new System.Drawing.Point(1022, 44);
            this.btn_rankingTableSavePath.Name = "btn_rankingTableSavePath";
            this.btn_rankingTableSavePath.Size = new System.Drawing.Size(112, 34);
            this.btn_rankingTableSavePath.TabIndex = 1;
            this.btn_rankingTableSavePath.Text = "选择";
            this.btn_rankingTableSavePath.UseVisualStyleBackColor = true;
            // 
            // tb_rankingTableSavePath
            // 
            this.tb_rankingTableSavePath.Location = new System.Drawing.Point(6, 44);
            this.tb_rankingTableSavePath.Name = "tb_rankingTableSavePath";
            this.tb_rankingTableSavePath.Size = new System.Drawing.Size(988, 35);
            this.tb_rankingTableSavePath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(923, 456);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "生成数量";
            // 
            // num_createCount
            // 
            this.num_createCount.Location = new System.Drawing.Point(923, 489);
            this.num_createCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_createCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_createCount.Name = "num_createCount";
            this.num_createCount.Size = new System.Drawing.Size(101, 35);
            this.num_createCount.TabIndex = 4;
            this.num_createCount.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(923, 549);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "生成";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lb_state
            // 
            this.lb_state.AutoSize = true;
            this.lb_state.Location = new System.Drawing.Point(1090, 563);
            this.lb_state.Name = "lb_state";
            this.lb_state.Size = new System.Drawing.Size(57, 30);
            this.lb_state.TabIndex = 6;
            this.lb_state.Text = "状态";
            // 
            // dlg_modelOpenFile
            // 
            this.dlg_modelOpenFile.FileName = "openFileDialog1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_rankingTableLoadPath);
            this.groupBox3.Controls.Add(this.tb_rankingTableLoadPath);
            this.groupBox3.Location = new System.Drawing.Point(12, 145);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1154, 96);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "牌型表输入路径";
            // 
            // btn_rankingTableLoadPath
            // 
            this.btn_rankingTableLoadPath.Location = new System.Drawing.Point(1022, 44);
            this.btn_rankingTableLoadPath.Name = "btn_rankingTableLoadPath";
            this.btn_rankingTableLoadPath.Size = new System.Drawing.Size(112, 34);
            this.btn_rankingTableLoadPath.TabIndex = 1;
            this.btn_rankingTableLoadPath.Text = "选择";
            this.btn_rankingTableLoadPath.UseVisualStyleBackColor = true;
            this.btn_rankingTableLoadPath.Click += new System.EventHandler(this.btn_rankingTableLoadPath_Click);
            // 
            // tb_rankingTableLoadPath
            // 
            this.tb_rankingTableLoadPath.Location = new System.Drawing.Point(6, 44);
            this.tb_rankingTableLoadPath.Name = "tb_rankingTableLoadPath";
            this.tb_rankingTableLoadPath.PlaceholderText = "请选牌型表";
            this.tb_rankingTableLoadPath.Size = new System.Drawing.Size(988, 35);
            this.tb_rankingTableLoadPath.TabIndex = 0;
            // 
            // tb_modelSheetName
            // 
            this.tb_modelSheetName.Location = new System.Drawing.Point(18, 533);
            this.tb_modelSheetName.Name = "tb_modelSheetName";
            this.tb_modelSheetName.Size = new System.Drawing.Size(221, 35);
            this.tb_modelSheetName.TabIndex = 8;
            this.tb_modelSheetName.Text = "pokerHandRanking";
            this.tb_modelSheetName.TextChanged += new System.EventHandler(this.tb_modelSheetName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 500);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 30);
            this.label2.TabIndex = 9;
            this.label2.Text = "SheetName";
            // 
            // Form_Ranking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 602);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_modelSheetName);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lb_state);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.num_createCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_Ranking";
            this.Text = "生成牌型表";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_createCount)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Button btn_modelLoadPath;
        private TextBox tb_modelLoadPath;
        private GroupBox groupBox2;
        private Button btn_rankingTableSavePath;
        private TextBox tb_rankingTableSavePath;
        private Label label1;
        private NumericUpDown num_createCount;
        private Button button1;
        private Label lb_state;
        private SaveFileDialog dlg_rankingTableSaveFile;
        private OpenFileDialog dlg_modelOpenFile;
        private GroupBox groupBox3;
        private Button btn_rankingTableLoadPath;
        private TextBox tb_rankingTableLoadPath;
        private TextBox tb_modelSheetName;
        private Label label2;
    }
}