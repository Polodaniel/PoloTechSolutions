using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronicoDesktop.Models
{
    public class MarcacaoResultado
    {
        /// <summary>
        /// Chave da Menssagem 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 0 - Erro
        /// 1 - Sucesso 
        /// </summary>
        public bool Resultado { get; set; }

        /// <summary>
        /// Menssagem da Operação
        /// </summary>
        public string Menssagem { get; set; }
    }
}
