using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
namespace CamouflageFolder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string GetFolType()
        {
            int Tid = comboBox1.SelectedIndex;
            switch (Tid)
            {
                case 0: return @"{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                case 1: return @"{450D8FBA-AD25-11D0-98A8-0800361B1103}";
                case 2: return @"{992CFFA0-F557-101A-88EC-00DD010CCC48}";
                case 3: return @"{21EC2020-3AEA-1069-A2DD-08002B30309D}";
                case 4: return @"{D6277990-4C6A-11CF-8D87-00AA0060F5BF}";
                case 5: return @"{2227A280-3AEA-1069-A2DE-08002B30309D}";
                case 6: return @"{208D2C60-3AEA-1069-A2D7-08002B30309D}";
                case 7: return @"{645FF040-5081-101B-9F08-00AA002F954E}";
                case 8: return @"{85BBD920-42A0-1069-A2E4-08002B30309D}";
                case 9: return @"{BD84B380-8CA2-1069-AB1D-08000948F534}";
                case 10: return @"{BDEADF00-C265-11d0-BCED-00A0C90AB50F}";
            }
            return @"{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (folderBrowserDialog1.SelectedPath.Length >= 4)
                {
                    txtFolPath.Text = folderBrowserDialog1.SelectedPath;
                }
                else
                {
                    MessageBox.Show("不能对盘符进行伪装", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 11)
            {
                txtID.ReadOnly = false;
                txtID.Text = "";
            }
            else
            {
                txtID.ReadOnly = true;
                txtID.Text = GetFolType();
            }

        }

        private void Camouflage(string str)
        {
            StreamWriter sw = File.CreateText(txtFolPath.Text.Trim() + @"\desktop.ini");
            sw.WriteLine(@"[.ShellClassInfo]");
            sw.WriteLine("CLSID=" + str);
            sw.Close();
            File.SetAttributes(txtFolPath.Text.Trim() + @"\desktop.ini", FileAttributes.Hidden);
            File.SetAttributes(txtFolPath.Text.Trim(), FileAttributes.System);
            MessageBox.Show("伪装成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.txtFolPath.Text == "")
            {
                MessageBox.Show("请选择文件夹路径！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (txtID.ReadOnly == false)
                    {
                        string str = txtID.Text.Trim();
                        if (str.StartsWith("."))
                            str = str.Substring(1);
                        if (!str.StartsWith("{")||str.Trim().Length!=38)
                        {
                            MessageBox.Show("自定义类型错误！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Camouflage(str);
                        }
                    }
                    else
                    {
                        Camouflage(GetFolType());
                    }
                }
                catch
                {
                    MessageBox.Show ("不要进行多次伪装！","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtFolPath.Text == "")
            {
                MessageBox.Show("请选择加密过的文件夹！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    FileInfo fi = new FileInfo(txtFolPath.Text.Trim() + @"\desktop.ini");
                    if (!fi.Exists)
                    {
                        MessageBox.Show("该文件夹没有被伪装！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(1000);
                        File.Delete(txtFolPath.Text + @"\desktop.ini");
                        File.SetAttributes(txtFolPath.Text.Trim(), FileAttributes.System);
                        MessageBox.Show("还原成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("不要多次还原！");
                }
            }
        }
    }
}
