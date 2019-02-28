using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 用树型列表动态显示菜单
{
    public partial class Frm_Logon : Form
    {
        public Frm_Logon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "mr" && textBox2.Text == "mrsoft")
            {
                DialogResult = DialogResult.OK;//将当前窗体的对话框返回值设为OK
                this.Close();
            }
            else
                MessageBox.Show("用户名或密码错误。");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
