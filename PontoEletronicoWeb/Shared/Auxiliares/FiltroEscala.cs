using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Shared.Auxiliares
{
    public class FiltroEscala
    {
        public bool Status { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int TurnoId { get; set; }
        public int ClienteId { get; set; }
    }
}
