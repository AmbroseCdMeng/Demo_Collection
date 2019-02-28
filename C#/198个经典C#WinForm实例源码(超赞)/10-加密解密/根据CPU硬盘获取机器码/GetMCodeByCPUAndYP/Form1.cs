using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Management;

namespace GetMCodeByCPUAndYP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = getCpu() + GetDiskVolumeSerialNumber();//获得24位Cpu和硬盘序列号
            string[] strid = new string[24];
            for (int i = 0; i < 24; i++)//把字符赋给数组
            {
                strid[i] = label1.Text.Substring(i, 1);
            }
            label1.Text = "";
            Random rdid = new Random();
            for (int i = 0; i < 24; i++)//从数组随机抽取24个字符组成新的字符生成机器码
            {
                label1.Text += strid[rdid.Next(0, 24)];
            }
        }
        //取得设备硬盘的卷标号
        public string GetDiskVolumeSerialNumber()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"d:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }
        //获得CPU的序列号
        public string getCpu()
        {
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuConnection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
                break;
            }
            return strCpu;
        }
    }
}