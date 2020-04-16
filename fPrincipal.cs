using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAndromeda
{
    public partial class fPrincipal : Form
    {
        public fPrincipal()
        {
            InitializeComponent();
            customizarDesign();
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            this.Padding = new System.Windows.Forms.Padding(1);
        }

        const uint WM_NCHITTEST = 0x0084, WM_MOUSEMOVE = 0x0200,
                     HTLEFT = 10, HTRIGHT = 11, HTBOTTOMRIGHT = 17,
                     HTBOTTOM = 15, HTBOTTOMLEFT = 16, HTTOP = 12,
                     HTTOPLEFT = 13, HTTOPRIGHT = 14;
        Size formSize;
        Point screenPoint;
        Point clientPoint;

        private void btnControleAcesso_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(pnlControleAcesso);
        }

        Dictionary<uint, Rectangle> boxes;
        const int RHS = 10; // RESIZE_HANDLE_SIZE
        bool handled;

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(pnlCadastro);
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(pnlRelatorios);
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
        }

        private void btnPermissoes_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair do sistema?", "Sair", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                fLogin login = new fLogin();
                login.Closed += (s, args) => this.Close();
                login.Show();
            }
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

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fPrincipal_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
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
        private void customizarDesign()
        {
            pnlControleAcesso.Visible = false;
            pnlCadastro.Visible = false;
            pnlRelatorios.Visible = false;
        }
        private void esconderSubMenu()
        {
            if (pnlControleAcesso.Visible) pnlControleAcesso.Visible = false;
            if (pnlCadastro.Visible) pnlCadastro.Visible = false;
            if (pnlRelatorios.Visible) pnlRelatorios.Visible = false;
        }
        private void mostrarSubMenu(Panel panel)
        {
            if (!panel.Visible)
            {
                esconderSubMenu();
                panel.Visible = true;
            }
            else
                panel.Visible = false;
        }
    }
}
