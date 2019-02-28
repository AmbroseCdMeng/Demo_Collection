using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HideKit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region  公共变量
        IntPtr Tem_Handle;//获取控件及窗体的句柄
        bool Tem_show = false;
        #endregion

        #region  API声明
        //获取当前鼠标下可视化控件的句柄
        [DllImport("user32.dll")]
        public static extern int WindowFromPoint(int xPoint, int yPoint);
        //获取指定句柄的父级句柄
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            KitInitialization(panel1);
        }

        public void KitInitialization(Panel Pane)
        {
            Pane.Left = -Pane.Width + 3;
            Pane.Top = 0;
            Pane.Height = this.Height-35;
        }

        #region  获取当前鼠标下可视化控件的句柄
        /// <summary>
        /// 获取当前鼠标下可视化控件的句柄
        /// </summary>
        /// <param x="int">当前鼠标的X坐标</param>
        /// <param y="int">当前鼠标的Y坐标</param>
        public IntPtr FormNameAt(int x, int y, Panel P)
        {
            IntPtr Tem_hWnd;//设置存储句柄的变量
            Tem_Handle = (IntPtr)(WindowFromPoint(x, y));//获取当前鼠标下可视化控件的句柄
            Tem_hWnd = Tem_Handle;//记录原始句柄
            while (Tem_hWnd != P.Handle)//遍历该句柄的父级句柄
            {
                if (Tem_hWnd == this.Handle || Tem_hWnd == ((IntPtr)0))
                    break;
                Tem_Handle = Tem_hWnd;//记录当前句柄
                Tem_hWnd = GetParent(Tem_hWnd);//获取父级句柄
            }
            return Tem_hWnd;//返回最底层的父级句柄
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (panel1.Handle == FormNameAt(Cursor.Position.X, Cursor.Position.Y, panel1))//当鼠标移致到该窗体上
            {
                timer2.Stop();
                panel1.Left = 0;
                Tem_show = true;
            }
            else
            {

                Tem_show = false;
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!Tem_show)
            {
                KitInitialization(panel1);
                timer2.Stop();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Tem_show = false;
            KitInitialization(panel1);
            timer2.Stop();
        }
    }
}
