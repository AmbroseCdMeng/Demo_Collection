using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PlanText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProgressBarText ProgressBarT = new ProgressBarText();
        private void Form1_Load(object sender, EventArgs e)
        {
            ProgressBarT.Font = Font;
            ProgressBarT.Text = "0%";
            ProgressBarT.ForeColor = Color.Blue;
            ProgressBarT.Control = progressBar1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value >= progressBar1.Maximum)
                timer1.Stop();
            else
            {
                progressBar1.Value = progressBar1.Value + 2;
                ProgressBarT.Text = ((float)((float)progressBar1.Value / (float)progressBar1.Maximum) * 100).ToString() + "%";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
