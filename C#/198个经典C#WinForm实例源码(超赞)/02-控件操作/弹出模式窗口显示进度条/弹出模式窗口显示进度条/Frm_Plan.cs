using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;//线程序的命名空间

namespace 弹出模式窗口显示进度条
{
    public partial class Frm_Plan : Form
    {
        public Frm_Plan()
        {
            InitializeComponent();
        }

        #region  变量
        FileStream FormerOpen;
        FileStream ToFileOpen;
        private System.Threading.Thread thdAddFile; //创建一个线程
        string fountain = "";
        string aim = "";
        #endregion

        #region  返回上一级目录
        /// <summary>
        /// 返回上一级目录
        /// </summary>
        /// <param dir="string">目录</param>
        /// <returns>返回String对象</returns>
        public string UpAndDown_Dir(string dir)
        {
            string Change_dir = "";
            Change_dir = Directory.GetParent(dir).FullName;//获取指定路径的父目录
            return Change_dir;
        }
        #endregion

        #region  文件夹的复制
        /// <summary>
        /// 文件夹的复制
        /// </summary>
        /// <param Ddir="string">要复制的目的路径</param>
        /// <param Sdir="string">要复制的原路径</param>
        private void Files_Copy(string Ddir, string Sdir)
        {
            DirectoryInfo dir = new DirectoryInfo(Sdir);//实例化DirectoryInfo类
            string SbuDir = Ddir;
            try
            {
                if (!dir.Exists)//判断所指的文件或文件夹是否存在
                    return;//退出该操作
                DirectoryInfo dirD = dir as DirectoryInfo;//如果给定参数不是文件夹则退出
                string UpDir = UpAndDown_Dir(Ddir);//获取当前路径的父目录
                if (dirD == null)//判断文件夹是否为空
                {
                    Directory.CreateDirectory(UpDir + "\\" + dirD.Name);//如果为空，创建文件夹并退出
                    return;
                }
                else
                {
                    Directory.CreateDirectory(UpDir + "\\" + dirD.Name);//创建文件夹
                }
                SbuDir = UpDir + "\\" + dirD.Name + "\\";//获取文件夹中文件的路径
                FileSystemInfo[] files = dirD.GetFileSystemInfos();//获取文件夹中所有文件和文件夹
                //对单个FileSystemInfo进行判断,如果是文件夹则进行递归操作
                foreach (FileSystemInfo FSys in files)
                {
                    FileInfo file = FSys as FileInfo;//实例化FileInfo类
                    if (file != null)//如果是文件的话，进行文件的复制操作
                    {
                        fountain = SbuDir + "\\" + file.Name;//获取源文件的路径
                        aim = file.DirectoryName + "\\" + file.Name;//获取目的文件的路径
                        this.Text = aim;//在窗体标题栏中显示目的文件的路径
                        CopyFile(aim, fountain, 1024, progressBar1);//文件的复制
                    }
                    else
                    {
                        Files_Copy(SbuDir + FSys.Name, Sdir + "\\" + FSys.Name);//如果是文件，则进行递归调用
                    }
                }
                progressBar1.Value = progressBar1.Maximum;//将progressBar1控件的进度值设为最大
                this.Close();//关闭当前窗体
            }
            catch (Exception ex)
            {
                MessageBox.Show("文件制复失败。");
                return;
            }
        }
        #endregion

        public void CopyFile(string FormerFile, string toFile, int SectSize, ProgressBar progressBar1)
        {
            progressBar1.Value = 0;//设置进度栏的当前位置为0
            progressBar1.Minimum = 0;//设置进度栏的最小值为0
            FileStream fileToCreate = new FileStream(toFile, FileMode.Create);//创建目的文件，如果已存在将被覆盖
            fileToCreate.Close();//关闭所有资源
            fileToCreate.Dispose();//释放所有资源
            FormerOpen = new FileStream(FormerFile, FileMode.Open, FileAccess.Read);//以只读方式打开源文件
            ToFileOpen = new FileStream(toFile, FileMode.Append, FileAccess.Write);//以写方式打开目的文件
            int max = Convert.ToInt32(Math.Ceiling((double)FormerOpen.Length / (double)SectSize));//根据一次传输的大小，计算传输的个数
            progressBar1.Maximum = max;//设置进度栏的最大值
            int FileSize;//要拷贝的文件的大小
            if (SectSize < FormerOpen.Length)//如果分段拷贝，即每次拷贝内容小于文件总长度
            {
                byte[] buffer = new byte[SectSize];//根据传输的大小，定义一个字节数组
                int copied = 0;//记录传输的大小
                int tem_n = 1;//设置进度栏中进度块的增加个数
                while (copied <= ((int)FormerOpen.Length - SectSize))//拷贝主体部分
                {
                    FileSize = FormerOpen.Read(buffer, 0, SectSize);//从0开始读，每次最大读SectSize
                    FormerOpen.Flush();//清空缓存
                    ToFileOpen.Write(buffer, 0, SectSize);//向目的文件写入字节
                    ToFileOpen.Flush();//清空缓存
                    ToFileOpen.Position = FormerOpen.Position;//使源文件和目的文件流的位置相同
                    copied += FileSize;//记录已拷贝的大小
                    progressBar1.Value = progressBar1.Value + tem_n;//增加进度栏的进度块
                }
                int left = (int)FormerOpen.Length - copied;//获取剩余大小
                FileSize = FormerOpen.Read(buffer, 0, left);//读取剩余的字节
                FormerOpen.Flush();//清空缓存
                ToFileOpen.Write(buffer, 0, left);//写入剩余的部分
                ToFileOpen.Flush();//清空缓存
            }
            else//如果整体拷贝，即每次拷贝内容大于文件总长度
            {
                byte[] buffer = new byte[FormerOpen.Length];//获取文件的大小
                FormerOpen.Read(buffer, 0, (int)FormerOpen.Length);//读取源文件的字节
                FormerOpen.Flush();//清空缓存
                ToFileOpen.Write(buffer, 0, (int)FormerOpen.Length);//写放字节
                ToFileOpen.Flush();//清空缓存
            }
            //FormerOpen.Close();//释放所有资源
            //ToFileOpen.Close();//释放所有资源
        }

        private void Frm_Plan_Shown(object sender, EventArgs e)
        {
            string tem_str = label2.Text;
            tem_str = "\\" + tem_str.Substring(tem_str.LastIndexOf('\\') + 1, tem_str.Length - tem_str.LastIndexOf('\\') - 1);//获取目的文件的路径
            Files_Copy(label3.Text + tem_str, label2.Text);//文件夹的复制
        }


    }
}
