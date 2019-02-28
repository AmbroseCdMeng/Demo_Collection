using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
namespace fingerprint
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        [DllImport("kernel32")]
        public static extern int Beep(int dwFreg,int dwDuration);

        SqlConnection conn;
        SqlCommand cmd;

        private void Form2_Load(object sender, EventArgs e)
        {
            axZKFPEngX1.InitEngine();//连接指纹仪
            cbbDep.SelectedIndex = 0;//获取当前选定项的索引
            cbbJob.SelectedIndex = 0;
            cbbSex.SelectedIndex = 0;
            conn = new SqlConnection("server=.;database=db_finger;uid=sa;pwd=");//设置连接的数据库
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")//如果没有输入员工姓名
            {
                MessageBox.Show("请输入员工姓名","警告",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                string uname = txtName.Text.Trim();//记录员工姓名
                string usex = cbbSex.Text.Trim();//记录员工性别
                string udep = cbbDep.Text.Trim();//记录员工部门
                string ujob = cbbJob.Text.Trim();//记录员工职务
                string uinfo = txtInfo.Text.Trim();//记录员工备份
                conn.Open();//连接数据库
                string finger = axZKFPEngX1.GetTemplateAsString();//获取当前指纹图片的字符串
                cmd = new SqlCommand("select count(*) from tb_finger where Ufinger='" + uname + "'", conn);//查找当前员工是否已存在
                int N =Convert.ToInt32( cmd.ExecuteScalar());//获取查找的记录数
                if (N > 0)//如果有记录
                {
                    //数据库中已有该员工
                    if (MessageBox.Show("此员工指纹已经添加过了！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        txtName.Text = "";//清空
                        txtName.Focus();//获取焦点
                        conn.Close();//关闭数据库的连接
                    }
                }
                else
                {
                    //向数据表中插入当有员工的信息
                    SqlCommand cmd1 = new SqlCommand("insert into tb_finger(Uname,Usex,Udep,Ujob,Uinfo,Ufinger) values('" + uname.Trim() + "','" + usex + "','" + udep + "','" + ujob + "','" + uinfo + "','"+finger+"')", conn);
                    int i = cmd1.ExecuteNonQuery();//获取SQL影响的行数
                    if (i > 0)//插入成功
                    {
                        MessageBox.Show("指纹录入成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    conn.Close();//断开数据库的连接
                }
            }
        }

        private void axZKFPEngX1_OnImageReceived(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            Graphics canvas = panel1.CreateGraphics();
            axZKFPEngX1.PrintImageAt(canvas.GetHdc().ToInt32(), 0, 0, panel1.Width, panel1.Height);
            canvas.Dispose();
            Beep(3000,100);
        }

        private void axZKFPEngX1_OnFeatureInfo(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnFeatureInfoEvent e)
        {
            String sTemp = "";
            int j = 0;
            if (axZKFPEngX1.IsRegister)
            {
                j = axZKFPEngX1.EnrollIndex - 1;
                sTemp = "Register status: still press finger " + j.ToString() + " times!";
            }
            sTemp = sTemp + "指纹质量";
            if (e.aQuality != 0)
                sTemp = sTemp + "不好";
            else
                sTemp = sTemp + "好";
            if (sTemp.Trim() == "指纹质量好")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            axZKFPEngX1.EndEngine();
        }

        private void axZKFPEngX1_OnCapture(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEvent e)
        {
            bool temp = false;
            string tp = "";
            string Ntemp = axZKFPEngX1.GetTemplateAsString();//获取当前指纹图片的字符串
            SqlConnection conn = new SqlConnection("server=.;database=db_finger;uid=sa;pwd=");//设置数据库的连接
            conn.Open();//连接数据库
            SqlCommand cmd = new SqlCommand("select * from tb_finger", conn);//查找表中的所有信息
            SqlDataReader sdr = cmd.ExecuteReader();//执行SQL语句
            while (sdr.Read())//读取表中的数据
            {
                string Ofinger = sdr["Ufinger"].ToString();//获取数据表中已存在的指纺图片的字符串
                if (axZKFPEngX1.VerFingerFromStr(ref Ofinger, Ntemp, false, ref temp))//如果两个图片相同
                {
                    button1.Enabled = false;//禁止信息的插入
                    MessageBox.Show("该指纹已经录入","警告",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    button1.Enabled = true;
                }
            }

        }
    }
}
