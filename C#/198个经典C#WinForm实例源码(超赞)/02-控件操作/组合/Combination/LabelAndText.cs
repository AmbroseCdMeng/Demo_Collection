using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Combination
{
    public partial class LabelAndText : UserControl
    {
        public LabelAndText()
        {
            InitializeComponent();
        }

        private string TLabelText = "";
        [Browsable(true), Category("设置控件"), Description("设置Label控件的Text属性")]
        public string LabelText
        {
            get { return TLabelText; }
            set
            {
                TLabelText = value;
                Invalidate();
            }
        }

        private string TTextBoxText = "";
        [Browsable(true), Category("设置控件"), Description("设置TextBox控件的Text属性")]
        public string TextBoxText
        {
            get { return TTextBoxText; }
            set
            {
                TTextBoxText = value;
                Invalidate();
            }
        }

        private void LabelAndText_Paint(object sender, PaintEventArgs e)
        {
            if (LabelText.Length > 0)
                label1.Text = LabelText;
            if (TextBoxText.Length > 0)
                textBox1.Text = TextBoxText;
            this.Width = label1.Width + textBox1.Width + 1;
            label1.Left = 0;
            textBox1.Left = label1.Width + 1;
        }
    }
}
