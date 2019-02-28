using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Collections;

using System.IO.Compression;

using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Runtime.Serialization;
using Microsoft.Win32;

namespace GetDiskList
{
    class BaseClass
    {
        public class Win32
        {
            public const uint SHGFI_ICON = 0x100;
            public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
            public const uint SHGFI_SMALLICON = 0x1; // 'Small icon
            [DllImport("shell32.dll", EntryPoint = "ExtractIcon")]
            public static extern int ExtractIcon(IntPtr hInst, string lpFileName, int nIndex);
            [DllImport("shell32.dll", EntryPoint = "SHGetFileInfo")]
            public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttribute, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint Flags);
            [DllImport("User32.dll", EntryPoint = "DestroyIcon")]
            public static extern int DestroyIcon(IntPtr hIcon);
            [DllImport("shell32.dll")]
            public static extern uint ExtractIconEx(string lpszFile, int nIconIndex, int[] phiconLarge, int[] phiconSmall, uint nIcons);
            [StructLayout(LayoutKind.Sequential)]
            public struct SHFILEINFO
            {
                public IntPtr hIcon;
                public IntPtr iIcon;
                public uint dwAttributes;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
                public string szDisplayName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
                public string szTypeName;
            }
        }

        #region  �ļ��еĸ���
        /// <summary>
        /// �ļ��еĸ���
        /// </summary>
        /// <param Ddir="string">Ҫ���Ƶ�Ŀ��·��</param>
        /// <param Sdir="string">Ҫ���Ƶ�ԭ·��</param>
        public void Files_Copy(string Ddir, string Sdir)
        {
            DirectoryInfo dir = new DirectoryInfo(Sdir);
            string SbuDir = Ddir;
            try
            {
                if (!dir.Exists)//�ж���ָ���ļ����ļ����Ƿ����
                {
                    return;
                }
                DirectoryInfo dirD = dir as DirectoryInfo;//����������������ļ������˳�
                string UpDir = UpAndDown_Dir(Ddir);
                if (dirD == null)//�ж��ļ����Ƿ�Ϊ��
                {
                    Directory.CreateDirectory(UpDir + "\\" + dirD.Name);//���Ϊ�գ������ļ��в��˳�
                    return;
                }
                else
                {
                    Directory.CreateDirectory(UpDir + "\\" + dirD.Name);
                }
                SbuDir = UpDir + "\\" + dirD.Name + "\\";
                FileSystemInfo[] files = dirD.GetFileSystemInfos();//��ȡ�ļ����������ļ����ļ���
                //�Ե���FileSystemInfo�����ж�,������ļ�������еݹ����
                foreach (FileSystemInfo FSys in files)
                {
                    FileInfo file = FSys as FileInfo;
                    if (file != null)//������ļ��Ļ��������ļ��ĸ��Ʋ���
                    {
                        FileInfo SFInfo = new FileInfo(file.DirectoryName + "\\" + file.Name);//��ȡ�ļ����ڵ�ԭʼ·��
                        SFInfo.CopyTo(SbuDir + "\\" + file.Name, true);//���ļ����Ƶ�ָ����·����
                    }
                    else
                    {
                        string pp = FSys.Name;//��ȡ��ǰ���������ļ�������
                        Files_Copy(SbuDir + FSys.ToString(), Sdir + "\\" + FSys.ToString());//������ļ�������еݹ����
                    }
                }
            }
            catch
            {
                MessageBox.Show("�ļ��Ƹ�ʧ�ܡ�");
                return;
            }
        }
        #endregion

        #region  ������һ��Ŀ¼
        /// <summary>
        /// ������һ��Ŀ¼
        /// </summary>
        /// <param dir="string">Ŀ¼</param>
        /// <returns>����String����</returns>
        public string UpAndDown_Dir(string dir)
        {
            string Change_dir = "";
            Change_dir = Directory.GetParent(dir).FullName;
            return Change_dir;
        }
        #endregion

