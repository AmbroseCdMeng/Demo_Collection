using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vista风格的日历
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Point CPoint;
        private void dateTimeControl1_MouseDown(object sender, MouseEventArgs e)
        {
            CPoint = new Point(-e.X, -e.Y);
        }

        private void dateTimeControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = Control.MousePosition;//获取当前鼠标的屏幕坐标
                myPosittion.Offset(CPoint.X, CPoint.Y);//重载当前鼠标的位置
                this.DesktopLocation = myPosittion;//设置当前窗体在屏幕上的位置
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimeControl1.Date = DateTime.Now.Date;
        }

        MonthCalendar MonthC = new MonthCalendar();

        private void ToolS_UPday_Click(object sender, EventArgs e)
        {
            int tem_Day = 0;
            int tem_Month = 0;
            int tem_Year = 0;
            MonthC.TodayDate = dateTimeControl1.Date;
            tem_Day = dateTimeControl1.Date.Day;
            tem_Month = dateTimeControl1.Date.Month;
            tem_Year = dateTimeControl1.Date.Year;
            switch (Convert.ToInt32(((ToolStripMenuItem)sender).Tag.ToString()))
            {
                case 1: SetDate(MonthC, tem_Year, tem_Month, tem_Day - 1, 2); break;
                case 2: SetDate(MonthC, tem_Year, tem_Month, tem_Day + 1, 2); break;
                case 3: SetDate(MonthC, tem_Year, tem_Month - 1, tem_Day, 1); break;
                case 4: SetDate(MonthC, tem_Year, tem_Month + 1, tem_Day, 1); break;
                case 5: SetDate(MonthC, tem_Year - 1, tem_Month, tem_Day, 0); break;
                case 6: SetDate(MonthC, tem_Year + 1, tem_Month, tem_Day, 0); break;
                case 7: Close(); break;
            }
            dateTimeControl1.Date = MonthC.TodayDate;
        }

        public void SetDate(MonthCalendar MC, int y, int m, int d,int ymd)
        {
            int tem_y = y;
            int tem_m = m;
            int tem_d = d;
            if (tem_d == 0)
            {
                tem_m -= 1;
                m -= 1;
                tem_d = 33;
                ymd = 1;
            }
            if (tem_m == 0)
                tem_m = 12;
            if (tem_m == 13)
                tem_m = 1;
            switch (tem_m)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    {
                        if (tem_d > 31)
                        {
                            if (ymd == 2)
                            {
                                tem_d = 1;
                                tem_m += 1;
                            }
                            if (ymd == 1)
                                tem_d = 31;
                        }
                        break;
                    }
                case 2:
                    {
                        if (Convert.ToInt32(dateTimeControl1.Tag.ToString()) == 1)
                        {
                            if (tem_d > 29)
                            {
                                if (ymd == 2)
                                {
                                    tem_d = 1;
                                    tem_m += 1;
                                }
                                if (ymd == 1)
                                    tem_d = 29;
                            }
                        }
                        else
                        {
                            if (tem_d > 28)
                            {
                                if (ymd == 2)
                                {
                                    tem_d = 1;
                                    tem_m += 1;
                                }
                                if (ymd == 1)
                                    tem_d = 28;
                            }
                        }
                        break;
                    }
                case 4:
                case 6:
                case 9:
                case 11:
                    {
                        if (tem_d > 30)
                        {
                            if (ymd == 2)
                            {
                                tem_d = 1;
                                tem_m += 1;
                            }
                            if (ymd == 1)
                                tem_d = 30;
                        }
                        break;
                    }
            }
            if (m == 0)
            {
                tem_m = 12;
                tem_y = tem_y - 1;
            }
            if (m == 13)
            {
                tem_m = 1;
                tem_y = tem_y + 1;
            }
            try
            {
                MC.TodayDate = Convert.ToDateTime(tem_y.ToString() + "-" + tem_m.ToString() + "-" + tem_d.ToString());
            }
            catch
            {
                MC.TodayDate = Convert.ToDateTime(y.ToString() + "-" + m.ToString() + "-" + "28");
            }
        }
    }
}
