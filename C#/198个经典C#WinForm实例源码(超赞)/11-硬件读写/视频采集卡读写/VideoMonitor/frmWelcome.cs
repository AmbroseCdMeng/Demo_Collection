using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoMonitor
{
    public partial class frmWelcome : Form
    {
        public frmWelcome()
        {
            InitializeComponent();
        }

        private void frmWelcome_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 5000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmWelcome_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }
    }
}