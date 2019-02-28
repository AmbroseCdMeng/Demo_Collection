namespace ShadeColorControl
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
            this.t_Control1 = new ClarityControl.T_Control();
            this.SuspendLayout();
            // 
            // t_Control1
            // 
            this.t_Control1.BackColor = System.Drawing.Color.Transparent;
            this.t_Control1.Location = new System.Drawing.Point(33, 62);
            this.t_Control1.Name = "t_Control1";
            this.t_Control1.ShadeAspect = ClarityControl.T_Control.AspectStyle.TopToButtom;
            this.t_Control1.ShadeColor = System.Drawing.Color.Black;
            this.t_Control1.Size = new System.Drawing.Size(200, 53);
            this.t_Control1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.t_Control1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ClarityControl.T_Control t_Control1;
    }
}

