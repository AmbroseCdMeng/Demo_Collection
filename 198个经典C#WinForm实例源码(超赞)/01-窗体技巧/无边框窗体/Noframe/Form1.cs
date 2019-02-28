using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Noframe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static Point CPoint;
        private void panel_Title_MouseDown(object sender, MouseEventArgs e)
        {
            CPoint = new Point(-e.X, -e.Y);
        }

        private void panel_Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = Control.MousePosition;//获取当前鼠标的屏幕坐标
                myPosittion.Offset(CPoint.X, CPoint.Y);//重载当前鼠标的位置
                this.DesktopLocation = myPosittion;//设置当前窗体在屏幕上的位置
            }
        }

        private void pictureBox_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
