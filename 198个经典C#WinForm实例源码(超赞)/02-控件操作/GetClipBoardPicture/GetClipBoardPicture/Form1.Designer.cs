namespace GetClipBoardPicture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cut = new System.Windows.Forms.Button();
            this.copy = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.previousSheet = new System.Windows.Forms.Button();
            this.nextSheet = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 130);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cut
            // 
            this.cut.Location = new System.Drawing.Point(177, 40);
            this.cut.Name = "cut";
            this.cut.Size = new System.Drawing.Size(45, 23);
            this.cut.TabIndex = 1;
            this.cut.Text = "剪切";
            this.cut.UseVisualStyleBackColor = true;
            this.cut.Click += new System.EventHandler(this.cut_Click);
            // 
            // copy
            // 
            this.copy.Location = new System.Drawing.Point(177, 95);
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(45, 23);
            this.copy.TabIndex = 2;
            this.copy.Text = "粘贴";
            this.copy.UseVisualStyleBackColor = true;
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(257, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(130, 130);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // previousSheet
            // 
            this.previousSheet.Location = new System.Drawing.Point(12, 167);
            this.previousSheet.Name = "previousSheet";
            this.previousSheet.Size = new System.Drawing.Size(49, 23);
            this.previousSheet.TabIndex = 4;
            this.previousSheet.Text = "上一张";
            this.previousSheet.UseVisualStyleBackColor = true;
            this.previousSheet.Click += new System.EventHandler(this.previousSheet_Click);
            // 
            // nextSheet
            // 
            this.nextSheet.Location = new System.Drawing.Point(93, 167);
            this.nextSheet.Name = "nextSheet";
            this.nextSheet.Size = new System.Drawing.Size(49, 23);
            this.nextSheet.TabIndex = 5;
            this.nextSheet.Text = "下一张";
            this.nextSheet.UseVisualStyleBackColor = true;
            this.nextSheet.Click += new System.EventHandler(this.nextSheet_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "哼哼.gif");
            this.imageList1.Images.SetKeyName(1, "幸福.gif");
            this.imageList1.Images.SetKeyName(2, "夜晚.gif");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 266);
            this.Controls.Add(this.nextSheet);
            this.Controls.Add(this.previousSheet);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.copy);
            this.Controls.Add(this.cut);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "获取剪贴板中图片";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cut;
        private System.Windows.Forms.Button copy;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button previousSheet;
        private System.Windows.Forms.Button nextSheet;
        private System.Windows.Forms.ImageList imageList1;
    }
}

