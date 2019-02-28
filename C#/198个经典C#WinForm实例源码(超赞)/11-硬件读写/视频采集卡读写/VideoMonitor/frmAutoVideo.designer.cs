namespace VideoMonitor
{
    partial class frmAutoVideo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSure = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxDate = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboxWeek = new System.Windows.Forms.ComboBox();
            this.NUDownHour = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NUDownMin = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cboxVideo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDownHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDownMin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(215, 140);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(132, 140);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 23);
            this.btnSure.TabIndex = 15;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboxDate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboxWeek);
            this.groupBox1.Controls.Add(this.NUDownHour);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.NUDownMin);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(9, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 77);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "录像时刻";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(251, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "分";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(120, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "时";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "小时：";
            // 
            // cboxDate
            // 
            this.cboxDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDate.FormattingEnabled = true;
            this.cboxDate.Location = new System.Drawing.Point(193, 48);
            this.cboxDate.Name = "cboxDate";
            this.cboxDate.Size = new System.Drawing.Size(56, 20);
            this.cboxDate.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "星期：";
            // 
            // cboxWeek
            // 
            this.cboxWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxWeek.FormattingEnabled = true;
            this.cboxWeek.Items.AddRange(new object[] {
            "星期一",
            "星期二",
            "星期三",
            "星期四",
            "星期五",
            "星期六",
            "星期日"});
            this.cboxWeek.Location = new System.Drawing.Point(62, 48);
            this.cboxWeek.Name = "cboxWeek";
            this.cboxWeek.Size = new System.Drawing.Size(74, 20);
            this.cboxWeek.TabIndex = 8;
            // 
            // NUDownHour
            // 
            this.NUDownHour.Location = new System.Drawing.Point(62, 18);
            this.NUDownHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.NUDownHour.Name = "NUDownHour";
            this.NUDownHour.Size = new System.Drawing.Size(54, 21);
            this.NUDownHour.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "日期：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(154, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "分钟：";
            // 
            // NUDownMin
            // 
            this.NUDownMin.Location = new System.Drawing.Point(195, 18);
            this.NUDownMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.NUDownMin.Name = "NUDownMin";
            this.NUDownMin.Size = new System.Drawing.Size(54, 21);
            this.NUDownMin.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(251, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "日";
            // 
            // cboxVideo
            // 
            this.cboxVideo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxVideo.FormattingEnabled = true;
            this.cboxVideo.Items.AddRange(new object[] {
            "每天",
            "每周",
            "每月"});
            this.cboxVideo.Location = new System.Drawing.Point(31, 27);
            this.cboxVideo.Name = "cboxVideo";
            this.cboxVideo.Size = new System.Drawing.Size(259, 20);
            this.cboxVideo.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "录像频率：";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmAutoVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 171);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboxVideo);
            this.Controls.Add(this.label3);
            this.Name = "frmAutoVideo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定时录像设置";
            this.Load += new System.EventHandler(this.frmAutoVideo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDownHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDownMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboxDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboxWeek;
        private System.Windows.Forms.NumericUpDown NUDownHour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown NUDownMin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboxVideo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
    }
}