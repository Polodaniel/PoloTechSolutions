using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronicoDesktop.Models
{
    public class Funcionario : BaseModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Pis { get; set; }
        public bool PossuiBiometria { get; set; }
        public List<Biometria> Biometrias { get; set; }
        public string Biometria
        {
            get => PossuiBiometria ? "Sim" : "Não";
        }
    }
}
