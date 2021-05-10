using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronicoDesktop.Models.View
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
    }
}
