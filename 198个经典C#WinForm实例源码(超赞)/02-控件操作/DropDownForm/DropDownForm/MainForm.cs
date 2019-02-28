using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DropDownForm
{
    public partial class DropDownForm :System.Windows.Forms.Form
    {
        #region 声明的变量
        private System.Drawing.Rectangle Rect;//定义一个存储矩形框的数组
        private FormState InfoStyle = FormState.Hide;//定义变量为隐藏
        static private DropDownForm dropDownForm = new DropDownForm();//实例化当前窗体
        private static int AW_HIDE = 0x00010000;
        private static int AW_SLIDE = 0x00040000;
        private static int AW_VER_NEGATIVE = 0x00000008;
        #endregion

        #region 该窗体的构造方法
        public DropDownForm()
        {
            InitializeComponent();
            //初始化工作区大小
            System.Drawing.Rectangle rect = System.Windows.Forms.Screen.GetWorkingArea(this);
            this.Rect = new System.Drawing.Rectangle(rect.Right - this.Width - 1, rect.Bottom - this.Height - 1, this.Width, this.Height);
        }
        #endregion

        #region 调用API函数显示窗体
        [DllImportAttribute("user32.dll")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        #endregion

        #region 鼠标控制图片的变化
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            for (int i = 0; i < imageList1.Images.Count; i++)
            {
                if (i == 1)
                    pictureBox1.Image = imageList1.Images[i];
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < imageList1.Images.Count; i++)
            {
                if (i == 0)
                    pictureBox1.Image = imageList1.Images[i];
            }
        }
        #endregion

        #region 定义标识窗体移动状态的枚举值
        protected enum FormState
        {
            //隐藏窗体
            Hide=0,
            //显示窗体
            Display=1,
            //显示窗体中
            Displaying=2,
            //隐藏窗体中
            Hiding=3
        }
        #endregion

        #region 用属性标识当前状态
        protected FormState FormNowState
        {
            get { return this.InfoStyle; }
            set { this.InfoStyle = value; }
        }
        #endregion

        #region 显示窗体
        public  void ShowForm()
        {
            switch (this.FormNowState)
            {
                case FormState.Hide:
                    if (this.Height <= this.Rect.Height - 192)//当窗体没有完全显示时
                        this.SetBounds(Rect.X, this.Top - 192, Rect.Width, this.Height + 192);//使窗体不断上移
                    else
                    {
                        this.SetBounds(Rect.X, Rect.Y, Rect.Width, Rect.Height);//设置当前窗体的边界
                        this.FormNowState = FormState.Display;//设置当前窗体的操作状态为显示
                    }
                    AnimateWindow(this.Handle, 800, AW_SLIDE + AW_VER_NEGATIVE);//动态显示本窗体
                    break;
            }
        }
        #endregion

        #region 关闭窗体
        public void CloseForm()
        {
            switch (this.FormNowState)
            {
                case FormState.Display://显示当前窗体
                    if (this.Top <= this.Rect.Bottom - 192)//如果窗体没有完全隐藏
                    {
                        this.SetBounds(Rect.X, this.Top + 192, Rect.Width, this.Height - 192);//使窗体不断下移
                    }
                    else
                    {
                        this.Close();//隐藏当前窗体
                        this.FormNowState = FormState.Hide;//设置窗体的操作状态为隐藏
                    }
                    break;
            }
        }
        #endregion

        #region 返回当前窗体的实例化对象
        static public DropDownForm Instance()
        {
            return dropDownForm;
        }
        #endregion

        #region 在窗体的关闭事件中进行动态关闭
        private void DropDownForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            AnimateWindow(this.Handle, 800, AW_SLIDE + AW_VER_NEGATIVE + AW_HIDE);
            this.Close();
        }
        #endregion
    }
}
