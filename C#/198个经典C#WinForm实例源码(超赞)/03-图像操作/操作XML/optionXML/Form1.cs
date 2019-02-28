using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace optionXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //private bool _alreadyDispose = false;
        private XmlDocument xmlDoc = new XmlDocument();

        private XmlNode xmlNode;
        private XmlElement xmlElem;
        string xmlPath;

        public void CreatXmlNodes(string MainNode, string Node, string Attrib, string AttribValue)
        {
            XmlNode mainNode = xmlDoc.SelectSingleNode(MainNode);
            XmlElement objElem = xmlDoc.CreateElement(Node);
            objElem.SetAttribute(Attrib, AttribValue);
            mainNode.AppendChild(objElem);
            xmlDoc.Save(xmlPath);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            XmlNode MainNode = xmlDoc.SelectSingleNode("flvLists/item");
            XmlElement xe = (XmlElement)MainNode;
            //设置元素的属性
            xe.SetAttribute("title", "ls");
            xmlDoc.Save(xmlPath);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            xmlPath = Application.StartupPath.ToString();
            xmlPath = xmlPath.Substring(0, xmlPath.LastIndexOf("\\"));
            xmlPath = xmlPath.Substring(0, xmlPath.LastIndexOf("\\"));
            xmlPath += @"\list.xml";
            xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreatXmlNodes("flvLists", "item", "value", "ls");
        }
    }
}
