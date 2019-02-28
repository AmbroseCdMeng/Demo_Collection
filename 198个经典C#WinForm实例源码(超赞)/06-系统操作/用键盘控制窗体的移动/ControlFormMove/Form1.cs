using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlFormMove
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Point point = this.Location;
            switch (e.KeyData)
            {
                case Keys.Up:
                    point.Y -= 2;
                    break;
                case Keys.Down:
                    point.Y += 2;
                    break;
                case Keys.Right:
                    point.X += 2;
                    break;
                case Keys.Left:
                    point.X -= 2;
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                default: break;
            }
            this.Location = point;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.KeyPreview = true;
        }
    }
}
