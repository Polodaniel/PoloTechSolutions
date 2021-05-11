using PontoEletronicoDesktop.Data;
using PontoEletronicoDesktop.Views.Princial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PontoEletronicoDesktop
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            
            Application.SetCompatibleTextRenderingDefault(false);

            BancoDados();

            Application.Run(new frmPrincipal());
        }

        private static void BancoDados() 
        {
            SQLConexao.CriarBancoSQLite();
        }
    }
}
