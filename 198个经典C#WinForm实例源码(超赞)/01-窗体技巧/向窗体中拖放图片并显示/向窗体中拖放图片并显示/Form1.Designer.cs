namespace 向窗体中拖放图片并显示
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
            this.panel_face = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Tool_Ima = new System.Windows.Forms.ToolStripMenuItem();
            this.Tool_File = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel_face.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_face
            // 
            this.panel_face.ContextMenuStrip = this.contextMenuStrip1;
            this.panel_face.Controls.Add(this.treeView1);
            this.panel_face.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_face.Location = new System.Drawing.Point(0, 0);
            this.panel_face.Name = "panel_face";
            this.panel_face.Size = new System.Drawing.Size(391, 238);
            this.panel_face.TabIndex = 0;
            this.panel_face.Visible = false;
            this.panel_face.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tool_Ima,
            this.Tool_File});
            this.contextMenuStrip1.Name = "contextMenuStrip2";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // Tool_Ima
            // 
            this.Tool_Ima.Name = "Tool_Ima";
            this.Tool_Ima.Size = new System.Drawing.Size(152, 22);
            this.Tool_Ima.Tag = "1";
            this.Tool_Ima.Text = "拖放图片";
            this.Tool_Ima.Click += new System.EventHandler(this.Tool_Ima_Click);
            // 
            // Tool_File
            // 
            this.Tool_File.Name = "Tool_File";
            this.Tool_File.Size = new System.Drawing.Size(152, 22);
            this.Tool_File.Tag = "2";
            this.Tool_File.Text = "拖放文件夹";
            this.Tool_File.Click += new System.EventHandler(this.Tool_Ima_Click);
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(391, 238);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 238);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.panel_face);
            this.Name = "Form1";
            this.Text = "向窗体中拖放图片并显示";
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.panel_face.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_face;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Tool_Ima;
        private System.Windows.Forms.ToolStripMenuItem Tool_File;
        private System.Windows.Forms.TreeView treeView1;

    }
}

