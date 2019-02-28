using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections;
namespace IDCard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public delegate int HookProc(int nCode, int wParam, IntPtr lParam);
        static int hHook = 0;
        public const int WH_KEYBOARD_LL = 13;
        //LowLevel键盘截获，如果是WH_KEYBOARD＝2，并不能对系统键盘截取，Acrobat Reader会在你截取之前获得键盘。  
        HookProc KeyBoardHookProcedure;
        [DllImport("kernel32")]
        public static extern int Beep(int dwFreq, int dwDuration);//让计算机蜂鸣
        string DataPath = "";//数据库路径
        OleDbConnection con;//OleDbConnection对象，连接数据库
        OleDbCommand cmd;//OleDbCommand对象，执行SQL语句
        //键盘Hook结构函数  
        [StructLayout(LayoutKind.Sequential)]
        public class KeyBoardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }
        [DllImport("user32.dll")]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        //抽掉钩子  
        public static extern bool UnhookWindowsHookEx(int idHook);
        [DllImport("user32.dll")]
        //调用下一个钩子  
        public static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        public string  getNum(string code)
        {
            string flag = "";
            switch (code)
            {
                case "048":
                    flag="0"; break;
                case "049":
                    flag = "1"; break;
                case "050":
                    flag = "2"; break;
                case "051":
                    flag = "3"; break;
                case "052":
                    flag = "4"; break;
                case "053":
                    flag = "5"; break;
                case "054":
                    flag = "6"; break;
                case "055":
                    flag = "7"; break;
                case "056":
                    flag = "8"; break;
                case "057":
                    flag = "9"; break;
            }
            return flag;
        }
        public void Hook_Start()
        {

            // 安装键盘钩子  
            if (hHook == 0)
            {
                KeyBoardHookProcedure = new HookProc(KeyBoardHookProc);
                hHook = SetWindowsHookEx(WH_KEYBOARD_LL,
                          KeyBoardHookProcedure,
                        GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
                //如果设置钩子失败.  
                if (hHook == 0)
                {
                    Hook_Clear(); 
                }
            }
        }

        //取消钩子事件  
        public void Hook_Clear()
        {
            bool retKeyboard = true;
            if (hHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hHook);
                hHook = 0;
            }
            //如果去掉钩子失败.  
            if (!retKeyboard) throw new Exception("UnhookWindowsHookEx failed.");
        }

        //这里可以添加自己想要的信息处理  
        string NumCode="";
        public int KeyBoardHookProc(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                if (wParam == 0x0104 || wParam == 0x0100)
                {
                    KeyBoardHookStruct kbh = (KeyBoardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyBoardHookStruct));
                    int flag = kbh.vkCode;
                    switch (flag)
                    {
                        case 96:
                            NumCode += "0"; break;
                        case 97:
                            NumCode += "1"; break;
                        case 98:
                            NumCode += "2"; break;
                        case 99:
                            NumCode += "3"; break;
                        case 100:
                            NumCode += "4"; break;
                        case 101:
                            NumCode += "5"; break;
                        case 102:
                            NumCode += "6"; break;
                        case 103:
                            NumCode += "7"; break;
                        case 104:
                            NumCode += "8"; break;
                        case 105:
                            NumCode += "9"; break;
                    }

                    if (flag == 13)
                    {
                        if (NumCode.Length != 0)
                        {
                            string c = "";
                            string id = "";
                            for (int i = 0; i <= NumCode.Length - 3; i += 3)
                            {
                                string b = NumCode.Substring(i, 3);
                                c += getNum(b);
                            }
                            id = c;
                            if (id.Length == 8)//如果卡号为8位
                            {
                                //实例化OleDbConnection对象
                                con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + DataPath);
                                con.Open();//打开数据库连接
                                //实例化OleDbCommand对象，根据ID卡号检索数据表
                                cmd = new OleDbCommand("select * from tb_UserInfo where CardID='" + id + "'", con);
                                OleDbDataReader sdr = cmd.ExecuteReader();//实例化OleDbDataReader对象
                                sdr.Read();//读取记录
                                txtShowCardID.Text = id;//获取ID卡号
                                txtShowName.Text = sdr["UName"].ToString();//获取员工姓名
                                cbbShowSex.Text = sdr["USex"].ToString();//获取员工性别
                                cbbShowDep.Text = sdr["UDep"].ToString();//获取员工部门
                                con.Close();//关闭数据库连接
                                Beep(3000, 100);//计算机蜂鸣
                            }
                            NumCode = "";
                        }
                    }

                }
            }
            return CallNextHookEx(hHook, nCode, wParam, lParam);
        } 



        private void Form1_Load(object sender, EventArgs e)
        {
            cbbdep.SelectedIndex = 0;//设置部门下拉框的第一项被选中
            cbbsex.SelectedIndex = 0;//设置性别下拉框的第一项被选中
            //获取数据库路径
            DataPath = Application.StartupPath.ToString();
            DataPath = DataPath.Substring(0, DataPath.LastIndexOf("\\"));
            DataPath = DataPath.Substring(0, DataPath.LastIndexOf("\\"));
            DataPath += @"\db.mdb";
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox1.Enabled = true;
                Hook_Clear();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                groupBox1.Enabled = false;
                Hook_Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtIdcard.Text = "";
            txtName.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtIdcard.Text == "" || txtName.Text == "")//如果没有输入ID卡号和员工姓名
            {
                //弹出警告信息
                if (MessageBox.Show("请将数据填写完整！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    if (txtIdcard.Text == "")//如果没有输入ID卡号
                        txtIdcard.Focus();//则光标处在输入ID卡号的文本框
                    if (txtName.Text == "")//如果没有输入员工姓名
                        txtName.Focus();//则光标处在输入员工姓名的文本框
                    if (txtIdcard.Text == "" && txtName.Text == "")//如果都没输入数据
                        txtIdcard.Focus();//则光标处在输入ID卡号的文本框
                }
            }
            else//如果输入了数据
            {
                if (txtIdcard.Text.Trim().Length != 8)//如果输入的ID卡号不是8位
                {
                    //弹出警告信息
                    if (MessageBox.Show("ID卡号必须为8位！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        txtIdcard.Text = "";//清空输入ID卡号的文本框
                        txtIdcard.Focus();//让光标处在输入ID卡号的文本框上
                    }
                }
                else//如果输入的ID卡号为8位
                {
                    //实例化OleDbConnection对象
                    con=new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + DataPath);
                    con.Open();//打开连接
                    //实例化OleDbCommand对象
                    cmd = new OleDbCommand("select count(*) from tb_UserInfo where CardID='"+txtIdcard.Text.Trim()+"'", con);
                    int flag =Convert.ToInt32(cmd.ExecuteScalar());//判断是否已经添加过此ID卡号
                    if (flag > 0)//如果大于0则说明已经添加过
                    {
                        //弹出警告信息
                        if (MessageBox.Show("ID卡号已经添加过了！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                        {
                            button2_Click(sender, e);//清空输入ID卡号和员工姓名的文本框
                        }
                    }
                    else//如果小于0说明没有添加过
                    {
                        //实例化OleDbCommand对象
                        cmd = new OleDbCommand("insert into tb_UserInfo(CardID,UName,USex,UDep) values ('" + txtIdcard.Text.Trim() + "','" + txtName.Text.Trim() + "','" + cbbsex.Text.Trim() + "','" + cbbdep.Text.Trim() + "')", con);
                        int k = cmd.ExecuteNonQuery();//执行insert语句，将输入的信息添加到数据库中
                        if (k > 0)//如果大于0则操作成功
                        {
                            //弹出提示信息
                            if (MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                button2_Click(sender, e);//清空输入ID卡号和员工姓名的文本框
                            }
                        }
                    }
                    con.Close();//关闭数据库连接
                }
            }
        }

        private void txtIdcard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar <= '9' && e.KeyChar >= '0') && e.KeyChar != '\r' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
