using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace numberConvert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string CNumToCh(string x)
        {
            //数字转换为中文后的数组 
            string[] num = new string[] { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
            //为数字位数建立一个位数组 
            string[] digit = new string[] { "", "拾", "佰", "仟" };
            //为数字单位建立一个单位数组 
            string[] units = new string[] { "", ",万,", ",亿,", ",万亿," };
            string returnValue = ""; //返回值 
            int finger = 0; //字符位置指针 
            int m = x.Length % 4; //取模 
            int k = 0;
            if (m > 0)
                k=x.Length / 4 + 1;
            else
                k=x.Length / 4;
            //外层循环,四位一组,每组最后加上单位: ",万亿,",",亿,",",万," 
            for (int i = k; i > 0; i--)
            {
                int L = 4;
                if (i == k && m != 0)
                    L = m;
                //得到一组四位数 
                string four = x.Substring(finger, L);
                int l = four.Length;
                //内层循环在该组中的每一位数上循环  
                for (int j = 0; j < l; j++)
                {
                    //处理组中的每一位数加上所在的位 
                    int n = Convert.ToInt32(four.Substring(j, 1));
                    if (n == 0)
                    {
                        if (j < l - 1&& Convert.ToInt32(four.Substring(j + 1, 1)) > 0 && !returnValue.EndsWith(num[n]))
                            returnValue += num[n];
                    }
                    else
                    {
                        if (!(n == 1 && (returnValue.EndsWith(num[0]) | returnValue.Length == 0) && j == l - 2))
                            returnValue += num[n];
                        returnValue += digit[l - j - 1];
                    }
                }
                finger += L;
                //每组最后加上一个单位:",万,",",亿," 等 
                if (i < k) //如果不是最高位的一组 
                {
                    if (Convert.ToInt32(four) != 0)
                        //如果所有4位不全是0则加上单位",万,",",亿,"等 
                        returnValue += units[i - 1];
                }
                else
                {
                    //处理最高位的一组,最后必须加上单位 
                    returnValue += units[i - 1];
                }
            }
            return returnValue;
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtStr.Text.Trim() == "")
            {
                return;
            }
            else
            {
                if (txtStr.Text.Trim().Length > 16)
                {
                    MessageBox.Show("数字金额太大！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (txtStr.Text.Trim().Substring(0, 1) == "0")
                    {
                        MessageBox.Show("请正确输入金额！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        richTextBox1.Text = CNumToCh(txtStr.Text.Trim());
                    }
                }
            }
        }

        private void txtStr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar!=8&&!char.IsDigit(e.KeyChar))&&e.KeyChar!=13)
            {
                MessageBox.Show("请输入数字！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStr.Text = "";
                txtStr.Focus();
            }
        }
    }
}
