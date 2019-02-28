using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//��ӵ������ռ�
using System.Data.OleDb;
using VideoMonitor.CommonClass;

namespace VideoMonitor
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        DataCon datacon = new DataCon();
        DataOperate dataoperate = new DataOperate();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                errorProName.SetError(txtName, "�û�������Ϊ��!");
            }
            else
            {
                errorProName.Clear();
                string strSql = "select * from tb_admin where name='" + txtName.Text + "' and pwd='" + txtPwd.Text + "'";
                DataSet ds = dataoperate.getDs(strSql, "tb_admin");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.Hide();
                    frmMain frmmain = new frmMain();
                    frmmain.Show();
                }
                else
                {
                    MessageBox.Show("�û������������", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPwd.Focus();
                e.Handled = true;
            }
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin.Focus();
                e.Handled = true;
            }
        }
    }
}