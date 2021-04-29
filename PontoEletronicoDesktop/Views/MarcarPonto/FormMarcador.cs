using LeitorFS;
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
using System.IO;
using SourceAFIS.Simple;
using PontoEletronicoDesktop.Models;
using PontoEletronicoDesktop.Controllers;

namespace PontoEletronicoDesktop.Views.MarcarPonto
{
    public partial class FormMarcador : FormBase
    {
        #region Variaveis
        const int INDICE = 50;

        private Timer tmr = new Timer();

        private LeitorFS80 LeitorBiometrico { get; set; }

        private static AfisEngine AFIS = new AfisEngine();

        private List<Person> ListaFuncionarios;
        #endregion

        #region Contrutor
        public FormMarcador(string TituloForm)
        {
            InitializeComponent();

            lblTituloForm.Text = TituloForm;

            bkwBiometria.WorkerReportsProgress = true;
            bkwBiometria.WorkerSupportsCancellation = true;

            InicializaComponenteBiometrico();

        }

        private void FormMarcador_Shown(object sender, EventArgs e)
        {
            bkwLoad.RunWorkerAsync();
        }

        private void FormMarcador_Load(object sender, EventArgs e)
        {
            tmr.Interval = 1;
            tmr.Enabled = true;
            tmr.Tick += new EventHandler(Ticks);

            bkwBiometria.RunWorkerAsync();
        }

        private void Ticks(object sender, EventArgs e)
        {
            string Src = DateTime.Now.ToLongTimeString();

            lblHora.Text = Src;
        }
        #endregion

        #region Eventos
        private void InicializaComponenteBiometrico() =>
            LeitorBiometrico = new LeitorFS80();

