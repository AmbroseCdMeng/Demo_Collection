namespace Combination
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
            this.labelAndText1 = new Combination.LabelAndText();
            this.SuspendLayout();
            // 
            // labelAndText1
            // 
            this.labelAndText1.LabelText = "职工姓名：";
            this.labelAndText1.Location = new System.Drawing.Point(37, 60);
            this.labelAndText1.Name = "labelAndText1";
            this.labelAndText1.Size = new System.Drawing.Size(166, 21);
            this.labelAndText1.TabIndex = 0;
            this.labelAndText1.TextBoxText = "张某";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.labelAndText1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private LabelAndText labelAndText1;
    }
}

