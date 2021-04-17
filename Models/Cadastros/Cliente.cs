using Models.Interfaces;
using Models.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Cadastros
{
    public class Cliente : BaseModelDominio, IDominio<Cliente>, ISelectView<ClienteView>
    {
        #region Construtor
        public Cliente()
        {
            this.Status = true;
        }
        #endregion
        public string Nome { get; set; }

        #region Endereço
        public string Cep { get; set; }
        public string Logadouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        #endregion

        #region Metodos Dominio
        public Cliente GetModel() =>
            this;

        public override void IsValid() { }

        public ClienteView SelectView() =>
            new ClienteView
            {
                Id = this.Id,
                Nome = this.Nome,
                Status = this.Status,

                Logadouro = this.Logadouro,
                Bairro = this.Bairro,
                Numero = this.Numero,
                Cidade = this.Cidade,
                Cep = this.Cep
            };

        public void Update(Cliente Model, int usuarioId)
        {
            this.Nome = Model.Nome;
            this.Status = Model.Status;

            this.Logadouro = Model.Logadouro;
            this.Bairro = Model.Bairro;
            this.Numero = Model.Numero;
            this.Cidade = Model.Cidade;
            this.Cep = Model.Cep;

            this.RegistraAlteracao(usuarioId);
        }
        #endregion

    }
}
