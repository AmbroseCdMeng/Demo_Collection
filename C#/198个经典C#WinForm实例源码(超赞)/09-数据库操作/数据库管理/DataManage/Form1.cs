using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace DataManage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 定义全局变量
        private static string strServer = "";  //SQL服务器
        private static string strUID = "";     //登录用户
        private static string strPwd = "";     //登录密码
        private static string strDatabase = "";//要执行操作的数据库名
        #endregion

        //绑定当前局域网中的所有SQL服务器
        private void Form1_Load(object sender, EventArgs e)
        {
            SQLDMO.Application SQLServer = new SQLDMO.Application();
            SQLDMO.NameList strServerList = SQLServer.ListAvailableSQLServers();
            if (strServerList.Count > 0)
            {
                for (int i = 0; i < strServerList.Count; i++)
                {
                    toolStripTextBox1.Items.Add(strServerList.Item(i + 1));
                }
            }
            toolStripTextBox1.SelectedIndex = 0;
        }

        private void toolStripTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                toolStripTextBox3.Focus();
        }

        private void toolStripTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                toolStripButton1_Click(sender, e);
        }

        //登录SQL服务器
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            try
            {
                strServer = toolStripTextBox1.Text;
                strUID = toolStripTextBox2.Text;
                strPwd = toolStripTextBox3.Text;
                string str = "Data Source=" + strServer + ";database=master;Uid=" + strUID + ";Pwd=" + strPwd + ";";
                TreeNode TNode = new TreeNode("服务器：" + strServer);
                DataTable myTable = getTable(str, "select name from sysdatabases", "sysdatabases");
                for (int i = 0; i < myTable.Rows.Count; i++)
                    TNode.Nodes.Add(myTable.Rows[i]["name"].ToString());
                treeView1.Nodes.Add(TNode);
            }
            catch { }
        }

        //退出当前应用程序
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //控制快捷菜单
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            strDatabase = e.Node.Text;
            if (strDatabase.Contains("服务器："))
            {
                备份数据库ToolStripMenuItem.Enabled = 还原数据库ToolStripMenuItem.Enabled = 分离数据库ToolStripMenuItem.Enabled = false;
                附加数据库ToolStripMenuItem.Enabled = true;
            }
            else
            {
                备份数据库ToolStripMenuItem.Enabled = 还原数据库ToolStripMenuItem.Enabled = 分离数据库ToolStripMenuItem.Enabled = true;
                附加数据库ToolStripMenuItem.Enabled = false;
            }
        }

        //切换到备份数据库面板
        private void 备份数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        //切换到还原数据库面板
        private void 还原数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        //切换到附加数据库面板
        private void 附加数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        //分离数据库
        private void 分离数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source="+strServer+";Database=master;uid=" + strUID + ";pwd=" + strPwd + ";"))
            {
                try
                {
                    con.Open();
                    string sql = "exec sp_detach_db @dbname='" + strDatabase + "'";
                    string single = "alter database " + strDatabase + " set single_user with rollback immediate " + sql;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = single;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("数据库分离成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    toolStripButton1_Click(sender, e);
                    treeView1.ExpandAll();
                }
                catch (Exception ey)
                {
                    MessageBox.Show(ey.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //选择要附加的数据库
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.mdf(数据库文件)|*.mdf|*.*(所有文件)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strName = openFileDialog1.FileName;
                textBox1.Text = strName;
                if (strName.ToLower().Contains("_data"))
                    textBox2.Text = strName.Remove(strName.LastIndexOf("_Data")).Substring(strName.Remove(strName.LastIndexOf("_Data")).LastIndexOf('\\') + 1);
                else
                    textBox2.Text = strName.Remove(strName.LastIndexOf('.')).Substring(strName.Remove(strName.LastIndexOf('.')).LastIndexOf('\\') + 1);
            }
        }

        //附加数据库
        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=" + strServer + ";Database=master;uid=" + strUID + ";pwd=" + strPwd + ";"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    StringBuilder sb = new StringBuilder();
                    sb.Append("sp_attach_single_file_db @dbname='" + textBox2.Text + "',");
                    sb.Append("@physname='" + textBox1.Text + "'");
                    cmd.CommandText = sb.ToString();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("数据库附加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    toolStripButton1_Click(sender, e);
                    treeView1.ExpandAll();
                }
                catch (Exception ety)
                {
                    MessageBox.Show(ety.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //选择备份文件的存放路径
        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                textBox3.Text = folderBrowserDialog1.SelectedPath;
        }

        //备份数据库
        private void button4_Click(object sender, EventArgs e)
        {
            string filepath = "";
            if (textBox3.Text.EndsWith("\\"))
                filepath = textBox3.Text + textBox4.Text.Trim();
            else
                filepath = textBox3.Text + "\\" + textBox4.Text.Trim();
            if (!File.Exists(filepath))
            {
                SqlConnection con = new SqlConnection();		//利用代码实现连接数据库
                con.ConnectionString = "Data Source=" + strServer + ";Database=" + strDatabase + ";uid=" + strUID + ";pwd=" + strPwd + ";";
                con.Open();
                SqlCommand com = new SqlCommand();
                com.CommandText = "BACKUP DATABASE " + strDatabase + " TO DISK = '" + filepath + "'";
                com.Connection = con;	//连接
                com.ExecuteNonQuery();	//执行
                con.Close();
                MessageBox.Show("数据库备份成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("请重新命名！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //选择要还原的数据库文件
        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.bak(备份文件)|*.bak|*.*(所有文件)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = openFileDialog1.FileName;
            }
        }

        //还原数据库
        private void button6_Click(object sender, EventArgs e)
        {
            string path = textBox5.Text;//获得备份文件路径
            if (path != "" && strDatabase != "")
            {
                string SqlStr1 = "Data Source=" + strServer + ";Database=" + strDatabase + ";uid=" + strUID + ";pwd=" + strPwd + ";";
                string SqlStr2 = "use master restore database " + strDatabase + " from disk='" + path + "'";
                string SqlStr3 = "backup log db_CRM to disk='" + path + "' use master restore database " + strDatabase + " from disk='" + path + "'";
                string single1 = "alter database " + strDatabase + " set single_user with rollback immediate " + SqlStr2;
                string single2 = "alter database " + strDatabase + " set single_user with rollback immediate " + SqlStr3;
                using (SqlConnection con = new SqlConnection(SqlStr1))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    try
                    {
                        cmd.CommandText = single1;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("数据库还原成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        cmd.CommandText = single2;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("数据库还原成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        #region 获得数据表结构
        /// <summary>
        /// 获得数据表结构
        /// </summary>
        /// <param name="strCon">连接字符串</param>
        /// <param name="strSql">SQL语句</param>
        /// <param name="strTable">数据表名</param>
        /// <returns>DataTable类型</returns>
        private DataTable getTable(string strCon, string strSql, string strTable)
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(strCon);
                SqlDataAdapter da = new SqlDataAdapter(strSql, sqlcon);
                DataTable dt = new DataTable(strTable);
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
