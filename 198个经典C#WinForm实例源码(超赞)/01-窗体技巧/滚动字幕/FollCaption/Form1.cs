using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FollCaption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Top = this.Height;
            this.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (listBox1.Top < -listBox1.Height)
            {
                listBox1.Top = this.Height;
            }
            listBox1.Top = listBox1.Top - 5;
            this.Focus();
        }
    }
}
