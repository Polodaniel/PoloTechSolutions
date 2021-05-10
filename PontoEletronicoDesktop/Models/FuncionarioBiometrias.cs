using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronicoDesktop.Models
{
    public class FuncionarioBiometrias
    {
        public int CodFuncionario { get; set; }

        public List<Biometria> Biometrias { get; set; }
    }
}
