using System;
using System.Collections.Generic;
using System.Text;

namespace Models.View.Desktop
{
    public class MarcacaoResultado
    {
        public MarcacaoResultado() =>
            Id = Guid.NewGuid();

        public MarcacaoResultado(bool Resultado, string Menssagem) : this()
        {
            this.Resultado = Resultado;
            this.Menssagem = Menssagem;
        }

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
