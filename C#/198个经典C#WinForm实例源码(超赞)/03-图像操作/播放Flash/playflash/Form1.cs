using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace playflash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        AxShockwaveFlashObjects.AxShockwaveFlash ax;

        private void AddFlash()
        {
            ax = new AxShockwaveFlashObjects.AxShockwaveFlash();
            panel1.Controls.Add(ax);
            ax.Dock = DockStyle.Fill;
            ax.ScaleMode = 1;
            ax.Stop();
        }

        private void ControlState(int i)
        {
            if (i == 0)
            {
                播放ToolStripMenuItem.Enabled = false;
                第一帧ToolStripMenuItem.Enabled = false;
                向前ToolStripMenuItem.Enabled = false;
                向后ToolStripMenuItem.Enabled = false;
            }
            else
            {
                播放ToolStripMenuItem.Enabled = true;
                第一帧ToolStripMenuItem.Enabled = true;
                向前ToolStripMenuItem.Enabled = true;
                向后ToolStripMenuItem.Enabled = true;
            }
        }


        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ax.Visible = true;
                string flashPath = openFileDialog1.FileName;
                ax.Movie = flashPath;
                panel1.Visible = true;
                ControlState(1);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddFlash();
            ax.Visible = false;
            ControlState(0);
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ax.Dispose();
            AddFlash();
            ControlState(0);
            ax.Stop();
            ax.Visible = false;
        }

        private void 向前ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ax.Back();
        }

        private void 向后ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ax.Forward();
        }

        private void 关于Flash播放器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void 第一帧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ax.Rewind();
        }

        private void 播放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (播放ToolStripMenuItem.CheckState  == CheckState.Checked)
            {
                播放ToolStripMenuItem.CheckState = CheckState.Unchecked;
                ax.Stop();
            }
            else
            {
                播放ToolStripMenuItem.CheckState = CheckState.Checked;
                ax.Play();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ax.Playing == true)
            {
                播放ToolStripMenuItem.CheckState = CheckState.Checked;
            }
            else
            {
                播放ToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Size  s=new Size(423,386);
            if (this.Size == s)
            {
                panel1.Visible = true;
            }
            else
            {
                if (ax.Playing == false)
                {
                    this.BackColor = Color.Black;
                    panel1.Visible = false;
                }
            }
        }
    }
}                                                                                                                                                                                                                                                                   
