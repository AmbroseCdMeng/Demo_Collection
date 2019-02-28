namespace 自制数值文本框组件
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
            this.button1 = new System.Windows.Forms.Button();
            this.numberBox1 = new 自制数值文本框组件.NumberBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "保留两位小数";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numberBox1
            // 
            this.numberBox1.DataStyle = 自制数值文本框组件.NumberBox.StyleSort.Null;
            this.numberBox1.DecimalDigit = 2;
            this.numberBox1.Location = new System.Drawing.Point(31, 17);
            this.numberBox1.Name = "numberBox1";
            this.numberBox1.ReservedDigit = 2;
            this.numberBox1.ReservedStyle = 自制数值文本框组件.NumberBox.Reserved.Tropism;
            this.numberBox1.Size = new System.Drawing.Size(148, 21);
            this.numberBox1.TabIndex = 2;
            this.numberBox1.Text = "-87987.54735543";
            this.numberBox1.TextChanged += new System.EventHandler(this.numberBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 88);
            this.Controls.Add(this.numberBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "自制数值文本框控件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private NumberBox numberBox1;
    }
}

