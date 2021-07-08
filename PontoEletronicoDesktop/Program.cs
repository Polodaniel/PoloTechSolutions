﻿using PontoEletronicoDesktop.Data;
using PontoEletronicoDesktop.Views.Princial;
using PontoEletronicoDesktop.Views.SplashScreen;
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

            //Application.Run(new frmPrincipal());
            Application.Run(new frmSplashScreen());
        }


    }
}
