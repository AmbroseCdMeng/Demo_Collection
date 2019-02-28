using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//添加的命名空间
using VideoMonitor.CommonClass;
using System.IO.Ports;
using Microsoft.Win32;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;

namespace VideoMonitor
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region 定义公共变量，并实例化公共类对象
        PelcoD pelcod = new PelcoD();
        SoftReg softreg = new SoftReg();
        CommonClass.DataOperate dataoperate = new VideoMonitor.CommonClass.DataOperate();
        string strName = Application.StartupPath + "\\VideoSet.ini";//定义要读取的INI文件
        SerialPort serialPort = new SerialPort("COM1", 9600, Parity.None, 8);
        int m_dwDevNum = 0;
        byte addressin = Byte.Parse(Convert.ToString(0x01));
        byte speedin = Byte.Parse(Convert.ToString(0xff));
        byte[] messagesend;
        string strFrequency = "";                                //记录录像频率
        int intHour = 0;                                         //记录录像小时
        int intMin = 0;                                          //记录录像分钟
        string strWeek = "";                                     //记录录像星期
        string strDate = "";                                     //记录录像日期
        static DateTime dtLTime;
        static int intFlag = 0;
        #endregion

        //窗体加载时，初始化视频卡，并开始预览视频
        private void frmMain_Load(object sender, EventArgs e)
        {
            frmWelcome frmwelcome = new frmWelcome();
            frmwelcome.ShowDialog(); 
            dtLTime = DateTime.Now;
            timer1.Start();
            timer2.Start();
            setVideoBG("");
            plVideo1.BorderStyle = BorderStyle.Fixed3D;
            RegistryKey retkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("software", true).CreateSubKey("wxk").CreateSubKey("wxk.INI");
            foreach (string strRNum in retkey.GetSubKeyNames())//判断是否注册
            {
                if (strRNum == softreg.getRNum())
                {
                    this.Text = "视频监控模块（已注册）";
                    btnReg.Enabled = false;
                    startMonitor();
                    return;
                }
            }
            this.Text = "视频监控模块（未注册）";
            btnReg.Enabled = true;
            btnSetMonitor.Enabled = btnAutoMonitor.Enabled = false;
            startMonitor();
            MessageBox.Show("您现在使用的是试用版，该软件可以免费试用30次！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Int32 tLong;
            try
            {
                tLong = (Int32)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\angel", "UseTimes", 0);
                MessageBox.Show("感谢您已使用了" + tLong + "次", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\angel", "UseTimes", 0, RegistryValueKind.DWord);
                MessageBox.Show("欢迎新用户使用本软件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            tLong = (Int32)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\angel", "UseTimes", 0);
            if (tLong < 30)
            {
                int Times = tLong + 1;
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\angel", "UseTimes", Times);
            }
            else
            {
                MessageBox.Show("试用次数已到", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }

        //移动窗体位置时，视频随之移动
        private void frmMain_Move(object sender, EventArgs e)
        {
            MoveVideo();
        }

        #region  云台控制
        //增加聚焦
        private void btnAHighlghts_MouseDown(object sender, MouseEventArgs e)
        {
            messagesend = pelcod.CameraFocus(addressin, PelcoD.Focus.Near);
            serialPort.Open();
            serialPort.Write(messagesend, 0, 7);
            serialPort.Close();
        }
        //减小聚焦
        private void btnCHighlghts_MouseDown(object sender, MouseEventArgs e)
        {
            messagesend = pelcod.CameraFocus(addressin, PelcoD.Focus.Far);
            serialPort.Open();
            serialPort.Write(messagesend, 0, 7);
            serialPort.Close();
        }
        //增加对焦
        private void btnAFocus_MouseDown(object sender, MouseEventArgs e)
        {
            messagesend = pelcod.CameraZoom(addressin, PelcoD.Zoom.Tele);
            serialPort.Open();
            serialPort.Write(messagesend, 0, 7);
            serialPort.Close();
        }
        //减小对焦
        private void btnCFocus_MouseDown(object sender, MouseEventArgs e)
        {
            messagesend = pelcod.CameraZoom(addressin, PelcoD.Zoom.Wide);
            serialPort.Open();
            serialPort.Write(messagesend, 0, 7);
            serialPort.Close();
        }
        //增加光圈
        private void btnAAperture_MouseDown(object sender, MouseEventArgs e)
        {
            messagesend = pelcod.CameraIrisSwitch(addressin, PelcoD.Iris.Close);
            serialPort.Open();
            serialPort.Write(messagesend, 0, 7);
            serialPort.Close();
        }
        //减小光圈
        private void btnCAperture_MouseDown(object sender, MouseEventArgs e)
        {
            messagesend = pelcod.CameraIrisSwitch(addressin, PelcoD.Iris.Open);
            serialPort.Open();
            serialPort.Write(messagesend, 0, 7);
            serialPort.Close();
        }
        //增加雨刷
        private void btnAWipers_MouseDown(object sender, MouseEventArgs e)
        {
            messagesend = pelcod.CameraSwitch(addressin, PelcoD.Switch.On);
            serialPort.Open();
            serialPort.Write(messagesend, 0, 7);
            serialPort.Close();
        }
        //减小雨刷
        private void btnCWipers_MouseDown(object sender, MouseEventArgs e)
        {
            messagesend = pelcod.CameraSwitch(addressin, PelcoD.Switch.Off);
            serialPort.Open();
            serialPort.Write(messagesend, 0, 7);
            serialPort.Close();
        }
        //方向控制——上
        private void btnUp_MouseDown(object sender, MouseEventArgs e)
        {
            messagesend = pelcod.CameraTilt(addressin, PelcoD.Tilt.Up, speedin);
            serialPort.Open();
            serialPort.Write(messagesend, 0, 7);
            serialPort.Close();
        }
        //方向控制——下
        private void btnDown_MouseDown(object sender, MouseEventArgs e)
        {
            messagesend = pelcod.CameraTilt(addressin, PelcoD.Tilt.Down, speedin);
            serialPort.Open();
            serialPort.Write(messagesend, 0, 7);
            serialPort.Close();
        }
        //方向控制——左
        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            messagesend = pelcod.CameraPan(addressin, PelcoD.Pan.Left, speedin);
            serialPort.Open();
            serialPort.Write(messagesend, 0, 7);
            serialPort.Close();
        }
        //方向控制——右
        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            messagesend = pelcod.CameraPan(addressin, PelcoD.Pan.Right, speedin);
            serialPort.Open();
            serialPort.Write(messagesend, 0, 7);
            serialPort.Close();
        }
        #endregion

        #region 控制视频窗口的亮度、对比度 、饱和度和色度
        //控制视频窗口的亮度
        private void TBarBright_Scroll(object sender, EventArgs e)
        {
            VideoOperate.VCASetVidDeviceColor(intFlag, VideoOperate.COLORCONTROL.BRIGHTNESS, TBarBright.Value);
        }
        //控制视频窗口的对比度
        private void TBarContrast_Scroll(object sender, EventArgs e)
        {
            VideoOperate.VCASetVidDeviceColor(intFlag, VideoOperate.COLORCONTROL.CONTRAST, TBarContrast.Value);
        }
        //控制视频窗口的饱和度
        private void TBarSaturation_Scroll(object sender, EventArgs e)
        {
            VideoOperate.VCASetVidDeviceColor(intFlag, VideoOperate.COLORCONTROL.SATURATION, TBarSaturation.Value);
        }
        //控制视频窗口的色度
        private void TBarColor_Scroll(object sender, EventArgs e)
        {
            VideoOperate.VCASetVidDeviceColor(intFlag, VideoOperate.COLORCONTROL.HUE, TBarColor.Value);
        }
        #endregion

        //打开监控管理窗体
        private void btnSetMonitor_Click(object sender, EventArgs e)
        {
            frmSetMonitor frmsetmonitor = new frmSetMonitor();
            frmsetmonitor.ShowDialog();
        }

        //录像
        private void btnVideo_Click(object sender, EventArgs e)
        {
            if (btnVideo.Text == "录像")
            {
                sfDialog.Filter = "*.avi|*.avi";
                sfDialog.Title = "保存视频文件";
                sfDialog.InitialDirectory = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\")) + "\\Video\\";
                if (sfDialog.ShowDialog() == DialogResult.OK)
                {
                    btnVideo.Text = "停止录像";
                    VideoOperate.VCASetKeyFrmInterval(intFlag, 250);
                    VideoOperate.VCASetBitRate(intFlag, 256);
                    VideoOperate.VCASetVidCapFrameRate(intFlag, 25, false);
                    VideoOperate.VCASetVidCapSize(intFlag, 320, 240);
                    VideoOperate.VCASetXVIDQuality(intFlag, 10, 3);
                    VideoOperate.VCASetXVIDCompressMode(intFlag, VideoOperate.COMPRESSMODE.XVID_VBR_MODE);
                    VideoOperate.VCAStartVideoCapture(intFlag, VideoOperate.CAPMODEL.CAP_MPEG4_STREAM, VideoOperate.MP4MODEL.MPEG4_AVIFILE_CALLBACK, sfDialog.FileName);
                }
            }
            else if (btnVideo.Text == "停止录像")
            {
                btnVideo.Text = "录像";
                VideoOperate.VCAStopVideoCapture(0);
            }
        }

        //打开定时录像设置窗体
        private void btnSetVideo_Click(object sender, EventArgs e)
        {
            frmAutoVideo frmautovideo = new frmAutoVideo();
            frmautovideo.ShowDialog();
        }

        //回放
        private void btnPlay_Click(object sender, EventArgs e)
        {
            frmPlay frmpaly = new frmPlay();
            frmpaly.ShowDialog();
        }

        //快照
        private void btnSnapShots_Click(object sender, EventArgs e)
        {
            if (rbtnBMP.Checked)
            {
                VideoOperate.VCASaveAsBmpFile(intFlag, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\")) + "\\Photo\\" + DateTime.Now.ToFileTime() + ".bmp");
            }
            else
            {
                VideoOperate.VCASaveAsJpegFile(intFlag, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\")) + "\\Photo\\" + DateTime.Now.ToFileTime() + ".jpg", 100);
            }
        }

        //开始自动监控
        private void btnAutoMonitor_Click(object sender, EventArgs e)
        {
            if (btnAutoMonitor.Text == "开始")
            {
                if (rbtnWideWatch.Checked)
                {
                    messagesend = pelcod.CameraTilt(addressin, PelcoD.Tilt.Up, speedin);
                    serialPort.Open();
                    serialPort.Write(messagesend, 0, 7);
                    serialPort.Close();
                    Thread.Sleep(2000);
                    messagesend = pelcod.CameraPan(addressin, PelcoD.Pan.Left, speedin);
                    serialPort.Open();
                    serialPort.Write(messagesend, 0, 7);
                    serialPort.Close();
                    Thread.Sleep(2000);
                    messagesend = pelcod.CameraTilt(addressin, PelcoD.Tilt.Down, speedin);
                    serialPort.Open();
                    serialPort.Write(messagesend, 0, 7);
                    serialPort.Close();
                    Thread.Sleep(2000);
                    messagesend = pelcod.CameraPan(addressin, PelcoD.Pan.Right, speedin);
                    serialPort.Open();
                    serialPort.Write(messagesend, 0, 7);
                    serialPort.Close();
                }
                else if (rbtnVerticalWatch.Checked)
                {
                    messagesend = pelcod.CameraTilt(addressin, PelcoD.Tilt.Up, speedin);
                    serialPort.Open();
                    serialPort.Write(messagesend, 0, 7);
                    serialPort.Close();
                    Thread.Sleep(2000);
                    messagesend = pelcod.CameraTilt(addressin, PelcoD.Tilt.Down, speedin);
                    serialPort.Open();
                    serialPort.Write(messagesend, 0, 7);
                    serialPort.Close();
                }
                else
                {
                    messagesend = pelcod.CameraPan(addressin, PelcoD.Pan.Left, speedin);
                    serialPort.Open();
                    serialPort.Write(messagesend, 0, 7);
                    serialPort.Close();
                    Thread.Sleep(2000);
                    messagesend = pelcod.CameraPan(addressin, PelcoD.Pan.Right, speedin);
                    serialPort.Open();
                    serialPort.Write(messagesend, 0, 7);
                    serialPort.Close();
                }
                btnAutoMonitor.Text = "停止";
            }
            else
            {
                stopMove();
                btnAutoMonitor.Text = "开始";
            }
        }

        //停止监控
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (btnStop.Text == "停止")
            {
                string strDPath = Application.StartupPath;
                string strPath = strDPath.Substring(0, strDPath.LastIndexOf("\\")).Substring(0, strDPath.Substring(0, strDPath.LastIndexOf("\\")).LastIndexOf("\\")) + "\\Image\\主页面\\bg.bmp";
                setVideoBG(strPath);
                VideoOperate.VCAUnInitSdk();
                btnStop.Text = "开始";
            }
            else if (btnStop.Text == "开始")
            {
                setVideoBG("");
                startMonitor();
                btnStop.Text = "停止";
            }
        }

        //打开软件注册窗体
        private void btnReg_Click(object sender, EventArgs e)
        {
            btnStop_Click(sender, e);
            frmRegister frmregister = new frmRegister();
            frmregister.Show();
            this.Hide();
        }

        #region  释放鼠标时，视频监控停止移动
        private void btnUp_MouseUp(object sender, MouseEventArgs e)
        {
            stopMove();
        }
        private void btnDown_MouseUp(object sender, MouseEventArgs e)
        {
            stopMove();
        }
        private void btnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            stopMove();
        }
        private void btnRight_MouseUp(object sender, MouseEventArgs e)
        {
            stopMove();
        }
        private void btnAHighlghts_MouseUp(object sender, MouseEventArgs e)
        {
            stopMove();
        }
        private void btnCHighlghts_MouseUp(object sender, MouseEventArgs e)
        {
            stopMove();
        }
        private void btnAFocus_MouseUp(object sender, MouseEventArgs e)
        {
            stopMove();
        }
        private void btnCFocus_MouseUp(object sender, MouseEventArgs e)
        {
            stopMove();
        }
        private void btnAAperture_MouseUp(object sender, MouseEventArgs e)
        {
            stopMove();
        }
        private void btnCAperture_MouseUp(object sender, MouseEventArgs e)
        {
            stopMove();
        }
        private void btnAWipers_MouseUp(object sender, MouseEventArgs e)
        {
            stopMove();
        }
        private void btnCWipers_MouseUp(object sender, MouseEventArgs e)
        {
            stopMove();
        }
        #endregion

        //查看当前日期、运行时间及所剩磁盘容量
        private void timer1_Tick(object sender, EventArgs e)
        {
            labCurrent.Text = "当前时间：" + getWeek() + " " + DateTime.Now.ToString();
            TimeSpan tsTime = DateTime.Now - dtLTime;
            labTime.Text = "运行" + tsTime.Days + "天 " + tsTime.Hours.ToString("00") + ":" + tsTime.Minutes.ToString("00") + ":" + tsTime.Seconds.ToString("00");
            string strDPath = Application.StartupPath;
            string strPath = strDPath.Substring(0, strDPath.LastIndexOf("\\")).Substring(0, strDPath.Substring(0, strDPath.LastIndexOf("\\")).LastIndexOf("\\")) + "\\Video\\";
            StringBuilder shortName = new System.Text.StringBuilder(256);
            GetShortPathName(strPath, shortName, 256);
            DriveInfo DInfo=new DriveInfo(shortName.ToString().Substring(0,2));
            labContainer.Text = shortName.ToString() + "(空闲" + DInfo.TotalFreeSpace / 1024 / 1024 + "M)";
        }

        //读取INI文件中内容，以便自动录像
        private void timer2_Tick(object sender, EventArgs e)
        {
            strFrequency = dataoperate.ReadString("VideoSet", "Frequency", "", strName);
            intHour = Convert.ToInt32(dataoperate.ReadString("VideoSet", "Hour", "", strName));
            intMin = Convert.ToInt32(dataoperate.ReadString("VideoSet", "Min", "", strName));
            strWeek = dataoperate.ReadString("VideoSet", "Week", "", strName);
            strDate = dataoperate.ReadString("VideoSet", "Date", "", strName);
            switch (strFrequency)
            {
                case "每天":
                    if (DateTime.Now.Hour == intHour && DateTime.Now.Minute == intMin)
                    {
                        timer2.Enabled = false;
                        AutoVideo();
                    }
                    break;
                case "每周":
                    if (getWeek() == strWeek && DateTime.Now.Hour == intHour && DateTime.Now.Minute == intMin)
                    {
                        timer2.Enabled = false;
                        AutoVideo();
                    }
                    break;
                case "每月":
                    if (DateTime.Now.Month == Convert.ToInt32(strDate) && DateTime.Now.Hour == intHour && DateTime.Now.Minute == intMin)
                    {
                        timer2.Enabled = false;
                        AutoVideo();
                    }
                    break;
            }
        }

        //关闭主窗体时，退出应用程序 
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //退出应用程序
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region 选中视频窗口
        private void plVideo1_Click(object sender, EventArgs e)
        {
            ControlSelect(plVideo1, plVideo2, plVideo3, plVideo4);
            intFlag = 0;
        }
        private void plVideo2_Click(object sender, EventArgs e)
        {
            ControlSelect(plVideo2, plVideo1, plVideo3, plVideo4);
            intFlag = 1;
        }
        private void plVideo3_Click(object sender, EventArgs e)
        {
            ControlSelect(plVideo3, plVideo1, plVideo2, plVideo4);
            intFlag = 2;
        }
        private void plVideo4_Click(object sender, EventArgs e)
        {
            ControlSelect(plVideo4, plVideo1, plVideo2, plVideo3);
            intFlag = 3;
        }
        #endregion

        #region 控制双击视频窗口时的大小
        private void plVideo1_DoubleClick(object sender, EventArgs e)
        {
            ControlVideo(plVideo1, plVideo2, plVideo3, plVideo4);
        }
        private void plVideo2_DoubleClick(object sender, EventArgs e)
        {
            ControlVideo(plVideo2, plVideo1, plVideo3, plVideo4);
        }
        private void plVideo3_DoubleClick(object sender, EventArgs e)
        {
            ControlVideo(plVideo3, plVideo1, plVideo2, plVideo4);
        }
        private void plVideo4_DoubleClick(object sender, EventArgs e)
        {
            ControlVideo(plVideo4, plVideo1, plVideo2, plVideo3);
        }
        #endregion

        #region 开始监控
        /// <summary>
        /// 开始监控
        /// </summary>
        private void startMonitor()
        {
            if (VideoOperate.VCAInitSdk(this.Handle, VideoOperate.DISPLAYTRANSTYPE.PCI_MEMORY_VIDEOMEMORY, false))
            {
                m_dwDevNum = VideoOperate.VCAGetDevNum();
                if (m_dwDevNum == 0)
                {
                    MessageBox.Show("VC404卡驱动程序没有安装");
                }
                else
                {
                    for (int i = 0; i < m_dwDevNum; i++)
                    {
                        foreach (Control ctl in this.Controls)
                        {
                            if ((ctl is Panel) && (ctl.Name == "plVideo" + (i + 1)))
                            {
                                VideoOperate.VCAOpenDevice(i, ctl.Handle);
                                VideoOperate.VCAStartVideoPreview(i);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region 停止监控
        /// <summary>
        /// 停止监控
        /// </summary>
        private void stopMove()
        {
            messagesend = pelcod.CameraStop(addressin);
            serialPort.Open();
            serialPort.Write(messagesend, 0, 7);
            serialPort.Close();
        }
        #endregion

        #region 控制双击视频时的大小
        /// <summary>
        /// 控制双击视频时的大小
        /// </summary>
        /// <param name="pl1">双击的视频窗口</param>
        /// <param name="pl2">未双击的视频窗口</param>
        /// <param name="pl3">未双击的视频窗口</param>
        /// <param name="pl4">未双击的视频窗口</param>
        private void ControlVideo(Panel pl1,Panel pl2,Panel pl3,Panel pl4)
        {
            if (pl1.Width == 362 && pl1.Height == 325)
            {
                pl2.Width = pl3.Width = pl4.Width = 0;
                pl2.Height = pl3.Height = pl4.Height = 0;
                pl1.Location = new Point(212, 118);
                pl1.Width = 724;
                pl1.Height = 650;
            }
            else if (pl1.Width == 724 && pl1.Height == 650)
            {
                pl1.Dock = DockStyle.None;
                pl1.Width = pl2.Width = pl3.Width = pl4.Width = 362;
                pl1.Height = pl2.Height = pl3.Height = pl4.Height = 325;
                switch (pl1.Name)
                {
                    case "plVideo1":
                        pl1.Location = new Point(212, 118);
                        break;
                    case "plVideo2":
                        pl1.Location = new Point(574, 118);
                        break;
                    case "plVideo3":
                        pl1.Location = new Point(212, 442);
                        break;
                    case "plVideo4":
                        pl1.Location = new Point(574, 442);
                        break;
                }
            }
            MoveVideo();
        }
        #endregion

        #region 移动窗体位置时，视频随之移动
        /// <summary>
        /// 移动窗体位置时，视频随之移动
        /// </summary>
        private void MoveVideo()
        {
            for (int i = 0; i < m_dwDevNum; i++)
            {
                foreach (Control ctl in this.Controls)
                {
                    if ((ctl is Panel) && (ctl.Name == "plVideo" + (i + 1)))
                    {
                        ctl.Invalidate();
                        VideoOperate.VCAUpdateOverlayWnd(this.Handle);
                        VideoOperate.VCAUpdateVideoPreview(i, ctl.Handle);
                    }
                }
            }
        }
        #endregion

        #region 控制Panel控件的背景色
        /// <summary>
        /// 控制Panel控件的背景色
        /// </summary>
        /// <param name="strImage"></param>
        private void setVideoBG(string strImage)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is Panel)
                {
                    if (strImage == "")
                        ctl.BackgroundImage = null;
                    else
                        ctl.BackgroundImage = System.Drawing.Image.FromFile(strImage);
                }
            }
        }
        #endregion

        #region  判断星期几
        /// <summary>
        /// 判断星期几
        /// </summary>
        /// <returns></returns>
        public string getWeek()
        {
            string str = DateTime.Now.DayOfWeek.ToString();
            str.IndexOf("1");
            string strWeek = "";
            switch (str)
            {
                case "Monday":
                    strWeek = "星期一";
                    break;
                case "Tuesday":
                    strWeek = "星期二";
                    break;
                case "Wednesday":
                    strWeek = "星期三";
                    break;
                case "Thursday":
                    strWeek = "星期四";
                    break;
                case "Friday":
                    strWeek = "星期五";
                    break;
                case "Saturday":
                    strWeek = "星期六";
                    break;
                case "Sunday":
                    strWeek = "星期日";
                    break;
            }
            return strWeek;
        }
        #endregion
        
        #region 将长路径名转换为短路径名
        /// <summary>
        /// 将长路径名转换为短路径名
        /// </summary>
        /// <param name="lpszLongPath">长路径名</param>
        /// <param name="lpszShortPath">短路径名</param>
        /// <param name="cchBuffer">缓冲区长度</param>
        /// <returns>装载到cchBuffer缓冲区的字符数量，如果cchBuffer的长度不足，不能容下文件名，就返回需要的缓冲区长度</returns>
        [DllImport("Kernel32.dll")]
        private static extern Int16 GetShortPathName(string lpszLongPath, StringBuilder lpszShortPath, Int16 cchBuffer);
        #endregion

        #region 选中视频窗口
        /// <summary>
        /// 选中视频窗口
        /// </summary>
        /// <param name="pl1">选中的视频窗口</param>
        /// <param name="pl2">未选中的视频窗口</param>
        /// <param name="pl3">未选中的视频窗口</param>
        /// <param name="pl4">未选中的视频窗口</param>
        private void ControlSelect(Panel pl1, Panel pl2, Panel pl3, Panel pl4)
        {
            pl1.BorderStyle = BorderStyle.Fixed3D;
            pl2.BorderStyle = pl3.BorderStyle = pl4.BorderStyle = BorderStyle.FixedSingle;
        }
        #endregion

        #region 自动录像
        /// <summary>
        /// 自动录像
        /// </summary>
        private void AutoVideo()
        {
            btnVideo.Text = "停止录像";
            string strPath = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\")) + "\\Video\\";
            VideoOperate.VCASetKeyFrmInterval(intFlag, 250);
            VideoOperate.VCASetBitRate(intFlag, 256);
            VideoOperate.VCASetVidCapFrameRate(intFlag, 25, false);
            VideoOperate.VCASetVidCapSize(intFlag, 320, 240);
            VideoOperate.VCASetXVIDQuality(intFlag, 10, 3);
            VideoOperate.VCASetXVIDCompressMode(intFlag, VideoOperate.COMPRESSMODE.XVID_VBR_MODE);
            VideoOperate.VCAStartVideoCapture(intFlag, VideoOperate.CAPMODEL.CAP_MPEG4_STREAM, VideoOperate.MP4MODEL.MPEG4_AVIFILE_CALLBACK, strPath + DateTime.Now.ToString("yyyyMMddhhmmss") + ".avi");
        }
        #endregion
    }
}