using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Management;

namespace RemoteControl
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        public static int flag = 0;
        public static string strName = "";
        public static string strHost = "";
        public static string strLName = "";
        public static string strLPwd = "";
        public bool blFlag = false;
        DataBase database = new DataBase();

        private void FrmMain_Load(object sender, EventArgs e)
        {
            UserInfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmEdit frmedit = new frmEdit();
            flag = 0;
            frmedit.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndices.Count > 0)
            {
                frmEdit frmedit = new frmEdit();
                flag = 1;
                strName = listBox1.Text;
                DataSet myds = database.getDs("select * from tb_User where Name='" + strName + "'");
                strHost = myds.Tables[0].Rows[0][1].ToString();
                strLName = myds.Tables[0].Rows[0][2].ToString();
                strLPwd = myds.Tables[0].Rows[0][3].ToString();
                frmedit.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndices.Count > 0)
                database.getCmd("delete from tb_User where Name='" + strName + "'");
            UserInfo();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.Text;
            strName = listBox1.Text;
            textBox2.Text = database.getDs("select * from tb_User where Name='" + listBox1.Text + "'").Tables[0].Rows[0][1].ToString();
            textBox4.Text = database.getDs("select * from tb_User where Name='" + listBox1.Text + "'").Tables[0].Rows[0][2].ToString();
            textBox3.Text = database.getDs("select * from tb_User where Name='" + listBox1.Text + "'").Tables[0].Rows[0][3].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CloseComputer("Shutdown");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CloseComputer("Reboot");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserInfo();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && textBox1.Text != "")
                textBox2.Focus();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && textBox2.Text != "")
                button1.Focus();
        }

        public void UserInfo()
        {
            listBox1.DisplayMember = "Name";
            listBox1.DataSource = database.getDs("select Name from tb_User").Tables[0];
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #region 关闭或重启远程计算机
        /// <summary>
        /// 关闭或重启远程计算机
        /// </summary>
        /// <param name="doinfo">要执行的操作命令</param>
        private void CloseComputer(string doinfo)
        {
            ConnectionOptions op = new ConnectionOptions();
            op.Username = textBox4.Text;
            op.Password = textBox3.Text;
            ManagementScope scope = new ManagementScope("\\\\" + textBox2.Text + "\\root\\cimv2:Win32_Service", op);
            try
            {
                scope.Connect();
                ObjectQuery oq = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher query1 = new ManagementObjectSearcher(scope, oq);
                //得到WMI控制 
                ManagementObjectCollection queryCollection1 = query1.Get();
                foreach (ManagementObject mobj in queryCollection1)
                {
                    string[] str = { "" };
                    mobj.InvokeMethod(doinfo, str);
                }
            }
            catch (Exception ey)
            {
                MessageBox.Show(ey.Message);
            }
        }
        #endregion
    }
}
