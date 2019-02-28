using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 自定义窗体的最大化_最小化和关闭按钮
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = Properties.Resources.登录界面标题.Width;
            this.Height = Properties.Resources.登录界面标题.Height + Properties.Resources.登录界面下面.Height;
            panel_Title.BackgroundImage = Properties.Resources.登录界面标题;
            panel_ALL.BackgroundImage = Properties.Resources.登录界面下面;
            pictureBox_Min.Image = null;
            pictureBox_Min.Image = Properties.Resources.最小化按钮;
            pictureBox_Max.Image = null;
            pictureBox_Max.Image = Properties.Resources.最大化按钮;
            pictureBox_Close.Image = null;
            pictureBox_Close.Image = Properties.Resources.关闭按钮;
        }

        #region  设置窗体的最大化、最小化和关闭按钮的单击事件
        /// <summary>
        /// 设置窗体的最大化、最小化和关闭按钮的单击事件
        /// </summary>
        /// <param Frm_Tem="Form">窗体</param>
        /// <param n="int">标识</param>
        public void FrmClickMeans(Form Frm_Tem, int n)
        {
            switch (n)
            {
                case 0:
                    Frm_Tem.WindowState = FormWindowState.Minimized;
                    break;
                case 1:
                    {
                        if (Frm_Tem.WindowState == FormWindowState.Maximized)
                            Frm_Tem.WindowState = FormWindowState.Normal;
                        else
                            Frm_Tem.WindowState = FormWindowState.Maximized;
                        break;
                    }
                case 2:
                    Frm_Tem.Close();
                    break;
            }
        }
        #endregion

        #region  控制图片的切换状态
        /// <summary>
        /// 控制图片的切换状态
        /// </summary>
        /// <param Frm_Tem="Form">要改变图片的对象</param>
        /// <param n="int">标识</param>
        /// <param ns="int">移出移入标识</param>
        public static PictureBox Tem_PictB = new PictureBox();
        public void ImageSwitch(object sender, int n, int ns)
        {
            Tem_PictB = (PictureBox)sender;

            switch (n)
            {
                case 0:
                    {
                        Tem_PictB.Image = null;
                        if (ns == 0)
                            Tem_PictB.Image = Properties.Resources.最小化变色;
                        if (ns == 1)
                            Tem_PictB.Image = Properties.Resources.最小化按钮;
                        break;
                    }
                case 1:
                    {
                        Tem_PictB.Image = null;
                        if (ns == 0)
                            Tem_PictB.Image = Properties.Resources.最大化变色;
                        if (ns == 1)
                            Tem_PictB.Image = Properties.Resources.最大化按钮;
                        break;
                    }
                case 2:
                    {
                        Tem_PictB.Image = null;
                        if (ns == 0)
                            Tem_PictB.Image = Properties.Resources.关闭变色;
                        if (ns == 1)
                            Tem_PictB.Image = Properties.Resources.关闭按钮;
                        break;
                    }
            }
        }
        #endregion

        private void pictureBox_Close_Click(object sender, EventArgs e)
        {
            FrmClickMeans(this, Convert.ToInt16(((PictureBox)sender).Tag.ToString()));
        }

        private void pictureBox_Close_MouseEnter(object sender, EventArgs e)
        {
            ImageSwitch(sender, Convert.ToInt16(((PictureBox)sender).Tag.ToString()), 0);
        }

        private void pictureBox_Close_MouseLeave(object sender, EventArgs e)
        {
            ImageSwitch(sender, Convert.ToInt16(((PictureBox)sender).Tag.ToString()), 1);
        }


    }
}
