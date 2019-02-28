using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataGridViewOperate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 声明的变量
        static string connectionString = "Data Source=.;DataBase=pubs;integrated security=sspi";		//连接数据库字符串
        SqlConnection conn = new SqlConnection(connectionString);					//连接数据库
        SqlDataAdapter Adapter;											//声明Adapter对象
        DataSet dataSet = new DataSet();										//声明数据集dataSet对象

        #endregion

        #region 显示数据
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        #endregion

        #region 显示行号
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush brushOne = new SolidBrush(Color.Red);//定义一个颜色为红色的画刷
            //绘制行号
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, brushOne, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        #endregion

        #region 合并列相同的内容
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)//绘制单元格事件
        {
            // 对第1列相同单元格进行合并     
            if (e.ColumnIndex == 2 && e.RowIndex != -1 || e.ColumnIndex == 3 && e.RowIndex != -1)
            {
                Brush datagridBrush = new SolidBrush(dataGridView1.GridColor);
                SolidBrush groupLineBrush = new SolidBrush(e.CellStyle.BackColor);
                using (Pen datagridLinePen = new Pen(datagridBrush))
                {
                    // 清除单元格
                    e.Graphics.FillRectangle(groupLineBrush, e.CellBounds);
                    if (e.RowIndex < dataGridView1.Rows.Count - 1 && dataGridView1.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value != null && dataGridView1.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value.ToString() != e.Value.ToString())
                    {
                        //绘制底边线
                        e.Graphics.DrawLine(datagridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                        // 画右边线
                        e.Graphics.DrawLine(datagridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    }
                    else
                    {
                        // 画右边线
                        e.Graphics.DrawLine(datagridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    }
                    //对最后一条记录只画底边线
                    if (e.RowIndex == dataGridView1.Rows.Count - 1)
                    {
                        //绘制底边线
                        e.Graphics.DrawLine(datagridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    }
                    // 填写单元格内容，相同的内容的单元格只填写第一个                        
                    if (e.Value != null)
                    {
                        if (!(e.RowIndex > 0 && dataGridView1.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value.ToString() == e.Value.ToString()))
                        {
                            //绘制单元格内容
                            e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault);
                        }
                    }
                    e.Handled = true;
                }
            }
        }

        #endregion

        #region 更新数据库，显示最新变化
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells[0].Value.ToString() != "" || dataGridView1.SelectedCells[0].Value != null)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommandBuilder commBuilder = new SqlCommandBuilder(Adapter);
                    Adapter.Update(dataSet.Tables["UserInfo"]);
                    dataGridView1.AllowUserToAddRows = false;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        #endregion

        #region 从数据库中读取数据
        private void ShowData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) 							//判断数据库是否关闭
                    conn.Open();												//打开数据库
                dataSet.Clear();												//清空数据集里原有的内容
                //定义查询字符串
                string selectString = "select job_id as 工作编号,job_desc as 工作次序,min_lvl as 最低水平,max_lvl as 最高水平 from jobs";
                Adapter = new SqlDataAdapter(selectString, conn); 			//实例化填充数据集和更新数据库的对象
                Adapter.Fill(dataSet, "UserInfo");									//填充dataSet数据集
                DataTable dataTable = dataSet.Tables["UserInfo"];				//定义一张表用来存储从数据库中读出的内容
                dataGridView1.DataSource = dataTable.DefaultView; 					//为dataGridView1绑定数据源
            }
            catch (SqlException ex) 											//捕获异常
            {
                MessageBox.Show(ex.Message); 									//显示异常信息
            }
            finally
            {
                conn.Close();												//关闭数据库
            }

        }
        #endregion

        #region 添加新行
        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //设置DataGridView控件允许用户添加新单元格属性为真
            dataGridView1.AllowUserToAddRows = true;
            //选中单元格内容存在且不为空
            if (dataGridView1.SelectedCells[0].Value.ToString() != "" || dataGridView1.SelectedCells[0].Value != null)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed) 			 		//判断数据库连接状态是否处于关闭
                    {
                        conn.Open();										//打开数据库
                    }
                    //将数据库中的数据自动生成一个表单
                    SqlCommandBuilder commBuilder = new SqlCommandBuilder(Adapter);
                    Adapter.Update(dataSet.Tables["UserInfo"]);					//更新数据集中内容
                    ShowData();											//显示数据集中内容
                }
                catch (SqlException ex) 										//捕获异常
                {
                    MessageBox.Show(ex.Message);							//显示异常信息
                }
                finally
                {
                    conn.Close();											//关闭数据库
                }
            }

        }
        #endregion

    }
}
