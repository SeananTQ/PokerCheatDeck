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
            this.SuspendLayout();
            // 
            // btn_star
            // 
            this.btn_star.Location = new System.Drawing.Point(355, 397);
            this.btn_star.Name = "btn_star";
            this.btn_star.Size = new System.Drawing.Size(123, 41);
            this.btn_star.TabIndex = 1;
            this.btn_star.Text = "Star";
            this.btn_star.UseVisualStyleBackColor = true;
            this.btn_star.Click += new System.EventHandler(this.btn_star_Click);
            // 
            // rtb_main
            // 
            this.rtb_main.Location = new System.Drawing.Point(12, 12);
            this.rtb_main.Name = "rtb_main";
            this.rtb_main.Size = new System.Drawing.Size(776, 379);
            this.rtb_main.TabIndex = 2;
            this.rtb_main.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtb_main);
            this.Controls.Add(this.btn_star);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_star;
        private RichTextBox rtb_main;
    }
}