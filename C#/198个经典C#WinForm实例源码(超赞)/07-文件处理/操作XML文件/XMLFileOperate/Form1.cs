using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace XMLFileOperate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static public string strName = "";//记录读取时XML文件路径
        static public string strOne = "";//定义两个变量保存文本框内的值
        static public string strTwo = "";
        static public string strThree = "";//保存子标记名称
        static public string strFour = "";//保存第二个子节点的属性名
        static public string strFive = "";//保存第二个节点的属性值
        static public string strSix = "";//保存节点路径

        private XmlDocument xmlDocument = new XmlDocument();
        private XmlNode xmlNode;
        private XmlElement xmlElement;
        DataSet dataSet = new DataSet();//声明此数据集，存储读取出的XML数据

        private void Form1_Load(object sender, EventArgs e)
        {
            strName = "fileTwo.xml";
            if (File.Exists(strName))
            {
                ShowXml();
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }
        }

        //修改创建的XML文件
        private void button7_Click(object sender, EventArgs e)
        {
            //修改第一个节点的属性
            xmlDocument.Load(strName);
            XmlNode nodeOne = xmlDocument.SelectSingleNode("//" + strThree);
            XmlElement ElementOne = (XmlElement)nodeOne;
            ElementOne.SetAttribute(attribute.Text, textBox4.Text);

            //修改第一个节点的值            
            XmlNode nodeTwo = xmlDocument.SelectSingleNode("//" + strThree + "/*");
            XmlElement ElementTwo = (XmlElement)nodeTwo;
            ElementTwo.InnerText = nodeContent.Text;

            //修改第二个节点的属性值
            XmlNode mainNodeThree = xmlDocument.SelectSingleNode("//" + textBox7.Text + "[@" + strFour + "='" + strFive + "']");
            XmlElement ElementThree = (XmlElement)mainNodeThree;
            ElementThree.SetAttribute(textBox10.Text, textBox8.Text);

            //修改第二个节点的值
            XmlNode nodeFour = xmlDocument.SelectSingleNode("//" + textBox7.Text + "[@" + strFour + "='" + textBox8.Text + "']/*");
            XmlElement ElementFour = (XmlElement)nodeFour;
            ElementFour.InnerText = textBox11.Text;

            xmlDocument.Save(strName);
            MessageBox.Show("恭喜你，修改成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            ShowXml();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //修改文本框的ReadOnly属性
            readOnlytrue();
            //选定DataGridView中的一条记录在文本框内显示
            for (int i = 0; i < dataGridView1.Rows.Count; i++)  //遍历DataGridView中的每一行信息
            {
                if (dataGridView1.Rows[i].Selected)//判断该行是否被选中
                {
                    if (i <= 0)
                    {
                        nodeContent.Text = dataGridView1.Rows[i].Cells[childNode.Text].Value.ToString();  //在文本框内显示XML文件内的信息
                        textBox4.Text = dataGridView1.Rows[i].Cells[attribute.Text].Value.ToString();
                        strOne = nodeContent.Text;
                    }
                    if (i > 0)
                    {
                        textBox11.Text = dataGridView1.Rows[i].Cells[childNode.Text].Value.ToString();
                        textBox8.Text = dataGridView1.Rows[i].Cells[attribute.Text].Value.ToString();
                        strTwo = textBox11.Text;
                        strFive = textBox8.Text;
                    }
                }
            }
            //从指定路径加载XML文档
            xmlDocument.Load(strName);

            //从根节点开始读取
            XmlNode xNode = (XmlNode)xmlDocument.DocumentElement;
            root.Text = xNode.Name;

            //读取子节点的属性及内容
            XmlNode nodeTwo = xmlDocument.SelectSingleNode(root.Text + "/*");
            firstNode.Text = nodeTwo.Name;
            textBox7.Text = firstNode.Text;
            strThree = firstNode.Text;


            //读取次子节点的名称及内容
            XmlNode nodeThree = xmlDocument.SelectSingleNode(root.Text + "/" + firstNode.Text + "/*");
            childNode.Text = nodeThree.Name;
            textBox9.Text = childNode.Text;

            //读取指定节点的属性名
            XmlNode nodeOne = xmlDocument.SelectSingleNode("//" + firstNode.Text);
            XmlAttributeCollection xmlAttribute = nodeOne.Attributes;
            for (int i = 0; i < xmlAttribute.Count; i++)
            {
                if (i == 0)
                {
                    attribute.Text = xmlAttribute.Item(i).Name;
                    textBox10.Text = attribute.Text;
                    strFour = textBox10.Text;
                }
            }
        }

        //自定义一个方法更改文本框的只读属性
        private void readOnlytrue()
        {
            root.ReadOnly = true;
            childNode.ReadOnly = true;
            attribute.ReadOnly = true;
            firstNode.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
        }

        //选定DataGridView中的数据，进行删除操作
        private void button2_Click(object sender, EventArgs e)
        {
            //判断是否有选中行
            if (dataGridView1.SelectedRows.Count != 0)
            {
                xmlDocument.Load(strName);
                //通过循环获取选中行的XPath
                for (int i = 0; i < dataGridView1.Rows.Count; i++)  //遍历DataGridView中的每一行信息
                {
                    if (dataGridView1.Rows[i].Selected)//判断该行是否被选中
                    {
                        string attriString = dataGridView1.Rows[i].Cells[attribute.Text].Value.ToString();
                        strSix = root.Text + "/" + strThree + "[@" + strFour + "='" + attriString + "']";//被选中节点的XPath
                    }
                }

                string mainNode = strSix.Substring(0, strSix.LastIndexOf("/"));
                xmlDocument.SelectSingleNode(mainNode).RemoveChild(xmlDocument.SelectSingleNode(strSix));//从XML文件下移除节点的语句
                xmlDocument.Save(strName);
                ShowXml();
            }
            else
            {
                MessageBox.Show("暂无选中行，不能进行删除操作！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //添加记录到当前节点下
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                xmlDocument.Load(strName);

                //添加节点的属性及属性值
                XmlNode nodeOne = xmlDocument.SelectSingleNode(root.Text);
                XmlElement elementOne = xmlDocument.CreateElement(textBox6.Text);
                elementOne.SetAttribute(textBox3.Text, textBox1.Text);
                nodeOne.AppendChild(elementOne);

                //添加当前节点的子节点及节点内容
                XmlNode nodeTwo = xmlDocument.SelectSingleNode("//" + textBox6.Text + "[@" + strFour + "='" + textBox1.Text + "']");
                XmlElement elementTwo = xmlDocument.CreateElement(textBox2.Text);
                elementTwo.InnerText = textBox5.Text;
                nodeTwo.AppendChild(elementTwo);

                xmlDocument.Save(strName);
                MessageBox.Show("节点添加成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ShowXml();
            }
            else
            {
                MessageBox.Show("节点内容不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //读取XML文件
        public void ShowXml()
        {
            //读取XML文件信息
            dataSet.Clear();
            dataSet.ReadXml(strName);
            dataGridView1.DataSource = dataSet.Tables[0].DefaultView;
        }
        //创建一个XML文档
        private void button3_Click(object sender, EventArgs e)
        {
            //添加XML的声明部分
            xmlNode = xmlDocument.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            xmlDocument.AppendChild(xmlNode);

            //添加一个根节点
            xmlElement = xmlDocument.CreateElement("", root.Text, "");
            xmlDocument.AppendChild(xmlElement);

            //添加一个带属性值的次根节点
            XmlNode mainNode = xmlDocument.SelectSingleNode(root.Text);
            XmlElement ElementTwo = xmlDocument.CreateElement(firstNode.Text);
            ElementTwo.SetAttribute(attribute.Text, textBox4.Text);
            mainNode.AppendChild(ElementTwo);

            //在当前节点添加一个仅带值的节点
            XmlNode mainNodeOne = xmlDocument.SelectSingleNode(@root.Text + "/" + firstNode.Text);
            XmlElement ElementThree = xmlDocument.CreateElement(childNode.Text);
            ElementThree.InnerText = nodeContent.Text;
            mainNodeOne.AppendChild(ElementThree);

            //在根节点下，添加第二个子节点
            XmlNode mainNodeTwo = xmlDocument.SelectSingleNode(root.Text);
            XmlElement ElementFour = xmlDocument.CreateElement(textBox7.Text);
            ElementFour.SetAttribute(textBox10.Text, textBox8.Text);
            mainNodeTwo.AppendChild(ElementFour);
            strFour = textBox10.Text;

            //在当前节点添加一个仅带值的节点
            XmlNode mainNodeThree = xmlDocument.SelectSingleNode("//" + textBox7.Text + "[@" + strFour + "='" + textBox8.Text + "']");
            XmlElement ElementFive = xmlDocument.CreateElement(textBox9.Text);
            ElementFive.InnerText = textBox11.Text;
            mainNodeThree.AppendChild(ElementFive);

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "XML文件（*.XML）|*.XML";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                xmlDocument.Save(saveDialog.FileName);
            }
        }
    }
}
