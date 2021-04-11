using System;
using System.Collections.Generic;
using System.Text;

namespace Models.View
{
    public class FuncionarioView : BaseView
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
        public bool PossuiBiometria { get; set; }


        public string CodigoString
        {
            get => Id.ToString().PadLeft(4, '0');
        }

        public string Situacao
        {
            get => Status ? "Ativado" : "Desativado";
        }

        public string Biometria
        {
            get => PossuiBiometria ? "Sim" : "Não";
        }
    }
}
