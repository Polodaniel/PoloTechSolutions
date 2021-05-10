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

namespace PontoEletronicoDesktop.Views.Princial
{
    public partial class frmInicio : BaseForm
    {
        public frmInicio(string TituloForm)
        {
            InitializeComponent();

            lblTituloForm.Text = TituloForm;

            InicializaDatas();
        }

        private void InicializaDatas()
        {
            var DataAtual = DateTime.Now;
            var DataLicenca = new DateTime(2021, 07, 31, 23, 59, 59);

            if (DataAtual <= DataLicenca)
            {
                var DiferencaDatas = DataAtual - DataLicenca;

                lblMensagemQuatro.Text = string.Concat(MontarHora(DiferencaDatas.Ticks), " restante(s)");
            }
            else
            {
                lblMensagemQuatro.Text = "Licença Expirada. Entre em contato com PoloTech Solutions.";
                lblMensagemQuatro.ForeColor = Color.DarkRed;
            }


        }

        public string MontarHora(long horaTicks)
        {
            var horaC = new TimeSpan(horaTicks);

            return string.Concat(horaC.ToString(@"dd"), " dia(s) e ", horaC.ToString(@"hh"), " hora(s) e ", horaC.ToString(@"mm"), " minutos");// horaC.ToString(@"dd");
        }
    }
}
