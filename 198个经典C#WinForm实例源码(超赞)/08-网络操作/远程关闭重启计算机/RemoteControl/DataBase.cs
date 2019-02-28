using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace RemoteControl
{
    //=====================================================
    //Copyright (C) 2008-2009 小科
    //All rights reserved
    //CLR版本:            2.0.50727.1433
    //新建项输入的名称: DataBase
    //机器名称:            MRWXK
    //命名空间名称:      RemoteControl
    //文件名:              DataBase
    //当前系统时间:      2008-11-26 13:42:40
    //当前登录用户名:   Administrator
    //创建年份:           2008
    //http://www.mingribook.com
    //======================================================
    class DataBase
    {
        OleDbConnection oledbcon;
        OleDbCommand oledbcmd;
        OleDbDataAdapter oledbda;
        DataSet myds;

        public OleDbConnection getCon()
        {
            oledbcon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_RemoteControl.mdb;");
            return oledbcon;
        }

        public void getCmd(string strSql)
        {
            oledbcon = getCon();
            oledbcmd = new OleDbCommand(strSql, oledbcon);
            oledbcon.Open();
            oledbcmd.ExecuteNonQuery();
            oledbcon.Close();
        }

        public DataSet getDs(string strSql)
        {
            oledbcon = getCon();
            oledbda = new OleDbDataAdapter(strSql, oledbcon);
            myds = new DataSet();
            oledbda.Fill(myds);
            return myds;
        }
    }
}
