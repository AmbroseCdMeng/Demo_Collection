using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Net;
namespace DynamicTaskStock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Thread td;
        private TcpListener tcpListener;
        string message="";
        private void Form1_Load(object sender, EventArgs e)
        {
            td = new Thread(new ThreadStart(this.StartListen));
            td.Start();
        }

        private void StartListen()
        {
            tcpListener = new TcpListener(888);
            tcpListener.Start();
            while (true)
            {
                TcpClient tclient = tcpListener.AcceptTcpClient();  //接受连接请求
                NetworkStream nstream = tclient.GetStream();        //获取数据流
                byte[] mbyte = new byte[1024];                      //建立缓存
                int i = nstream.Read(mbyte, 0, mbyte.Length);       //将数据流写入缓存
                message = Encoding.Default.GetString(mbyte, 0, i);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.tcpListener != null)
            {
                tcpListener.Stop();
            }
            if (td != null)
            {
                if (td.ThreadState == ThreadState.Running)
                {
                    td.Abort();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress[] ip = Dns.GetHostAddresses(Dns.GetHostName());
                string message ="你好兄弟";
                TcpClient client = new TcpClient(txtAdd.Text, 888);
                NetworkStream netstream = client.GetStream();
                StreamWriter wstream = new StreamWriter(netstream, Encoding.Default);
                wstream.Write(message);
                wstream.Flush();
                wstream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool k = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (message.Length > 0)
            {
                if (k)
                {
                    notifyIcon1.Icon = Properties.Resources._1;
                    k = false;
                }
                else
                {
                    notifyIcon1.Icon = Properties.Resources._2;
                    k = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            message = "";
            notifyIcon1.Icon = Properties.Resources._3;
        }
    }
}
