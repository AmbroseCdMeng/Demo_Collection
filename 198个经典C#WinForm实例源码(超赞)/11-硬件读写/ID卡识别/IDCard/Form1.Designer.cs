namespace IDCard
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIdcard = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbbdep = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbsex = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbbShowDep = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbShowSex = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtShowName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtShowCardID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIdcard);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cbbdep);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbbsex);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入员工信息";
            // 
            // txtIdcard
            // 
            this.txtIdcard.Location = new System.Drawing.Point(69, 21);
            this.txtIdcard.Name = "txtIdcard";
            this.txtIdcard.Size = new System.Drawing.Size(137, 21);
            this.txtIdcard.TabIndex = 4;
            this.txtIdcard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdcard_KeyPress);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(214, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "重置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(131, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbbdep
            // 
            this.cbbdep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbdep.FormattingEnabled = true;
            this.cbbdep.Items.AddRange(new object[] {
            "C#部门",
            "ASP.NET部门",
            "基础部",
            "VB部门",
            "VC部门",
            "JAVA部门"});
            this.cbbdep.Location = new System.Drawing.Point(279, 57);
            this.cbbdep.Name = "cbbdep";
            this.cbbdep.Size = new System.Drawing.Size(137, 20);
            this.cbbdep.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "所属部门：";
            // 
            // cbbsex
            // 
            this.cbbsex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbsex.FormattingEnabled = true;
            this.cbbsex.Items.AddRange(new object[] {
            "男职工",
            "女职工"});
            this.cbbsex.Location = new System.Drawing.Point(69, 57);
            this.cbbsex.Name = "cbbsex";
            this.cbbsex.Size = new System.Drawing.Size(137, 20);
            this.cbbsex.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "员工性别：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(279, 21);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(137, 21);
            this.txtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "员工姓名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID卡编号：";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(10, 8);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(95, 16);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "添加员工信息";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(10, 157);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(95, 16);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "获取员工信息";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbbShowDep);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbbShowSex);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtShowName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtShowCardID);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(10, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 93);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "员工信息";
            // 
            // cbbShowDep
            // 
            this.cbbShowDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbShowDep.FormattingEnabled = true;
            this.cbbShowDep.Items.AddRange(new object[] {
            "C#部门",
            "ASP.NET部门",
            "基础部",
            "VB部门",
            "VC部门",
            "JAVA部门"});
            this.cbbShowDep.Location = new System.Drawing.Point(279, 57);
            this.cbbShowDep.Name = "cbbShowDep";
            this.cbbShowDep.Size = new System.Drawing.Size(137, 20);
            this.cbbShowDep.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "所属部门：";
            // 
            // cbbShowSex
            // 
            this.cbbShowSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbShowSex.FormattingEnabled = true;
            this.cbbShowSex.Items.AddRange(new object[] {
            "男职工",
            "女职工"});
            this.cbbShowSex.Location = new System.Drawing.Point(69, 57);
            this.cbbShowSex.Name = "cbbShowSex";
            this.cbbShowSex.Size = new System.Drawing.Size(137, 20);
            this.cbbShowSex.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "员工性别：";
            // 
            // txtShowName
            // 
            this.txtShowName.Location = new System.Drawing.Point(279, 21);
            this.txtShowName.Name = "txtShowName";
            this.txtShowName.Size = new System.Drawing.Size(137, 21);
            this.txtShowName.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(212, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "员工姓名：";
            // 
            // txtShowCardID
            // 
            this.txtShowCardID.Location = new System.Drawing.Point(69, 22);
            this.txtShowCardID.Name = "txtShowCardID";
            this.txtShowCardID.Size = new System.Drawing.Size(137, 21);
            this.txtShowCardID.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "ID卡编号：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 276);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "使用ID卡识别员工编号";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbbdep;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbsex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbbShowDep;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbShowSex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtShowName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtShowCardID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIdcard;
    }
}

