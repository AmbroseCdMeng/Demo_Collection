using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
namespace Microimage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Image ResourceImage;
        private int ImageWidth;
        private int ImageHeight;
        public string ErrMessage;
        public bool ThumbnailCallback()
        {
            return false;
        }
        public bool GetReducedImage(double Percent, string targetFilePath)
        {
            try
            {
                Bitmap bt = new Bitmap(120, 120);
                Graphics g = Graphics.FromImage(bt);
                g.Clear(Color.White);
                Image ReducedImage;
                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                ImageWidth = Convert.ToInt32(ResourceImage.Width * Percent);
                ImageHeight = Convert.ToInt32(ResourceImage.Height * Percent);
                ReducedImage = ResourceImage.GetThumbnailImage(ImageWidth, ImageHeight, callb, IntPtr.Zero);
                if (ImageWidth > ImageHeight)
                {
                    g.DrawImage(ReducedImage, 0, (int)(120 - ImageHeight) / 2, ImageWidth, ImageHeight);
                }
                else
                {
                    g.DrawImage(ReducedImage, (int)(120 - ImageWidth) / 2, 0, ImageWidth, ImageHeight);
                }
                g.DrawRectangle(new Pen(Color.Gainsboro), 0, 0, 119, 119);
                bt.Save(@targetFilePath, ImageFormat.Jpeg);
                bt.Dispose();
                ReducedImage.Dispose();
                return true;
            }
            catch (Exception e)
            {
                ErrMessage = e.Message;
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double percent;
            string imgpath = openFileDialog1.FileName;
            string imgName = imgpath.ToString().Substring(imgpath.ToString().LastIndexOf("\\") + 1, imgpath.ToString().Length - 1 - imgpath.ToString().LastIndexOf("\\"));
            imgName = imgName.Remove(imgName.LastIndexOf("."));
            if (openFileDialog1.FileName.Length != 0)
            {
                ResourceImage = Image.FromFile(openFileDialog1.FileName);
                if (ResourceImage.Width < ResourceImage.Height)
                {
                    percent = (double)120 / ResourceImage.Height;
                }
                else
                {
                    percent = (double)120 / ResourceImage.Width;
                }
                GetReducedImage(percent, "c:\\_" + imgName + ".JPG");
                pictureBox2.Image = Image.FromFile("c:\\_" + imgName + ".JPG");
            }
        }
    }
}
