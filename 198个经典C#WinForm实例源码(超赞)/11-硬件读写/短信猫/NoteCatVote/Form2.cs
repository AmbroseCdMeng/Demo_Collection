using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NoteCatVote
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtItem.Text == "" || txtVote.Text == ""||txtContent.Text=="")
            {
                MessageBox.Show("请输入投票项目或初始票数","警告",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (DataClass.DataNum() < 4)
                {
                    int isf;
                    if (cbbIs.SelectedIndex == 0)
                    {
                        isf = 1;
                    }
                    else
                    {
                        isf = 0;
                    }
                    string str = "insert into tb_Vote(Item,Ballot,content,IsRelease) values('" + txtItem.Text.Trim() + "','" + Convert.ToInt32(txtVote.Text.Trim()) + "','" + txtContent.Text.Trim() + "','" + isf + "')";
                    if (DataClass.ExecuteSQL(str) > 0)
                    {
                        MessageBox.Show("输入成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtItem.Text = "";
                        txtVote.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("只允许添加四个投票选项！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtVote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar <= '9' && e.KeyChar >= '0') && e.KeyChar != '\r' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtVote_TextChanged(object sender, EventArgs e)
        {
            if (txtVote.Text.Length >= 2)
            {
                if (txtVote.Text.Trim().StartsWith("0"))
                {
                    txtVote.Text = txtVote.Text.Trim().Substring(1).ToString();
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cbbIs.SelectedIndex = 0;
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_TabStopChanged(object sender, EventArgs e)
        {

        }


        private void tabControl1_Click(object sender, EventArgs e)
        {
            string str = "select ID as 编号,Item as 项目,content as 短信,Ballot as 票数 from tb_Vote";
            DataClass.BindDataGridView(dataGridView1, str);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void 删除数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
                string str = "delete from tb_Vote where ID=" + id;
                if (DataClass.ExecuteSQL(str) > 0)
                {
                    string str1 = "select ID as 编号,Item as 项目,content as 短信,Ballot as 票数 from tb_Vote";
                    DataClass.BindDataGridView(dataGridView1, str1);
                }
            }
        }

        Form3 frm3;
        private void 修改数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                frm3 = new Form3();
                frm3.id = dataGridView1.SelectedCells[0].Value.ToString();
                frm3.ShowDialog();
            }
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            string str = "select ID as 编号,Item as 项目,content as 短信,Ballot as 票数 from tb_Vote";
            DataClass.BindDataGridView(dataGridView1, str);
        }
    }
}
