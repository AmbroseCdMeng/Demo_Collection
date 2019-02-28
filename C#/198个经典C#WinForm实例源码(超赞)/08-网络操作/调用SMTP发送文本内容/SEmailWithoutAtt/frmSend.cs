using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SEmailWithoutAtt
{
    public partial class frmSend : Form
    {
        public frmSend()
        {
            InitializeComponent();
        }
        //对邮件内容进行编码
        private static string Base64Encode(string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }

        private void SendEmail(MailMessage message)
        {
            message.Subject = Base64Encode(txtSubject.Text);    //设置发送邮件的主题
            message.Body = Base64Encode(txtContent.Text);       //设置发送邮件的内容
            //实例化SmtpClient邮件发送类对象
            SmtpClient client = new SmtpClient(txtServer.Text, Convert.ToInt32(txtPort.Text));
            //设置用于验证发件人身份的凭据
            client.Credentials = new System.Net.NetworkCredential(txtName.Text, txtPwd.Text);
            //发送邮件
            client.Send(message);
        }

        private void frmSend_Load(object sender, EventArgs e)
        {
            txtServer.Text = Dns.GetHostName();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateEmail(txtSend.Text))
                {
                    //设置邮件发送人和接收人
                    MailMessage message = null;
                    if (txtTo.Text.IndexOf(",") != -1)
                    {
                        string[] strEmail = txtTo.Text.Split(',');
                        string sumEmail = "";
                        for (int i = 0; i < strEmail.Length; i++)
                        {
                            sumEmail = strEmail[i];
                            message = new MailMessage(new MailAddress(txtSend.Text), new MailAddress(sumEmail));
                            SendEmail(message);
                        }
                    }
                    else
                    {
                        message = new MailMessage(new MailAddress(txtSend.Text), new MailAddress(txtTo.Text));
                        SendEmail(message);
                    }
                    MessageBox.Show("发送成功");
                }
            }
            catch
            {
                MessageBox.Show("发送失败!");
            }
        }

        private void frmSend_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #region  验证输入为Email
        /// <summary>
        /// 验证输入为Email
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool validateEmail(string str)
        {
            return Regex.IsMatch(str, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }
        #endregion
    }
}