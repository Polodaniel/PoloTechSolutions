using Models.Cadastros;
using Models.Ponto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.View
{
    public class EscalaView : BaseView
    {
        public EscalaView() =>
            ListaFuncionarios = new List<string>();

        public DateTime? DataInicio { get; set; }
        public string Turno { get; set; }
        public string HoraTurno { get; set; }
        public string Cliente { get; set; }
        public List<string> ListaFuncionarios { get; set; }

        public string ColorBorder
        {
            get
            {
                var result = "darkgray";

                if (DataInicio.HasValue)
                {
                    var DataAtul = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    var DataEscalaAtual = new DateTime(DataInicio.Value.Year, DataInicio.Value.Month, DataInicio.Value.Day);

                    if (DataEscalaAtual == DataAtul)
                        result = "darkgreen";
                    else if (DataEscalaAtual < DataAtul)
                        result = "darkgray";
                    else if (DataEscalaAtual < DataAtul)
                        result = "lightgray";
                }

                return result;
            }
        }

        public DateTime DataFim { get; internal set; }
    }
}
