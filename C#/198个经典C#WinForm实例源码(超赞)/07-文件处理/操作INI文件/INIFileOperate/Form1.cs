using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace INIFileOperate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region 变量声明区
        public string str = "";//该变量保存INI文件所在的具体物理位置
        public string strOne = "";
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFileName);

        public string ContentReader(string area, string key, string def)
        {
            StringBuilder stringBuilder = new StringBuilder(1024);
            GetPrivateProfileString(area, key, def, stringBuilder, 1024, str);
            return stringBuilder.ToString();
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(
            string mpAppName,
            string mpKeyName,
            string mpDefault,
            string mpFileName);

        #endregion

        #region 窗体加载部分
        private void Form1_Load(object sender, EventArgs e)
        {
            #region 判断是否存在INI文件，如果存在就显示
            str = Application.StartupPath +"\\ConnectString.ini";
            //此方法也可通过：str = System.AppDomain.CurrentDomain.BaseDirectory + @"ConnectString.ini";
            strOne = System.IO.Path.GetFileNameWithoutExtension(str);
            if (File.Exists(str))
            {
                server.Text = ContentReader(strOne, "Data Source", "");
                database.Text = ContentReader(strOne, "DataBase", "");
                uid.Text = ContentReader(strOne, "Uid", "");
                pwd.Text = ContentReader(strOne, "Pwd", "");
            }
            #endregion
        }
        #endregion

        #region 进行修改操作
        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(str))
            {
                WritePrivateProfileString(strOne, "Data Source", server.Text, str);
                WritePrivateProfileString(strOne, "DataBase", database.Text, str);
                WritePrivateProfileString(strOne, "Uid", uid.Text, str);
                WritePrivateProfileString(strOne, "Pwd", pwd.Text, str);
                MessageBox.Show("恭喜你，修改成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("对不起，你所要修改的文件不存在，请确认后再进行修改操作！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
