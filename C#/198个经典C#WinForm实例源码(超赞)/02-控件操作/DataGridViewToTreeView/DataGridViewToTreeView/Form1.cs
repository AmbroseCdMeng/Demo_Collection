using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataGridViewToTreeView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //声明本程序需要的变量
        public static string[,] recordInfo;

        //窗体加载时，显示原有的数据
        private void Form1_Load(object sender, EventArgs e)
        {
            #region 在DataGridView及TreeView中显示数据
            string connString = "server=.;database=pubs;integrated security=sspi"; 	//连接数据库字符串
            SqlConnection conn = new SqlConnection(connString); 					//建立数据库的连接
            conn.Open();												//打开数据库
            //定义查询字符串
            string selectString = "select au_id as 用户编号,au_lname as 用户名,phone as 联系电话 from authors";
            SqlDataAdapter Adapter = new SqlDataAdapter(selectString, conn);			//定义填充对象
            DataSet dataset = new DataSet();									//定义数据集dataset
            Adapter.Fill(dataset, "UserInfo");									//填充数据集dataset
            dataGridView1.DataSource = dataset.Tables["UserInfo"].DefaultView;			//为DataGridView控件绑定数据源
            TreeNode treeNode = new TreeNode("用户信息", 0, 0); 					//定义一个TreeNode节点
            treeView1.Nodes.Add(treeNode); 									//添加定义完的节点
            #endregion
            追加节点ToolStripMenuItem.Checked = true;    						//默认情况下追加节点

        }

        //DataGridView的按下鼠标事件
        private void dataGridView1_MouseDown(object sender,MouseEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                //定义一个二维数组，数组中的每一行代表DataGridView中的一条记录
                recordInfo = new string[dataGridView1.Rows.Count, dataGridView1.Columns.Count];

                //当按下鼠标左键时，首先获取选定行，记录每一行对应的信息
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Selected)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            recordInfo[i, j] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
            }
        }

        //当鼠标进入TreeView控件时，触发的操作
        private void treeView1_MouseEnter(object sender, EventArgs e)
        {
            if (追加节点ToolStripMenuItem.Checked == true)//判断拖放操作的类型是否为追加节点
            {
                #region 代码区域
                if (recordInfo != null && recordInfo.Length != 0)
                {
                    //用双重for循环遍历数组recordInfo中的内容
                    for (int i = 0; i < recordInfo.GetLength(0); i++)
                    {
                        for (int j = 0; j < recordInfo.GetLength(1); j++)
                        {
                            //判断数组中的值是否为空
                            if (recordInfo[i, j] != null)
                            {
                                if (j == 0)
                                {
                                    //向TreeView中加入节点
                                    TreeNode Node1 = new TreeNode(recordInfo[i, j].ToString());
                                    treeView1.SelectedNode.Nodes.Add(Node1);
                                    treeView1.SelectedNode = Node1;
                                }
                                else
                                {
                                    //添加子级节点下的子节点
                                    TreeNode Node2 = new TreeNode(recordInfo[i, j].ToString());
                                    treeView1.SelectedNode.Nodes.Add(Node2);
                                }
                            }

                        }
                        treeView1.SelectedNode = treeView1.Nodes[0];
                        treeView1.ExpandAll();
                    }
                    //清空recordInfo中的记录
                    for (int m = 0; m < recordInfo.GetLength(0); m++)
                    {
                        for (int n = 0; n < recordInfo.GetLength(1); n++)
                        {
                            recordInfo[m, n] = null;
                        }
                    }
                }

                #endregion
            }
            if (清空内容ToolStripMenuItem.Checked == true)//判断拖放操作的类型是否为追加节点
            {
                if (treeView1.SelectedNode.Nodes.Count != 0)//判断数组recordnfo是否存在内容
                {
                    treeView1.SelectedNode.Remove();//清空treeView控件中的内容
                    TreeNode treeNode = new TreeNode("用户信息", 0, 0);//指定的标签文本初始化TreeNode对象
                    treeView1.Nodes.Add(treeNode);//将先前创建的树节点添加到树节点集合的末尾
                    treeView1.SelectedNode = treeNode;//设置当前树视图控件中选定节点为刚创建完的节点
                    #region 代码区域
                    if (recordInfo != null && recordInfo.Length != 0)
                    {
                        //用双重for循环遍历数组recordInfo中的内容
                        for (int i = 0; i < recordInfo.GetLength(0); i++)
                        {
                            for (int j = 0; j < recordInfo.GetLength(1); j++)
                            {
                                //判断数组中的值是否为空
                                if (recordInfo[i, j] != null)
                                {
                                    if (j == 0)
                                    {
                                        //向TreeView中加入节点
                                        TreeNode Node1 = new TreeNode(recordInfo[i, j].ToString());
                                        treeView1.SelectedNode.Nodes.Add(Node1);
                                        treeView1.SelectedNode = Node1;
                                    }
                                    else
                                    {
                                        //添加子级节点下的子节点
                                        TreeNode Node2 = new TreeNode(recordInfo[i, j].ToString());
                                        treeView1.SelectedNode.Nodes.Add(Node2);
                                    }
                                }

                            }
                            treeView1.SelectedNode = treeView1.Nodes[0];
                            treeView1.ExpandAll();
                        }
                        //清空recordInfo中的记录
                        for (int m = 0; m < recordInfo.GetLength(0); m++)
                        {
                            for (int n = 0; n < recordInfo.GetLength(1); n++)
                            {
                                recordInfo[m, n] = null;
                            }
                        }
                    }

                    #endregion
                    追加节点ToolStripMenuItem.Checked = true;
                    清空内容ToolStripMenuItem.Checked = false;
                }

            }
        }

        #region 默认项的设置
        private void 清空内容ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (追加节点ToolStripMenuItem.Checked == true)				//当追加节点类型被勾选时
            {
                清空内容ToolStripMenuItem.Checked = true; 			//清空节点类型变为勾选状态
                追加节点ToolStripMenuItem.Checked = false; 			//追加节点类型变为不选中状态
            }

        }

        private void 追加节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (清空内容ToolStripMenuItem.Checked == true) 			//当清空节点类型被勾选时
            {
                追加节点ToolStripMenuItem.Checked = true; 			//追加节点类型变为勾选状态
                清空内容ToolStripMenuItem.Checked = false; 			//清空内容节点类型变为不选中状态
            }
        }

        #endregion
    }
}
