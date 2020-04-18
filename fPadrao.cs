using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAndromeda
{
    public partial class fPadrao : Form
    {
        const uint WM_NCHITTEST = 0x0084, WM_MOUSEMOVE = 0x0200, HTLEFT = 10, HTRIGHT = 11, HTBOTTOMRIGHT = 17,
        HTBOTTOM = 15, HTBOTTOMLEFT = 16, HTTOP = 12, HTTOPLEFT = 13, HTTOPRIGHT = 14;
        Size formSize;
        Point screenPoint, clientPoint;
        Dictionary<uint, Rectangle> boxes;
        const int RHS = 10; // RESIZE_HANDLE_SIZE
        bool handled;
        public fPadrao()
        {
            InitializeComponent();
            this.Padding = new System.Windows.Forms.Padding(1);
        }
        protected override void WndProc(ref Message m)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                base.WndProc(ref m);
                return;
            }

            handled = false;
            if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE)
            {
                formSize = this.Size;
                screenPoint = new Point(m.LParam.ToInt32());
                clientPoint = this.PointToClient(screenPoint);

                boxes = new Dictionary<uint, Rectangle>() {
                {HTBOTTOMLEFT, new Rectangle(0, formSize.Height - RHS, RHS, RHS)},
                {HTBOTTOM, new Rectangle(RHS, formSize.Height - RHS, formSize.Width - 2*RHS, RHS)},
                {HTBOTTOMRIGHT, new Rectangle(formSize.Width - RHS, formSize.Height - RHS, RHS, RHS)},
                {HTRIGHT, new Rectangle(formSize.Width - RHS, RHS, RHS, formSize.Height - 2*RHS)},
                {HTTOPRIGHT, new Rectangle(formSize.Width - RHS, 0, RHS, RHS) },
                {HTTOP, new Rectangle(RHS, 0, formSize.Width - 2*RHS, RHS) },
                {HTTOPLEFT, new Rectangle(0, 0, RHS, RHS) },
                {HTLEFT, new Rectangle(0, RHS, RHS, formSize.Height - 2*RHS) }
            };

                foreach (var hitBox in boxes)
                {
                    if (hitBox.Value.Contains(clientPoint))
                    {
                        m.Result = (IntPtr)hitBox.Key;
                        handled = true;
                        break;
                    }
                }
            }

            if (!handled)
                base.WndProc(ref m);
        }
        private void fPadrao_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private void fPadrao_ResizeEnd(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                btnMaximizar.Image = Properties.Resources.up;
            }
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                btnMaximizar.Image = Properties.Resources.down;
                this.WindowState = FormWindowState.Maximized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                btnMaximizar.Image = Properties.Resources.up;
                this.WindowState = FormWindowState.Normal;
            }
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
