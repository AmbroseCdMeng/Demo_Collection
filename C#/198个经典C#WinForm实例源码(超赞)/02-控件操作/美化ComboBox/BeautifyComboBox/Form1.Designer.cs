namespace BeautifyComboBox
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
            this.b_ComboBox1 = new BeautifyComboBox.B_ComboBox();
            this.SuspendLayout();
            // 
            // b_ComboBox1
            // 
            this.b_ComboBox1.Color1 = System.Drawing.Color.CornflowerBlue;
            this.b_ComboBox1.Color1Gradual = System.Drawing.Color.Thistle;
            this.b_ComboBox1.Color2 = System.Drawing.Color.PaleGreen;
            this.b_ComboBox1.Color2Gradual = System.Drawing.Color.DarkKhaki;
            this.b_ComboBox1.ColorSelect = System.Drawing.Color.Gainsboro;
            this.b_ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.b_ComboBox1.FormattingEnabled = true;
            this.b_ComboBox1.GradualC = false;
            this.b_ComboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.b_ComboBox1.Location = new System.Drawing.Point(60, 66);
            this.b_ComboBox1.Name = "b_ComboBox1";
            this.b_ComboBox1.Size = new System.Drawing.Size(121, 22);
            this.b_ComboBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.b_ComboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private B_ComboBox b_ComboBox1;
    }
}

