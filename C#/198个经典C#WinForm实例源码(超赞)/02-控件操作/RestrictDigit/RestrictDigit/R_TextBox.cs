using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RestrictDigit
{
    public partial class R_TextBox : TextBox
    {
        public R_TextBox()
        {
            InitializeComponent();
        }

        string strleng = "";

        private int TDigit = 10;
        [Browsable(true), Category("限定位数文本框"), Description("位数设置")]
        public int Digit
        {
            get { return TDigit; }
            set
            {
                TDigit = value;
            }
        }

        private void R_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            strleng = Text + e.KeyChar.ToString();
            if (strleng.Length > Digit)
            {
                if (this.SelectedText.Length == 0)
                    e.Handled = true;
            }
        }
    }
}
