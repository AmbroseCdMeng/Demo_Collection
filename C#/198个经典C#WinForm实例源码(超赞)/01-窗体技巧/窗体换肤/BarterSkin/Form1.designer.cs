namespace BarterSkin
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox_Close = new System.Windows.Forms.PictureBox();
            this.panel_Title = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolS_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox_Min = new System.Windows.Forms.PictureBox();
            this.pictureBox_Max = new System.Windows.Forms.PictureBox();
            this.panel_ALL = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Close)).BeginInit();
            this.panel_Title.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Max)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Close
            // 
            this.pictureBox_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Close.Location = new System.Drawing.Point(269, 11);
            this.pictureBox_Close.Name = "pictureBox_Close";
            this.pictureBox_Close.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_Close.TabIndex = 3;
            this.pictureBox_Close.TabStop = false;
            this.pictureBox_Close.Tag = "2";
            this.pictureBox_Close.MouseLeave += new System.EventHandler(this.pictureBox_Close_MouseLeave);
            this.pictureBox_Close.Click += new System.EventHandler(this.pictureBox_Close_Click);
            this.pictureBox_Close.MouseEnter += new System.EventHandler(this.pictureBox_Close_MouseEnter);
            // 
            // panel_Title
            // 
            this.panel_Title.ContextMenuStrip = this.contextMenuStrip1;
            this.panel_Title.Controls.Add(this.pictureBox_Close);
            this.panel_Title.Controls.Add(this.pictureBox_Min);
            this.panel_Title.Controls.Add(this.pictureBox_Max);
            this.panel_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Title.Location = new System.Drawing.Point(0, 0);
            this.panel_Title.Name = "panel_Title";
            this.panel_Title.Size = new System.Drawing.Size(298, 37);
            this.panel_Title.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolS_1,
            this.ToolS_2,
            this.ToolS_3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 70);
            // 
            // ToolS_1
            // 
            this.ToolS_1.Name = "ToolS_1";
            this.ToolS_1.Size = new System.Drawing.Size(100, 22);
            this.ToolS_1.Tag = "1";
            this.ToolS_1.Text = "换肤1";
            this.ToolS_1.Click += new System.EventHandler(this.ToolS_1_Click);
            // 
            // ToolS_2
            // 
            this.ToolS_2.Name = "ToolS_2";
            this.ToolS_2.Size = new System.Drawing.Size(100, 22);
            this.ToolS_2.Tag = "2";
            this.ToolS_2.Text = "换肤2";
            this.ToolS_2.Click += new System.EventHandler(this.ToolS_1_Click);
            // 
            // ToolS_3
            // 
            this.ToolS_3.Name = "ToolS_3";
            this.ToolS_3.Size = new System.Drawing.Size(100, 22);
            this.ToolS_3.Tag = "3";
            this.ToolS_3.Text = "换肤3";
            this.ToolS_3.Click += new System.EventHandler(this.ToolS_1_Click);
            // 
            // pictureBox_Min
            // 
            this.pictureBox_Min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Min.Location = new System.Drawing.Point(217, 11);
            this.pictureBox_Min.Name = "pictureBox_Min";
            this.pictureBox_Min.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_Min.TabIndex = 2;
            this.pictureBox_Min.TabStop = false;
            this.pictureBox_Min.Tag = "0";
            this.pictureBox_Min.MouseLeave += new System.EventHandler(this.pictureBox_Close_MouseLeave);
            this.pictureBox_Min.Click += new System.EventHandler(this.pictureBox_Close_Click);
            this.pictureBox_Min.MouseEnter += new System.EventHandler(this.pictureBox_Close_MouseEnter);
            // 
            // pictureBox_Max
            // 
            this.pictureBox_Max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Max.Location = new System.Drawing.Point(243, 11);
            this.pictureBox_Max.Name = "pictureBox_Max";
            this.pictureBox_Max.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_Max.TabIndex = 0;
            this.pictureBox_Max.TabStop = false;
            this.pictureBox_Max.Tag = "1";
            this.pictureBox_Max.MouseLeave += new System.EventHandler(this.pictureBox_Close_MouseLeave);
            this.pictureBox_Max.Click += new System.EventHandler(this.pictureBox_Close_Click);
            this.pictureBox_Max.MouseEnter += new System.EventHandler(this.pictureBox_Close_MouseEnter);
            // 
            // panel_ALL
            // 
            this.panel_ALL.ContextMenuStrip = this.contextMenuStrip1;
            this.panel_ALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ALL.Location = new System.Drawing.Point(0, 37);
            this.panel_ALL.Name = "panel_ALL";
            this.panel_ALL.Size = new System.Drawing.Size(298, 157);
            this.panel_ALL.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 194);
            this.Controls.Add(this.panel_ALL);
            this.Controls.Add(this.panel_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Close)).EndInit();
            this.panel_Title.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Max)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Close;
        private System.Windows.Forms.Panel panel_Title;
        private System.Windows.Forms.PictureBox pictureBox_Min;
        private System.Windows.Forms.PictureBox pictureBox_Max;
        private System.Windows.Forms.Panel panel_ALL;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolS_1;
        private System.Windows.Forms.ToolStripMenuItem ToolS_2;
        private System.Windows.Forms.ToolStripMenuItem ToolS_3;
    }
}

