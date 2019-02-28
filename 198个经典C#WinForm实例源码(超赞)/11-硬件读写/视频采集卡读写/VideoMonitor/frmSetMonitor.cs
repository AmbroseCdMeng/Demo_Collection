using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using VideoMonitor.CommonClass;

namespace VideoMonitor
{
    public partial class frmSetMonitor : Form
    {
        public frmSetMonitor()
        {
            InitializeComponent();
        }

        DataOperate dataoperate = new DataOperate();
        DataSet ds;
        private void frmSetMonitor_Load(object sender, EventArgs e)
        {
            lviewBind();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("�û�������Ϊ�գ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ds = dataoperate.getDs("select * from tb_admin where name='" + txtName.Text + "'", "tb_admin");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("���û��Ѿ����ڣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataoperate.getCom("insert into tb_admin (name,pwd) values('" + txtName.Text + "','" + txtPwd.Text + "')");
                    lviewBind();
                    txtName.Text = txtPwd.Text = string.Empty;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty && txtPwd.Text == string.Empty)
            {
                MessageBox.Show("�û��������벻��Ϊ�գ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataoperate.getCom("update tb_admin set pwd ='" + txtPwd.Text + "' where name='" + txtName.Text + "'");
                lviewBind();
                txtName.Text = txtPwd.Text = string.Empty;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtName.Text.ToLower() == "tsoft")
            {
                MessageBox.Show("���û��ǳ����û�������ɾ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dataoperate.getCom("delete from tb_admin where name='" + txtName.Text + "'");
                lviewBind();
                txtName.Text = lview.Items[0].Text;
            }
        }

        private void lview_Click(object sender, EventArgs e)
        {
            txtName.Text = lview.SelectedItems[0].Text;
            txtPwd.Text = string.Empty;
        }

        public void lviewBind()
        {
            lview.Items.Clear();
            ds = dataoperate.getDs("select name from tb_admin", "tb_admin");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListViewItem lvItem = new ListViewItem(dr[0].ToString(), 0);
                lvItem.SubItems.Add(dr[0].ToString());
                lview.Items.Add(lvItem);
            }
        }
    }
}