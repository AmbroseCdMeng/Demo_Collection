using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace drawLine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap bt = new Bitmap(pictureBox1.Image);
                Graphics g = Graphics.FromImage(bt);
                g.DrawLine(new Pen(Color.Red, 40), new Point(0,bt.Height/2), new Point(bt.Width,bt.Height/2));
                g.DrawLine(new Pen(Color.Red, 40), new Point(bt.Width/2,0), new Point(bt.Width/2, bt.Height));
                g.DrawLine(new Pen(Color.Red, 40), new Point(0, 0), new Point(bt.Width, bt.Height));
                g.DrawLine(new Pen(Color.Red, 40), new Point(0,bt.Height), new Point(bt.Width,0));
                pictureBox1.Image = bt;
            }
        }
    }
}
