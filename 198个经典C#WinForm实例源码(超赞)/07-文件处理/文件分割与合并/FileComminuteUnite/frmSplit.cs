using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace FileComminuteUnite
{
    public partial class frmSplit : Form
    {
        public frmSplit()
        {
            InitializeComponent();
        }

        #region �ָ��ļ�
        /// <summary>
        /// �ָ��ļ�
        /// </summary>
        /// <param name="strFlag">�ָλ</param>
        /// <param name="intFlag">�ָ��С</param>
        /// <param name="strPath">�ָ����ļ����·��</param>
        /// <param name="strFile">Ҫ�ָ���ļ�</param>
        /// <param name="PBar">��������ʾ</param>
        public void SplitFile(string strFlag, int intFlag, string strPath, string strFile, ProgressBar PBar)
        {
            int iFileSize = 0;
            //����ѡ�����趨�ָ��С�ļ��Ĵ�С
            switch (strFlag)
            {
                case "Byte":
                    iFileSize = intFlag;
                    break;
                case "KB":
                    iFileSize = intFlag * 1024;
                    break;
                case "MB":
                    iFileSize = intFlag * 1024 * 1024;
                    break;
                case "GB":
                    iFileSize = intFlag * 1024 * 1024 * 1024;
                    break;
            }
            //���ļ���ȫ·����Ӧ���ַ������ļ���ģʽ����ʼ��FileStream�ļ���ʵ��
            FileStream SplitFileStream = new FileStream(strFile, FileMode.Open);
            //��FileStream�ļ�������ʼ��BinaryReader�ļ��Ķ���
            BinaryReader SplitFileReader = new BinaryReader(SplitFileStream);
            //ÿ�ηָ��ȡ���������
            byte[] TempBytes;
            //С�ļ�����
            int iFileCount = (int)(SplitFileStream.Length / iFileSize);
            PBar.Maximum = iFileCount;
            if (SplitFileStream.Length % iFileSize != 0) iFileCount++;
            string[] TempExtra = strFile.Split('.');
            //ѭ�������ļ��ָ�ɶ��С�ļ�
            for (int i = 1; i <= iFileCount; i++)
            {
                //ȷ��С�ļ����ļ�����
                string sTempFileName = strPath + @"\" + i.ToString().PadLeft(4, '0') + "." + TempExtra[TempExtra.Length - 1]; //С�ļ���
                //�����ļ����ƺ��ļ���ģʽ����ʼ��FileStream�ļ���ʵ��
                FileStream TempStream = new FileStream(sTempFileName, FileMode.OpenOrCreate);
                //��FileStreamʵ������������ʼ��BinaryWriter��д��ʵ��
                BinaryWriter TempWriter = new BinaryWriter(TempStream);
                //�Ӵ��ļ��ж�ȡָ����С����
                TempBytes = SplitFileReader.ReadBytes(iFileSize);
                //�Ѵ�����д��С�ļ�
                TempWriter.Write(TempBytes);
                //�ر���д�����γ�С�ļ�
                TempWriter.Close();
                //�ر��ļ���
                TempStream.Close();
                PBar.Value = i - 1;
            }
            //�رմ��ļ��Ķ���
            SplitFileReader.Close();
            SplitFileStream.Close();
            MessageBox.Show("�ļ��ָ�ɹ�!");
        }
        #endregion

        #region �ϲ��ļ�
        /// <summary>
        /// �ϲ��ļ�
        /// </summary>
        /// <param name="list">Ҫ�ϲ����ļ�����</param>
        /// <param name="strPath">�ϲ�����ļ�����</param>
        /// <param name="PBar">��������ʾ</param>
        public void CombinFile(string[] strFile, string strPath, ProgressBar PBar)
        {
            PBar.Maximum = strFile.Length;
            FileStream AddStream = null;
            //�Ժϲ�����ļ����ƺʹ򿪷�ʽ����������ʼ��FileStream�ļ���
            AddStream = new FileStream(strPath, FileMode.Append);
            //��FileStream�ļ�������ʼ��BinaryWriter��д���������Ժϲ��ָ���ļ�
            BinaryWriter AddWriter = new BinaryWriter(AddStream);
            FileStream TempStream = null;
            BinaryReader TempReader = null;
            //ѭ���ϲ�С�ļ��������ɺϲ��ļ�
            for (int i = 0; i < strFile.Length; i++)
            {
                //��С�ļ�����Ӧ���ļ����ƺʹ�ģʽ����ʼ��FileStream�ļ��������ȡ�ָ�����
                TempStream = new FileStream(strFile[i].ToString(), FileMode.Open);
                TempReader = new BinaryReader(TempStream);
                //��ȡ�ָ��ļ��е����ݣ������ɺϲ����ļ�
                AddWriter.Write(TempReader.ReadBytes((int)TempStream.Length));
                //�ر�BinaryReader�ļ��Ķ���
                TempReader.Close();
                //�ر�FileStream�ļ���
                TempStream.Close();
                PBar.Value = i + 1;
            }
            //�ر�BinaryWriter�ļ���д��
            AddWriter.Close();
            //�ر�FileStream�ļ���
            AddStream.Close();
            MessageBox.Show("�ļ��ϲ��ɹ���");
        }
        #endregion

        private void frmSplit_Load(object sender, EventArgs e)
        {
            timer1.Start();//������ʱ��
        }

        //ѡ��Ҫ�ָ���ļ�
        private void btnSFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog.FileName;
            }
        }

        //ִ���ļ��ָ����
        private void btnSplit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLength.Text == ""||txtFile.Text.Trim()==""||txtPath.Text.Trim()=="")
                {
                    MessageBox.Show("�뽫��Ϣ��д������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLength.Focus();
                }
                else if (cboxUnit.Text == "")
                {
                    MessageBox.Show("��ѡ��Ҫ�ָ���ļ���λ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboxUnit.Focus();
                }
                else
                {
                    SplitFile(cboxUnit.Text, Convert.ToInt32(txtLength.Text.Trim()), txtPath.Text, txtFile.Text, progressBar);
                }
            }
            catch { }
        }

        //ѡ��ָ����ļ����·��
        private void btnSPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        //ѡ��Ҫ�ϳɵ��ļ�
        private void btnCFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string Selectfile = "";
                string[] files = openFileDialog.FileNames;
                for (int i = 0; i < files.Length; i++)
                {
                    Selectfile += "," + files[i].ToString();
                }
                if (Selectfile.StartsWith(","))
                {
                    Selectfile = Selectfile.Substring(1);
                }
                if (Selectfile.EndsWith(","))
                {
                    Selectfile.Remove(Selectfile.LastIndexOf(","),1);
                }
                txtCFile.Text = Selectfile;
            }
        }

        //ѡ��ϳɺ���ļ����·��
        private void btnCPath_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtCPath.Text = saveFileDialog.FileName;
            }
        }

        //ִ�кϳ��ļ�����
        private void btnCombin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCFile.Text.Trim() == "" || txtCPath.Text.Trim() == "")
                {
                    MessageBox.Show("�뽫��Ϣ����������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (txtCFile.Text.IndexOf(",") == -1)
                        MessageBox.Show("��ѡ��Ҫ�ϳɵ��ļ�������Ϊ������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        string[] strFiles = txtCFile.Text.Split(',');
                        CombinFile(strFiles, txtCPath.Text, progressBar);
                    }
                }
            }
            catch { }
        }

        //���ӡ��ָ/���ϲ�����ť�Ŀ���״̬
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txtFile.Text != "" && txtPath.Text != "")
                btnSplit.Enabled = true;
            else
                btnSplit.Enabled = false;
            if (txtCFile.Text != "" && txtCPath.Text != "")
                btnCombin.Enabled = true;
            else
                btnCombin.Enabled = false;
        }
    }
}