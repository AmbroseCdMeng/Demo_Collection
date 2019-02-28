using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace CreatePDFDocument
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //该变量保存PDF的文档名
        public static string filePath = "";

        //创建PDF文档
        private void button1_Click(object sender, EventArgs e)
        {
            //给出文件保存信息，确定保存位置
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF文件（*.PDF）|*.PDF";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                //开始创建PDF文档
                Document document = new Document();
                PdfWriter.getInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();
                BaseFont baseFont = BaseFont.createFont(@"c:\windows\fonts\SIMSUN.TTC,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 20);
                document.Add(new Paragraph(richTextBox1.Text, font));
                document.Close();
                MessageBox.Show("祝贺你，文档创建成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }
    }
}
