using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NoteCatVote
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void 投票设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void 系统信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("MSINFO32.EXE");
        }

        private void 开始投票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            开始投票ToolStripMenuItem.Enabled = false;
            tsslinfo.Text = "投票正在进行中......";
            timer1.Start();
            tabControl1.Visible = true;
            DataClass.GetVote(lblUser1, lblUser2, lblUser3, lblUser4, pb1, pb2, pb3, pb4, lblballot1, lblballot2, lblballot3, lblballot4);
        }

        private void 结束投票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            开始投票ToolStripMenuItem.Enabled = true;
            tsslinfo.Text = "";
            timer1.Stop();
            tabControl1.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataClass.GetVote(lblUser1, lblUser2, lblUser3, lblUser4, pb1, pb2, pb3, pb4, lblballot1, lblballot2, lblballot3, lblballot4);
            DataClass.InceptNote();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }
    }
}
