namespace VideoMonitor
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnCWipers = new System.Windows.Forms.Button();
            this.btnAWipers = new System.Windows.Forms.Button();
            this.btnCAperture = new System.Windows.Forms.Button();
            this.btnAAperture = new System.Windows.Forms.Button();
            this.btnCFocus = new System.Windows.Forms.Button();
            this.btnAFocus = new System.Windows.Forms.Button();
            this.btnCHighlghts = new System.Windows.Forms.Button();
            this.btnAHighlghts = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnSetMonitor = new System.Windows.Forms.Button();
            this.btnVideo = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnSnapShots = new System.Windows.Forms.Button();
            this.btnAutoMonitor = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.rbtnBMP = new System.Windows.Forms.RadioButton();
            this.rbtnJPG = new System.Windows.Forms.RadioButton();
            this.sfDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnReg = new System.Windows.Forms.Button();
            this.rbtnVerticalWatch = new System.Windows.Forms.RadioButton();
            this.rbtnLevelWatch = new System.Windows.Forms.RadioButton();
            this.rbtnWideWatch = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labContainer = new System.Windows.Forms.Label();
            this.labTime = new System.Windows.Forms.Label();
            this.labCurrent = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSetVideo = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TBarColor = new System.Windows.Forms.TrackBar();
            this.TBarSaturation = new System.Windows.Forms.TrackBar();
            this.TBarContrast = new System.Windows.Forms.TrackBar();
            this.TBarBright = new System.Windows.Forms.TrackBar();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.plVideo4 = new System.Windows.Forms.Panel();
            this.plVideo2 = new System.Windows.Forms.Panel();
            this.plVideo3 = new System.Windows.Forms.Panel();
            this.plVideo1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TBarColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBarSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBarContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBarBright)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCWipers
            // 
            this.btnCWipers.Location = new System.Drawing.Point(93, 138);
            this.btnCWipers.Name = "btnCWipers";
            this.btnCWipers.Size = new System.Drawing.Size(64, 31);
            this.btnCWipers.TabIndex = 11;
            this.btnCWipers.Text = "雨刷-";
            this.btnCWipers.UseVisualStyleBackColor = true;
            this.btnCWipers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCWipers_MouseDown);
            this.btnCWipers.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCWipers_MouseUp);
            // 
            // btnAWipers
            // 
            this.btnAWipers.Location = new System.Drawing.Point(16, 138);
            this.btnAWipers.Name = "btnAWipers";
            this.btnAWipers.Size = new System.Drawing.Size(64, 31);
            this.btnAWipers.TabIndex = 10;
            this.btnAWipers.Text = "雨刷+";
            this.btnAWipers.UseVisualStyleBackColor = true;
            this.btnAWipers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAWipers_MouseDown);
            this.btnAWipers.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAWipers_MouseUp);
            // 
            // btnCAperture
            // 
            this.btnCAperture.Location = new System.Drawing.Point(93, 99);
            this.btnCAperture.Name = "btnCAperture";
            this.btnCAperture.Size = new System.Drawing.Size(64, 31);
            this.btnCAperture.TabIndex = 9;
            this.btnCAperture.Text = "光圈-";
            this.btnCAperture.UseVisualStyleBackColor = true;
            this.btnCAperture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCAperture_MouseDown);
            this.btnCAperture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCAperture_MouseUp);
            // 
            // btnAAperture
            // 
            this.btnAAperture.Location = new System.Drawing.Point(16, 99);
            this.btnAAperture.Name = "btnAAperture";
            this.btnAAperture.Size = new System.Drawing.Size(64, 31);
            this.btnAAperture.TabIndex = 8;
            this.btnAAperture.Text = "光圈+";
            this.btnAAperture.UseVisualStyleBackColor = true;
            this.btnAAperture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAAperture_MouseDown);
            this.btnAAperture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAAperture_MouseUp);
            // 
            // btnCFocus
            // 
            this.btnCFocus.Location = new System.Drawing.Point(93, 60);
            this.btnCFocus.Name = "btnCFocus";
            this.btnCFocus.Size = new System.Drawing.Size(64, 31);
            this.btnCFocus.TabIndex = 7;
            this.btnCFocus.Text = "对焦-";
            this.btnCFocus.UseVisualStyleBackColor = true;
            this.btnCFocus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCFocus_MouseDown);
            this.btnCFocus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCFocus_MouseUp);
            // 
            // btnAFocus
            // 
            this.btnAFocus.Location = new System.Drawing.Point(16, 60);
            this.btnAFocus.Name = "btnAFocus";
            this.btnAFocus.Size = new System.Drawing.Size(64, 31);
            this.btnAFocus.TabIndex = 6;
            this.btnAFocus.Text = "对焦+";
            this.btnAFocus.UseVisualStyleBackColor = true;
            this.btnAFocus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAFocus_MouseDown);
            this.btnAFocus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAFocus_MouseUp);
            // 
            // btnCHighlghts
            // 
            this.btnCHighlghts.Location = new System.Drawing.Point(93, 20);
            this.btnCHighlghts.Name = "btnCHighlghts";
            this.btnCHighlghts.Size = new System.Drawing.Size(64, 31);
            this.btnCHighlghts.TabIndex = 5;
            this.btnCHighlghts.Text = "聚焦-";
            this.btnCHighlghts.UseVisualStyleBackColor = true;
            this.btnCHighlghts.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCHighlghts_MouseDown);
            this.btnCHighlghts.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCHighlghts_MouseUp);
            // 
            // btnAHighlghts
            // 
            this.btnAHighlghts.Location = new System.Drawing.Point(16, 20);
            this.btnAHighlghts.Name = "btnAHighlghts";
            this.btnAHighlghts.Size = new System.Drawing.Size(64, 31);
            this.btnAHighlghts.TabIndex = 4;
            this.btnAHighlghts.Text = "聚焦+";
            this.btnAHighlghts.UseVisualStyleBackColor = true;
            this.btnAHighlghts.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAHighlghts_MouseDown);
            this.btnAHighlghts.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAHighlghts_MouseUp);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(12, 60);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(43, 38);
            this.btnLeft.TabIndex = 14;
            this.btnLeft.Text = "左";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLeft_MouseDown);
            this.btnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnLeft_MouseUp);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(114, 60);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(43, 38);
            this.btnRight.TabIndex = 15;
            this.btnRight.Text = "右";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRight_MouseDown);
            this.btnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRight_MouseUp);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(63, 103);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(43, 38);
            this.btnDown.TabIndex = 13;
            this.btnDown.Text = "下";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseDown);
            this.btnDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseUp);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(63, 20);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(43, 38);
            this.btnUp.TabIndex = 12;
            this.btnUp.Text = "上";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseDown);
            this.btnUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseUp);
            // 
            // btnSetMonitor
            // 
            this.btnSetMonitor.Location = new System.Drawing.Point(601, 825);
            this.btnSetMonitor.Name = "btnSetMonitor";
            this.btnSetMonitor.Size = new System.Drawing.Size(87, 30);
            this.btnSetMonitor.TabIndex = 30;
            this.btnSetMonitor.Text = "监控管理";
            this.btnSetMonitor.UseVisualStyleBackColor = true;
            this.btnSetMonitor.Click += new System.EventHandler(this.btnSetMonitor_Click);
            // 
            // btnVideo
            // 
            this.btnVideo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVideo.Location = new System.Drawing.Point(6, 54);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(75, 30);
            this.btnVideo.TabIndex = 23;
            this.btnVideo.Text = "录像";
            this.btnVideo.UseVisualStyleBackColor = true;
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(85, 54);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 30);
            this.btnPlay.TabIndex = 24;
            this.btnPlay.Text = "回放";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnSnapShots
            // 
            this.btnSnapShots.Location = new System.Drawing.Point(96, 16);
            this.btnSnapShots.Name = "btnSnapShots";
            this.btnSnapShots.Size = new System.Drawing.Size(65, 30);
            this.btnSnapShots.TabIndex = 22;
            this.btnSnapShots.Text = "快照";
            this.btnSnapShots.UseVisualStyleBackColor = true;
            this.btnSnapShots.Click += new System.EventHandler(this.btnSnapShots_Click);
            // 
            // btnAutoMonitor
            // 
            this.btnAutoMonitor.Location = new System.Drawing.Point(41, 39);
            this.btnAutoMonitor.Name = "btnAutoMonitor";
            this.btnAutoMonitor.Size = new System.Drawing.Size(76, 28);
            this.btnAutoMonitor.TabIndex = 19;
            this.btnAutoMonitor.Text = "开始";
            this.btnAutoMonitor.UseVisualStyleBackColor = true;
            this.btnAutoMonitor.Click += new System.EventHandler(this.btnAutoMonitor_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(777, 825);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 30);
            this.btnStop.TabIndex = 32;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // rbtnBMP
            // 
            this.rbtnBMP.AutoSize = true;
            this.rbtnBMP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.rbtnBMP.Checked = true;
            this.rbtnBMP.Location = new System.Drawing.Point(8, 23);
            this.rbtnBMP.Name = "rbtnBMP";
            this.rbtnBMP.Size = new System.Drawing.Size(41, 16);
            this.rbtnBMP.TabIndex = 20;
            this.rbtnBMP.TabStop = true;
            this.rbtnBMP.Text = "BMP";
            this.rbtnBMP.UseVisualStyleBackColor = false;
            // 
            // rbtnJPG
            // 
            this.rbtnJPG.AutoSize = true;
            this.rbtnJPG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.rbtnJPG.Location = new System.Drawing.Point(49, 23);
            this.rbtnJPG.Name = "rbtnJPG";
            this.rbtnJPG.Size = new System.Drawing.Size(41, 16);
            this.rbtnJPG.TabIndex = 21;
            this.rbtnJPG.Text = "JPG";
            this.rbtnJPG.UseVisualStyleBackColor = false;
            // 
            // sfDialog
            // 
            this.sfDialog.RestoreDirectory = true;
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(695, 825);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(75, 30);
            this.btnReg.TabIndex = 31;
            this.btnReg.Text = "注册";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // rbtnVerticalWatch
            // 
            this.rbtnVerticalWatch.AutoSize = true;
            this.rbtnVerticalWatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.rbtnVerticalWatch.Location = new System.Drawing.Point(110, 20);
            this.rbtnVerticalWatch.Name = "rbtnVerticalWatch";
            this.rbtnVerticalWatch.Size = new System.Drawing.Size(47, 16);
            this.rbtnVerticalWatch.TabIndex = 18;
            this.rbtnVerticalWatch.Text = "垂直";
            this.rbtnVerticalWatch.UseVisualStyleBackColor = false;
            // 
            // rbtnLevelWatch
            // 
            this.rbtnLevelWatch.AutoSize = true;
            this.rbtnLevelWatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.rbtnLevelWatch.Location = new System.Drawing.Point(59, 20);
            this.rbtnLevelWatch.Name = "rbtnLevelWatch";
            this.rbtnLevelWatch.Size = new System.Drawing.Size(47, 16);
            this.rbtnLevelWatch.TabIndex = 17;
            this.rbtnLevelWatch.Text = "水平";
            this.rbtnLevelWatch.UseVisualStyleBackColor = false;
            // 
            // rbtnWideWatch
            // 
            this.rbtnWideWatch.AutoSize = true;
            this.rbtnWideWatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.rbtnWideWatch.Checked = true;
            this.rbtnWideWatch.Location = new System.Drawing.Point(8, 20);
            this.rbtnWideWatch.Name = "rbtnWideWatch";
            this.rbtnWideWatch.Size = new System.Drawing.Size(47, 16);
            this.rbtnWideWatch.TabIndex = 16;
            this.rbtnWideWatch.TabStop = true;
            this.rbtnWideWatch.Text = "广角";
            this.rbtnWideWatch.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labContainer);
            this.groupBox1.Controls.Add(this.labTime);
            this.groupBox1.Controls.Add(this.labCurrent);
            this.groupBox1.Location = new System.Drawing.Point(212, 767);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 52);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // labContainer
            // 
            this.labContainer.AutoSize = true;
            this.labContainer.Location = new System.Drawing.Point(377, 22);
            this.labContainer.Name = "labContainer";
            this.labContainer.Size = new System.Drawing.Size(0, 12);
            this.labContainer.TabIndex = 2;
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Location = new System.Drawing.Point(264, 22);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(0, 12);
            this.labTime.TabIndex = 1;
            // 
            // labCurrent
            // 
            this.labCurrent.AutoSize = true;
            this.labCurrent.Location = new System.Drawing.Point(24, 22);
            this.labCurrent.Name = "labCurrent";
            this.labCurrent.Size = new System.Drawing.Size(0, 12);
            this.labCurrent.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAHighlghts);
            this.groupBox2.Controls.Add(this.btnCHighlghts);
            this.groupBox2.Controls.Add(this.btnAFocus);
            this.groupBox2.Controls.Add(this.btnCFocus);
            this.groupBox2.Controls.Add(this.btnAAperture);
            this.groupBox2.Controls.Add(this.btnCAperture);
            this.groupBox2.Controls.Add(this.btnAWipers);
            this.groupBox2.Controls.Add(this.btnCWipers);
            this.groupBox2.Location = new System.Drawing.Point(744, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 178);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "云台控制";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDown);
            this.groupBox3.Controls.Add(this.btnUp);
            this.groupBox3.Controls.Add(this.btnRight);
            this.groupBox3.Controls.Add(this.btnLeft);
            this.groupBox3.Location = new System.Drawing.Point(744, 199);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(166, 149);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "方向控制";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbtnLevelWatch);
            this.groupBox4.Controls.Add(this.btnAutoMonitor);
            this.groupBox4.Controls.Add(this.rbtnWideWatch);
            this.groupBox4.Controls.Add(this.rbtnVerticalWatch);
            this.groupBox4.Location = new System.Drawing.Point(744, 355);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(166, 75);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "自动监控";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSetVideo);
            this.groupBox5.Controls.Add(this.btnSnapShots);
            this.groupBox5.Controls.Add(this.rbtnJPG);
            this.groupBox5.Controls.Add(this.rbtnBMP);
            this.groupBox5.Controls.Add(this.btnVideo);
            this.groupBox5.Controls.Add(this.btnPlay);
            this.groupBox5.Location = new System.Drawing.Point(744, 436);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(166, 128);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "快照与录像";
            // 
            // btnSetVideo
            // 
            this.btnSetVideo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetVideo.Location = new System.Drawing.Point(39, 90);
            this.btnSetVideo.Name = "btnSetVideo";
            this.btnSetVideo.Size = new System.Drawing.Size(92, 30);
            this.btnSetVideo.TabIndex = 25;
            this.btnSetVideo.Text = "定时录像";
            this.btnSetVideo.UseVisualStyleBackColor = true;
            this.btnSetVideo.Click += new System.EventHandler(this.btnSetVideo_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.TBarColor);
            this.groupBox6.Controls.Add(this.TBarSaturation);
            this.groupBox6.Controls.Add(this.TBarContrast);
            this.groupBox6.Controls.Add(this.TBarBright);
            this.groupBox6.Location = new System.Drawing.Point(744, 570);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(166, 175);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "色彩控制";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "色度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "饱和度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "对比度";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "亮度";
            // 
            // TBarColor
            // 
            this.TBarColor.Location = new System.Drawing.Point(39, 125);
            this.TBarColor.Maximum = 127;
            this.TBarColor.Minimum = -128;
            this.TBarColor.Name = "TBarColor";
            this.TBarColor.Size = new System.Drawing.Size(124, 45);
            this.TBarColor.TabIndex = 29;
            this.TBarColor.TickFrequency = 25;
            this.TBarColor.Scroll += new System.EventHandler(this.TBarColor_Scroll);
            // 
            // TBarSaturation
            // 
            this.TBarSaturation.Location = new System.Drawing.Point(39, 93);
            this.TBarSaturation.Maximum = 127;
            this.TBarSaturation.Minimum = -128;
            this.TBarSaturation.Name = "TBarSaturation";
            this.TBarSaturation.Size = new System.Drawing.Size(123, 45);
            this.TBarSaturation.TabIndex = 28;
            this.TBarSaturation.TickFrequency = 25;
            this.TBarSaturation.Value = 64;
            this.TBarSaturation.Scroll += new System.EventHandler(this.TBarSaturation_Scroll);
            // 
            // TBarContrast
            // 
            this.TBarContrast.Location = new System.Drawing.Point(39, 58);
            this.TBarContrast.Maximum = 127;
            this.TBarContrast.Minimum = -128;
            this.TBarContrast.Name = "TBarContrast";
            this.TBarContrast.Size = new System.Drawing.Size(124, 45);
            this.TBarContrast.TabIndex = 27;
            this.TBarContrast.TickFrequency = 25;
            this.TBarContrast.Value = 68;
            this.TBarContrast.Scroll += new System.EventHandler(this.TBarContrast_Scroll);
            // 
            // TBarBright
            // 
            this.TBarBright.Location = new System.Drawing.Point(39, 21);
            this.TBarBright.Maximum = 255;
            this.TBarBright.Name = "TBarBright";
            this.TBarBright.Size = new System.Drawing.Size(123, 45);
            this.TBarBright.TabIndex = 26;
            this.TBarBright.TickFrequency = 25;
            this.TBarBright.Value = 80;
            this.TBarBright.Scroll += new System.EventHandler(this.TBarBright_Scroll);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // plVideo4
            // 
            this.plVideo4.BackColor = System.Drawing.Color.Fuchsia;
            this.plVideo4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("plVideo4.BackgroundImage")));
            this.plVideo4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plVideo4.Location = new System.Drawing.Point(374, 336);
            this.plVideo4.Name = "plVideo4";
            this.plVideo4.Size = new System.Drawing.Size(362, 325);
            this.plVideo4.TabIndex = 3;
            this.plVideo4.DoubleClick += new System.EventHandler(this.plVideo4_DoubleClick);
            this.plVideo4.Click += new System.EventHandler(this.plVideo4_Click);
            // 
            // plVideo2
            // 
            this.plVideo2.BackColor = System.Drawing.Color.Fuchsia;
            this.plVideo2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("plVideo2.BackgroundImage")));
            this.plVideo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plVideo2.Location = new System.Drawing.Point(374, 12);
            this.plVideo2.Name = "plVideo2";
            this.plVideo2.Size = new System.Drawing.Size(362, 325);
            this.plVideo2.TabIndex = 1;
            this.plVideo2.DoubleClick += new System.EventHandler(this.plVideo2_DoubleClick);
            this.plVideo2.Click += new System.EventHandler(this.plVideo2_Click);
            // 
            // plVideo3
            // 
            this.plVideo3.BackColor = System.Drawing.Color.Fuchsia;
            this.plVideo3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("plVideo3.BackgroundImage")));
            this.plVideo3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plVideo3.Location = new System.Drawing.Point(12, 336);
            this.plVideo3.Name = "plVideo3";
            this.plVideo3.Size = new System.Drawing.Size(362, 325);
            this.plVideo3.TabIndex = 2;
            this.plVideo3.DoubleClick += new System.EventHandler(this.plVideo3_DoubleClick);
            this.plVideo3.Click += new System.EventHandler(this.plVideo3_Click);
            // 
            // plVideo1
            // 
            this.plVideo1.BackColor = System.Drawing.Color.Fuchsia;
            this.plVideo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("plVideo1.BackgroundImage")));
            this.plVideo1.Location = new System.Drawing.Point(12, 12);
            this.plVideo1.Name = "plVideo1";
            this.plVideo1.Size = new System.Drawing.Size(362, 325);
            this.plVideo1.TabIndex = 33;
            this.plVideo1.DoubleClick += new System.EventHandler(this.plVideo1_DoubleClick);
            this.plVideo1.Click += new System.EventHandler(this.plVideo1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(859, 825);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "退出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(917, 748);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.plVideo1);
            this.Controls.Add(this.plVideo4);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.plVideo3);
            this.Controls.Add(this.plVideo2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnSetMonitor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Move += new System.EventHandler(this.frmMain_Move);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TBarColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBarSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBarContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBarBright)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCAperture;
        private System.Windows.Forms.Button btnAAperture;
        private System.Windows.Forms.Button btnCFocus;
        private System.Windows.Forms.Button btnAFocus;
        private System.Windows.Forms.Button btnCHighlghts;
        private System.Windows.Forms.Button btnAHighlghts;
        private System.Windows.Forms.Button btnCWipers;
        private System.Windows.Forms.Button btnAWipers;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnSetMonitor;
        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnSnapShots;
        private System.Windows.Forms.Button btnAutoMonitor;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.RadioButton rbtnBMP;
        private System.Windows.Forms.RadioButton rbtnJPG;
        private System.Windows.Forms.SaveFileDialog sfDialog;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.RadioButton rbtnVerticalWatch;
        private System.Windows.Forms.RadioButton rbtnLevelWatch;
        private System.Windows.Forms.RadioButton rbtnWideWatch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labContainer;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Label labCurrent;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSetVideo;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TrackBar TBarColor;
        private System.Windows.Forms.TrackBar TBarSaturation;
        private System.Windows.Forms.TrackBar TBarContrast;
        private System.Windows.Forms.TrackBar TBarBright;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel plVideo4;
        private System.Windows.Forms.Panel plVideo3;
        private System.Windows.Forms.Panel plVideo2;
        private System.Windows.Forms.Panel plVideo1;
        private System.Windows.Forms.Button btnClose;
    }
}

