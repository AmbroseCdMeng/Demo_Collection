using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 像Excel一样复制DataGridView中的单元格区域数据
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
