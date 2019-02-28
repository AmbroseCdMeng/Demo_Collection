using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrintStuResume
{
    public partial class frmPrint : Form
    {
        public frmPrint()
        {
            InitializeComponent();
        }

        //窗体获得焦点时显示打印按钮
        private void frmPrint_Activated(object sender, EventArgs e)
        {
            button1.Visible = true;
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            labName.Text = frmMain.strName;
            labSex.Text = frmMain.strSex;
            labNPlace.Text = frmMain.strNPlace;
            labBirthday.Text = Convert.ToDateTime(frmMain.strBirthday).ToShortDateString();
            labNation.Text = frmMain.strNation;
            labSGao.Text = frmMain.strSGao;
            labTZhong.Text = frmMain.strTZhong;
            labHunYin.Text = frmMain.strHunYin;
            labXUELI.Text = frmMain.strXUELLI;
            labAddress.Text = frmMain.strAddress;
            labZY.Text = frmMain.strZHUANYE;
            labYX.Text = frmMain.strBYYX;
            labBYSJ.Text = Convert.ToDateTime(frmMain.strBYSJ).ToShortDateString();
            labWY.Text = frmMain.strWAIYU;
            labTel.Text = frmMain.strTel;
            labEmail.Text = frmMain.strEmail;
            labZW.Text = frmMain.strYPZW;
            labQZLX.Text = frmMain.strQZLX;
            labPlace.Text = frmMain.strGZDQ;
            labSalary.Text = frmMain.strSalary;
            labYear.Text = frmMain.strGZNX;
            labGZJL.Text = frmMain.strGZJL;
            labTC.Text = frmMain.strTECHANG;
            pictureBox1.Image = frmMain.imgPhoto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            CaptureScreen();
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest,
            int nXDest, int nYDest, int nWidth, int nHeight,
            IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics mygraphics = panel1.CreateGraphics();
            Size s = panel1.Size;
            memoryImage = new Bitmap(s.Width, s.Height,
                mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(
                memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, panel1.ClientRectangle.Width,
                panel1.ClientRectangle.Height, dc1, 0, 0,
                13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }
    }
}
