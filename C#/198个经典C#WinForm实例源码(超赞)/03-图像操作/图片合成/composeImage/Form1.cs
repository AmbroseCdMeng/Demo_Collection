using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace composeImage
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
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(openFileDialog2.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null && pictureBox2.Image != null)
            {
                Bitmap bt = new Bitmap(pictureBox1.Image);
                Graphics g = Graphics.FromImage(bt);
                g.DrawImage(pictureBox2.Image,new Point(5,5));
                pictureBox3.Image = bt;
            }
        }
    }
}
