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

        private bool _selecionado;

        public bool Selecionado 
        { 
            get => _selecionado;
            set 
            {
                _selecionado = value;

                if (value)
                    Status = value;
            } 
        }

        public string Display { get; set; }
        public string DisplayDois { get; set; }
    }
}
