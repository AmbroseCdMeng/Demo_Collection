using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace 仿XP系统的任务栏菜单
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static Panel Var_Panel = new Panel();
        private static PictureBox Var_Pict = new PictureBox();
        private static int Var_i = 0;
        private Font Var_Font = new Font("宋体", 9); 

        private void pictureBox_1_Click(object sender, EventArgs e)
        {
            Var_i = Convert.ToInt16(((PictureBox)sender).Tag.ToString());
            switch (Var_i)
            {
                case 1:
                    {
                        Var_Panel = panel_Gut_1;
                        Var_Pict = pictureBox_1;
                        break;
                    }
                case 2:
                    {
                        Var_Panel = panel_Gut_2;
                        Var_Pict = pictureBox_2;
                        break;
                    }
                case 3:
                    {
                        Var_Panel = panel_Gut_3;
                        Var_Pict = pictureBox_3;
                        break;
                    }

            }
            if (Convert.ToInt16(Var_Panel.Tag.ToString()) == 0 || Convert.ToInt16(Var_Panel.Tag.ToString()) == 2)
            {
                Var_Panel.Tag = 1;//隐藏标识
                Var_Pict.Image = null;
                Var_Pict.Image = Properties.Resources.朝下按钮;
                Var_Panel.Visible = false;
            }
            else
            {
                if (Convert.ToInt16(Var_Panel.Tag.ToString()) == 1)
                {
                    Var_Panel.Tag = 2;//显示标识
                    Var_Pict.Image = null;
                    Var_Pict.Image = Properties.Resources.朝上按钮;
                    Var_Panel.Visible = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox_1.Image = null;
            pictureBox_1.Image = Properties.Resources.朝上按钮;
            pictureBox_2.Image = null;
            pictureBox_2.Image = Properties.Resources.朝上按钮;
            pictureBox_3.Image = null;
            pictureBox_3.Image = Properties.Resources.朝上按钮;
            Var_Font = label_1.Font;
        }

        private void label_1_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Gray;
            ((Label)sender).Font = new Font(Var_Font, Var_Font.Style | FontStyle.Underline);
        }

        private void label_1_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Black;
            ((Label)sender).Font = new Font(Var_Font, Var_Font.Style);
        }
    }
}
