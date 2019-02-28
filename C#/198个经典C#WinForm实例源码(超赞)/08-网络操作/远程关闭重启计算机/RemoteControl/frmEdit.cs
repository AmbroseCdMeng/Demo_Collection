using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RemoteControl
{
    public partial class frmEdit : Form
    {
        public frmEdit()
        {
            InitializeComponent();
        }

        DataBase database = new DataBase();
        FrmMain frmmain = new FrmMain();

        private void frmEdit_Load(object sender, EventArgs e)
        {
            if (FrmMain.flag == 0)
            {
                button1.Enabled = true;
                button2.Enabled = false;
            }
            else if (FrmMain.flag == 1)
            {
                button1.Enabled = false;
                button2.Enabled = true;
                textBox1.Text = FrmMain.strName;
                textBox2.Text = FrmMain.strHost;
                textBox3.Text = FrmMain.strLPwd;
                textBox4.Text = FrmMain.strLName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (database.getDs("select Name from tb_User where Name='" + textBox1.Text + "'").Tables[0].Rows.Count == 0)
            {
                if (textBox1.Text !="" && textBox2.Text != "")
                {
                    database.getCmd("insert into tb_User(Name,Host,LName,LPwd) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox3.Text + "')");
                    this.Close();
                }
            }
            else
                MessageBox.Show("用户已经存在！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != FrmMain.strName)
            {
                if (database.getDs("select Name from tb_User where Name='" + textBox1.Text + "'").Tables[0].Rows.Count == 0)
                {
                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        database.getCmd("update tb_User set Name='" + textBox1.Text + "',Host='" + textBox2.Text + "',LName='" + textBox4.Text + "',LPwd='" + textBox3.Text + "' where Name='" + FrmMain.strName + "'");
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("用户已经存在！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox2.Text != "")
                {
                    database.getCmd("update tb_User set Host='" + textBox2.Text + "',LName='" + textBox4.Text + "',LPwd='" + textBox3.Text + "' where Name='" + FrmMain.strName + "'");
                    this.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && textBox1.Text !="")
                textBox2.Focus();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && textBox2.Text != "")
                textBox4.Focus();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && textBox2.Text != "")
                textBox3.Focus();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && textBox2.Text != "")
                button1.Focus();
        }
    }
}
