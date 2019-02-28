using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImgType
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string imgpath;
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Text = "图片路径："+openFileDialog1.FileName;
                imgpath = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bt = new Bitmap(imgpath);
                bt.Save("c:\\1.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                MessageBox.Show("格式转换成功");
            }
            catch { }
        }
    }
}
