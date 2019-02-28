using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 自定义窗体的最大化_最小化和关闭按钮
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
