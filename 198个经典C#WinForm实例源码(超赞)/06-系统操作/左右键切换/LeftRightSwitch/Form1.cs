using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LeftRightSwitch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SwapMouseButton")]
        public extern static int SwapMouseButton(int bSwap);

        private void button1_Click(object sender, EventArgs e)
        {
            SwapMouseButton(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SwapMouseButton(0);
        }
    }
}
