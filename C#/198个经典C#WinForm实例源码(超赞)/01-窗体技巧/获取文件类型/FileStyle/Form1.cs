using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileStyle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;							//设置拖放操作中目标放置类型为复制
            String[] str_Drop = (String[])e.Data.GetData(DataFormats.FileDrop, true);//检索数据格式相关联的数据
            Data_List(listView1, str_Drop[0]);
        }

        public void Data_List(ListView LV, string F)  //Form或MouseEventArgs添加命名空间using System.Windows.Forms;
        {
            string enlarge = "";
            if (F.LastIndexOf(".") == F.Length - 4)
            {
                enlarge = F.Substring(F.LastIndexOf(".") + 1, 3);
            }
            ListViewItem item = new ListViewItem(F);
            item.SubItems.Add(enlarge);
            LV.Items.Add(item);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            listView1.GridLines = true;//在各数据之间形成网格线
            listView1.View = View.Details;//显示列名称
            listView1.FullRowSelect = true;//在单击某项时，对其进行选中
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;//隐藏列标题

            listView1.Columns.Add("文件名", listView1.Width - 65, HorizontalAlignment.Right);//设置头像
            listView1.Columns.Add("类型", 60, HorizontalAlignment.Center);//设置头像
        }
    }
}
