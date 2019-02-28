using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vista风格的日历
{
    public partial class Frm_Data : Form
    {
        public Frm_Data()
        {
            InitializeComponent();
        }
        public static string Var_D = "";
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Var_D = monthCalendar1.TodayDate.Date.ToString();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
