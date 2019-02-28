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

        #region 实例化公共类对象，并定义公共变量
        CommonClass.DataOperate dataoperate = new VideoMonitor.CommonClass.DataOperate();
        string strName = Application.StartupPath + "\\VideoSet.ini";//定义要读取的INI文件
        #endregion

        //窗体加载时读取INI设置文件中的内容，并显示在相应的下拉列表中
        private void frmAutoVideo_Load(object sender, EventArgs e)
        {
            timer1.Start();
            for (int i = 1; i < 31; i++)
            {
                cboxDate.Items.Add(i);//给日期下拉列表赋值
            }
            cboxVideo.Text = dataoperate.ReadString("VideoSet", "Frequency", "", strName);
            NUDownHour.Value = Convert.ToDecimal(dataoperate.ReadString("VideoSet", "Hour", "", strName));
            NUDownMin.Value = Convert.ToDecimal(dataoperate.ReadString("VideoSet", "Min", "", strName));
            cboxWeek.Text = dataoperate.ReadString("VideoSet", "Week", "", strName);
            cboxDate.Text = dataoperate.ReadString("VideoSet", "Date", "", strName);
        }

        //单击“确定”按钮，修改INI设置文件的内容
        private void btnSure_Click(object sender, EventArgs e)
        {
            CommonClass.DataOperate.WritePrivateProfileString("VideoSet", "Frequency", cboxVideo.Text, strName);
            CommonClass.DataOperate.WritePrivateProfileString("VideoSet", "Hour", NUDownHour.Value.ToString(), strName);
            CommonClass.DataOperate.WritePrivateProfileString("VideoSet", "Min", NUDownMin.Value.ToString(), strName);
            CommonClass.DataOperate.WritePrivateProfileString("VideoSet", "Week", cboxWeek.Text, strName);
            CommonClass.DataOperate.WritePrivateProfileString("VideoSet", "Date", cboxDate.Text, strName);
            MessageBox.Show("定时录像设置成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //在计时器中调用自定义方法监控各控件可用状态
        private void timer1_Tick(object sender, EventArgs e)
        {
            ControlState();
        }

        //关闭当前窗体
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 根据录像频率下拉列表框中的选择项控制其他控件的可用状态
        /// <summary>
        /// 根据录像频率下拉列表框中的选择项控制其他控件的可用状态
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