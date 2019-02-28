using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DisplayRowCount
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region 声明的变量
        static string connectionString = "Data Source=.;DataBase=pubs;integrated security=sspi";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlDataAdapter Adapter;
        DataSet dataSet = new DataSet();
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                dataSet.Clear();
                string selectString = "select job_id as 工作编号,job_desc as 工作次序,min_lvl as 最低水平,max_lvl as 最高水平 from jobs";
                Adapter = new SqlDataAdapter(selectString, conn);
                Adapter.Fill(dataSet, "UserInfo");
                DataTable dataTable = dataSet.Tables["UserInfo"];
                dataGridView1.DataSource = dataTable.DefaultView;
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

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush brushOne = new SolidBrush(Color.Red);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, brushOne, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }
    }
}
