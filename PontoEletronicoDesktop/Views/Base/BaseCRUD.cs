using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PontoEletronicoDesktop.Views.Base
{
    public partial class BaseCRUD : BaseForm
    {
        public BaseCRUD() =>
            InitializeComponent();

        protected virtual void btnBusca_Click(object sender, EventArgs e) { }

        protected virtual void btnLimpar_Click(object sender, EventArgs e) { }

        protected virtual void btnSalvar_Click(object sender, EventArgs e) { }

        protected virtual void btnEditar_Click(object sender, EventArgs e) { }

        protected virtual void btnFechar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja fechar ?", "Fechar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
                this.Close();
        }
    }
}