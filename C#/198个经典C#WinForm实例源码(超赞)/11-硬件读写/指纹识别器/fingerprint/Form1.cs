using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
namespace fingerprint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("kernel32")]
        public static extern int Beep(int dwFreg, int dwDuration);

        bool isConnected;//判断是否已经连接
        string savapath = "";

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (axZKFPEngX1.InitEngine() == 0)//初始化指纹仪
            {
                richTextBox1.Clear();//清空richTextBox1控件
                tsslInfo.Text = "指纹仪连接成功";//显示指纹仪连接成功
                richTextBox1.AppendText("初始化成功！" + "\n");
                richTextBox1.AppendText("设备总数：" + axZKFPEngX1.SensorCount.ToString() + "\n");//显示指纹仪总数
                richTextBox1.AppendText("图像宽度：" + axZKFPEngX1.ImageWidth.ToString() + "\n");//显示图片的宽度
                richTextBox1.AppendText("图像高度：" + axZKFPEngX1.ImageHeight.ToString() + "\n");//显示图片的高度
                txtCN.Text = axZKFPEngX1.SensorSN;//获取指纹仪的注册码
                isConnected = true;//标识，指纹仪连接成功
                toolStripButton1.Enabled = false;//连接按钮不可用
            }
            else
            {
                tsslInfo.Text = "指纹仪连接失败";//显示指纹仪连接失败
                richTextBox1.Clear();//清空richTextBox1控件
                isConnected = false;//标识，指纹仪连接失败
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string savapath = "";
            if (!isConnected) return;
            if (radioButton1.Checked)
            {
                axZKFPEngX1.SaveBitmap("c:\\ls_lb.bmp");
                savapath = "c:\\ls_lb.bmp";
            }
            else
            {
                axZKFPEngX1.SaveJPG("c:\\ls_lb.jpg");
                savapath = "c:\\ls_lb.jpg";
            }
            MessageBox.Show("指纹保存成功！保存位置：" + savapath, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        //设备获取到指纹图像或者通过AddImageFile和AddBitmap加入指纹图像时调用该事件
        private void axZKFPEngX1_OnImageReceived(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            Graphics canvas = panel1.CreateGraphics();//获取panel1控件的Graphics类
            axZKFPEngX1.PrintImageAt(canvas.GetHdc().ToInt32(), 0, 0, panel1.Width, panel1.Height);//在panel1控件上绘制指纹图片
            canvas.Dispose();//释放
            axZKFPEngX1.SaveBitmap("c:\\ls_lb.bmp");//存储指纹图片
            Beep(3000, 100);//发出声音
        }

        //在进行指纹验证模板时触发
        private void axZKFPEngX1_OnCapture(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEvent e)
        {
            if (e.actionResult)//如果成功取到指纹模板
            {
                lblName.Text = "";//清空
                lblsex.Text = "";
                lbldep.Text = "";
                lbljob.Text = "";
                bool temp = false;//定义布尔变量
                Graphics g = panel1.CreateGraphics();//获取panel1控件的Graphics类
                string tp = "";//记录是对比成功还是对比失败
                string Ntemp = axZKFPEngX1.GetTemplateAsString();//获取当前指纹图片的字符串
                SqlConnection conn = new SqlConnection("server=.;database=db_finger;uid=sa;pwd=");//设置要连接数据库
                conn.Open();//连接数据库
                SqlCommand cmd = new SqlCommand("select * from tb_finger", conn);//获取指定表中的信息
                SqlDataReader sdr = cmd.ExecuteReader();//执行查询
                while (sdr.Read())//遍历表中的信息
                {
                    string Ofinger = sdr["Ufinger"].ToString();//获取表中记录的图片信息
                    if (axZKFPEngX1.VerFingerFromStr(ref Ofinger, Ntemp, false, ref temp))//如果两个图片相同
                    {
                        lblName.Text = sdr["Uname"].ToString();//获取当前职工的名称
                        lblsex.Text = sdr["Usex"].ToString();//获取当前职工的性别
                        lbldep.Text = sdr["Udep"].ToString();//获取当前职工的部门
                        lbljob.Text = sdr["Ujob"].ToString();//获取当前职工的职务
                        tp = "考勤成功";//记录考勤成功
                        break;
                    }
                    else
                    {
                        tp = "考勤失败";
                    }

                }
                //在panel1控件的指定位置显示是否考勤成功
                g.DrawString(tp, new Font("黑体", 50, FontStyle.Bold), new SolidBrush(Color.Red), new PointF(18, 120));
            }
        }

        //取得指纹初始特征，设备取到指纹图像后触发
        private void axZKFPEngX1_OnFeatureInfo(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnFeatureInfoEvent e)
        {
            String sTemp = "";//定义字符串变量
            int j = 0;
            if (axZKFPEngX1.IsRegister)//如要登记指纹
            {
                j = axZKFPEngX1.EnrollIndex - 1;//设置当前登记指纹的有效次数
                sTemp = "Register status: still press finger " + j.ToString() + " times!";
            }
            sTemp = sTemp + " 指纹质量";
            if (e.aQuality != 0)//如果指纹质量不好
                sTemp = sTemp + "不好";
            else
                sTemp = sTemp + "好";
            tsslInfo.Text = sTemp;//显示当前指纹质量的好坏
            if (sTemp.Trim() == "指纹质量好")//如果指纹质量好
            {
                string imgpath = "c:\\ls_lb.bmp";

            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            string tem_s = "";
            string tem_d = "";
            if (radioButton1.Checked)
            {
                axZKFPEngX1.SaveBitmap("c:\\ls_lb.bmp");
                savapath = "c:\\ls_lb.bmp";
            }
            else
            {
                axZKFPEngX1.SaveJPG("c:\\ls_lb.jpg");
                savapath = "c:\\ls_lb.jpg";
            }
        }

        //指纹登记
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            axZKFPEngX1.EndEngine();//断开指纹仪的连接
            toolStripButton1.Enabled = true;//使用使连接按钮可用
            richTextBox1.Text = "";//清空
            tsslInfo.Text = "考勤结束";//显示考勤结束
            lblName.Text = "";
            lblsex.Text = "";
            lbldep.Text = "";
            lbljob.Text = "";
            txtCN.Text = "";
            panel1.Refresh();//控件强制重绘
            Form2 frm2 = new Form2();//实例化Form2类
            frm2.ShowDialog();//显示窗体

        }

        //断开连接
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = true;
            axZKFPEngX1.EndEngine();
            richTextBox1.Text = "";
            tsslInfo.Text = "考勤结束";
            lblName.Text = "";
            lblsex.Text = "";
            lbldep.Text = "";
            lbljob.Text = "";
            txtCN.Text = "";
            panel1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }
    }
}
