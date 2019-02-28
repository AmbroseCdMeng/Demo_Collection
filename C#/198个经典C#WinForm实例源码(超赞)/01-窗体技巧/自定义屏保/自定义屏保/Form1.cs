using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 自定义屏保
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Control FrmContainer = new Control();//实例化Control类
        bool isbool = true;//是否开启了屏保
        int fontSize = 0;//字休大小
        public Point mouse = new Point(0, 0);//记录鼠标的位置

        private void button1_Click(object sender, EventArgs e)
        {
            preview();//对预览进行初始化
        }

        /// <summary>
        /// 对预览进行初始化
        /// </summary>
        public void preview()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;//使窗体有边框
            this.WindowState = FormWindowState.Normal;//使窗体恢复默认大小
            this.BackColor = Color.Gainsboro;//设设置窗体的背景颜色
            panel1.Visible = true;//显示该控件
            multimedia(panel1);//设置窗体中各控件的样式
            timer1.Start();//启动计时器
        }

        /// <summary>
        /// 隐藏或显示Label类的控件
        /// </summary>
        /// <param n ="bool">要改变图片的对象</param>
        public void LabelVisible(bool n)
        {
            label1.Visible = n;//隐藏或显示该控件
            label2.Visible = n;
            label3.Visible = n;
            label4.Visible = n;
        }

        /// <summary>
        /// 在显示预览和屏保前，对窗体中的各控件进行设置
        /// </summary>
        /// <param panel ="Control">设置父级控件</param>
        public void multimedia(Control panel)
        {
            LabelVisible(true);//显示要移动的文本
            if (panel.Name == "form1")//如果父级窗体是当前窗体
            {
                isbool = false;//隐藏
                fontSize = 20;//设置字体大小
            }
            else
            {
                isbool = true;//显示
                fontSize = 10;//设置字体大小
            }
            label1.Text = "字幕滚动";//设置文本
            label1.Parent = panel;//设置父级控件
            label1.Font = new Font("宋体", fontSize, FontStyle.Bold);//设置字体样式
            label2.Parent = panel;//设置父级控件
            label2.Text = "字" + "\n" + "幕" + "\n" + "滚" + "\n" + "动";//设置纵向文本
            label2.Font = new Font("宋体", fontSize, FontStyle.Bold);//设置字体样式
            label3.Text = "动滚幕字";//设置文本
            label3.Parent = panel;//设置父级控件
            label3.Font = new Font("宋体", fontSize, FontStyle.Bold);//设置字体样式
            label4.Text = "动" + "\n" + "滚" + "\n" + "幕" + "\n" + "字";//设置纵向文本
            label4.Parent = panel;//设置父级控件
            label4.Font = new Font("宋体", fontSize, FontStyle.Bold);//设置字体样式
            panel.Visible = isbool;//隐藏或显示
            button1.Visible = isbool;//隐藏或显示
            button2.Visible = isbool;//隐藏或显示
            label1.Top = panel.Height / 4;//设置当前控件的显示位置
            label3.Top = (panel.Height / 4) * 3;//设置当前控件的显示位置
            label3.Left = 0 - label2.Width;//设置当前控件的显示位置
            label4.Left = (panel.Width / 4) * 3;//设置当前控件的显示位置
            label4.Top = 0 - label2.Height;//设置当前控件的显示位置
            label2.Left = panel.Width / 4;//设置当前控件的显示位置
            FrmContainer = panel;//记录父级控件
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //文字从右到左滚动
            label1.Left = label1.Left - 2;//向左移动
            if ((label1.Left + label1.Width) < 1)//当超出左边界时
                label1.Left = FrmContainer.Width;//在右边出现
            //文字从下到上滚动
            label2.Top = label2.Top - 1;//向上移动
            if ((label2.Top + label2.Height) < 1)//当超出上边界时
                label2.Top = FrmContainer.Height;//在下边出现
            //文字从左到右滚动
            if (label3.Left > FrmContainer.Width)//如果超出右边界
                label3.Left = 0 - label2.Width;//在左边出现
            else
                label3.Left = label3.Left + 2;//向右移动
            //文字从上到下滚动
            if (label4.Top > FrmContainer.Height)//如果超出下边界
                label4.Top = 0 - label4.Height;//在上边出现
            else
                label4.Top = label4.Top + 1;//向下移动
            //如果在屏保情况下，鼠标移动
            if ((mouse.X != Control.MousePosition.X || mouse.Y != Control.MousePosition.Y) && panel1.Visible == false)
                preview();//恢复预览状态
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;//窗体无边框
            this.WindowState = FormWindowState.Maximized;//窗体最大化
            this.BackColor = Color.Black;//设置窗体背景为黑色
            multimedia(this);//设置窗体中各控件的样式
            timer1.Start();//启动计时器
            button1.Visible = false;//隐藏
            button2.Visible = false;//隐藏
            panel1.Visible = false;//隐藏
            mouse = Control.MousePosition;//获取鼠标的屏幕坐标
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LabelVisible(false);//隐藏要移动的文本
        }
    }
}
