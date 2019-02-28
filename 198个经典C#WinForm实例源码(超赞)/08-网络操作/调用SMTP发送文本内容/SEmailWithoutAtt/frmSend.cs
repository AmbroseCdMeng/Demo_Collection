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
        //���ʼ����ݽ��б���
        private static string Base64Encode(string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }

        private void SendEmail(MailMessage message)
        {
            message.Subject = Base64Encode(txtSubject.Text);    //���÷����ʼ�������
            message.Body = Base64Encode(txtContent.Text);       //���÷����ʼ�������
            //ʵ����SmtpClient�ʼ����������
            SmtpClient client = new SmtpClient(txtServer.Text, Convert.ToInt32(txtPort.Text));
            //����������֤��������ݵ�ƾ��
            client.Credentials = new System.Net.NetworkCredential(txtName.Text, txtPwd.Text);
            //�����ʼ�
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
                    //�����ʼ������˺ͽ�����
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
                    MessageBox.Show("���ͳɹ�");
                }
            }
            catch
            {
                MessageBox.Show("����ʧ��!");
            }
        }

        private void frmSend_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #region  ��֤����ΪEmail
        /// <summary>
        /// ��֤����ΪEmail
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