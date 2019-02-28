using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace drawcur
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int _X, _Y;
        [StructLayout(LayoutKind.Sequential)]
        private struct ICONINFO
        {
            public bool fIcon;
            public Int32 xHotspot;
            public Int32 yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public Point ptScreenPos;
        }
        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        private static extern int GetSystemMetrics(int mVal);
        [DllImport("user32.dll", EntryPoint = "GetCursorInfo")]
        private static extern bool GetCursorInfo(ref CURSORINFO cInfo);
        [DllImport("user32.dll", EntryPoint = "CopyIcon")]
        private static extern IntPtr CopyIcon(IntPtr hIcon);
        [DllImport("user32.dll", EntryPoint = "GetIconInfo")]
        private static extern bool GetIconInfo(IntPtr hIcon, out ICONINFO iInfo);
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private Bitmap CaptureCursor(ref int _CX, ref int _CY)
        {
            IntPtr _Icon;
            CURSORINFO _CursorInfo = new CURSORINFO();
            ICONINFO _IconInfo;
            _CursorInfo.cbSize = Marshal.SizeOf(_CursorInfo);
            if (GetCursorInfo(ref _CursorInfo))
            {
                if (_CursorInfo.flags == 0x00000001)
                {
                    _Icon = CopyIcon(_CursorInfo.hCursor);

                    if (GetIconInfo(_Icon, out _IconInfo))
                    {
                        _CX = _CursorInfo.ptScreenPos.X - _IconInfo.xHotspot;
                        _CY = _CursorInfo.ptScreenPos.Y - _IconInfo.yHotspot;
                        return Icon.FromHandle(_Icon).ToBitmap();
                    }
                }
            }
            return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int x=Control.MousePosition.X;
            int y=Control.MousePosition.Y;
            pictureBox1.Image = CaptureCursor(ref x,ref y);
        }
    }
}
