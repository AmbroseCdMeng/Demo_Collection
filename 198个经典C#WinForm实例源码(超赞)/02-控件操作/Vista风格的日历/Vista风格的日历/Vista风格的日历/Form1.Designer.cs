namespace Vista风格的日历
{
    partial class Form1
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolS_UPday = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_Downday = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_Upmonth = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_Downmonth = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_Upyear = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_Downyear = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimeControl1 = new Vista风格的日历.DateTimeControl();
            this.ToolS_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolS_UPday,
            this.ToolS_Downday,
            this.ToolS_Upmonth,
            this.ToolS_Downmonth,
            this.ToolS_Upyear,
            this.ToolS_Downyear,
            this.ToolS_Close});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 180);
            // 
            // ToolS_UPday
            // 
            this.ToolS_UPday.Name = "ToolS_UPday";
            this.ToolS_UPday.Size = new System.Drawing.Size(152, 22);
            this.ToolS_UPday.Tag = "1";
            this.ToolS_UPday.Text = "前一天";
            this.ToolS_UPday.Click += new System.EventHandler(this.ToolS_UPday_Click);
            // 
            // ToolS_Downday
            // 
            this.ToolS_Downday.Name = "ToolS_Downday";
            this.ToolS_Downday.Size = new System.Drawing.Size(152, 22);
            this.ToolS_Downday.Tag = "2";
            this.ToolS_Downday.Text = "后一天";
            this.ToolS_Downday.Click += new System.EventHandler(this.ToolS_UPday_Click);
            // 
            // ToolS_Upmonth
            // 
            this.ToolS_Upmonth.Name = "ToolS_Upmonth";
            this.ToolS_Upmonth.Size = new System.Drawing.Size(152, 22);
            this.ToolS_Upmonth.Tag = "3";
            this.ToolS_Upmonth.Text = "前一月";
            this.ToolS_Upmonth.Click += new System.EventHandler(this.ToolS_UPday_Click);
            // 
            // ToolS_Downmonth
            // 
            this.ToolS_Downmonth.Name = "ToolS_Downmonth";
            this.ToolS_Downmonth.Size = new System.Drawing.Size(152, 22);
            this.ToolS_Downmonth.Tag = "4";
            this.ToolS_Downmonth.Text = "后一月";
            this.ToolS_Downmonth.Click += new System.EventHandler(this.ToolS_UPday_Click);
            // 
            // ToolS_Upyear
            // 
            this.ToolS_Upyear.Name = "ToolS_Upyear";
            this.ToolS_Upyear.Size = new System.Drawing.Size(152, 22);
            this.ToolS_Upyear.Tag = "5";
            this.ToolS_Upyear.Text = "前一年";
            this.ToolS_Upyear.Click += new System.EventHandler(this.ToolS_UPday_Click);
            // 
            // ToolS_Downyear
            // 
            this.ToolS_Downyear.Name = "ToolS_Downyear";
            this.ToolS_Downyear.Size = new System.Drawing.Size(152, 22);
            this.ToolS_Downyear.Tag = "6";
            this.ToolS_Downyear.Text = "后一年";
            this.ToolS_Downyear.Click += new System.EventHandler(this.ToolS_UPday_Click);
            // 
            // dateTimeControl1
            // 
            this.dateTimeControl1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.dateTimeControl1.BackColor = System.Drawing.Color.Transparent;
            this.dateTimeControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.dateTimeControl1.Date = new System.DateTime(2008, 12, 8, 0, 0, 0, 0);
            this.dateTimeControl1.Location = new System.Drawing.Point(4, 3);
            this.dateTimeControl1.Name = "dateTimeControl1";
            this.dateTimeControl1.Size = new System.Drawing.Size(158, 154);
            this.dateTimeControl1.TabIndex = 0;
            this.dateTimeControl1.Tag = 0;
            this.dateTimeControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dateTimeControl1_MouseMove);
            this.dateTimeControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dateTimeControl1_MouseDown);
            // 
            // ToolS_Close
            // 
            this.ToolS_Close.Name = "ToolS_Close";
            this.ToolS_Close.Size = new System.Drawing.Size(152, 22);
            this.ToolS_Close.Tag = "7";
            this.ToolS_Close.Text = "退出";
            this.ToolS_Close.Click += new System.EventHandler(this.ToolS_UPday_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(178, 161);
            this.Controls.Add(this.dateTimeControl1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Red;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimeControl dateTimeControl1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolS_UPday;
        private System.Windows.Forms.ToolStripMenuItem ToolS_Downday;
        private System.Windows.Forms.ToolStripMenuItem ToolS_Upmonth;
        private System.Windows.Forms.ToolStripMenuItem ToolS_Downmonth;
        private System.Windows.Forms.ToolStripMenuItem ToolS_Upyear;
        private System.Windows.Forms.ToolStripMenuItem ToolS_Downyear;
        private System.Windows.Forms.ToolStripMenuItem ToolS_Close;

    }
}

