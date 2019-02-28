using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;
namespace NoteCatVote
{
    class DataClass
    {
        public static string jcom="";
        public static string btl="";
        public static string power = "YIWU-IJDD-CDQW-JDWG";

        public static OleDbConnection DataConn()
        {
            string strg = Application.StartupPath.ToString();
            strg = strg.Substring(0, strg.LastIndexOf("\\"));
            strg = strg.Substring(0, strg.LastIndexOf("\\"));
            strg += @"\db.mdb";
            return new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strg);
        }

        public static int ExecuteSQL(string sql)
        {
            int flag = 0;
            OleDbConnection conn = DataConn();
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql,conn);
            flag=cmd.ExecuteNonQuery();
            conn.Close();
            return flag;
        }

        public static void BindDataGridView(DataGridView dg,string sql)
        {
            OleDbConnection conn = DataConn();
            OleDbDataAdapter sda = new OleDbDataAdapter(sql,conn);
            DataTable dt=new DataTable();
            sda.Fill(dt);
            dg.DataSource = dt.DefaultView;
        }

        public static void GetInfo(TextBox tb,TextBox tb2,TextBox tb3, ComboBox cb, string str)
        {
            OleDbConnection conn = DataConn();
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(str, conn);
            OleDbDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            tb.Text = sdr["Item"].ToString();
            tb2.Text = sdr["Ballot"].ToString();
            tb3.Text=sdr["content"].ToString();
            string pp = sdr["IsRelease"].ToString();
            if (pp == "0")
            {
                cb.SelectedIndex = 1;
            }
            else
            {
                cb.SelectedIndex = 0;
            }
            sdr.Close();
            conn.Close();
        }

        public static void GetVote(Label lb1,Label lb2,Label lb3,Label lb4,
            ProgressBar pb1,ProgressBar pb2,ProgressBar pb3,ProgressBar pb4,
            Label lb11,Label lb12,Label lb13,Label lb14)
        {
            string sql = "select top 4 * from tb_Vote where IsRelease=1";
            OleDbConnection conn = DataConn();
            OleDbDataAdapter sda = new OleDbDataAdapter(sql,conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            lb1.Text = ds.Tables[0].Rows[0][1].ToString();
            lb2.Text = ds.Tables[0].Rows[1][1].ToString();
            lb3.Text = ds.Tables[0].Rows[2][1].ToString();
            lb4.Text = ds.Tables[0].Rows[3][1].ToString();
            int num = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString()) + Convert.ToInt32(ds.Tables[0].Rows[1][2].ToString())
                + Convert.ToInt32(ds.Tables[0].Rows[2][2].ToString()) + Convert.ToInt32(ds.Tables[0].Rows[3][2].ToString());
            pb1.Maximum = num;
            pb2.Maximum = num;
            pb3.Maximum = num;
            pb4.Maximum = num;

            pb1.Value = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());
            pb2.Value = Convert.ToInt32(ds.Tables[0].Rows[1][2].ToString());
            pb3.Value = Convert.ToInt32(ds.Tables[0].Rows[2][2].ToString());
            pb4.Value = Convert.ToInt32(ds.Tables[0].Rows[3][2].ToString());

            lb11.Text = ds.Tables[0].Rows[0][2].ToString() + "票";
            lb12.Text = ds.Tables[0].Rows[1][2].ToString() + "票";
            lb13.Text = ds.Tables[0].Rows[2][2].ToString() + "票";
            lb14.Text = ds.Tables[0].Rows[3][2].ToString() + "票";
        }

        public static int DataNum()
        {
            int i = 0;
            OleDbConnection conn = DataConn();
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("select count(*) from tb_Vote", conn);
            i = (int)cmd.ExecuteScalar();
            conn.Close();
            return i;
        }


        public static void AddData(string num, string content)
        {
            OleDbConnection conn = DataConn();
            conn.Open();
            string str = "select count(*) from tb_Resvice where smsnum='"+num+"'";
            OleDbCommand cmd = new OleDbCommand(str,conn);
            int i = (int)cmd.ExecuteScalar();
            if (i > 0)
            {
            }
            else
            {
                cmd = new OleDbCommand("insert into tb_Resvice([smsnum],[smscontent]) values('" + num + "','" + content + "')", conn);
                cmd.ExecuteNonQuery();
                string sql = "select * from tb_Vote";
                OleDbDataAdapter sda = new OleDbDataAdapter(sql,conn);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    if (ds.Tables[0].Rows[j][3].ToString() == content)
                    {
                        string newstr = "update tb_Vote set Ballot=Ballot+1 where content='"+content.ToLower()+"'";
                        cmd = new OleDbCommand(newstr,conn);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            conn.Close();
        }

        public static void InceptNote()//接收短信
        {
           jcom = GSM.GSMModemGetDevice();　　 //ＣＯＭ１
           btl = GSM.GSMModemGetBaudrate();　　//波特率
           //连接设备
           if (GSM.GSMModemInitNew(jcom, btl, null, null, false, power) == false)
           {
               MessageBox.Show("设备连接失败!" + GSM.GSMModemGetErrorMsg(), "提示", MessageBoxButtons.OK);
               return;
            }
            string smscontent = GSM.GSMModemSMSReadAll(1);
            if (smscontent != null)
            {
                string newstr = smscontent.Replace("||", "#");
                string[] scontent = newstr.Split('#');
                string smscon = "";
                for (int i = 0; i < scontent.Length; i++)
                {
                    smscon = scontent[i];
                    string[] a = smscon.Split('|');
                    string b = "";
                    b = a[0].ToString();
                    if (b.Length < 11 && smscon != "")
                    {
                        string smsstr = b;
                        string smscot = scontent[i].Substring(b.Length, scontent[i].Length - b.Length).Replace("|", "");
                        AddData(smsstr, smscot);
                    }
                    else
                    {
                        if (smscon != "")
                        {
                            if (scontent[i].Substring(0, 1) == "|")
                            {
                                string smsstr = scontent[i].Substring(3, scontent[i].Length - 3).Substring(0, 11);
                                string smscot = scontent[i].Substring(14, scontent[i].Length - 14).Replace("|", "");
                                AddData(smsstr, smscot);
                            }
                            else
                            {
                                string smsstr = scontent[i].Substring(2, scontent[i].Length - 2).Substring(0, 11);
                                string smscot = scontent[i].Substring(13, scontent[i].Length - 13).Replace("|", "");
                                AddData(smsstr, smscot);
                            }
                        }
                    }
                }
            }
        }

    }

    class GSM
    {
        //初始化gsm modem,并连接gsm modem
        [DllImport("dllforvc.dll",
             EntryPoint = "GSMModemInitNew",
             CharSet = CharSet.Ansi,
             CallingConvention = CallingConvention.StdCall)]
        public static extern bool GSMModemInitNew(
            string device,//通讯端口
            string baudrate,//波特率
            string initstring,
            string charset,
            bool swHandshake,
            string sn//序列号
            );

        //获取短信猫新的标识号码
        [DllImport("dllforvc.dll",
             EntryPoint = "GSMModemGetSnInfoNew",
             CharSet = CharSet.Ansi,
             CallingConvention = CallingConvention.StdCall)]
        public static extern string GSMModemGetSnInfoNew(string device, string baudrate);

        //获取当前通讯端口
        [DllImport("dllforvc.dll",
             EntryPoint = "GSMModemGetDevice",
             CharSet = CharSet.Ansi,
             CallingConvention = CallingConvention.StdCall)]
        public static extern string GSMModemGetDevice();

        //获取当前通讯波特率
        [DllImport("dllforvc.dll",
             EntryPoint = "GSMModemGetBaudrate",
             CharSet = CharSet.Ansi,
             CallingConvention = CallingConvention.StdCall)]
        public static extern string GSMModemGetBaudrate();

        //断开连接并释放内存空间		
        [DllImport("dllforvc.dll",
             EntryPoint = "GSMModemRelease",
             CharSet = CharSet.Ansi,
             CallingConvention = CallingConvention.StdCall)]
        public static extern void GSMModemRelease();

        //取得错误信息	
        [DllImport("dllforvc.dll",
             EntryPoint = "GSMModemGetErrorMsg",
             CharSet = CharSet.Ansi,
             CallingConvention = CallingConvention.StdCall)]
        public static extern string GSMModemGetErrorMsg();

        //发送短信息
        [DllImport("dllforvc.dll",
             EntryPoint = "GSMModemSMSsend",
             CharSet = CharSet.Ansi,
             CallingConvention = CallingConvention.StdCall)]
        public static extern bool GSMModemSMSsend(
            string serviceCenterAddress,
            int encodeval,
            string text,
            int textlen,
            string phonenumber,
            bool requestStatusReport);

        //接收短信息返回字符串格式为:手机号码|短信内容||手机号码|短信内容||
        //RD_opt为１接收短信息后不做任何处理，０为接收后删除信息
        [DllImport("dllforvc.dll",
             EntryPoint = "GSMModemSMSReadAll",
             CharSet = CharSet.Ansi,
             CallingConvention = CallingConvention.StdCall)]
        public static extern string GSMModemSMSReadAll(int RD_opt);
    }
}
