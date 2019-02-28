using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordToRtf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static void WordToHtmlRtf(string WordFilePath)
        {
            try
            {
                Word.Application wApp = new Word.Application();
                //指定原文件和目标文件 
                object docPath = WordFilePath;
                string htmlPath = WordFilePath.Substring(0, WordFilePath.Length - 3) + "rtf";
                object Target = htmlPath;
                //缺省参数 
                object Unknown = Type.Missing;
                //只读方式打开 
                object readOnly = true;
                //打开doc文件 
                Word.Document document = wApp.Documents.Open(ref docPath, ref Unknown,
                ref readOnly, ref Unknown, ref Unknown,
                ref Unknown, ref Unknown, ref Unknown,
                ref Unknown, ref Unknown, ref Unknown,
                ref Unknown);
                // 指定格式
                object format = Word.WdSaveFormat.wdFormatRTF;
                // 转换格式 
                document.SaveAs(ref Target, ref format,
                ref Unknown, ref Unknown, ref Unknown,
                ref Unknown, ref Unknown, ref Unknown,
                ref Unknown, ref Unknown, ref Unknown);
                // 关闭文档和Word程序 
                document.Close(ref Unknown, ref Unknown, ref Unknown);
                wApp.Quit(ref Unknown, ref Unknown, ref Unknown);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                WordToHtmlRtf(textBox1.Text.Trim());
                MessageBox.Show("转换成功，保存在Word文件的同目录下！");
            }
        }
    }
}
