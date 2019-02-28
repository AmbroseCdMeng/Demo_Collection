namespace NoteCatVote
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslinfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始投票ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结束投票ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.投票设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblballot4 = new System.Windows.Forms.Label();
            this.lblballot3 = new System.Windows.Forms.Label();
            this.lblballot2 = new System.Windows.Forms.Label();
            this.lblballot1 = new System.Windows.Forms.Label();
            this.pb4 = new System.Windows.Forms.ProgressBar();
            this.pb3 = new System.Windows.Forms.ProgressBar();
            this.pb2 = new System.Windows.Forms.ProgressBar();
            this.pb1 = new System.Windows.Forms.ProgressBar();
            this.lblUser4 = new System.Windows.Forms.Label();
            this.lblUser3 = new System.Windows.Forms.Label();
            this.lblUser2 = new System.Windows.Forms.Label();
            this.lblUser1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslinfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 272);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(467, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslinfo
            // 
            this.tsslinfo.Name = "tsslinfo";
            this.tsslinfo.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.功能ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(467, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 功能ToolStripMenuItem
            // 
            this.功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始投票ToolStripMenuItem,
            this.结束投票ToolStripMenuItem,
            this.退出系统ToolStripMenuItem});
            this.功能ToolStripMenuItem.Name = "功能ToolStripMenuItem";
            this.功能ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.功能ToolStripMenuItem.Text = "功能";
            // 
            // 开始投票ToolStripMenuItem
            // 
            this.开始投票ToolStripMenuItem.Name = "开始投票ToolStripMenuItem";
            this.开始投票ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.开始投票ToolStripMenuItem.Text = "开始投票";
            this.开始投票ToolStripMenuItem.Click += new System.EventHandler(this.开始投票ToolStripMenuItem_Click);
            // 
            // 结束投票ToolStripMenuItem
            // 
            this.结束投票ToolStripMenuItem.Name = "结束投票ToolStripMenuItem";
            this.结束投票ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.结束投票ToolStripMenuItem.Text = "结束投票";
            this.结束投票ToolStripMenuItem.Click += new System.EventHandler(this.结束投票ToolStripMenuItem_Click);
            // 
            // 退出系统ToolStripMenuItem
            // 
            this.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            this.退出系统ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.退出系统ToolStripMenuItem.Text = "退出系统";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.投票设置ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 投票设置ToolStripMenuItem
            // 
            this.投票设置ToolStripMenuItem.Name = "投票设置ToolStripMenuItem";
            this.投票设置ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.投票设置ToolStripMenuItem.Text = "投票设置";
            this.投票设置ToolStripMenuItem.Click += new System.EventHandler(this.投票设置ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem,
            this.系统信息ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 系统信息ToolStripMenuItem
            // 
            this.系统信息ToolStripMenuItem.Name = "系统信息ToolStripMenuItem";
            this.系统信息ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.系统信息ToolStripMenuItem.Text = "系统信息";
            this.系统信息ToolStripMenuItem.Click += new System.EventHandler(this.系统信息ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(467, 248);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblballot4);
            this.tabPage1.Controls.Add(this.lblballot3);
            this.tabPage1.Controls.Add(this.lblballot2);
            this.tabPage1.Controls.Add(this.lblballot1);
            this.tabPage1.Controls.Add(this.pb4);
            this.tabPage1.Controls.Add(this.pb3);
            this.tabPage1.Controls.Add(this.pb2);
            this.tabPage1.Controls.Add(this.pb1);
            this.tabPage1.Controls.Add(this.lblUser4);
            this.tabPage1.Controls.Add(this.lblUser3);
            this.tabPage1.Controls.Add(this.lblUser2);
            this.tabPage1.Controls.Add(this.lblUser1);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(459, 223);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "投票进行中";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblballot4
            // 
            this.lblballot4.AutoSize = true;
            this.lblballot4.Location = new System.Drawing.Point(337, 147);
            this.lblballot4.Name = "lblballot4";
            this.lblballot4.Size = new System.Drawing.Size(0, 12);
            this.lblballot4.TabIndex = 12;
            // 
            // lblballot3
            // 
            this.lblballot3.AutoSize = true;
            this.lblballot3.Location = new System.Drawing.Point(337, 114);
            this.lblballot3.Name = "lblballot3";
            this.lblballot3.Size = new System.Drawing.Size(0, 12);
            this.lblballot3.TabIndex = 11;
            // 
            // lblballot2
            // 
            this.lblballot2.AutoSize = true;
            this.lblballot2.Location = new System.Drawing.Point(337, 81);
            this.lblballot2.Name = "lblballot2";
            this.lblballot2.Size = new System.Drawing.Size(0, 12);
            this.lblballot2.TabIndex = 10;
            // 
            // lblballot1
            // 
            this.lblballot1.AutoSize = true;
            this.lblballot1.Location = new System.Drawing.Point(337, 51);
            this.lblballot1.Name = "lblballot1";
            this.lblballot1.Size = new System.Drawing.Size(0, 12);
            this.lblballot1.TabIndex = 9;
            // 
            // pb4
            // 
            this.pb4.Location = new System.Drawing.Point(164, 147);
            this.pb4.Name = "pb4";
            this.pb4.Size = new System.Drawing.Size(167, 10);
            this.pb4.TabIndex = 8;
            // 
            // pb3
            // 
            this.pb3.Location = new System.Drawing.Point(164, 114);
            this.pb3.Name = "pb3";
            this.pb3.Size = new System.Drawing.Size(167, 10);
            this.pb3.TabIndex = 7;
            // 
            // pb2
            // 
            this.pb2.Location = new System.Drawing.Point(164, 81);
            this.pb2.Name = "pb2";
            this.pb2.Size = new System.Drawing.Size(167, 10);
            this.pb2.TabIndex = 6;
            // 
            // pb1
            // 
            this.pb1.Location = new System.Drawing.Point(164, 51);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(167, 10);
            this.pb1.TabIndex = 5;
            // 
            // lblUser4
            // 
            this.lblUser4.AutoSize = true;
            this.lblUser4.Location = new System.Drawing.Point(79, 147);
            this.lblUser4.Name = "lblUser4";
            this.lblUser4.Size = new System.Drawing.Size(0, 12);
            this.lblUser4.TabIndex = 4;
            // 
            // lblUser3
            // 
            this.lblUser3.AutoSize = true;
            this.lblUser3.Location = new System.Drawing.Point(79, 112);
            this.lblUser3.Name = "lblUser3";
            this.lblUser3.Size = new System.Drawing.Size(0, 12);
            this.lblUser3.TabIndex = 3;
            // 
            // lblUser2
            // 
            this.lblUser2.AutoSize = true;
            this.lblUser2.Location = new System.Drawing.Point(79, 81);
            this.lblUser2.Name = "lblUser2";
            this.lblUser2.Size = new System.Drawing.Size(0, 12);
            this.lblUser2.TabIndex = 2;
            // 
            // lblUser1
            // 
            this.lblUser1.AutoSize = true;
            this.lblUser1.Location = new System.Drawing.Point(79, 49);
            this.lblUser1.Name = "lblUser1";
            this.lblUser1.Size = new System.Drawing.Size(0, 12);
            this.lblUser1.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(43, 24);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(369, 168);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::NoteCatVote.Properties.Resources.bg;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 248);
            this.panel1.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 294);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "短信猫投票系统[作者：WildWolf]";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始投票ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结束投票ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 投票设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统信息ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ProgressBar pb4;
        private System.Windows.Forms.ProgressBar pb3;
        private System.Windows.Forms.ProgressBar pb2;
        private System.Windows.Forms.ProgressBar pb1;
        private System.Windows.Forms.Label lblUser4;
        private System.Windows.Forms.Label lblUser3;
        private System.Windows.Forms.Label lblUser2;
        private System.Windows.Forms.Label lblUser1;
        private System.Windows.Forms.Label lblballot4;
        private System.Windows.Forms.Label lblballot3;
        private System.Windows.Forms.Label lblballot2;
        private System.Windows.Forms.Label lblballot1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel tsslinfo;
    }
}

