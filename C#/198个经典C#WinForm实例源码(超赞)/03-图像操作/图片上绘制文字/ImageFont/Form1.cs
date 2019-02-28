using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageFont
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 && pictureBox1.Image != null)
            {
                Bitmap bt = new Bitmap(pictureBox1.Image);
                string myfont = textBox1.Text.Trim();
                Graphics g = Graphics.FromImage(bt);
                g.DrawString(textBox1.Text.Trim(), new Font("宋体", 50), new SolidBrush(Color.Red), new PointF(10,10));
                pictureBox1.Image = bt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}
