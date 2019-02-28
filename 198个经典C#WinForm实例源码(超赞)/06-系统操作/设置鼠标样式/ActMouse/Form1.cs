using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ActMouse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr LoadCursorFromFile(string fileName);

        [DllImport("user32", EntryPoint = "LoadCursorFromFile")]
        public static extern int IntLoadCursorFromFile(string lpFileName);

        [DllImport("user32", EntryPoint = "SetSystemCursor")]
        public static extern void SetSystemCursor(int hcur, int i);

        const int OCR_NORAAC = 32512;//标准
        private void button1_Click(object sender, EventArgs e)
        {
            //将要修改的标鼠图片存入到系统的WINDOWS\Cursors目录下
            //设置正常选择鼠标
            int cur = IntLoadCursorFromFile(@"C:\WINDOWS\Cursors\mouse.ani");
            SetSystemCursor(cur, OCR_NORAAC);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //恢复正常选择鼠标
            int cur = IntLoadCursorFromFile(@"C:\WINDOWS\Cursors\arrow_m.cur");
            SetSystemCursor(cur, OCR_NORAAC);
        }
    }
}
