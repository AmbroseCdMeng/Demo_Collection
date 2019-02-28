using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FocusChangeColor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.CornflowerBlue;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                int n = Convert.ToInt32(((TextBox)sender).Tag.ToString());
                Clear_Control(this.Controls, n, 6);
            }
        }

        #region  遍历指定的控件
        /// <summary>
        /// 遍历指定的控件
        /// </summary>
        /// <param Con="ControlCollection">可视化控件</param>
        /// <param n="int">控件标识</param>
        /// <param m="int">最大标识</param>
        public void Clear_Control(Control.ControlCollection Con, int n, int m)
        {
            int tem_n=0;
            foreach (Control C in Con)
            { //遍历可视化组件中的所有控件
                if (C.GetType().Name == "TextBox")  //判断是否为TextBox控件
                {
                    if (n == m)
                        tem_n = 1;
                    else
                        tem_n = n + 1;
                    if (Convert.ToInt32(((TextBox)C).Tag.ToString())==tem_n)
                        ((TextBox)C).Focus();   //清空当前控件
                }
            }
        }
        #endregion
    }
}
