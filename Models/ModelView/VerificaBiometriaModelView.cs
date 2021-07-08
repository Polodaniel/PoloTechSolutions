using Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ModelView
{
    public class VerificaBiometriaModelView
    {
        public int FuncionarioId { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataRegistro { get; set; }
        public Biometria Biometria { get; set; }
    }
}
