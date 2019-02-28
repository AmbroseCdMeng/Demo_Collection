namespace Noframe
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox_Close = new System.Windows.Forms.PictureBox();
            this.panel_Title = new System.Windows.Forms.Panel();
            this.pictureBox_Min = new System.Windows.Forms.PictureBox();
            this.pictureBox_Max = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Close)).BeginInit();
            this.panel_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Max)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Close
            // 
            this.pictureBox_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_Close.BackgroundImage")));
            this.pictureBox_Close.Location = new System.Drawing.Point(277, 11);
            this.pictureBox_Close.Name = "pictureBox_Close";
            this.pictureBox_Close.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_Close.TabIndex = 3;
            this.pictureBox_Close.TabStop = false;
            this.pictureBox_Close.Tag = "2";
            this.pictureBox_Close.Click += new System.EventHandler(this.pictureBox_Close_Click);
            // 
            // panel_Title
            // 
            this.panel_Title.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_Title.BackgroundImage")));
            this.panel_Title.Controls.Add(this.pictureBox_Close);
            this.panel_Title.Controls.Add(this.pictureBox_Min);
            this.panel_Title.Controls.Add(this.pictureBox_Max);
            this.panel_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Title.Location = new System.Drawing.Point(0, 0);
            this.panel_Title.Name = "panel_Title";
            this.panel_Title.Size = new System.Drawing.Size(306, 37);
            this.panel_Title.TabIndex = 4;
            this.panel_Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Title_MouseMove);
            this.panel_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Title_MouseDown);
            // 
            // pictureBox_Min
            // 
            this.pictureBox_Min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Min.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_Min.BackgroundImage")));
            this.pictureBox_Min.Location = new System.Drawing.Point(225, 11);
            this.pictureBox_Min.Name = "pictureBox_Min";
            this.pictureBox_Min.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_Min.TabIndex = 2;
            this.pictureBox_Min.TabStop = false;
            this.pictureBox_Min.Tag = "0";
            // 
            // pictureBox_Max
            // 
            this.pictureBox_Max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Max.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_Max.BackgroundImage")));
            this.pictureBox_Max.Location = new System.Drawing.Point(251, 11);
            this.pictureBox_Max.Name = "pictureBox_Max";
            this.pictureBox_Max.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_Max.TabIndex = 0;
            this.pictureBox_Max.TabStop = false;
            this.pictureBox_Max.Tag = "1";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 162);
            this.panel1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 199);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Close)).EndInit();
            this.panel_Title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Max)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Close;
        private System.Windows.Forms.Panel panel_Title;
        private System.Windows.Forms.PictureBox pictureBox_Min;
        private System.Windows.Forms.PictureBox pictureBox_Max;
        private System.Windows.Forms.Panel panel1;
    }
}

