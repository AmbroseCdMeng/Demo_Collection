using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoMonitor
{
    public partial class frmPlay : Form
    {
        public frmPlay()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            ofDialog.Filter = "*.avi|*.avi";
            ofDialog.Title = "ѡ����Ƶ�ļ�";
            ofDialog.InitialDirectory = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\")) + "\\Video\\";
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                this.axWindowsMediaPlayer1.URL = ofDialog.FileName;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}