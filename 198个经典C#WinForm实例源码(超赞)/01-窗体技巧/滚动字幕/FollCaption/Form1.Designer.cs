namespace FollCaption
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.WindowText;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Items.AddRange(new object[] {
            "/// <summary>",
            "/// 在显示预览和屏保前，对窗体中的各控件进行设置",
            "/// </summary>",
            "/// <param panel =\"Control\">设置父级控件</param>",
            "public void multimedia(Control panel)",
            "{",
            "    LabelVisible(true);\t\t\t\t\t\t\t\t\t//显示要移动的文本",
            "    if (panel.Name == \"form1\")\t\t\t\t\t\t\t\t//如果父级窗体是当前窗体",
            "    {",
            "        isbool = false;\t\t\t\t\t\t\t\t\t//隐藏",
            "        fontSize = 20;\t\t\t\t\t\t\t\t\t//设置字体大小",
            "    }",
            "    else",
            "    {",
            "        isbool = true;\t\t\t\t\t\t\t\t\t\t//显示",
            "        fontSize = 10;\t\t\t\t\t\t\t\t\t//设置字体大小",
            "    }",
            "    label1.Text = \"字幕滚动\";\t\t\t\t\t\t\t\t//设置文本",
            "    label1.Parent = panel;\t\t\t\t\t\t\t\t\t//设置父级控件",
            "    label1.Font = new Font(\"宋体\", fontSize, FontStyle.Bold);\t\t//设置字体样式",
            "    label2.Parent = panel;\t\t\t\t\t\t\t\t\t//设置父级控件",
            "    label2.Text = \"字\" + \"\\n\" + \"幕\" + \"\\n\" + \"滚\" + \"\\n\" + \"动\";\t\t//设置纵向文本",
            "    label2.Font = new Font(\"宋体\", fontSize, FontStyle.Bold);\t\t//设置字体样式",
            "    label3.Text = \"动滚幕字\";\t\t\t\t\t\t\t//设置文本",
            "    label3.Parent = panel;\t\t\t\t\t\t\t\t\t//设置父级控件",
            "    label3.Font = new Font(\"宋体\", fontSize, FontStyle.Bold);\t\t//设置字体样式",
            "    label4.Text = \"动\" + \"\\n\" + \"滚\" + \"\\n\" + \"幕\" + \"\\n\" + \"字\";\t\t//设置纵向文本",
            "    label4.Parent = panel;\t\t\t\t\t\t\t\t\t//设置父级控件",
            "    label4.Font = new Font(\"宋体\", fontSize, FontStyle.Bold);\t\t//设置字体样式",
            "    panel.Visible = isbool;\t\t\t\t\t\t\t\t\t//隐藏或显示",
            "    button1.Visible = isbool;\t\t\t\t\t\t\t\t//隐藏或显示",
            "    button2.Visible = isbool;\t\t\t\t\t\t\t\t//隐藏或显示",
            "    label1.Top = panel.Height / 4;\t\t\t\t\t\t\t\t//设置当前控件的显示位置",
            "    label3.Top = (panel.Height / 4) * 3;\t\t\t\t\t\t\t//设置当前控件的显示位置",
            "    label3.Left = 0 - label2.Width;\t\t\t\t\t\t\t\t//设置当前控件的显示位置",
            "    label4.Left = (panel.Width / 4) * 3;\t\t\t\t\t\t\t//设置当前控件的显示位置",
            "    label4.Top = 0 - label2.Height;\t\t\t\t\t\t\t//设置当前控件的显示位置",
            "    label2.Left = panel.Width / 4;\t\t\t\t\t\t\t\t//设置当前控件的显示位置",
            "    FrmContainer = panel;\t\t\t\t\t\t\t\t\t//记录父级控件",
            "}"});
            this.listBox1.Location = new System.Drawing.Point(56, 377);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(400, 480);
            this.listBox1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(513, 341);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "滚动字幕";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Timer timer1;
    }
}

