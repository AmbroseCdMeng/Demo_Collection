using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ImageClarity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Image new_img;
        private void ChangeAlpha()
        {
            pictureBox1.Refresh();
            Bitmap source = new Bitmap(pictureBox1.Image);
            Bitmap effect = new Bitmap(pictureBox1.Image.Width,pictureBox1.Image.Height);
            Graphics _effect = Graphics.FromImage(effect);
            float[][] matrixItems ={new float[]{1,0,0,0,0},
                                      new float [] {0,1,0,0,0},
                                      new float []{0,0,1,0,0},
                                      new float []{0,0,0,0,0},
                                      new float[]{0,0,0,trackBar1.Value/255f,1}};
            ColorMatrix imgMatrix = new ColorMatrix(matrixItems);
            ImageAttributes imgEffect = new ImageAttributes();
            imgEffect.SetColorMatrix(imgMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            if (source.Width <= 368)
            {
                _effect.DrawImage(source, new Rectangle(0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height), 0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height, GraphicsUnit.Pixel, imgEffect);
            }
            else
            {
                _effect.DrawImage(pictureBox1.Image, new Rectangle(0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height), 0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height, GraphicsUnit.Pixel, imgEffect);
            }
            pictureBox1.Image = effect;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            ChangeAlpha();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}
