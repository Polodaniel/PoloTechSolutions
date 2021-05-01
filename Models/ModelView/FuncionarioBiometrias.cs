using Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ModelView
{
    public class FuncionarioBiometrias
    {
        public int CodFuncionario { get; set; }

        public List<Biometria> Biometrias { get; set; }
    }
}
