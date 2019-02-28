using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace ImageDate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static PropertyItem[] GetExif(string fileName)
        {
            FileStream Mystream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            //通过指定的数据流来创建Image
            Image image = Image.FromStream(Mystream, true, false);
            return image.PropertyItems;
        }
        private string GetDateTime(System.Drawing.Imaging.PropertyItem[] parr)
        {
            Encoding ascii = Encoding.ASCII;
            //遍历图像文件元数据，检索所有属性
            foreach (PropertyItem pp in parr)
            {
                //如果是PropertyTagDateTime，则返回该属性所对应的值
                if (pp.Id == 0x0132)
                {
                    return ascii.GetString(pp.Value);
                }
            }
            //若没有相关的EXIF信息则返回N/A
            return "N/A";
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = GetDateTime(GetExif(openFileDialog1.FileName));
            }
        }
    }
}
