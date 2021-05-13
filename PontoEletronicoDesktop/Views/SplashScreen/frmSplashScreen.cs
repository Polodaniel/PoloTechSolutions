using PontoEletronicoDesktop.Data;
using PontoEletronicoDesktop.Views.Princial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PontoEletronicoDesktop.Views.SplashScreen
{
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen() =>
            InitializeComponent();

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            bkwLoad.RunWorkerAsync();
        }

        private void btnFechar_Click(object sender, EventArgs e) =>
            Application.Exit();

        private async void bkwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            pgbLoad.BeginInvoke(new Action(() =>
            {
                pgbLoad.Visible = true;
                pgbLoad.Style = ProgressBarStyle.Marquee;
                pgbLoad.MarqueeAnimationSpeed = 1;
            }));

            await Task.Delay(10000);

            var result = await BancoDados();

            pgbLoad.BeginInvoke(new Action(() =>
            {
                pgbLoad.Visible = false;

                if (result)
                {
                    var form = new frmPrincipal();
                    
                    this.Hide();

                    form.Show();
                }
                else 
                {
                    MessageBox.Show("Ops! Ocorreu um erro ao inicializar o sistema !", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }

        private async Task<bool> BancoDados() =>
            await SQLConexao.CriarBancoSQLiteAsync();
    }
}