        public void listFolders(ToolStripComboBox tscb)//��ȡ���ش���Ŀ¼
        {
            string[] logicdrives = System.IO.Directory.GetLogicalDrives();
            for (int i = 0; i < logicdrives.Length; i++)
            {
                tscb.Items.Add(logicdrives[i]);
                tscb.SelectedIndex = 0;
            }
        }
        int k = 0;
        public void GOBack(ListView lv,ImageList il,string path)
        {

            if (AllPath.Length != 3)
            {
                string NewPath = AllPath.Remove(AllPath.LastIndexOf("\\")).Remove(AllPath.Remove(AllPath.LastIndexOf("\\")).LastIndexOf("\\")) + "\\";
                lv.Items.Clear();
                GetListViewItem(NewPath, il, lv);
                AllPath = NewPath;
            }
            else
            {
                if (k == 0)
                {
                    lv.Items.Clear();
                    GetListViewItem(path, il, lv);
                    k++;
                }
            }
        }
        public string Mpath()
        {
            string path=AllPath;
            return path;
        }
        public static string AllPath = "";//---------
        public void GetPath(string path, ImageList imglist, ListView lv,int ppath)//-------
        {
                string pp = "";
                string uu = "";
                if (ppath == 0)
                {
                    if (AllPath != path)
                    {
                        lv.Items.Clear();
                        AllPath = path;
                        GetListViewItem(AllPath, imglist, lv);
                    }
                }
                else
                {
                    uu = AllPath + path;
                    if (Directory.Exists(uu))
                    {
                        AllPath = AllPath + path + "\\";
                        pp = AllPath.Substring(0, AllPath.Length - 1);
                        lv.Items.Clear();
                        GetListViewItem(pp, imglist, lv);
                    }
                    else
                    {
                        uu = AllPath + path;
                        System.Diagnostics.Process.Start(uu);
                    }
                }
        }
        public void GetListViewItem(string path, ImageList imglist, ListView lv)//��ȡָ��·���������ļ�����ͼ��
        {
            lv.Items.Clear();
            Win32.SHFILEINFO shfi = new Win32.SHFILEINFO();
            try
            {
                string[] dirs = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);
                for (int i = 0; i < dirs.Length; i++)
                {
                    string[] info = new string[4];
                    DirectoryInfo dir = new DirectoryInfo(dirs[i]);
                    if (dir.Name == "RECYCLER" || dir.Name == "RECYCLED" || dir.Name == "Recycled" || dir.Name == "System Volume Information")
                    { }
                    else
                    {
                        //���ͼ��
                        Win32.SHGetFileInfo(dirs[i],
                                            (uint)0x80,
                                            ref shfi,
                                            (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi),
                                            (uint)(0x100 | 0x400)); //ȡ��Icon��TypeName
                        //���ͼ��
                        imglist.Images.Add(dir.Name, (Icon)Icon.FromHandle(shfi.hIcon).Clone());
                        info[0] = dir.Name;
                        info[1] = "";
                        info[2] = "�ļ���";
                        info[3] = dir.LastWriteTime.ToString();
                        ListViewItem item = new ListViewItem(info, dir.Name);
                        lv.Items.Add(item);
                        //����ͼ��
                        Win32.DestroyIcon(shfi.hIcon);
                    }
                }
                for (int i = 0; i < files.Length; i++)
                {
                    string[] info = new string[4];
                    FileInfo fi = new FileInfo(files[i]);
                    string Filetype = fi.Name.Substring(fi.Name.LastIndexOf(".")+1,fi.Name.Length- fi.Name.LastIndexOf(".") -1);
                    string newtype=Filetype.ToLower();
                    if (newtype == "sys" || newtype == "ini" || newtype == "bin" || newtype == "log" || newtype == "com" || newtype == "bat" || newtype == "db")
                    { }
                    else
                    {


                        //���ͼ��
                        Win32.SHGetFileInfo(files[i],
                                            (uint)0x80,
                                            ref shfi,
                                            (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi),
                                            (uint)(0x100 | 0x400)); //ȡ��Icon��TypeName
                        //���ͼ��
                        imglist.Images.Add(fi.Name, (Icon)Icon.FromHandle(shfi.hIcon).Clone());
                        info[0] = fi.Name;
                        info[1] = fi.Length.ToString();
                        info[2] = fi.Extension.ToString();
                        info[3] = fi.LastWriteTime.ToString();
                        ListViewItem item = new ListViewItem(info, fi.Name);
                        lv.Items.Add(item);
                        //����ͼ��
                        Win32.DestroyIcon(shfi.hIcon);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
