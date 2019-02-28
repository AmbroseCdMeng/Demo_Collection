using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileBatchCopy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.GridLines = true;//在各数据之间形成网格线
            listView1.View = View.Details;//显示列名称
            listView1.FullRowSelect = true;//在单击某项时，对其进行选中
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;//隐藏列标题
            listView1.Columns.Add("文件路径", listView1.Width - 5, HorizontalAlignment.Right);
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;							//设置拖放操作中目标放置类型为复制
            String[] str_Drop = (String[])e.Data.GetData(DataFormats.FileDrop, true);//检索数据格式相关联的数据
            Data_List(listView1, str_Drop[0]);
        }

        public void Data_List(ListView LV, string F)  //Form或MouseEventArgs添加命名空间using System.Windows.Forms;
        {
            ListViewItem item = new ListViewItem(F);
            LV.Items.Add(item);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string FileName = "";
            int tem_n = 0;
            string DName = "";
            if (textBox1.Text.Length > 0 && listView1.Items.Count > 0)
            {
                try
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        FileName = listView1.Items[i].SubItems[0].Text;
                        tem_n = FileName.LastIndexOf("\\");
                        FileName = FileName.Substring(tem_n + 1, FileName.Length - tem_n - 1);
                        DName = textBox1.Text.Trim() + "\\" + FileName;
                        CopyFile(listView1.Items[i].SubItems[0].Text, DName, 1024);
                        this.Text = "复制：" + listView1.Items[i].SubItems[0].Text;
                    }
                    MessageBox.Show("文件批量复制完成。");
                }
                catch
                {
                    MessageBox.Show("文件复制错误。");
                }
            }
        }

        FileStream FormerOpen;
        FileStream ToFileOpen;
        /// <summary>
        /// 文件的复制
        /// </summary>
        /// <param FormerFile="string">源文件路径</param>
        /// <param toFile="string">目的文件路径</param> 
        /// <param SectSize="int">传输大小</param> 
        /// <param progressBar="ProgressBar">ProgressBar控件</param> 
        public void CopyFile(string FormerFile, string toFile, int SectSize)
        {
            FileStream fileToCreate = new FileStream(toFile, FileMode.Create);		//创建目的文件，如果已存在将被覆盖
            fileToCreate.Close();										//关闭所有资源
            fileToCreate.Dispose();										//释放所有资源
            FormerOpen = new FileStream(FormerFile, FileMode.Open, FileAccess.Read);//以只读方式打开源文件
            ToFileOpen = new FileStream(toFile, FileMode.Append, FileAccess.Write);	//以写方式打开目的文件
            //根据一次传输的大小，计算传输的个数
            //int max = Convert.ToInt32(Math.Ceiling((double)FormerOpen.Length / (double)SectSize));

            int FileSize;												//要拷贝的文件的大小
            //如果分段拷贝，即每次拷贝内容小于文件总长度
            if (SectSize < FormerOpen.Length)
            {
                byte[] buffer = new byte[SectSize];							//根据传输的大小，定义一个字节数组
                int copied = 0;										//记录传输的大小
                while (copied <= ((int)FormerOpen.Length - SectSize))			//拷贝主体部分
                {
                    FileSize = FormerOpen.Read(buffer, 0, SectSize);			//从0开始读，每次最大读SectSize
                    FormerOpen.Flush();								//清空缓存
                    ToFileOpen.Write(buffer, 0, SectSize);					//向目的文件写入字节
                    ToFileOpen.Flush();									//清空缓存
                    ToFileOpen.Position = FormerOpen.Position;				//使源文件和目的文件流的位置相同
                    copied += FileSize;									//记录已拷贝的大小
                }
                int left = (int)FormerOpen.Length - copied;						//获取剩余大小
                FileSize = FormerOpen.Read(buffer, 0, left);					//读取剩余的字节
                FormerOpen.Flush();									//清空缓存
                ToFileOpen.Write(buffer, 0, left);							//写入剩余的部分
                ToFileOpen.Flush();									//清空缓存
            }
            //如果整体拷贝，即每次拷贝内容大于文件总长度
            else
            {
                byte[] buffer = new byte[FormerOpen.Length];				//获取文件的大小
                FormerOpen.Read(buffer, 0, (int)FormerOpen.Length);			//读取源文件的字节
                FormerOpen.Flush();									//清空缓存
                ToFileOpen.Write(buffer, 0, (int)FormerOpen.Length);			//写放字节
                ToFileOpen.Flush();									//清空缓存
            }
            FormerOpen.Close();										//释放所有资源
            ToFileOpen.Close();										//释放所有资源
        }


    }
}
