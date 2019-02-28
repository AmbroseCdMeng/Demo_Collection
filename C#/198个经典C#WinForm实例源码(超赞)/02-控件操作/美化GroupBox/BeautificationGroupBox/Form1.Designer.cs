namespace BeautificationGroupBox
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
            this.b_GroupBox1 = new BeautificationGroupBox.B_GroupBox();
            this.SuspendLayout();
            // 
            // b_GroupBox1
            // 
            this.b_GroupBox1.FColor = System.Drawing.Color.RoyalBlue;
            this.b_GroupBox1.LineColor = System.Drawing.Color.Silver;
            this.b_GroupBox1.Location = new System.Drawing.Point(39, 72);
            this.b_GroupBox1.Name = "b_GroupBox1";
            this.b_GroupBox1.Size = new System.Drawing.Size(200, 100);
            this.b_GroupBox1.TabIndex = 0;
            this.b_GroupBox1.TabStop = false;
            this.b_GroupBox1.Text = "员工信息";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.b_GroupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private B_GroupBox b_GroupBox1;





    }
}

