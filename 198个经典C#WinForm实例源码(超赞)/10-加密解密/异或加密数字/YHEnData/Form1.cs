using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YHEnData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    textBox2.Text = (Convert.ToInt32(textBox1.Text) ^ 123).ToString();
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    textBox1.Text = (Convert.ToInt32(textBox2.Text) ^ 123).ToString();
                }
            }
            catch { }
        }
    }
}