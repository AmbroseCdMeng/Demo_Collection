using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace listviewItemAdd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class CustomListView : ListView
        {
            public CustomListView()
            {
                SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
                UpdateStyles();
            }
        }
        CustomListView clv = new CustomListView();


        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Add(i.ToString());
            i+=100;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clv.Width = 304;
            clv.Height = 112;
            panel1.Controls.Add(clv);
        }
        int j = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            clv.Items.Add(j.ToString());
            j += 100;
        }
    }
}
