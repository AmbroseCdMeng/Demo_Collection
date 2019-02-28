using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoMonitor
{
    public partial class frmAutoVideo : Form
    {
        public frmAutoVideo()
        {
            InitializeComponent();
        }

        #region ʵ������������󣬲����幫������
        CommonClass.DataOperate dataoperate = new VideoMonitor.CommonClass.DataOperate();
        string strName = Application.StartupPath + "\\VideoSet.ini";//����Ҫ��ȡ��INI�ļ�
        #endregion

        //�������ʱ��ȡINI�����ļ��е����ݣ�����ʾ����Ӧ�������б���
        private void frmAutoVideo_Load(object sender, EventArgs e)
        {
            timer1.Start();
            for (int i = 1; i < 31; i++)
            {
                cboxDate.Items.Add(i);//�����������б�ֵ
            }
            cboxVideo.Text = dataoperate.ReadString("VideoSet", "Frequency", "", strName);
            NUDownHour.Value = Convert.ToDecimal(dataoperate.ReadString("VideoSet", "Hour", "", strName));
            NUDownMin.Value = Convert.ToDecimal(dataoperate.ReadString("VideoSet", "Min", "", strName));
            cboxWeek.Text = dataoperate.ReadString("VideoSet", "Week", "", strName);
            cboxDate.Text = dataoperate.ReadString("VideoSet", "Date", "", strName);
        }

        //������ȷ������ť���޸�INI�����ļ�������
        private void btnSure_Click(object sender, EventArgs e)
        {
            CommonClass.DataOperate.WritePrivateProfileString("VideoSet", "Frequency", cboxVideo.Text, strName);
            CommonClass.DataOperate.WritePrivateProfileString("VideoSet", "Hour", NUDownHour.Value.ToString(), strName);
            CommonClass.DataOperate.WritePrivateProfileString("VideoSet", "Min", NUDownMin.Value.ToString(), strName);
            CommonClass.DataOperate.WritePrivateProfileString("VideoSet", "Week", cboxWeek.Text, strName);
            CommonClass.DataOperate.WritePrivateProfileString("VideoSet", "Date", cboxDate.Text, strName);
            MessageBox.Show("��ʱ¼�����óɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //�ڼ�ʱ���е����Զ��巽����ظ��ؼ�����״̬
        private void timer1_Tick(object sender, EventArgs e)
        {
            ControlState();
        }

        //�رյ�ǰ����
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region ����¼��Ƶ�������б���е�ѡ������������ؼ��Ŀ���״̬
        /// <summary>
        /// ����¼��Ƶ�������б���е�ѡ������������ؼ��Ŀ���״̬
        /// </summary>
        private void ControlState()
        {
            int index = cboxVideo.SelectedIndex;
            switch (index)
            {
                case 0:
                    NUDownHour.Enabled = NUDownMin.Enabled = true;
                    cboxWeek.Enabled = cboxDate.Enabled = false;
                    break;
                case 1:
                    NUDownHour.Enabled = NUDownMin.Enabled = cboxWeek.Enabled = true;
                    cboxDate.Enabled = false;
                    break;
                case 2:
                    NUDownHour.Enabled = NUDownMin.Enabled = cboxDate.Enabled = true;
                    cboxWeek.Enabled = false;
                    break;
            }
        }
        #endregion
    }
}