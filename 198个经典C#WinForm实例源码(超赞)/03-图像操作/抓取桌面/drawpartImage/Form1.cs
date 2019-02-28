using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace drawpartImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        private static extern int GetSystemMetrics(int mVal);
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap _Source = new Bitmap(GetSystemMetrics(0), GetSystemMetrics(1));
            using (Graphics g = Graphics.FromImage(_Source))
            {
                g.CopyFromScreen(0, 0, 0, 0, _Source.Size);
                g.Dispose();
            }
            pictureBox1.Image = _Source;
        }
    }
}
