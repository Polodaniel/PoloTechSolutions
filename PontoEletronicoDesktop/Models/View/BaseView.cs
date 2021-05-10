using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronicoDesktop.Models.View
{
    public class BaseView
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }

        public string CodigoString
        {
            get => Id.ToString().PadLeft(4, '0');
        }

        public string Situacao
        {
            get => Status ? "Ativado" : "Desativado";
        }
    }
}
