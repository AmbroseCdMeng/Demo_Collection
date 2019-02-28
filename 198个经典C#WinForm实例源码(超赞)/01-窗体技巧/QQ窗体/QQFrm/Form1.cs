using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace QQFrm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region  公共变量
        IntPtr Tem_Handle;//获取控件及窗体的句柄
        Point CPoint;//获取控件中鼠标的坐标
        static int Tem_place = 0;
        int Frm_Height = 0;
        int FrmHeight = 0;

        #endregion

        #region  API声明
        //获取当前鼠标下可视化控件的句柄
        [DllImport("user32.dll")]
        public static extern int WindowFromPoint(int xPoint, int yPoint);
        //获取指定句柄的父级句柄
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        //获取屏幕的大小
        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        private static extern int GetSystemMetrics(int mVal);
        #endregion

        #region  获取当前鼠标下可视化控件的句柄
        /// <summary>
        /// 获取当前鼠标下可视化控件的句柄
        /// </summary>
        /// <param x="int">当前鼠标的X坐标</param>
        /// <param y="int">当前鼠标的Y坐标</param>
        public IntPtr FormNameAt(int x, int y)
        {
            IntPtr Tem_hWnd;//设置存储句柄的变量
            Tem_Handle = (IntPtr)(WindowFromPoint(x, y));//获取当前鼠标下可视化控件的句柄
            Tem_hWnd = Tem_Handle;//记录原始句柄
            while (Tem_hWnd != ((IntPtr)0))//遍历该句柄的父级句柄
            {
                Tem_Handle = Tem_hWnd;//记录当前句柄
                Tem_hWnd = GetParent(Tem_hWnd);//获取父级句柄
            }
            return Tem_Handle;//返回最底层的父级句柄
        }
        #endregion


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Top < 3 && Tem_place==0)//如果窗体被移到屏幕的顶部
                {
                    if (this.Handle == FormNameAt(Cursor.Position.X, Cursor.Position.Y))//当鼠标移致到该窗体上
                    {
                        panel_Title.Tag = 1;//设置标识，用于判断窗体在屏幕顶部
                        timer2.Enabled = false;//不对窗体进行拉伸操作
                        this.Top = 0;//使窗体致顶
                    }
                    else
                    {
                        panel_Title.Tag = 1;//设置标识，用于判断窗体在屏幕顶部
                        timer2.Enabled = true;//将窗体在顶部进行隐藏
                    }
                }
                else
                {
                    if (this.Left < 3 || this.Right > GetSystemMetrics(0) - 3)//如果窗体被移到屏幕的左端或右端
                    {
                        if (this.Left < 3)//如果窗体被移到屏幕的左端
                        {
                            if (this.Handle == FormNameAt(Cursor.Position.X, Cursor.Position.Y))//当鼠标移致到该窗体上
                            {
                                panel_Title.Tag = 2;//设置标识，用于判断窗体在屏幕左端
                                timer2.Enabled = false;
                                Frm_Height = this.Height;
                                this.Left = 0;//使窗体致左
                                this.Top = 0;
                                this.Height = Screen.AllScreens[0].Bounds.Height;
                                Tem_place = 1;
                            }
                            else
                            {
                                panel_Title.Tag = 2;
                                timer2.Enabled = true;//将窗体在左端进行隐藏
                            }
                        }
                        if (this.Right > GetSystemMetrics(0) - 3)//如果窗体被移到屏幕的右端
                        {
                            if (this.Handle == FormNameAt(Cursor.Position.X, Cursor.Position.Y))//当鼠标移致到该窗体上
                            {
                                panel_Title.Tag = 3;//设置标识，用于判断窗体在屏幕右端
                                timer2.Enabled = false;
                                Frm_Height = this.Height;
                                this.Left = GetSystemMetrics(0) - this.Width;//使窗体致右
                                this.Top = 0;
                                this.Height = Screen.AllScreens[0].Bounds.Height;
                                Tem_place = 1;
                            }
                            else
                            {
                                panel_Title.Tag = 3;
                                timer2.Enabled = true;//将窗体在右端进行隐藏
                            }
                        }

                    }
                }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            switch (Convert.ToInt16(panel_Title.Tag.ToString()))//对标识进行判断
            {
                case 1://顶端隐藏
                    {
                        if (this.Top < 5)
                            this.Top = -(this.Height - 2);
                        break;
                    }
                case 2://左端隐藏
                    {
                        if (this.Left < 5)
                            this.Left = -(this.Width - 2);
                        break;
                    }
                case 3://右端隐藏
                    {
                        if ((this.Left + this.Width) > (GetSystemMetrics(0) - 5))
                            this.Left = GetSystemMetrics(0) - 2;
                        break;
                    }
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region  利用窗体上的控件移动窗体
        /// <summary>
        /// 利用控件移动窗体
        /// </summary>
        /// <param Frm="Form">窗体</param>
        /// <param e="MouseEventArgs">控件的移动事件</param>
        public void FrmMove(Form Frm, MouseEventArgs e)  //Form或MouseEventArgs添加命名空间using System.Windows.Forms;
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = Control.MousePosition;//获取当前鼠标的屏幕坐标
                myPosittion.Offset(CPoint.X, CPoint.Y);//重载当前鼠标的位置
                Frm.DesktopLocation = myPosittion;//设置当前窗体在屏幕上的位置
                Tem_place = 0;
                this.Height = FrmHeight;
            }
        }
        #endregion

        private void panel_Title_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
            CPoint = new Point(-e.X, -e.Y);
        }

        private void panel_Title_MouseMove(object sender, MouseEventArgs e)
        {
            FrmMove(this, e);
        }

        private void panel_Title_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Frm_Height = this.Height;
            FrmHeight = this.Height;
            this.TopMost = true;
        }
    }
}
