using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;

namespace NetBroadcast
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hashtable myHashtable = SelectXML("BroadCastInfo.xml");
            IDictionaryEnumerator IDEnumerator = myHashtable.GetEnumerator();
            while (IDEnumerator.MoveNext())
            {
                comboBox1.Items.Add(IDEnumerator.Key.ToString());
                comboBox2.Items.Add(IDEnumerator.Value.ToString());
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox2.Text = SelectXML("BroadCastInfo.xml", comboBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strUrl = comboBox1.Text;
            if (!comboBox1.Items.Contains(strUrl))
                AddXML("BroadCastInfo.xml", strUrl, comboBox2.Text);
            axWindowsMediaPlayer1.URL = comboBox1.Text;
        }

        #region 在XML文件中查找电台地址及名称
        /// <summary>
        /// 在XML文件中查找电台地址及名称
        /// </summary>
        /// <param name="strPath">XML文件路径</param>
        /// <returns>Hashtable对象，用来记录找到的电台地址及名称</returns>
        public Hashtable SelectXML(string strPath)
        {
            Hashtable HTable = new Hashtable();
            XmlDocument doc = new XmlDocument();
            doc.Load(strPath);
            //获取NewDataSet节点的所有子节点
            XmlNodeList xnl = doc.SelectSingleNode("BCastInfo").ChildNodes;
            string strVersion = "";
            string strInfo = "";
            foreach (XmlNode xn in xnl)//遍历所有子节点
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型
                if (xe.Name == "DInfo")//判断节点名为DInfo
                {
                    XmlNodeList xnlChild = xe.ChildNodes;//继续获取xe子节点的所有子节点
                    foreach (XmlNode xnChild in xnlChild)//遍历
                    {
                        XmlElement xeChild = (XmlElement)xnChild;//转换类型
                        if (xeChild.Name == "Address")
                        {
                            strVersion = xeChild.InnerText;
                        }
                        if (xeChild.Name == "Name")
                        {
                            strInfo = xeChild.InnerText;
                        }
                    }
                    HTable.Add(strVersion, strInfo);
                }
            }
            return HTable;
        }
        #endregion

        #region 在XML文件中查找指定电台地址所对应的名称
        /// <summary>
        /// 在XML文件中查找指定电台地址所对应的名称
        /// </summary>
        /// <param name="strPath">XML文件路径</param>
        /// <param name="strAddress">指定的电台地址</param>
        /// <returns>查找到的电台名称</returns>
        public string SelectXML(string strPath, string strAddress)
        {
            string strName = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(strPath);
            XmlNodeList nodes;
            XmlElement root = doc.DocumentElement;
            nodes = root.SelectNodes("descendant::DInfo[Address='" + strAddress + "']");
            foreach (XmlNode xn in nodes)//遍历所有子节点
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型
                if (xe.Name == "DInfo")//判断节点名为DInfo
                {
                    XmlNodeList xnlChild = xe.ChildNodes;//继续获取xe子节点的所有子节点
                    foreach (XmlNode xnChild in xnlChild)//遍历
                    {
                        XmlElement xeChild = (XmlElement)xnChild;//转换类型
                        if (xeChild.Name == "Name")
                        {
                            strName = xeChild.InnerText;
                            break; ;
                        }
                    }
                }
            }
            return strName;
        }
        #endregion

        #region 向XML文件中添加节点
        /// <summary>
        /// 向XML文件中添加节点
        /// </summary>
        /// <param name="strPath">XML文件路径</param>
        /// <param name="strNode1">电台地址</param>
        /// <param name="strNode2">名称</param>
        public void AddXML(string strPath, string strNode1, string strNode2)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(strPath);
            XmlNode newNode1;
            XmlNode newNode2;
            newNode1 = doc1.CreateElement("DInfo");
            newNode2 = doc1.CreateElement("Address");
            newNode2.InnerText = strNode1;
            newNode1.AppendChild(newNode2);
            newNode2 = doc1.CreateElement("Name");
            newNode2.InnerText = strNode2;
            newNode1.AppendChild(newNode2);
            doc1.DocumentElement.AppendChild(newNode1);
            doc1.Save(strPath);
        }
        #endregion
    }
}
