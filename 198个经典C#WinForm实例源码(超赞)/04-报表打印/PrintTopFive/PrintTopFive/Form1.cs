using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace PrintTopFive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 定义全局对象及变量
        int intPage = 0;//总页数
        int intRows = 30;//每页行数
        int EndRows = 0;//最后一页函数
        int currentpageindex = 1;//当前打印页
        Pen myPen = new Pen(Color.Black);
        Font myFont = new Font("宋体", 9);//字体
        Brush myBrush = new SolidBrush(Color.Black);//画刷
        int PrintPageHeight = 1169;//打印的默认高度
        int PrintPageWidth = 827;//打印的默认宽度
        int topmargin = 60; //顶边距 
        int rowgap = 32;//行高 
        int leftmargin = 50;//左边距 
        int rightmargin = 50;//左边距
        int buttommargin = 80;//底边距 
        int columnWidth1 = 57;//第一列宽度
        int columnWidth2 = 335;//第二列宽度
        int page = 0;//打印指定的页
        ArrayList list = new ArrayList();//记录打印范围
        int m = 0;//定义打印范围的索引值
        #endregion

        //加载数据
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection("Data Source=(local);Database=Northwind;Uid=sa;Pwd=;");
            SqlDataAdapter sqlda = new SqlDataAdapter("select CustomerID,CompanyName,Address from Customers", sqlcon);
            DataSet myds = new DataSet();
            sqlda.Fill(myds);
            dataGridView1.DataSource = myds.Tables[0];
            EndRows = (dataGridView1.Rows.Count-2) % intRows;//去掉标题和最后一行的空行
            if (EndRows > 0)
                intPage = Convert.ToInt32((dataGridView1.Rows.Count - 2) / intRows) + 1;
            else
                intPage = Convert.ToInt32((dataGridView1.Rows.Count - 2) / intRows);
            label1.Text = "共有" + (dataGridView1.Rows.Count - 2) + "条数据  共" + intPage + "页";
        }

        //打印
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strSubPages = "1-5".Split('-');
                int intStart = Convert.ToInt32(strSubPages[0].ToString());
                int intEnd = Convert.ToInt32(strSubPages[1].ToString());
                for (int j = intStart; j <= intEnd; j++)
                    list.Add(j);
                list.Sort();
                printPreviewDialog1.ShowDialog();
            }
            catch { }
        }

        //对打印文档进行设置
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
                #region 打印指定的多页
                if (m < list.Count)
                {
                    int startPage = Convert.ToInt32(list[m].ToString());
                    int intPrintRows = startPage * intRows;
                    int j = 0;
                    for (int i = 0 + (intPrintRows - 30); i < intPrintRows; i++)
                    {
                        if (i <= dataGridView1.Rows.Count - 2)
                        {
                            e.Graphics.DrawString(dataGridView1.Rows[i].Cells[0].Value.ToString(), myFont, myBrush, leftmargin + 5, topmargin + j * rowgap + 5);
                            e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), myFont, myBrush, leftmargin + columnWidth1 + 5, topmargin + j * rowgap + 5);
                            e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), myFont, myBrush, leftmargin + columnWidth1 + columnWidth2 + 5, topmargin + j * rowgap + 5);
                            e.Graphics.DrawLine(myPen, leftmargin, topmargin + j * rowgap + 1, PrintPageWidth - leftmargin - rightmargin, topmargin + j * rowgap + 1);
                            e.Graphics.DrawLine(myPen, leftmargin + columnWidth1, topmargin + j * rowgap, leftmargin + columnWidth1, PrintPageHeight - topmargin - buttommargin);
                            e.Graphics.DrawLine(myPen, leftmargin + columnWidth1 + columnWidth2, topmargin + j * rowgap, leftmargin + columnWidth1 + columnWidth2, PrintPageHeight - topmargin - buttommargin);
                            e.Graphics.DrawString("共 " + intPage + " 页   第 " + startPage + " 页", myFont, myBrush, PrintPageWidth - 200, (int)(PrintPageHeight - buttommargin / 2));
                            j++;
                        }
                    }
                    m++;//下一页的页码
                    if (startPage < Convert.ToInt32(list[list.Count - 1].ToString()))//如果当前页不是最后一页
                    {
                        e.HasMorePages = true;//打印副页
                    }
                    else
                    {
                        e.HasMorePages = false;//不打印副页
                        startPage = Convert.ToInt32(list[0].ToString());//当前打印的页编号设为设置的第一页
                    }
                }
                #endregion
            }
        }
    }
}