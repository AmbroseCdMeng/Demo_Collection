using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseCon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public static string strServer = "";
        private void Form2_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SQLDMO.Application SQLServer = new SQLDMO.Application();
            SQLDMO.NameList strServer = SQLServer.ListAvailableSQLServers();
            if (strServer.Count > 0)
            {
                for (int i = 0; i < strServer.Count; i++)
                {
                    listBox1.Items.Add(strServer.Item(i + 1));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndices.Count == 0)
                MessageBox.Show("请选择要连接的服务器！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            strServer = listBox1.Text;
        }
    }
}
