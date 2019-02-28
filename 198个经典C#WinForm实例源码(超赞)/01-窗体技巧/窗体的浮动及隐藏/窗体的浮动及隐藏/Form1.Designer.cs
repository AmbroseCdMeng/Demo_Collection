namespace 窗体的浮动及隐藏
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
            this.panel_Title = new System.Windows.Forms.Panel();
            this.panel_Close = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_Title.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Title
            // 
            this.panel_Title.BackColor = System.Drawing.Color.DarkBlue;
            this.panel_Title.BackgroundImage = global::窗体的浮动及隐藏.Properties.Resources._1;
            this.panel_Title.Controls.Add(this.panel_Close);
            this.panel_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Title.Location = new System.Drawing.Point(0, 0);
            this.panel_Title.Name = "panel_Title";
            this.panel_Title.Size = new System.Drawing.Size(170, 27);
            this.panel_Title.TabIndex = 0;
            this.panel_Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Title_MouseMove);
            this.panel_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Title_MouseDown);
            this.panel_Title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Title_MouseUp);
            // 
            // panel_Close
            // 
            this.panel_Close.BackColor = System.Drawing.Color.Red;
            this.panel_Close.BackgroundImage = global::窗体的浮动及隐藏.Properties.Resources.Close;
            this.panel_Close.Location = new System.Drawing.Point(149, 5);
            this.panel_Close.Name = "panel_Close";
            this.panel_Close.Size = new System.Drawing.Size(18, 18);
            this.panel_Close.TabIndex = 0;
            this.panel_Close.Click += new System.EventHandler(this.panel1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::窗体的浮动及隐藏.Properties.Resources._2;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 309);
            this.panel1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(170, 336);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_Title.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Title;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel_Close;
        private System.Windows.Forms.Panel panel1;
    }
}

