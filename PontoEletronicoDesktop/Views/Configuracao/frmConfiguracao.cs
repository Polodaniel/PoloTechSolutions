using PontoEletronicoDesktop.Controllers;
using PontoEletronicoDesktop.Models;
using PontoEletronicoDesktop.Views.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PontoEletronicoDesktop.Views.Configuracao
{
    public partial class frmConfiguracao : BaseCRUD
    {
        private List<Cliente> ListaClientes = new List<Cliente>();

        public Cliente ClienteSelecionado { get; private set; }

        public frmConfiguracao(string TituloForm)
        {
            InitializeComponent();

            lblTituloForm.Text = TituloForm;

            btnSalvar.Visible = true;
            btnEditar.Visible = false;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            
            bkwLoad.RunWorkerAsync();
        }

        private void LimparGrid()
        {
            grade.DataSource = null;
            grade.Rows.Clear();
            grade.Columns.Clear();
            grade.Refresh();

            //ListaFuncionarios = null;
        }

        protected override void btnBusca_Click(object sender, EventArgs e)
        {
            LimparGrid();

            bkwBuscar.RunWorkerAsync();
        }

        private async void bkwBuscar_DoWork(object sender, DoWorkEventArgs e)
        {
            pgbLoad.BeginInvoke(new Action(() =>
            {
                pgbLoad.Visible = true;
                pgbLoad.Style = ProgressBarStyle.Marquee;
                pgbLoad.MarqueeAnimationSpeed = 1;
            }));

            ListaClientes = await new ClientesController().BuscaClientesAsync();

            pgbLoad.BeginInvoke(new Action(() =>
            {
                pgbLoad.Visible = false;

                AtualizaGrid();
            }));
        }

        private void AtualizaGrid()
        {
            if (!Equals(ListaClientes, null) && ListaClientes.Count > 0)
            {
                grade.DataSource = ListaClientes;

                for (var i = 00; i < grade.Columns.Count; i++)
                    grade.Columns[i].Visible = false;

                grade.Columns[nameof(Cliente.CodigoString)].HeaderText = "Código";
                grade.Columns[nameof(Cliente.CodigoString)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grade.Columns[nameof(Cliente.CodigoString)].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grade.Columns[nameof(Cliente.CodigoString)].Visible = true;
                grade.Columns[nameof(Cliente.CodigoString)].ReadOnly = true;
                grade.Columns[nameof(Cliente.CodigoString)].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grade.Columns[nameof(Cliente.CodigoString)].DisplayIndex = 0;

                grade.Columns[nameof(Cliente.Nome)].HeaderText = "Nome";
                grade.Columns[nameof(Cliente.Nome)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grade.Columns[nameof(Cliente.Nome)].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grade.Columns[nameof(Cliente.Nome)].Visible = true;
                grade.Columns[nameof(Cliente.Nome)].ReadOnly = true;
                grade.Columns[nameof(Cliente.Nome)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grade.Columns[nameof(Cliente.Nome)].DisplayIndex = 1;

                grade.Columns[nameof(Cliente.StatusString)].HeaderText = "Status";
                grade.Columns[nameof(Cliente.StatusString)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grade.Columns[nameof(Cliente.StatusString)].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grade.Columns[nameof(Cliente.StatusString)].Visible = true;
                grade.Columns[nameof(Cliente.StatusString)].ReadOnly = true;
                grade.Columns[nameof(Cliente.StatusString)].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grade.Columns[nameof(Cliente.StatusString)].DisplayIndex = 2;

                grade.ClearSelection();
            }
        }

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Equals(ClienteSelecionado, null))
            {
                MessageBox.Show("Ops! Selecione ao menos 1 Cliente para Salvar.", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bkwSalvar.RunWorkerAsync();
        }

        private void pnlCliente_Resize(object sender, EventArgs e)
        {
            int x = (pnlCliente.Size.Width - gbClienteSelecionado.Width) / 2;
            int y = (pnlCliente.Size.Height - (gbClienteSelecionado.Height + 10)) / 2;

            gbClienteSelecionado.Location = new Point(x, y);
        }

        private void grade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var Id = Convert.ToInt32(grade.CurrentRow.Cells[nameof(Funcionario.Id)].Value);

            ClienteSelecionado = ListaClientes.Where(x => x.Id == Id).FirstOrDefault();

            if (!Equals(ClienteSelecionado, null))
            {
                txtCodigo.Text = ClienteSelecionado.CodigoString;
                txtNome.Text = ClienteSelecionado.Nome;
                txtCep.Text = ClienteSelecionado.Cep;
                txtLogradouro.Text = ClienteSelecionado.Logadouro;
                txtNumero.Text = ClienteSelecionado.Numero;
                txtBairro.Text = ClienteSelecionado.Bairro;
                txtCidade.Text = ClienteSelecionado.Cidade;
                txtPais.Text = ClienteSelecionado.Pais;
            }
            else
                MessageBox.Show("Ops! Cliente não foi localizado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bkwSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            pgbLoad.BeginInvoke(new Action(() =>
            {
                pgbLoad.Visible = true;
                pgbLoad.Style = ProgressBarStyle.Marquee;
                pgbLoad.MarqueeAnimationSpeed = 1;
            }));

            var result = new ClientesController().SalvarCienteSelecionado(ClienteSelecionado);

            if (result)
                MessageBox.Show("Informações Atualizada com Sucesso !", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Ops! Ocorreu um erro ao salvar.", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);

            pgbLoad.BeginInvoke(new Action(() =>
            {
                pgbLoad.Visible = false;
                pnlCentralCRUD.Enabled = false;
                btnSalvar.Enabled = false;
            }));
        }

        private void bkwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            pgbLoad.BeginInvoke(new Action(() =>
            {
                pgbLoad.Visible = true;
                pgbLoad.Style = ProgressBarStyle.Marquee;
                pgbLoad.MarqueeAnimationSpeed = 1;
            }));

            var ClienteSalvo = new ClientesController().BuscarClienteAtual();

            pgbLoad.BeginInvoke(new Action(() =>
            {
                pgbLoad.Visible = false;

                PopularInput(ClienteSalvo);
            }));
        }

        private void PopularInput(Cliente ClienteSalvo)
        {
            if (!Equals(ClienteSalvo, null))
            {
                txtCodigo.Text = ClienteSalvo.CodigoString;
                txtNome.Text = ClienteSalvo.Nome;
                txtCep.Text = ClienteSalvo.Cep;
                txtLogradouro.Text = ClienteSalvo.Logadouro;
                txtNumero.Text = ClienteSalvo.Numero;
                txtBairro.Text = ClienteSalvo.Bairro;
                txtCidade.Text = ClienteSalvo.Cidade;
                txtPais.Text = ClienteSalvo.Pais;
            }
            else
                MessageBox.Show("Ops! Cliente não foi localizado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
