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

namespace PontoEletronicoDesktop.Views.Atualizar
{
    public partial class frmAtualizarFuncionarioConsulta : BaseCRUD
    {
        private List<Funcionario> ListaFuncionarios = new List<Funcionario>();

        public frmAtualizarFuncionarioConsulta(string TituloForm)
        {
            InitializeComponent();

            lblTituloForm.Text = TituloForm;

            btnSalvar.Visible = false;
            btnEditar.Visible = true;
        }

        private void LimparGrid()
        {
            grade.DataSource = null;
            grade.Rows.Clear();
            grade.Columns.Clear();
            grade.Refresh();

            ListaFuncionarios = null;
        }

        protected override void btnBusca_Click(object sender, EventArgs e)
        {
            LimparGrid();

            bkwBuscar.RunWorkerAsync();
        }

        protected override void btnEditar_Click(object sender, EventArgs e)
        {
            if (grade.SelectedRows.Count == 0)
            {
                MessageBox.Show("Para Editar deve-se selecionar 1 registros.", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            var Id = Convert.ToInt32(grade.CurrentRow.Cells[nameof(Funcionario.Id)].Value);

            var FuncionarioSelecionado = ListaFuncionarios.Where(x => x.Id == Id).FirstOrDefault();

            if (!Equals(FuncionarioSelecionado, null))
            {
                var form = new frmAtualizarFuncionarioCadastro(FuncionarioSelecionado);
                form.Dock = DockStyle.Fill;
                form.TopLevel = false;
                form.Visible = true;

                var Principal = this.ParentForm;
                var pnlContentPrincipal = Principal.Controls.Find("pnlPrincipal", true).FirstOrDefault();
                pnlContentPrincipal.Controls.Clear();
                pnlContentPrincipal.Refresh();
                pnlContentPrincipal.Controls.Add(form);

                form.Show();

                Principal.Refresh();
                pnlContentPrincipal.Refresh();
                this.Close();
            }
            else
                MessageBox.Show("Ops! Não foi possivel identificar o Funcionario.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        protected override void btnLimpar_Click(object sender, EventArgs e) =>
            LimparGrid();

        private async void bkwBuscar_DoWork(object sender, DoWorkEventArgs e)
        {
            pgbLoad.BeginInvoke(new Action(() =>
            {
                pgbLoad.Visible = true;
                pgbLoad.Style = ProgressBarStyle.Marquee;
                pgbLoad.MarqueeAnimationSpeed = 1;
            }));

            ListaFuncionarios = await new FuncionariosController().BuscaFuncionariosAsync();

            pgbLoad.BeginInvoke(new Action(() =>
            {
                pgbLoad.Visible = false;

                AtualizaGrid();
            }));
        }

        private void AtualizaGrid()
        {
            if (!Equals(ListaFuncionarios, null) && ListaFuncionarios.Count > 0)
            {
                grade.DataSource = ListaFuncionarios;

                for (var i = 00; i < grade.Columns.Count; i++)
                    grade.Columns[i].Visible = false;

                grade.Columns[nameof(Funcionario.CodigoString)].HeaderText = "Código";
                grade.Columns[nameof(Funcionario.CodigoString)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grade.Columns[nameof(Funcionario.CodigoString)].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grade.Columns[nameof(Funcionario.CodigoString)].Visible = true;
                grade.Columns[nameof(Funcionario.CodigoString)].ReadOnly = true;
                grade.Columns[nameof(Funcionario.CodigoString)].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grade.Columns[nameof(Funcionario.CodigoString)].DisplayIndex = 0;

                grade.Columns[nameof(Funcionario.Nome)].HeaderText = "Nome";
                grade.Columns[nameof(Funcionario.Nome)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grade.Columns[nameof(Funcionario.Nome)].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grade.Columns[nameof(Funcionario.Nome)].Visible = true;
                grade.Columns[nameof(Funcionario.Nome)].ReadOnly = true;
                grade.Columns[nameof(Funcionario.Nome)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grade.Columns[nameof(Funcionario.Nome)].DisplayIndex = 1;

                grade.Columns[nameof(Funcionario.Biometria)].HeaderText = "Possui Biometria ?";
                grade.Columns[nameof(Funcionario.Biometria)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grade.Columns[nameof(Funcionario.Biometria)].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grade.Columns[nameof(Funcionario.Biometria)].Visible = true;
                grade.Columns[nameof(Funcionario.Biometria)].ReadOnly = true;
                grade.Columns[nameof(Funcionario.Biometria)].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grade.Columns[nameof(Funcionario.Biometria)].DisplayIndex = 2;

                grade.ClearSelection();

            }
        }
    }
}
