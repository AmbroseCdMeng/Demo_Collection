using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace magnetism
{
    public partial class Frm_Play : Form
    {
        public Frm_Play()
        {
            InitializeComponent();
        }

        #region  公共变量
        FrmClass Cla_FrmClass = new FrmClass();
        public static Form F_List = new Form();
        public static Form F_Libretto = new Form();
        public static Form F_Screen = new Form();
        #endregion

        private void Frm_Play_Load(object sender, EventArgs e)
        {
            //窗体位置的初始化
            Cla_FrmClass.FrmInitialize(this);
        }

        private void panel_Title_MouseDown(object sender, MouseEventArgs e)
        {
            int Tem_Y = 0;
            if (e.Button == MouseButtons.Left)
            {
                Cla_FrmClass.FrmBackCheck();
                Tem_Y = e.Y;
                FrmClass.FrmPoint = new Point(e.X, Tem_Y);
                FrmClass.CPoint = new Point(-e.X, -Tem_Y);
                if (FrmClass.Example_List_AdhereTo)
                {
                    Cla_FrmClass.FrmDistanceJob(this, F_List);
                    if (FrmClass.Example_Assistant_AdhereTo)
                    {
                        Cla_FrmClass.FrmDistanceJob(this, F_Libretto);
                    }
                }
                if (FrmClass.Example_Libretto_AdhereTo)
                {
                    Cla_FrmClass.FrmDistanceJob(this, F_Libretto);
                    if (FrmClass.Example_Assistant_AdhereTo)
                    {
                        Cla_FrmClass.FrmDistanceJob(this, F_List);
                    }
                }
            }
        }

        private void panel_Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                Cla_FrmClass.FrmMove(this, e);
                if (FrmClass.Example_List_AdhereTo)
                {

                    Cla_FrmClass.ManyFrmMove(this, e, F_List);
                    Cla_FrmClass.FrmInitialize(F_List);
                    if (FrmClass.Example_Assistant_AdhereTo)
                    {
                        Cla_FrmClass.ManyFrmMove(this, e, F_Libretto);
                        Cla_FrmClass.FrmInitialize(F_Libretto);
                    }
                }

                if (FrmClass.Example_Libretto_AdhereTo)
                {
                    Cla_FrmClass.ManyFrmMove(this, e, F_Libretto);
                    Cla_FrmClass.FrmInitialize(F_Libretto);
                    if (FrmClass.Example_Assistant_AdhereTo)
                    {
                        Cla_FrmClass.ManyFrmMove(this, e, F_List);
                        Cla_FrmClass.FrmInitialize(F_List);
                    }
                }
                Cla_FrmClass.FrmInitialize(this);
            }
        }

        private void panel_Title_MouseUp(object sender, MouseEventArgs e)
        {
            Cla_FrmClass.FrmPlace(this);
        }

        private void Frm_Play_Shown(object sender, EventArgs e)
        {
            //显示列表窗体
            F_List = new Frm_ListBox();
            F_List.ShowInTaskbar = false;
            FrmClass.Example_ListShow = true;
            F_List.Show();
            //显示歌词窗体
            F_Libretto = new Frm_Libretto();
            F_Libretto.ShowInTaskbar = false;
            FrmClass.Example_LibrettoShow = true;
            F_Libretto.Show();
            F_Libretto.Left = this.Left + this.Width;
            F_Libretto.Top = this.Top;
            //各窗体位置的初始化
            Cla_FrmClass.FrmInitialize(F_List);
            Cla_FrmClass.FrmInitialize(F_Libretto);
        }

        private void panel_Close_Click(object sender, EventArgs e)
        {
            F_List.Close();
            F_List.Dispose();
            F_Libretto.Close();
            F_Libretto.Dispose();
            F_Screen.Close();
            F_Screen.Dispose();
            this.Close();
        }

        private void panel_Title_Click(object sender, EventArgs e)
        {
            F_List.Focus();
            F_Libretto.Focus();
            this.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(F_List.Tag.ToString()) == 0)
            {
                F_List.Tag = 1;
                F_List.Visible = false;
            }
            else
            {
                F_List.Tag = 0;
                F_List.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(F_Libretto.Tag.ToString()) == 0)
            {
                F_Libretto.Tag = 1;
                F_Libretto.Visible = false;
            }
            else
            {
                F_Libretto.Tag = 0;
                F_Libretto.Visible = true;
            }
        }

    }
}
