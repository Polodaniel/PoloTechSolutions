using System;
using System.Collections.Generic;
using System.Text;

namespace Models.View
{
    public class FuncionarioView : BaseView
    {
        public string Nome { get; set; }

        public bool PossuiBiometria { get; set; }

        public string Biometria
        {
            get => PossuiBiometria ? "Sim" : "Não";
        }

        public bool Selecionado { get; set; }

        public string Display { get; set; }
        public string DisplayDois { get; set; }
    }
}
