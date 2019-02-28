using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace EncryptBAT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileMenu(Application.ExecutablePath + ",0", Application.ExecutablePath);
            string[] str = Environment.GetCommandLineArgs();
            try
            {
                string strFile = "";
                for (int i = 2; i < str.Length; i++)
                    strFile += str[i];
                FileInfo FInfo = new FileInfo(strFile);
                if (FInfo.Extension.ToLower() == ".mrbat")
                    textBox1.Text = strFile;
            }
            catch { }
        }
        
        //选择要加密或解密的文件
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.bat(bat文件)|*.bat|*.mrbat(mrbat加密文件)|*.mrbat|*.*(所有文件)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Text = openFileDialog1.FileName;
        }

        //加密bat文件
        private void button2_Click(object sender, EventArgs e)
        {
            string strPwd = textBox2.Text;
            byte[] btRKey = new byte[0];
            if (strPwd.Length == 6)
            {
                btRKey = new byte[] { (byte)strPwd[0], (byte)strPwd[1], (byte)strPwd[2], (byte)strPwd[3], (byte)strPwd[4], (byte)strPwd[5], (byte)strPwd[0], (byte)strPwd[1] };
            }
            if (strPwd.Length == 7)
            {
                btRKey = new byte[] { (byte)strPwd[0], (byte)strPwd[1], (byte)strPwd[2], (byte)strPwd[3], (byte)strPwd[4], (byte)strPwd[5], (byte)strPwd[6], (byte)strPwd[0] };
            }
            if (strPwd.Length >= 8)
            {
                btRKey = new byte[] { (byte)strPwd[0], (byte)strPwd[1], (byte)strPwd[2], (byte)strPwd[3], (byte)strPwd[4], (byte)strPwd[5], (byte)strPwd[6], (byte)strPwd[7] };
            }
            FileStream FStream = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read);
            FileStream NewFStream = new FileStream(textBox1.Text + ".mrbat", FileMode.OpenOrCreate, FileAccess.Write);
            NewFStream.SetLength((long)0);
            byte[] buffer = new byte[0x400];
            int MinNum = 0;
            long length = FStream.Length;
            int MaxNum = (int)(length / ((long)0x400));
            DES myDES = new DESCryptoServiceProvider();
            CryptoStream CStream = new CryptoStream(NewFStream, myDES.CreateEncryptor(btRKey, btRKey), CryptoStreamMode.Write);
            while (MinNum < length)
            {
                int count = FStream.Read(buffer, 0, 0x400);
                CStream.Write(buffer, 0, count);
                MinNum += count;
            }
            CStream.Close();
            NewFStream.Close();
            FStream.Close();
            File.Delete(textBox1.Text);
            MessageBox.Show("使用口令加密bat文件成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //解密bat文件
        private void button3_Click(object sender, EventArgs e)
        {
            string strPwd = textBox2.Text;
            FileStream FStream = null;
            FileStream NewFStream = null;
            CryptoStream CStream = null;
            try
            {
                try
                {
                    byte[] btRKey = new byte[0];
                    if (strPwd.Length == 6)
                    {
                        btRKey = new byte[] { (byte)strPwd[0], (byte)strPwd[1], (byte)strPwd[2], (byte)strPwd[3], (byte)strPwd[4], (byte)strPwd[5], (byte)strPwd[0], (byte)strPwd[1] };
                    }
                    if (strPwd.Length == 7)
                    {
                        btRKey = new byte[] { (byte)strPwd[0], (byte)strPwd[1], (byte)strPwd[2], (byte)strPwd[3], (byte)strPwd[4], (byte)strPwd[5], (byte)strPwd[6], (byte)strPwd[0] };
                    }
                    if (strPwd.Length >= 8)
                    {
                        btRKey = new byte[] { (byte)strPwd[0], (byte)strPwd[1], (byte)strPwd[2], (byte)strPwd[3], (byte)strPwd[4], (byte)strPwd[5], (byte)strPwd[6], (byte)strPwd[7] };
                    }
                    FStream = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read);
                    string strNewFile = textBox1.Text.Substring(0, textBox1.Text.Length - 6);
                    NewFStream = new FileStream(strNewFile, FileMode.OpenOrCreate, FileAccess.Write);
                    NewFStream.SetLength((long)0);
                    byte[] buffer = new byte[0x400];
                    int MinNum = 0;
                    long length = FStream.Length;
                    int MaxNum = (int)(length / ((long)0x400));
                    DES myDES = new DESCryptoServiceProvider();
                    CStream = new CryptoStream(NewFStream, myDES.CreateDecryptor(btRKey, btRKey), CryptoStreamMode.Write);
                    while (MinNum < length)
                    {
                        int count = FStream.Read(buffer, 0, 0x400);
                        CStream.Write(buffer, 0, count);
                        MinNum += count;
                    }
                    CStream.Close();
                    FStream.Close();
                    NewFStream.Close();
                    File.Delete(textBox1.Text);
                    System.Diagnostics.Process.Start(strNewFile);
                }
                catch
                {
                    MessageBox.Show("口令错误！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
                }
            }
            finally
            {
                CStream.Close();
                FStream.Close();
                NewFStream.Close();
            }
        }

        //创建快捷菜单
        public static void FileMenu(string strPath, string strName)
        {
            try
            {
                Registry.ClassesRoot.CreateSubKey(".mrbat");
                RegistryKey RKey1 = Registry.ClassesRoot.OpenSubKey(".mrbat", true);
                RKey1.SetValue("", "mrbatfile");
                RKey1.Close();
                Registry.ClassesRoot.CreateSubKey("mrbatfile");
                RegistryKey RKey2 = Registry.ClassesRoot.OpenSubKey("mrbatfile", true);
                RKey2.CreateSubKey("DefaultIcon");
                RKey2.CreateSubKey("shell");
                RKey2.Close();
                RegistryKey RKey3 = Registry.ClassesRoot.OpenSubKey("mrbatfile\\DefaultIcon", true);
                RKey3.SetValue("", strPath);
                RKey3.Close();
                RegistryKey RKey4 = Registry.ClassesRoot.OpenSubKey("mrbatfile\\shell", true);
                RKey4.CreateSubKey("使用口令打开");
                RKey4.Close();
                RegistryKey RKey5 = Registry.ClassesRoot.OpenSubKey("mrbatfile\\shell\\使用口令打开", true);
                RKey5.CreateSubKey("command");
                RKey5.Close();
                RegistryKey RKey6 = Registry.ClassesRoot.OpenSubKey("mrbatfile\\shell\\使用口令打开\\command", true);
                RKey6.SetValue("", strName + " \\F %1");
                RKey6.Close();
            }
            catch
            {
            }
        }
    }
}