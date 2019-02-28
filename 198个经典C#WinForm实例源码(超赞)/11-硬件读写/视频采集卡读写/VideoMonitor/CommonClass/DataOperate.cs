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

        #region ִ��SQL���
        /// <summary>
        /// ִ��SQL���
        /// </summary>
        /// <param name="strCon">Ҫִ�е�SQL���</param>
        public void getCom(string strCon)
        {
            oledbcon = datacon.getCon();
            oledbcom = new OleDbCommand(strCon, oledbcon);
            oledbcon.Open();
            oledbcom.ExecuteNonQuery();
            oledbcon.Close();
        }
        #endregion

        #region ����DataSet���ݼ�
        /// <summary>
        /// ����DataSet���ݼ�
        /// </summary>
        /// <param name="strCon">SQL���</param>
        /// <param name="tbname">���ݱ���</param>
        /// <returns>DataSet���ݼ�����</returns>
        public DataSet getDs(string strCon,string tbname)
        {
            oledbcon = datacon.getCon();
            oledbda = new OleDbDataAdapter(strCon, oledbcon);
            ds = new DataSet();
            oledbda.Fill(ds, tbname);
            return ds;
        }
        #endregion

        #region ΪINI�ļ���ָ���Ľڵ�ȡ���ַ���
        /// <summary>
        /// ΪINI�ļ���ָ���Ľڵ�ȡ���ַ���
        /// </summary>
        /// <param name="lpAppName">�������в��ҹؼ��ֵĽڵ�����</param>
        /// <param name="lpKeyName">����ȡ������</param>
        /// <param name="lpDefault">ָ������û���ҵ�ʱ���ص�Ĭ��ֵ</param>
        /// <param name="lpReturnedString">ָ��һ���ִ�����������������ΪnSize</param>
        /// <param name="nSize">ָ��װ�ص�lpReturnedString������������ַ�����</param>
        /// <param name="lpFileName">INI�ļ���</param>
        /// <returns>���Ƶ�lpReturnedString���������ֽ����������в�������ЩNULL��ֹ�ַ�</returns>
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFileName);
        #endregion

        #region �޸�INI�ļ�������
        /// <summary>
        /// �޸�INI�ļ�������
        /// </summary>
        /// <param name="lpApplicationName">��������д��Ľڵ�����</param>
        /// <param name="lpKeyName">�����õ�����</param>
        /// <param name="lpString">Ҫд������ַ���</param>
        /// <param name="lpFileName">INI�ļ���</param>
        /// <returns>�����ʾ�ɹ������ʾʧ��</returns>
        [DllImport("kernel32")]
        public static extern int WritePrivateProfileString(
            string lpApplicationName,
            string lpKeyName,
            string lpString,
            string lpFileName);
        #endregion

        #region ��INI�ļ��ж�ȡָ���ڵ������
        /// <summary>
        /// ��INI�ļ��ж�ȡָ���ڵ������
        /// </summary>
        /// <param name="section">INI�ڵ�</param>
        /// <param name="key">�ڵ��µ���</param>
        /// <param name="def">û���ҵ�����ʱ���ص�Ĭ��ֵ</param>
        /// <param name="def">Ҫ��ȡ��INI�ļ�</param>
        /// <returns>��ȡ�Ľڵ�����</returns>
        public string ReadString(string section, string key, string def, string fileName)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, temp, 1024, fileName);
            return temp.ToString();
        }
        #endregion
    }
}
