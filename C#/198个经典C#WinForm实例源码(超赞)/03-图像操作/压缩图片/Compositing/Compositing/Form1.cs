using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
namespace Compositing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static bool GetPicThumbnail(string sFile, string dFile, int dHeight, int dWidth)
        {
            Image iSource = Image.FromFile(sFile);
            ImageFormat tFormat = iSource.RawFormat;
            int sW = 0, sH = 0;
            // 按比例缩放
            Size tem_size = new Size(iSource.Width, iSource.Height);
            if (tem_size.Height > dHeight || tem_size.Width > dWidth)
            {
                if ((tem_size.Width * dHeight) > (tem_size.Height * dWidth))
                {
                    sW = dWidth;
                    sH = (dWidth * tem_size.Height) / tem_size.Width;
                }
                else
                {
                    sH = dHeight;
                    sW = (tem_size.Width * dHeight) / tem_size.Height;
                }
            }
            else
            {
                sW = tem_size.Width;
                sH = tem_size.Height;
            }
            Bitmap oB = new Bitmap(dWidth, dHeight);
            Graphics g = Graphics.FromImage(oB);
            g.Clear(Color.WhiteSmoke);
            // 设置画布的描绘质量
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);
            g.Dispose();
            // 以下代码为保存图片时，设置压缩质量
            EncoderParameters eP = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = 100;
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            eP.Param[0] = eParam;
            try
            {
                //获得包含有关内置图像编码解码器的信息的ImageCodecInfo对象。
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];//设置JPEG编码
                        break;
                    }
                }
                if (jpegICIinfo != null)
                {
                    oB.Save(dFile, jpegICIinfo, eP);
                }
                else
                {
                    oB.Save(dFile, tFormat);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                iSource.Dispose();
                oB.Dispose();
            }
        }
        string strSourcePath;
        string strSavePath;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string imgName = strSourcePath.ToString().Substring(strSourcePath.ToString().LastIndexOf("\\") + 1, strSourcePath.ToString().Length - 1 - strSourcePath.ToString().LastIndexOf("\\"));
            strSavePath = "c:\\_";
            Image ig = Image.FromFile(strSourcePath);
            GetPicThumbnail(strSourcePath, strSavePath + imgName, Convert.ToInt32(ig.Width * 50 / 100), Convert.ToInt32(ig.Height * 50 / 100));
            FileInfo fii = new FileInfo(strSavePath + imgName);
            label2.Text = "压缩后的图片大小："+(fii.Length/1024).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileInfo fi;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strSourcePath = openFileDialog1.FileName;
                fi = new FileInfo(strSourcePath);
                label1.Text = "原始图片大小："+(fi.Length/1024).ToString();
            }
        }
    }
}