        private void bkwBiometria_DoWork(object sender, DoWorkEventArgs e)
        {
            var FeitoLeitura = false;

            if (!LeitorBiometrico.Connected)
            {
                LeitorBiometrico.Init();
            }

            if (!LeitorBiometrico.Connected)
            {
                MessageBox.Show("Não foi identificao o Leitor de Biometria !", "Leitor de Biometria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Bitmap Biometria = new Bitmap(100, 100);

            do
            {
                if (LeitorBiometrico.IsFinger())
                {

                    Task.Delay(1000).Wait();

                    ImageConverter converter = new ImageConverter();

                    Biometria = LeitorBiometrico.ExportBitMap();

                    FeitoLeitura = true;

                }
            } while (!FeitoLeitura && LeitorBiometrico.Connected);

            ExibirBiometria(Biometria);
        }

        private void FormMarcador_FormClosing(object sender, FormClosingEventArgs e) =>
            tmr.Enabled = false;

        private void ExibirBiometria(Bitmap biometria)
        {
            pbBiometria.BeginInvoke(new Action(() =>
            {
                ValidacaoBiometria(biometria);

                pbBiometria.SizeMode = PictureBoxSizeMode.StretchImage;
                pbBiometria.Image = biometria;
            }));

        }

        private void ValidacaoBiometria(Bitmap bio)
        {
            // Cria o Objeto do Leitor
            var fpBiometriaCapturada = new Fingerprint();
            fpBiometriaCapturada.AsBitmap = new Bitmap(bio);

            // Cria um Candidado
            var BiometriaCapturada = new Person();
            BiometriaCapturada.Fingerprints.Add(fpBiometriaCapturada);

            RealizaVerificaoBiometria(BiometriaCapturada);
        }

        private void RealizaVerificaoBiometria(Person BiometriaCapturada)
        {
            try
            {
                pbBiometria.BeginInvoke(new Action(() =>
                {
                    var _lstCandidatos = ListaFuncionarios;

                    var Localizado = false;

                    AFIS.Threshold = INDICE;

                    try
                    {
                        foreach (var item in _lstCandidatos)
                        {
                            AFIS.Extract(BiometriaCapturada);
                            AFIS.Extract(item);

                            var Chance = AFIS.Verify(BiometriaCapturada, item);

                            if (Chance > 0)
                            {
                                var _func = new FuncionariosController().BuscarFuncionario(item.Id);

                                if (!Equals(_func, null))
                                {
                                    txtCodigo.Text = _func.Codigo.ToString();
                                    txtNome.Text = _func.Nome;
                                    txtBiometria.Text = _func.PossuiBiometriaString;
                                    txtStaus.Text = _func.DesativadoString;

                                    Localizado = true;

                                    MarcarPonto(_func);

                                    LimparInputs();
                                }
                            }
                        }

                        if (!Localizado)
                        {
                            LimparInputs();

                            MessageBox.Show("Funcionario não localizado !", "Biometria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao localizar a Biometria !", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));
            }
            catch (Exception er)
            {
                var msgErro = er.Message;
            }
        }

        private void MarcarPonto(Funcionario func)
        {
            var NovoPonto = new FolhaPonto();

            NovoPonto.FuncionarioId = func.Id;
            NovoPonto.DtaEscala = DateTime.Now;

            var result = new FolhaPontoController().MarcarPonto();
            //var result = new FolhaPontoController().MarcarPonto(NovoPonto);

            if (result)
            {
                MessageBox.Show("Salvo com Sucesso !");

                pbBiometria.Image = null;

            }
            else

                MessageBox.Show("Erro ao Salvar !");
        }

        public Bitmap ConverterArrayImagem(byte[] byteArrayIn)
        {
            try
            {
                if (!Equals(byteArrayIn, null))
                {

                    MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
                    ms.Write(byteArrayIn, 0, byteArrayIn.Length);
                    return (Bitmap)Bitmap.FromStream(ms, true);//.FromStream(ms, true);//Exception occurs here
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        private void bkwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            pgbLoad.BeginInvoke(new Action(() =>
            {
                pgbLoad.Visible = true;
                pgbLoad.Style = ProgressBarStyle.Marquee;
                pgbLoad.MarqueeAnimationSpeed = 1;
            }));

            ListaFuncionarios = MontaListaCandidaxtos(new FuncionariosController().BuscaFuncionariosBiometria());

            pgbLoad.BeginInvoke(new Action(() =>
            {
                pgbLoad.Visible = false;
            }));
        }

        private List<Person> MontaListaCandidaxtos(List<FuncinarioView> lists)
        {
            // Cria uma Lista de Candidatos
            var ListaCandidatos = new List<Person>();

            if (!Equals(lists, null) && lists.Count > 0)
            {
                foreach (var item in lists)
                {
                    var img = ConverterArrayImagem(item.Biometrias.FirstOrDefault().BiometriaImg);

                    if (!Equals(img, null))
                    {
                        try
                        {
                            var fpCandidato = new Fingerprint();
                            fpCandidato.AsBitmap = new Bitmap(img);

                            var Candidato = new Person();
                            Candidato.Id = item.Codigo;
                            Candidato.Fingerprints.Add(fpCandidato);

                            ListaCandidatos.Add(Candidato);
                        }
                        catch (Exception er)
                        {
                            var msgErr = er.Message;
                        }
                    }
                }
            }
            return ListaCandidatos;
        }
        #endregion

        #region Eventos de Botões
        private void btnBiometria_Click(object sender, EventArgs e)
        {
            LimparInputs();

            pbBiometria.Image = null;

            this.bkwBiometria.WorkerSupportsCancellation = true;

            if (!this.bkwBiometria.IsBusy)
                this.bkwBiometria.RunWorkerAsync();
            else
                this.bkwBiometria.CancelAsync();
        }

        private void LimparInputs()
        {
            txtCodigo.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtBiometria.Text = string.Empty;
            txtStaus.Text = string.Empty;
        }
        #endregion

        private void panel8_Resize(object sender, EventArgs e)
        {
            int x = (panel8.Size.Width - lblHora.Width) / 2;
            int y = (panel8.Size.Height - (lblHora.Height + 30)) / 2;

            lblHora.Location = new Point(x, y);
        }

    }
}
