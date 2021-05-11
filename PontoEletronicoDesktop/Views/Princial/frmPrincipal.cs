using PontoEletronicoDesktop.Views.Atualizar;
using PontoEletronicoDesktop.Views.Configuracao;
using PontoEletronicoDesktop.Views.MarcarPonto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PontoEletronicoDesktop.Views.Princial
{
    public partial class frmPrincipal : Form
    {
        #region Variaveis
        private bool MenuCollapse = false;
        #endregion

        #region Construtor
        public frmPrincipal()
        {
            InitializeComponent();

            TamanhoProgram();

            InicializaInicio();
        }
        #endregion

        #region Eventos 
        private void InicializaInicio()
        {
            LimparFormPrincipal();

            var form = new frmInicio("Início");
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            form.Visible = true;

            pnlPrincipal.Controls.Add(form);
        }

        private void InicializaMarcarPonto()
        {
            if (!ValidaLicenca())
            {
                MessageBox.Show("Licença Expirada. Entre em contato com PoloTech Solutions.", "Licença", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LimparFormPrincipal();

            var form = new frmMarcarPonto("Marcar o Ponto");
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            form.Visible = true;

            pnlPrincipal.Controls.Add(form);
        }

        private void InicializaAtualizaCadastro()
        {
            if (!ValidaLicenca())
            {
                MessageBox.Show("Licença Expirada. Entre em contato com PoloTech Solutions.", "Licença", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LimparFormPrincipal();

            var form = new frmAtualizarFuncionarioConsulta("Atualizar Cadastros");
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            form.Visible = true;

            pnlPrincipal.Controls.Add(form);
        }

        private void InicializaConfiguracao()
        {
            if (!ValidaLicenca())
            {
                MessageBox.Show("Licença Expirada. Entre em contato com PoloTech Solutions.", "Licença", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LimparFormPrincipal();

            var form = new frmConfiguracao("Configuração");
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            form.Visible = true;

            pnlPrincipal.Controls.Add(form);
        }

        private void LimparFormPrincipal() =>
            pnlPrincipal.Controls.Clear();

        private void TamanhoProgram()
        {
            var Width = Screen.PrimaryScreen.Bounds.Width;
            var Height = Screen.PrimaryScreen.Bounds.Height;

            this.Width = Width;
            this.Height = Height - 40;
        }
        #endregion

        #region Eventos Botões
        private void btnFechar_Click(object sender, EventArgs e) =>
            Application.Exit();

        private void btnInicio_Click(object sender, EventArgs e) =>
           InicializaInicio();

        private void btnMarcador_Click(object sender, EventArgs e) =>
            InicializaMarcarPonto();

        private void btnAtualizarCadastro_Click(object sender, EventArgs e) =>
            InicializaAtualizaCadastro();

        private void btnConfiguracao_Click(object sender, EventArgs e) =>
            InicializaConfiguracao();

        private void btnSair_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja sair do sistema ?", "Sair", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
                btnFechar.PerformClick();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MenuCollapse = !MenuCollapse ? true : false;
            pnlLateral.Width = MenuCollapse ? 46 : 210;
        }
        #endregion

        private bool ValidaLicenca()
        {
            var result = true;

            var DataAtual = DateTime.Now;
            var DataLicenca = new DateTime(2021, 07, 31, 23, 59, 59);

            result = DataAtual <= DataLicenca ? true : false;

            return result;
        }

        private void pnlPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
