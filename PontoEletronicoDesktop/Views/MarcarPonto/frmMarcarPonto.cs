using LeitorFS;
using PontoEletronicoDesktop.Controllers;
using PontoEletronicoDesktop.Data;
using PontoEletronicoDesktop.Models;
using PontoEletronicoDesktop.Models.View;
using PontoEletronicoDesktop.Views.Base;
using SourceAFIS.Simple;
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

namespace PontoEletronicoDesktop.Views.MarcarPonto
{
    public partial class frmMarcarPonto : BaseForm
    {
        #region Variaveis
        const int INDICE = 50;

        private Timer tmr = new Timer();

        public LeitorFS80 LeitorBiometrico { get; set; }

        private static AfisEngine AFIS = new AfisEngine();

        private List<Person> ListaFuncionarios;

        #endregion

        #region Construtor
        public frmMarcarPonto(string TituloForm)
        {
            InitializeComponent();

            lblTituloForm.Text = TituloForm;

            bkwBiometria.WorkerReportsProgress = true;
            bkwBiometria.WorkerSupportsCancellation = true;

            InicializaComponenteBiometrico();
        }

        private void frmMarcarPonto_Shown(object sender, EventArgs e) =>
            bkwLoad.RunWorkerAsync();

        private void frmMarcarPonto_Load(object sender, EventArgs e)
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
                                Localizado = true;

                                MarcarPontoAsync(item);

                                LimparInputs();
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

        private async Task MarcarPontoAsync(Person item)
        {
            var ClienteId = 0;

            var Cliente = await SQLConexao.ClientesAtivo();

            if (!Equals(Cliente, null))
                ClienteId = Cliente.Id;

            using (Request _app = new Request())
            {
                var result = await _app.PostMarcacaoPonto(new VerificaBiometriaModelView(item.Id, ClienteId));

                if (result.Resultado)
                {
                    MessageBox.Show(result.Menssagem, "Marcação do Ponto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    pbBiometria.Image = null;
                }
                else
                {
                    MessageBox.Show(result.Menssagem, "Marcação do Ponto", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    pbBiometria.Image = null;
                }
            }
        }

        public Bitmap ConverterArrayImagem(byte[] byteArrayIn)
        {
            try
            {
                if (!Equals(byteArrayIn, null))
                {

                    MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
                    ms.Write(byteArrayIn, 0, byteArrayIn.Length);
                    return (Bitmap)Bitmap.FromStream(ms, true);
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        private async void bkwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            pgbLoad.BeginInvoke(new Action(() =>
            {
                pgbLoad.Visible = true;
                pgbLoad.Style = ProgressBarStyle.Marquee;
                pgbLoad.MarqueeAnimationSpeed = 1;
            }));

            ListaFuncionarios = MontaListaCandidatos(await new FuncionariosController().BuscaFuncionariosAsync());

            pgbLoad.BeginInvoke(new Action(() =>
            {
                pgbLoad.Visible = false;
            }));
        }

        private List<Person> MontaListaCandidatos(List<Funcionario> ListaFuncionarios)
        {
            // Cria uma Lista de Candidatos
            var ListaCandidatos = new List<Person>();

            if (!Equals(ListaFuncionarios, null) && ListaFuncionarios.Count > 0)
            {
                try
                {
                    foreach (var item in ListaFuncionarios.Where(x => x.Biometrias.Count > 0).ToList())
                    {
                        var Candidato = new Person();
                        Candidato.Id = item.Id;

                        foreach (var itemBiometria in item.Biometrias)
                        {
                            var img = ConverterArrayImagem(itemBiometria.BiometriaImg);

                            var fpCandidato = new Fingerprint();
                            fpCandidato.AsBitmap = new Bitmap(img);

                            Candidato.Fingerprints.Add(fpCandidato);
                        }

                        ListaCandidatos.Add(Candidato);
                    }
                }
                catch (Exception er)
                {
                    var msgErr = er.Message;
                }

                //var ListaBiometrias = ListaFuncionarios.Where(x => x.Biometrias.Count > 0).SelectMany(x => x.Biometrias).ToList();

                //foreach (var item in ListaBiometrias)
                //{
                //    var img = ConverterArrayImagem(item.BiometriaImg);

                //    if (!Equals(img, null))
                //    {
                //        try
                //        {
                //            var fpCandidato = new Fingerprint();
                //            fpCandidato.AsBitmap = new Bitmap(img);

                //            var Candidato = new Person();
                //            Candidato.Id = item.FuncionarioId;
                //            Candidato.Fingerprints.Add(fpCandidato);

                //            ListaCandidatos.Add(Candidato);
                //        }
                //        catch (Exception er)
                //        {
                //            var msgErr = er.Message;
                //        }
                //    }
                //}
            }
            return ListaCandidatos;
        }
        #endregion

        #region Eventos de Botões
        private void btnBiometria_Click(object sender, EventArgs e)
        {
            LimparInputs();

            CancelarLeitorBiometrico();
        }

        public void CancelarLeitorBiometrico()
        {
            pbBiometria.Image = null;

            this.bkwBiometria.WorkerSupportsCancellation = true;

            if (!this.bkwBiometria.IsBusy)
                this.bkwBiometria.RunWorkerAsync();
            else
                this.bkwBiometria.CancelAsync();
        }


        private void LimparInputs()
        {

        }
        #endregion

        private void panel8_Resize(object sender, EventArgs e)
        {
            int x = (panel8.Size.Width - lblHora.Width) / 2;
            int y = (panel8.Size.Height - (lblHora.Height + 30)) / 2;

            lblHora.Location = new Point(x, y);
        }

        private async void bkwSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            //var result = new FuncionariosController().VerificarSalvar((VerificaBiometriaModelView)e.Argument, ListaFuncionarios);

            //using (Request _app = new Request())
            //{
            //    var Obj = (VerificaBiometriaModelView)e.Argument;

            //    var result = await _app.PostMarcacaoPonto(Obj);

            //    if (result)
            //    {
            //        MessageBox.Show("Informações Atualizada com Sucesso !", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //        MessageBox.Show("Ops! Ocorreu um erro ao salvar.", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
