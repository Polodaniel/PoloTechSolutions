using System;
using System.Collections.Generic;
using System.Text;

namespace Models.View.Desktop
{
    public class ClienteViewDesktop
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Logadouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Pais { get; set; }
        public bool Status { get; set; }
    }
}
