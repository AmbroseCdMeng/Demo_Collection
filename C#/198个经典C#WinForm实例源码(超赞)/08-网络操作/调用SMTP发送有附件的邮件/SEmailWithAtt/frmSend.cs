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

namespace SEmailWithAtt
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

        private void AddFile(string strFile,MailMessage message)
        {
            //ΪҪ���͵��ʼ�����������Ϣ
            Attachment myAttachment = new Attachment(strFile, System.Net.Mime.MediaTypeNames.Application.Octet);
            //Ϊ�������ʱ����Ϣ
            System.Net.Mime.ContentDisposition disposition = myAttachment.ContentDisposition;
            disposition.CreationDate = System.IO.File.GetCreationTime(strFile);
            disposition.ModificationDate = System.IO.File.GetLastWriteTime(strFile);
            disposition.ReadDate = System.IO.File.GetLastAccessTime(strFile);
            message.Attachments.Add(myAttachment);			//�������ĸ�����ӵ��ʼ���
        }

        private void SendEmail(MailMessage message)
        {
            message.Subject = Base64Encode(txtSubject.Text);    //���÷����ʼ�������
            message.Body = Base64Encode(txtContent.Text);       //���÷����ʼ�������
            if (txtAttachment.Text != "")
            {
                if (txtAttachment.Text.IndexOf(",") != 0)
                {
                    string[] strAttachment = txtAttachment.Text.Split(',');
                    for (int i = 0; i < strAttachment.Length; i++)
                    {
                        AddFile(strAttachment[i], message);
                    }
                }
                else
                {
                    AddFile(txtAttachment.Text, message);
                }
            }
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (txtAttachment.Text == "")
                {
                    txtAttachment.Text = openFileDialog.FileName;
                }
                else
                {
                    txtAttachment.Text += "," + openFileDialog.FileName;
                }
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