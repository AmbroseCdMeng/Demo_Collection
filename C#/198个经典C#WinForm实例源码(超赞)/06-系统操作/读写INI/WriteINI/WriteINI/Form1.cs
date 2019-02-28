using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WriteINI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        public static void IniWriteValue(string section, string key, string value, string path)
        {
            WritePrivateProfileString(section, key, value, path);
        }
        string strg;
        private void Form1_Load(object sender, EventArgs e)
        {
            strg = Application.StartupPath.ToString();
            strg = strg.Substring(0, strg.LastIndexOf("\\"));
            strg = strg.Substring(0, strg.LastIndexOf("\\"));
            strg += @"\Test.ini";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                IniWriteValue(textBox1.Text.Trim(),textBox2.Text.Trim(),textBox3.Text.Trim(),strg);
                MessageBox.Show("写入成功");
            }
        }
    }
}
