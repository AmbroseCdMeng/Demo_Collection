using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace OutLookMail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 查找与指定文件关联在一起的程序的文件名
        /// <summary>
        /// 查找与指定文件关联在一起的程序的文件名
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="lpOperation">指定字串“open”来打开lpFlie文档，或指定“Print”来打印它</param>
        /// <param name="lpFile">想用关联程序打印或打开一个程序名或文件名</param>
        /// <param name="lpParameters">如lpszFlie是可执行文件，则这个字串包含传递给执行程序的参数</param>
        /// <param name="lpDirectory">想使用的完整路径</param>
        /// <param name="nShowCmd">定义了如何显示启动程序的常数值</param>
        /// <returns>非零表示成功，零表示失败</returns>
        [DllImport("shell32.dll", EntryPoint = "ShellExecuteA")]
        public static extern int ShellExecute(
         IntPtr hwnd,
         String lpOperation,
         String lpFile,
         String lpParameters,
         String lpDirectory,
         int nShowCmd
         );
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (Regex.IsMatch(textBox1.Text, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
                    ShellExecute(this.Handle, String.Empty, "mailto:" + textBox1.Text, String.Empty, String.Empty, 1);
                else
                {
                    MessageBox.Show("请输入正确的邮箱格式");
                    textBox1.Text = string.Empty;
                }
            }
        }
    }
}
