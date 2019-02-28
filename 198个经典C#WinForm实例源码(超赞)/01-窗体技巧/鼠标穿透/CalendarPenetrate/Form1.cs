using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CalendarPenetrate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Point CPoint;
        private void monthCalendar1_MouseDown(object sender, MouseEventArgs e)
        {
            CPoint = new Point(-e.X, -e.Y);
        }

        private void monthCalendar1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = Control.MousePosition;//获取当前鼠标的屏幕坐标
                myPosittion.Offset(CPoint.X, CPoint.Y);//重载当前鼠标的位置
                this.DesktopLocation = myPosittion;//设置当前窗体在屏幕上的位置
            }
        }

        private const uint WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_EXSTYLE = (-20);
        private string Var_genre = "";//记录当前操作的类型

        #region 在窗口结构中为指定的窗口设置信息
        /// <summary>
        /// 在窗口结构中为指定的窗口设置信息
        /// </summary>
        /// <param name="hwnd">欲为其取得信息的窗口的句柄</param>
        /// <param name="nIndex">欲取回的信息</param>
        /// <param name="dwNewLong">由nIndex指定的窗口信息的新值</param>
        /// <returns></returns>
        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);
        #endregion

        #region 从指定窗口的结构中取得信息
        /// <summary>
        /// 从指定窗口的结构中取得信息
        /// </summary>
        /// <param name="hwnd">欲为其获取信息的窗口的句柄</param>
        /// <param name="nIndex">欲取回的信息</param>
        /// <returns></returns>
        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(IntPtr hwnd, int nIndex);
        #endregion

        #region 使窗口有鼠标穿透功能
        /// <summary>
        /// 使窗口有鼠标穿透功能
        /// </summary>
        private void CanPenetrate()
        {
            uint intExTemp = GetWindowLong(this.Handle, GWL_EXSTYLE);
            uint oldGWLEx = SetWindowLong(this.Handle, GWL_EXSTYLE, WS_EX_TRANSPARENT | WS_EX_LAYERED);
        }
        #endregion

        private void ToolS_P_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.7;
            CanPenetrate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;//窗体不出现在Windows任务栏中
            this.TopMost = true;//使窗体始终在其它窗体之上
        }

        private void ToolS_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
