using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PrintImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 实例化全局类对象和变量
        private Bitmap mImage;          //声明位图对象
        #endregion

        #region 将一幅位图从一个设备场景复制到另一个
        /// <summary>
        /// 将一幅位图从一个设备场景复制到另一个
        /// </summary>
        /// <param name="hdcDest">目标设备场景</param>
        /// <param name="nXDest">对目标DC中目标矩形左上角位置进行描述的那个点,用目标DC的逻辑X坐标表示</param>
        /// <param name="nYDest">对目标DC中目标矩形左上角位置进行描述的那个点,用目标DC的逻辑Y坐标表示</param>
        /// <param name="nWidth">欲传输图象的宽度</param>
        /// <param name="nHeight">欲传输图象的高度</param>
        /// <param name="hdcSrc">源设备场景,如光栅运算未指定源，则应设为0</param>
        /// <param name="nXSrc">对源DC中源矩形左上角位置进行描述的那个点用源DC的逻辑X坐标表示</param>
        /// <param name="nYSrc">对源DC中源矩形左上角位置进行描述的那个点用源DC的逻辑Y坐标表示</param>
        /// <param name="dwRop">传输过程要执行的光栅运算</param>
        /// <returns>非零表示成功，零表示失败</returns>
        [DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest,int nXDest,int nYDest,int nWidth,
            int nHeight,IntPtr hdcSrc,int nXSrc,int nYSrc,int dwRop);
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            captureScreen();
            printPreviewDialog1.ShowDialog();
        }     

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(mImage,200,50);                //打印图片
        }

        #region 绘制图片
        /// <summary>
        /// 绘制图片
        /// </summary>
        private void captureScreen()
        {
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                Size s = pictureBox1.Size;
                mImage = new Bitmap(s.Width, s.Height, g);
                using (Graphics mg = Graphics.FromImage(mImage))
                {
                    IntPtr dc1 = g.GetHdc();
                    IntPtr dc2 = mg.GetHdc();
                    BitBlt(dc2, 0, 0, pictureBox1.ClientRectangle.Width, pictureBox1.ClientRectangle.Height, dc1, 0, 0, 13369376);
                    g.ReleaseHdc(dc1);
                    mg.ReleaseHdc(dc2);
                }
            }
        }
        #endregion
    }
}
