using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VideoMonitor.CommonClass;
using Microsoft.Win32;

namespace VideoMonitor
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        SoftReg softreg = new SoftReg();

        private void frmRegister_Load(object sender, EventArgs e)
        {
            txtMNum.Text = softreg.getMNum();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (txtRNum.Text == "")
            {
                MessageBox.Show("注册码输入不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtRNum.Text.Equals(softreg.getRNum()))
                {
                    RegistryKey retkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("software", true).CreateSubKey("wxk").CreateSubKey("wxk.INI").CreateSubKey(txtRNum.Text);
                    retkey.SetValue("UserName", "mrsoft");
                    MessageBox.Show("注册成功,程序需要重新加载！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frmMain frmmain = new frmMain();
                    frmmain.Show();
                }
                else
                {
                    MessageBox.Show("注册码输入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frmmain = new frmMain();
            frmmain.Show();
        }
    }
}