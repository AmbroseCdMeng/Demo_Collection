﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _30Print
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 定义全局对象及变量
        int intPage = 0;//总页数
        int intRows = 0;//每页行数
        int EndRows = 0;//最后一页函数
        int currentpageindex = 1;//当前打印页
        Pen myPen = new Pen(Color.Black);
        Font myFont = new Font("宋体", 9);//字体
        Brush myBrush = new SolidBrush(Color.Black);//画刷
        int PrintPageHeight = 1169;//打印的默认高度
        int PrintPageWidth = 827;//打印的默认宽度
        int topmargin = 60; //顶边距 
        int rowgap = 0;//行高 
        int leftmargin = 50;//左边距 
        int rightmargin = 50;//左边距
        int buttommargin = 80;//底边距 
        int columnWidth1 = 57;//第一列宽度
        int columnWidth2 = 335;//第二列宽度
        #endregion

        //初始化数据
        private void Form1_Load(object sender, EventArgs e)
        {
            intRows = 30;
            SqlConnection sqlcon = new SqlConnection("Data Source=(local);Database=Northwind;Uid=sa;Pwd=;");
            SqlDataAdapter sqlda = new SqlDataAdapter("select CustomerID,CompanyName,Address from Customers", sqlcon);
            DataSet myds = new DataSet();
            sqlda.Fill(myds);
            dataGridView1.DataSource = myds.Tables[0];
            //设置每列的宽度
            dataGridView1.Columns[0].Width = 57;
            dataGridView1.Columns[1].Width = 260;
            dataGridView1.Columns[2].Width = 280;
            EndRows = (dataGridView1.Rows.Count - 2) % intRows;//去掉标题和最后一行的空行
            if (EndRows > 0)
                intPage = Convert.ToInt32((dataGridView1.Rows.Count - 2) / intRows) + 1;
            else
                intPage = Convert.ToInt32((dataGridView1.Rows.Count - 2) / intRows);
        }

        //打印
        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        //设置打印内容
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                PrintPageWidth = e.PageBounds.Width;//获取打印线张的宽度
                PrintPageHeight = e.PageBounds.Height;//获取打印线张的高度

                #region 绘制边框线
                e.Graphics.DrawLine(myPen, leftmargin, topmargin, PrintPageWidth - leftmargin - rightmargin, topmargin);
                e.Graphics.DrawLine(myPen, leftmargin, topmargin, leftmargin, PrintPageHeight - topmargin - buttommargin);
                e.Graphics.DrawLine(myPen, leftmargin, PrintPageHeight - topmargin - buttommargin, PrintPageWidth - leftmargin - rightmargin, PrintPageHeight - topmargin - buttommargin);
                e.Graphics.DrawLine(myPen, PrintPageWidth - leftmargin - rightmargin, topmargin, PrintPageWidth - leftmargin - rightmargin, PrintPageHeight - topmargin - buttommargin);
                #endregion

                #region 打印
                int intPrintRows = currentpageindex * intRows;
                rowgap = Convert.ToInt32((PrintPageHeight - topmargin - buttommargin - 5 * intRows) / intRows)+3;
                int j = 0;
                for (int i = 0 + (intPrintRows - intRows); i < intPrintRows; i++)
                {
                    if (i <= dataGridView1.Rows.Count - 2)
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[0].Value.ToString(), myFont, myBrush, leftmargin + 5, topmargin + j * rowgap + 5);
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), myFont, myBrush, leftmargin + columnWidth1 + 5, topmargin + j * rowgap + 5);
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), myFont, myBrush, leftmargin + columnWidth1 + columnWidth2 + 5, topmargin + j * rowgap + 5);
                        e.Graphics.DrawLine(myPen, leftmargin, topmargin + j * rowgap + 1, PrintPageWidth - leftmargin - rightmargin, topmargin + j * rowgap + 1);
                        e.Graphics.DrawLine(myPen, leftmargin + columnWidth1, topmargin + j * rowgap, leftmargin + columnWidth1, PrintPageHeight - topmargin - buttommargin);
                        e.Graphics.DrawLine(myPen, leftmargin + columnWidth1 + columnWidth2, topmargin + j * rowgap, leftmargin + columnWidth1 + columnWidth2, PrintPageHeight - topmargin - buttommargin);
                        e.Graphics.DrawString("共 " + intPage + " 页   第 " + currentpageindex + " 页", myFont, myBrush, PrintPageWidth - 200, (int)(PrintPageHeight - buttommargin / 2));
                        j++;
                    }
                }
                currentpageindex++;//下一页的页码
                if (currentpageindex <= intPage)//如果当前页不是最后一页
                {
                    e.HasMorePages = true;//打印副页
                }
                else
                {
                    e.HasMorePages = false;//不打印副页
                    currentpageindex = 1;//当前打印的页编号设为1
                }
                #endregion
            }
        }
    }
}