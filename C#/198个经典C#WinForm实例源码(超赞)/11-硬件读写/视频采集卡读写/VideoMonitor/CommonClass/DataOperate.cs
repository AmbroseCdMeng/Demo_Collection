using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace VideoMonitor.CommonClass
{
    class DataOperate
    {
        DataCon datacon = new DataCon();
        OleDbConnection oledbcon;
        OleDbCommand oledbcom;
        OleDbDataAdapter oledbda;
        DataSet ds;

        #region 执行SQL语句
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="strCon">要执行的SQL语句</param>
        public void getCom(string strCon)
        {
            oledbcon = datacon.getCon();
            oledbcom = new OleDbCommand(strCon, oledbcon);
            oledbcon.Open();
            oledbcom.ExecuteNonQuery();
            oledbcon.Close();
        }
        #endregion

        #region 生成DataSet数据集
        /// <summary>
        /// 生成DataSet数据集
        /// </summary>
        /// <param name="strCon">SQL语句</param>
        /// <param name="tbname">数据表名</param>
        /// <returns>DataSet数据集对象</returns>
        public DataSet getDs(string strCon,string tbname)
        {
            oledbcon = datacon.getCon();
            oledbda = new OleDbDataAdapter(strCon, oledbcon);
            ds = new DataSet();
            oledbda.Fill(ds, tbname);
            return ds;
        }
        #endregion

        #region 为INI文件中指定的节点取得字符串
        /// <summary>
        /// 为INI文件中指定的节点取得字符串
        /// </summary>
        /// <param name="lpAppName">欲在其中查找关键字的节点名称</param>
        /// <param name="lpKeyName">欲获取的项名</param>
        /// <param name="lpDefault">指定的项没有找到时返回的默认值</param>
        /// <param name="lpReturnedString">指定一个字串缓冲区，长度至少为nSize</param>
        /// <param name="nSize">指定装载到lpReturnedString缓冲区的最大字符数量</param>
        /// <param name="lpFileName">INI文件名</param>
        /// <returns>复制到lpReturnedString缓冲区的字节数量，其中不包括那些NULL中止字符</returns>
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFileName);
        #endregion

        #region 修改INI文件中内容
        /// <summary>
        /// 修改INI文件中内容
        /// </summary>
        /// <param name="lpApplicationName">欲在其中写入的节点名称</param>
        /// <param name="lpKeyName">欲设置的项名</param>
        /// <param name="lpString">要写入的新字符串</param>
        /// <param name="lpFileName">INI文件名</param>
        /// <returns>非零表示成功，零表示失败</returns>
        [DllImport("kernel32")]
        public static extern int WritePrivateProfileString(
            string lpApplicationName,
            string lpKeyName,
            string lpString,
            string lpFileName);
        #endregion

        #region 从INI文件中读取指定节点的内容
        /// <summary>
        /// 从INI文件中读取指定节点的内容
        /// </summary>
        /// <param name="section">INI节点</param>
        /// <param name="key">节点下的项</param>
        /// <param name="def">没有找到内容时返回的默认值</param>
        /// <param name="def">要读取的INI文件</param>
        /// <returns>读取的节点内容</returns>
        public string ReadString(string section, string key, string def, string fileName)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, temp, 1024, fileName);
            return temp.ToString();
        }
        #endregion
    }
}
