using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PrintGoodsOutBill
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 定义全局变量及对象
        string strCon = "Data Source=(local);Database=db_04;Uid=sa;Pwd=;";
        public static string strID = "";
        public static string strOutPeople = "";
        public static string strOutProvider = "";
        public static string strPlace = "";
        public static string strGID = "";
        public static string strGName = "";
        public static string strGSpec = "";
        public static string strGUnit = "";
        public static string strGMoney = "";
        public static string strGNum = "";
        public static string strSMoney = "";
        public static string strInDate = "";
        public static string strRemark = "";
        SqlConnection sqlcon;
        SqlDataAdapter sqlda;
        DataSet myds;
        #endregion

        //窗体初始化时显示所有入库信息
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(strCon);
            sqlda = new SqlDataAdapter("select * from tb_OutGoods",sqlcon);
            myds = new DataSet();
            sqlda.Fill(myds);
            dgvInfo.DataSource = myds.Tables[0];
        }

        //记录选中的出库单的详细信息
        private void dgvInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                strID = dgvInfo.Rows[e.RowIndex].Cells[0].Value.ToString();
                strOutPeople = dgvInfo.Rows[e.RowIndex].Cells[1].Value.ToString();
                strOutProvider = dgvInfo.Rows[e.RowIndex].Cells[2].Value.ToString();
                strPlace = dgvInfo.Rows[e.RowIndex].Cells[3].Value.ToString();
                strGID = dgvInfo.Rows[e.RowIndex].Cells[4].Value.ToString();
                strGName = dgvInfo.Rows[e.RowIndex].Cells[5].Value.ToString();
                strGSpec = dgvInfo.Rows[e.RowIndex].Cells[6].Value.ToString();
                strGUnit = dgvInfo.Rows[e.RowIndex].Cells[7].Value.ToString();
                strGMoney = "￥" + dgvInfo.Rows[e.RowIndex].Cells[8].Value.ToString();
                strGNum = dgvInfo.Rows[e.RowIndex].Cells[9].Value.ToString();
                strSMoney = "￥" + dgvInfo.Rows[e.RowIndex].Cells[10].Value.ToString();
                strInDate = dgvInfo.Rows[e.RowIndex].Cells[11].Value.ToString();
                strRemark = dgvInfo.Rows[e.RowIndex].Cells[12].Value.ToString();
            }
            catch { }
        }

        //打印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        //设置打印的商品出库单据
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int printWidth = e.PageBounds.Width;
            int printHeight = e.PageBounds.Height;
            int left = printWidth / 2 - 305;
            int right = printWidth / 2 + 305;
            int top = printHeight / 2-200;
            Brush myBrush = new SolidBrush(Color.Black);
            Pen mypen = new Pen(Color.Black);
            Font myFont = new Font("宋体", 12);
            e.Graphics.DrawString("商品出库单", new Font("宋体", 20, FontStyle.Bold), myBrush, new Point(printWidth / 2 - 100, top));
            e.Graphics.DrawLine(new Pen(Color.Black, 2), 300, top + 30, 480, top + 30);
            e.Graphics.DrawLine(new Pen(Color.Black, 2), 300, top + 34, 480, top + 34);
            e.Graphics.DrawString("吉林省明日科技有限公司", new Font("宋体", 9), myBrush, new Point(left + 2, top + 25));
            e.Graphics.DrawString("日期：" + DateTime.Now.ToLongDateString(), new Font("宋体", 12), myBrush, new Point(right - 190, top + 25));
            e.Graphics.DrawRectangle(mypen, left, top + 42, 610, 230);//绘制矩形框
            e.Graphics.DrawLine(mypen, left, top + 72, left + 610, top + 72);//第一行
            e.Graphics.DrawLine(mypen, left, top + 102, left + 610, top + 102);//第二行
            e.Graphics.DrawLine(mypen, left, top + 132, left + 610, top + 132);//第三行
            e.Graphics.DrawLine(mypen, left, top + 162, left + 610, top + 162);//第四行
            e.Graphics.DrawLine(mypen, left + 80, top + 42, left + 80, top + 272);//第一列
            e.Graphics.DrawLine(mypen, left + 220, top + 42, left + 220, top + 72);//第二列
            e.Graphics.DrawLine(mypen, left + 280, top + 42, left + 280, top + 72);//第三列
            e.Graphics.DrawLine(mypen, left + 410, top + 42, left + 410, top + 132);//第四列
            e.Graphics.DrawLine(mypen, left + 470, top + 42, left + 470, top + 162);//第五列
            e.Graphics.DrawLine(mypen, left + 170, top + 102, left + 170, top + 162);//第三行第二列
            e.Graphics.DrawLine(mypen, left + 220, top + 102, left + 220, top + 162);//第三行第三列
            e.Graphics.DrawLine(mypen, left + 300, top + 132, left + 300, top + 162);//第四行第四列
            e.Graphics.DrawLine(mypen, left + 360, top + 132, left + 360, top + 162);//第四行第五列
            e.Graphics.DrawLine(mypen, left + 520, top + 132, left + 520, top + 162);//第四行第七列
            //第一行数据
            e.Graphics.DrawString("出库日期", myFont, myBrush, new Point(left + 2, top + 50));
            e.Graphics.DrawString(strInDate, myFont, myBrush, new Point(left + 82, top + 50));
            e.Graphics.DrawString("单据号", myFont, myBrush, new Point(left + 222, top + 50));
            e.Graphics.DrawString(strID, myFont, myBrush, new Point(left + 282, top + 50));
            e.Graphics.DrawString("出库人", myFont, myBrush, new Point(left + 412, top + 50));
            e.Graphics.DrawString(strOutPeople, myFont, myBrush, new Point(left + 472, top + 50));
            //第二行数据
            e.Graphics.DrawString("供货商", myFont, myBrush, new Point(left + 2, top + 80));
            e.Graphics.DrawString(strOutProvider, myFont, myBrush, new Point(left + 82, top + 80));
            e.Graphics.DrawString("产地", myFont, myBrush, new Point(left + 412, top + 80));
            e.Graphics.DrawString(strPlace, myFont, myBrush, new Point(left + 472, top + 80));
            //第三行数据
            e.Graphics.DrawString("商品编号", myFont, myBrush, new Point(left + 2, top + 110));
            e.Graphics.DrawString(strGID, myFont, myBrush, new Point(left + 82, top + 110));
            e.Graphics.DrawString("名称", myFont, myBrush, new Point(left + 172, top + 110));
            e.Graphics.DrawString(strGName, myFont, myBrush, new Point(left + 222, top + 110));
            e.Graphics.DrawString("规格", myFont, myBrush, new Point(left + 412, top + 110));
            e.Graphics.DrawString(strGSpec, myFont, myBrush, new Point(left + 472, top + 110));
            //第四行数据
            e.Graphics.DrawString("单位", myFont, myBrush, new Point(left + 2, top + 140));
            e.Graphics.DrawString(strGUnit, myFont, myBrush, new Point(left + 82, top + 140));
            e.Graphics.DrawString("单价", myFont, myBrush, new Point(left + 172, top + 140));
            e.Graphics.DrawString(strGMoney, myFont, myBrush, new Point(left + 222, top + 140));
            e.Graphics.DrawString("数量", myFont, myBrush, new Point(left + 302, top + 140));
            e.Graphics.DrawString(strGNum, myFont, myBrush, new Point(left + 362, top + 140));
            e.Graphics.DrawString("金额", myFont, myBrush, new Point(left + 472, top + 140));
            e.Graphics.DrawString(strSMoney, myFont, myBrush, new Point(left + 522, top + 140));
            //第五行数据
            e.Graphics.DrawString("备注", myFont, myBrush, new Point(left + 2, top + 170));
            e.Graphics.DrawString(strRemark, myFont, myBrush, new Point(left + 82, top + 170));
        }
    }
}
