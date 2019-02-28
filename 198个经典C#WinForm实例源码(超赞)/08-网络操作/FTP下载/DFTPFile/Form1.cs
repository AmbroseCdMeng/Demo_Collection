using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace DFTPFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(textBox1.Text);
            ftpRequest.Credentials = new NetworkCredential(textBox2.Text,textBox3.Text);
            FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            Stream data = ftpResponse.GetResponseStream();
            string str = textBox1.Text.Substring(textBox1.Text.LastIndexOf("/"), textBox1.Text.Length - textBox1.Text.LastIndexOf("/"));
            string SavePath = str;
            if (File.Exists(SavePath))
            {
                File.Delete(str);
            }
            byte[] buffer = new byte[4096];
            FileStream stream  =new FileStream(SavePath,FileMode.Create);
            int count = 0;
            do
            {
                count = data.Read(buffer, 0, buffer.Length);
                if (count > 0)
                {
                    stream.Write(buffer, 0, count);
                }
            }
            while (count > 0);
            ftpResponse.Close();
            stream.Close();
        }
    }
}