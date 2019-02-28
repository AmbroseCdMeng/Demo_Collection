using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 自制数值文本框组件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            numberBox1.DataStyle = NumberBox.StyleSort.Decimal;
        }

        private void numberBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
