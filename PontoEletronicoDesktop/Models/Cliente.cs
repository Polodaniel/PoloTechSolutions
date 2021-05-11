using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronicoDesktop.Models
{
    public class Cliente : BaseModel
    {
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Logadouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Pais { get; set; }
    }
}
