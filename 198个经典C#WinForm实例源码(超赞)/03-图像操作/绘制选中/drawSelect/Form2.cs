using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace drawSelect
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        bool isdown=false;
        int px;
        int py;
        int px2;
        int py2;
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isdown = true;
                px = e.X;
                py = e.Y;
                panel1.Location = new Point(px, py);
            }
            else
            {
                Application.Exit();
            }
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isdown)
            {
                px2 = e.X;
                py2 = e.Y;

                panel1.Visible = true;
                panel1.Width = px2 - px;
                panel1.Height = py2- py;


                //Graphics g = this.CreateGraphics();
                //g.DrawRectangle(new Pen(Color.Red, 2), px, py, px2 - px, py2 - py);
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            isdown = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
