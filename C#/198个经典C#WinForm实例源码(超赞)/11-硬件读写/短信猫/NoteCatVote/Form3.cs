using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace NoteCatVote
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string id;
        private void Form3_Load(object sender, EventArgs e)
        {
            lblID.Text = id;
            string str="select * from tb_Vote where ID="+Convert.ToInt32(id);
            DataClass.GetInfo(txtItem, txtVote,txtContent, cbbIs, str);

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

        private void txtVote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar <= '9' && e.KeyChar >= '0') && e.KeyChar != '\r' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtItem.Text == "" || txtVote.Text == ""||txtContent.Text=="")
            {
                MessageBox.Show("请输入投票项目或初始票数", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int isf;
                if(cbbIs.SelectedIndex==0)
                {
                    isf=1;
                }
                else
                {
                    isf=0;
                }
                string str = "update tb_Vote set Item='" + txtItem.Text.Trim() + "',Ballot=" + Convert.ToInt32(txtVote.Text.Trim()) + ",content='"+txtContent.Text.Trim()+"', IsRelease=" + isf + " where ID=" + Convert.ToInt32(id);
                if (DataClass.ExecuteSQL(str) > 0)
                {
                    MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
    }
}
