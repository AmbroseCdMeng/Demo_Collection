using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace GetClipBoardPicture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int i = 0; //该变量用来表示ImageList中的图片数量

        private void nextSheet_Click(object sender, EventArgs e)
        {
            //激活“上一张”按钮
            previousSheet.Enabled = true;
            //判断是否越界
            if (i <imageList1.Images.Count)
            {
                i++;
                //判断是否浏览到最后一张
                if (i==imageList1.Images.Count-1)
                {
                    nextSheet.Enabled = false;
                }
                //当不越界时
                if (i < 3)
                {
                    pictureBox1.Image = imageList1.Images[i];
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //加载窗体时默认显示ImageList中的第一章图片
            pictureBox1.Image = imageList1.Images[0];
            //加载时“上一张”按钮处于不可用状态
            previousSheet.Enabled = false;
        }

        private void previousSheet_Click(object sender, EventArgs e)
        {
            nextSheet.Enabled = true;
            if (i < imageList1.Images.Count)
            {
                i--;
                if (i == 0)
                {
                    previousSheet.Enabled = false;
                }
                if (i >=0)
                {
                    pictureBox1.Image = imageList1.Images[i];
                }
            }
        }

        private void cut_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(imageList1.Images [i],false );
            MessageBox.Show("剪切成功！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Asterisk );
        }

        private void copy_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Clipboard.GetImage();
            MessageBox.Show("剪切成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
