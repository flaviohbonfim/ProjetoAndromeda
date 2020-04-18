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
            this.Padding = new System.Windows.Forms.Padding(1);
            tbcPrincipal.TabPages.Remove(tabCadastro);
            tbcPrincipal.TabPages.Remove(tabRelatorios);
            tbcPrincipal.TabPages.Remove(tabControleAcesso);
        }

        private void btnControleAcesso_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(pnlControleAcesso);
        }

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
            if (!tbcPrincipal.Controls.Contains(tabCadastro)) tbcPrincipal.TabPages.Add(tabCadastro);

            MetroFramework.Controls.MetroTabPage tp = new MetroFramework.Controls.MetroTabPage();
            string title = "tabCliente" + (tbcCadastro.TabCount + 1).ToString();
            tp.Name = title;
            tp.Text = "Cliente";
            tp.Padding = tabCadastro.Padding;
            tbcCadastro.TabPages.Add(tp);
            fCadCliente frm = new fCadCliente();
            frm.FormClosed += tabCadastroFechada;
            frm.TopLevel = false;
            tp.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();

            tbcPrincipal.SelectedTab = tabCadastro;
            tbcCadastro.SelectedTab = tp;
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            if (!tbcPrincipal.Controls.Contains(tabCadastro)) tbcPrincipal.TabPages.Add(tabCadastro);

            MetroFramework.Controls.MetroTabPage tp = new MetroFramework.Controls.MetroTabPage();
            string title = "tabProduto" + (tbcCadastro.TabCount + 1).ToString();
            tp.Name = title;
            tp.Text = "Produto";
            tp.Padding = tabCadastro.Padding;
            tbcCadastro.TabPages.Add(tp);
            fCadCliente frm = new fCadCliente();
            frm.FormClosed += tabCadastroFechada;
            frm.TopLevel = false;
            tp.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();

            tbcPrincipal.SelectedTab = tabCadastro;
            tbcCadastro.SelectedTab = tp;
        }
        private void tabCadastroFechada(object sender, FormClosedEventArgs e)
        {
            TabPage currentTab = tbcCadastro.SelectedTab;
            tbcCadastro.TabPages.Remove(currentTab);
            if (tbcCadastro.TabPages.Count == 0) tbcPrincipal.TabPages.Remove(tabCadastro);
        }
        private void tabControleAcessoFechada(object sender, FormClosedEventArgs e)
        {
            TabPage currentTab = tbcControleAcesso.SelectedTab;
            tbcControleAcesso.TabPages.Remove(currentTab);
            if (tbcControleAcesso.TabPages.Count == 0) tbcPrincipal.TabPages.Remove(tabControleAcesso);
        }
        private void tabRelatoriosFechada(object sender, FormClosedEventArgs e)
        {
            TabPage currentTab = tbcRelatorios.SelectedTab;
            tbcRelatorios.TabPages.Remove(currentTab);
            if (tbcRelatorios.TabPages.Count == 0) tbcPrincipal.TabPages.Remove(tabRelatorios);
        }
        private void btnUsuario_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            if (!tbcPrincipal.Controls.Contains(tabControleAcesso)) tbcPrincipal.TabPages.Add(tabControleAcesso);

            MetroFramework.Controls.MetroTabPage tp = new MetroFramework.Controls.MetroTabPage();
            string title = "tabUsuario" + (tbcControleAcesso.TabCount + 1).ToString();
            tp.Name = title;
            tp.Text = "Usuario";
            tp.Padding = tabControleAcesso.Padding;
            tbcControleAcesso.TabPages.Add(tp);
            fCadCliente frm = new fCadCliente();
            frm.FormClosed += tabControleAcessoFechada;
            frm.TopLevel = false;
            tp.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();

            tbcPrincipal.SelectedTab = tabControleAcesso;
            tbcControleAcesso.SelectedTab = tp;
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            if (!tbcPrincipal.Controls.Contains(tabControleAcesso)) tbcPrincipal.TabPages.Add(tabControleAcesso);

            MetroFramework.Controls.MetroTabPage tp = new MetroFramework.Controls.MetroTabPage();
            string title = "tabPerfil" + (tbcControleAcesso.TabCount + 1).ToString();
            tp.Name = title;
            tp.Text = "Perfil";
            tp.Padding = tabControleAcesso.Padding;
            tbcControleAcesso.TabPages.Add(tp);
            fCadCliente frm = new fCadCliente();
            frm.FormClosed += tabControleAcessoFechada;
            frm.TopLevel = false;
            tp.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();

            tbcPrincipal.SelectedTab = tabControleAcesso;
            tbcControleAcesso.SelectedTab = tp;
        }

        private void btnPermissoes_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            if (!tbcPrincipal.Controls.Contains(tabControleAcesso)) tbcPrincipal.TabPages.Add(tabControleAcesso);

            MetroFramework.Controls.MetroTabPage tp = new MetroFramework.Controls.MetroTabPage();
            string title = "tabPermissoes" + (tbcControleAcesso.TabCount + 1).ToString();
            tp.Name = title;
            tp.Text = "Permissoes";
            tp.Padding = tabControleAcesso.Padding;
            tbcControleAcesso.TabPages.Add(tp);
            fCadCliente frm = new fCadCliente();
            frm.FormClosed += tabControleAcessoFechada;
            frm.TopLevel = false;
            tp.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();

            tbcPrincipal.SelectedTab = tabControleAcesso;
            tbcControleAcesso.SelectedTab = tp;
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            if (!tbcPrincipal.Controls.Contains(tabRelatorios)) tbcPrincipal.TabPages.Add(tabRelatorios);

            MetroFramework.Controls.MetroTabPage tp = new MetroFramework.Controls.MetroTabPage();
            string title = "tabEstoque" + (tbcCadastro.TabCount + 1).ToString();
            tp.Name = title;
            tp.Text = "Estoque";
            tp.Padding = tabRelatorios.Padding;
            tbcRelatorios.TabPages.Add(tp);
            fCadCliente frm = new fCadCliente();
            frm.FormClosed += tabRelatoriosFechada;
            frm.TopLevel = false;
            tp.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();

            tbcPrincipal.SelectedTab = tabRelatorios;
            tbcRelatorios.SelectedTab = tp;
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            if (!tbcPrincipal.Controls.Contains(tabRelatorios)) tbcPrincipal.TabPages.Add(tabRelatorios);

            MetroFramework.Controls.MetroTabPage tp = new MetroFramework.Controls.MetroTabPage();
            string title = "tabVendas" + (tbcCadastro.TabCount + 1).ToString();
            tp.Name = title;
            tp.Text = "Vendas";
            tp.Padding = tabRelatorios.Padding;
            tbcRelatorios.TabPages.Add(tp);
            fCadCliente frm = new fCadCliente();
            frm.FormClosed += tabRelatoriosFechada;
            frm.TopLevel = false;
            tp.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();

            tbcPrincipal.SelectedTab = tabRelatorios;
            tbcRelatorios.SelectedTab = tp;
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

        private void fPrincipal_ResizeEnd(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                btnMaximizar.Image = Properties.Resources.up;
            }
        }
    }
}
