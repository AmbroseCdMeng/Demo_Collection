using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Popup窗口提醒
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Popup.Controls.Frm_Popup.Instance().Show();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
           
        }
    }
}
