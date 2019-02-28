using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace BeautificationGroupBox
{
    public partial class B_GroupBox : GroupBox
    {
        //private string BText;
        public B_GroupBox()
        {
            InitializeComponent();
            //BText = Name;
        }

        Rectangle rect;
        Rectangle rectT = new Rectangle(5, 1, 0, 0);
        float TextW = 0;
        float TextH = 0;
        string SText = "";
        bool NullText = false;

        
        //[Browsable(true), Category("属性设置"), Description("设置文本")]
        //public string Text
        //{
        //    get { return BText; }
        //    set
        //    {
        //        BText = value;
        //        if (BText.Length > 0)
        //            Invalidate();
        //    }
        //}

        private Color TLineColor = Color.Silver;
        [Browsable(true), Category("属性设置"), Description("设置文本")]
        public Color LineColor
        {
            get { return TLineColor; }
            set
            {
                TLineColor = value;
                Invalidate();
            }
        }

        private Color TFColor = Color.RoyalBlue;
        [Browsable(true), Category("属性设置"), Description("设置标题文本颜色")]
        public Color FColor
        {
            get { return TFColor; }
            set
            {
                TFColor = value;
                Invalidate();
            }
        }

        public void GetSize()
        {
            rect = new Rectangle(0, 0, this.Width, this.Height);//设置绘制按钮的矩形区域
        }

        public float GetTextSize(string str, Font F, bool B)
        {
            Graphics TitG = this.CreateGraphics();//创建Graphics类对象
            string TitS = str;//获取图表标题的名称
            SizeF TitSize = TitG.MeasureString(TitS, F);//将绘制的字符串进行格式化
            float TitWidth = TitSize.Width;//获取字符串的宽度
            float TitHeight = TitSize.Height;//获取字符串的高度
            if (B)
                return TitWidth;
            else
                return TitHeight;
        }

        //private void onLoad(object sender, EventArgs e)
        //{
        //    Text = base.Name;
        //}

        private void B_GroupBox_Paint(object sender, PaintEventArgs e)
        {
            GetSize();
            e.Graphics.FillRectangle(new SolidBrush(base.BackColor), rect);
            if (Text.Length > 0)
            {
                SText = Text;
                NullText = false;
            }
            else
            {
                SText = "空";
                NullText = true;
            }
            TextH = GetTextSize(SText, this.Font, false);
            TextH = TextH / (float)2.0;
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(LineColor), 1), rect.X + 1, rect.Y + 1 + TextH, rect.Width - 2, rect.Height - 2 - TextH);
            if (NullText)
                TextW = 0.0F;
            else
            {
                TextW = GetTextSize(SText, this.Font, true);
                rectT = new Rectangle(8, 1, 0, 0);
                rectT.Width = (int)Math.Floor(TextW);
                rectT.Height = (int)Math.Floor(TextH * 2);
                e.Graphics.FillRectangle(new SolidBrush(base.BackColor), rectT);
                e.Graphics.DrawString(SText, this.Font, new SolidBrush(this.FColor), new PointF(rectT.X + 2, rectT.Y));
            }
        }
    }
}
