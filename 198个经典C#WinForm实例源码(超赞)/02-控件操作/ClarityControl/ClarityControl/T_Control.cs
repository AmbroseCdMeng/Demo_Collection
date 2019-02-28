using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClarityControl
{
    public partial class T_Control : UserControl
    {
        public T_Control()
        {
            InitializeComponent();
        }

        private void TransparencyButton_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.Transparent;//使当前控件透明
        }
    }
}
