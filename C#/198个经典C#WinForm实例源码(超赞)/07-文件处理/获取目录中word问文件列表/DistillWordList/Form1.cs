using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Threading;
namespace DistillWordList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Thread td;

        private void GetWordList(string WordPath)
        {
            try
            {
                Word.Document doc = null;
                Word.Application app = new Word.Application();
                Object none = System.Reflection.Missing.Value;
                Word.Document doc2 = app.Documents.Add(ref none, ref none, ref none, ref none);
                object Unknown = Type.Missing;
                object missing = System.Reflection.Missing.Value;
                object filename = WordPath;
                object readOnly = false;
                object isVisble = true;
                object index = 0;
                doc = app.Documents.Open(ref filename, ref missing, ref readOnly,
                    ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown,
                    ref Unknown, ref Unknown, ref Unknown, ref Unknown);
                app.Visible = false;
                object start = 0;
                object end = 0;
                Word.Range rg = doc.Range(ref start, ref end);
                object oUseHeadingStyles = true;
                object oUpperHeadingLevel = 1;
                object oLowerHeadingLevel = 9;
                object oUseFields = false;
                object oTableID = 1;
                object oRightAlignPageNumbers = false;
                object oIncludePageNumbers = false;
                object oAddedStyles = null;
                object oUseHyperlinks = false;
                object oHidePageNumbersInWeb = false;
                doc.TablesOfContents.Add(rg, ref oUseHeadingStyles,
                    ref oUpperHeadingLevel, ref oLowerHeadingLevel,
                    ref oUseFields, ref oTableID, ref oRightAlignPageNumbers,
                    ref oIncludePageNumbers, ref oAddedStyles, ref oUseHyperlinks, ref oHidePageNumbersInWeb);
                if (doc.Fields.Count >= 1)
                {
                    doc.Fields.Item(1).Cut();
                    doc2.Range(ref start, ref end).Paste();
                }
                doc.Close(ref Unknown, ref Unknown, ref Unknown);
                app.Quit(ref Unknown, ref Unknown, ref Unknown);
            }
            catch(Exception ex)
            {
                MessageBox.Show("警告："+ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string[] filePath;
        FileInfo fi;
        string[] fileinfo=new string[4];
        private void GetFileInfos(string path)
        {
            listView1.Items.Clear();
            filePath=Directory.GetFiles(path,"*.doc");
            for (int i = 0; i < filePath.Length; i++)
            {
                string fpath = filePath[i].ToString();
                string name = fpath.Substring(fpath.LastIndexOf("\\") + 1, fpath.Length - fpath.LastIndexOf("\\") -1);
                fi=new FileInfo(fpath);
                string fsize = Convert.ToString(fi.Length / 1024) + "KB";
                fileinfo[0] = name;
                fileinfo[1] = fpath;
                fileinfo[2] = fsize;
                if (fsize != "0KB")
                {
                    ListViewItem lvi = new ListViewItem(fileinfo);
                    listView1.Items.Add(lvi);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
                GetFileInfos(txtPath.Text.Trim());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("警告：请选择要提取目录的文档！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string path = listView1.SelectedItems[0].SubItems[1].Text;
                GetWordList(path);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Word.Document doc = null;
            Word.Application app = new Word.Application();
            Object none = System.Reflection.Missing.Value;
            Word.Document doc2 = app.Documents.Add(ref none, ref none, ref none, ref none);
            
            object Unknown = Type.Missing;
            if (listView1.Items.Count> 0)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    string WordPath = listView1.Items[i].SubItems[1].Text;
                    object missing = System.Reflection.Missing.Value;
                    object filename = WordPath;
                    object readOnly = false;
                    object isVisble = true;
                    object index = 0;
                    doc = app.Documents.Open(ref filename, ref missing, ref readOnly,
                        ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown,
                        ref Unknown, ref Unknown, ref Unknown, ref Unknown);
                    app.Visible = false;

                    object start = 0;
                    object end = 0;
                    Word.Range rg = doc.Range(ref start, ref end);
                    object oUseHeadingStyles = true;
                    object oUpperHeadingLevel = 1;
                    object oLowerHeadingLevel = 9;
                    object oUseFields = false;
                    object oTableID = 1;
                    object oRightAlignPageNumbers = false;
                    object oIncludePageNumbers = false;
                    object oAddedStyles = null;
                    object oUseHyperlinks = false;
                    object oHidePageNumbersInWeb = false;
                    doc.TablesOfContents.Add(rg, ref oUseHeadingStyles,
                        ref oUpperHeadingLevel, ref oLowerHeadingLevel,
                        ref oUseFields, ref oTableID, ref oRightAlignPageNumbers,
                        ref oIncludePageNumbers, ref oAddedStyles, ref oUseHyperlinks, ref oHidePageNumbersInWeb);
                    if (doc.Fields.Count >= 1)
                    {
                        doc.Fields.Item(1).Cut();
                        doc2.Range(ref start, ref end).Paste();
                    }
                    doc.Close(ref Unknown, ref Unknown, ref Unknown);
                }
                app.Quit(ref Unknown, ref Unknown, ref Unknown);
            }
        }

        private void statPagenumber()
        {
            Word.Document doc = null;
            int mPages = 0;
            Word.Application app = new Word.Application();
            object Unknown = Type.Missing;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                string WordPath = listView1.Items[i].SubItems[1].Text;
                object missing = System.Reflection.Missing.Value;

                object filename = WordPath;
                object readOnly = false;
                object isVisble = true;
                object index = 0;
                doc = app.Documents.Open(ref filename, ref missing, ref readOnly,
                    ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown,
                    ref Unknown, ref Unknown, ref Unknown, ref Unknown);
                app.Visible = false;
                mPages = (int)app.Selection.get_Information(Word.WdInformation.wdNumberOfPagesInDocument);
                listView1.Items[i].SubItems[3].Text = mPages.ToString() + "页";
                doc.Close(ref Unknown, ref Unknown, ref Unknown);
            }
            app.Quit(ref Unknown, ref Unknown, ref Unknown);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            td = new Thread(new ThreadStart(this.statPagenumber));
            td.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (td != null)
            {
                td.Abort();
            }
        }
    }
}
