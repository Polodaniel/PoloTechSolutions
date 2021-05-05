using LeitorFS;
using PontoEletronicoDesktop.Controllers;
using PontoEletronicoDesktop.Models;
using PontoEletronicoDesktop.Models.Enum;
using PontoEletronicoDesktop.Views.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PontoEletronicoDesktop.Views.Atualizar
{
    public partial class frmAtualizarFuncionarioCadastro : BaseCRUD
    {
        private LeitorFS80 Leitor { get; set; }
        public DedoBiometria DedoSelecionado { get; private set; }

        private readonly FuncionariosController _App = new FuncionariosController();

        private Funcionario Funcionario;

        public frmAtualizarFuncionarioCadastro(Funcionario funcionarioSelecionado)
        {
            InitializeComponent();

            lblTituloForm.Text = "Atualizar Funcionário";

            Funcionario = funcionarioSelecionado;

            btnSalvar.Visible = true;
            btnEditar.Visible = false;
            pnlBotoesBusca.Visible = false;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        protected override void OnShown(EventArgs e)
        {
            if (!Equals(Funcionario, null))
            {
                lblCodigoFuncionario.Text = Funcionario.CodigoString;
                lblNomeFuncionario.Text = Funcionario.Nome.ToString();

                lblCodigoFuncionario.Visible = true;
                lblNomeFuncionario.Visible = true;

                if (!Equals(Funcionario.Biometrias, null) && Funcionario.Biometrias.Count() > 0)
                {
                    var DedoEsquerdo = Funcionario.Biometrias.Where(x => x.Dedo == DedoBiometria.IndicadorEsquerdo).FirstOrDefault();

                    if (!Equals(DedoEsquerdo, null))
                    {
                        pbBiometriaEsquerdo.SizeMode = PictureBoxSizeMode.StretchImage;
                        pbBiometriaEsquerdo.Image = byteArrayToImage(DedoEsquerdo.BiometriaImg);

                        btnBiometriaEsquerdo.Enabled = false;
                    }

                    var DedoDireito = Funcionario.Biometrias.Where(x => x.Dedo == DedoBiometria.IndicadorDireito).FirstOrDefault();

                    if (!Equals(DedoDireito, null))
                    {
                        pbBiometriaDireito.SizeMode = PictureBoxSizeMode.StretchImage;
                        pbBiometriaDireito.Image = byteArrayToImage(DedoEsquerdo.BiometriaImg);

                        btnBiometriaDireito.Enabled = false;
                    }

                    if (!Equals(DedoEsquerdo, null) && !Equals(DedoDireito, null))
                        btnSalvar.Enabled = false;
                }
            }
        }

        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void btnBiometriaEsquerdo_Click(object sender, EventArgs e)
        {
            Leitor = new LeitorFS.LeitorFS80();

            DedoSelecionado = DedoBiometria.IndicadorEsquerdo;

            bkwBiometria.RunWorkerAsync();
        }

        private void btnBiometriaDireito_Click(object sender, EventArgs e)
        {
            Leitor = new LeitorFS.LeitorFS80();

            DedoSelecionado = DedoBiometria.IndicadorDireito;

            bkwBiometria.RunWorkerAsync();
        }
        private void bkwBiometria_DoWork(object sender, DoWorkEventArgs e)
        {
            var FeitoLeitura = false;

            if (!Leitor.Connected)
                Leitor.Init();

            if (!Leitor.Connected)
            {
                MessageBox.Show("Não foi identificao o Leitor de Biometria !", "Leitor de Biometria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Bitmap Biometria = new Bitmap(100, 100);

            do
            {
                if (Leitor.IsFinger())
                {
                    Task.Delay(1000).Wait();

                    ImageConverter converter = new ImageConverter();

                    Biometria = Leitor.ExportBitMap();

                    var NovaBiometria = new Biometria();
                    NovaBiometria.FuncionarioId = Funcionario.Id;
                    NovaBiometria.BiometriaImg = (byte[])converter.ConvertTo(Biometria, typeof(byte[]));
                    NovaBiometria.Dedo = DedoSelecionado;

                    Funcionario.Biometrias.Add(NovaBiometria);
                    Funcionario.PossuiBiometria = true;

                    FeitoLeitura = true;

                }
            } while (!FeitoLeitura && Leitor.Connected);

            if (Funcionario.PossuiBiometria && !Equals(Funcionario.Biometria, null))
                ExibirBiometria(Biometria, DedoSelecionado);
        }

        private void ExibirBiometria(Bitmap biometria, DedoBiometria dedoSelecionado)
        {
            if (Equals(dedoSelecionado, DedoBiometria.IndicadorEsquerdo))
            {
                pbBiometriaEsquerdo.BeginInvoke(new Action(() =>
                {
                    pbBiometriaEsquerdo.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbBiometriaEsquerdo.Image = biometria;
                }));
            }
            else if (Equals(dedoSelecionado, DedoBiometria.IndicadorDireito))
            {
                pbBiometriaDireito.BeginInvoke(new Action(() =>
                {
                    pbBiometriaDireito.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbBiometriaDireito.Image = biometria;
                }));
            }
        }

        protected override void btnSalvar_Click(object sender, EventArgs e) =>
            bkwSalvar.RunWorkerAsync();

        private bool VerificaDigital()
        {
            var result = true;

            if (!Equals(Funcionario.Biometrias, null) && Funcionario.Biometrias.Count > 0)
                result = true;
            else
                result = false;

            return result;
        }

        private async void bkwSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            pgbLoad.BeginInvoke(new Action(() =>
            {
                pgbLoad.Visible = true;
                pgbLoad.Style = ProgressBarStyle.Marquee;
                pgbLoad.MarqueeAnimationSpeed = 1;
            }));

            if (!VerificaDigital())
            {
                MessageBox.Show("Ops! Faltou  cadastrar alguma digital, verifique e tente novamente.", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);

                pgbLoad.BeginInvoke(new Action(() =>
                {
                    pgbLoad.Visible = false;
                }));

                return;
            }

            using (Request _app = new Request())
            {
                var result = await _app.PostCadastroFuncionario(Funcionario);

                if (result)
                {
                    MessageBox.Show("Informações Atualizada com Sucesso !", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Ops! Ocorreu um erro ao salvar.", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            pgbLoad.BeginInvoke(new Action(() =>
            {
                pgbLoad.Visible = false;
                pnlCentralCRUD.Enabled = false;
                btnSalvar.Enabled = false;
            }));
        }
    }
}
