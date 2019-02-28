using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RestrictSize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int FrmWidth = 70;
        int FrmHeight = 70;
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.Width <= FrmWidth)
            {
                this.Width = FrmWidth;
            }
            if (this.Height <= FrmHeight)
            {
                this.Height = FrmHeight;
            }
        }
    }
}
