using System;
using System.Collections.Generic;
using System.Text;

namespace Models.View
{
    public class ClienteView : BaseView
    {
        public string Nome { get; set; }
        public string Logadouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
    }
}
