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
        public string Endereco { get; set; }
        public string Logadouro{ get; set; }
        public string Cidade{ get; set; }

        #region Metodos Dominio
        public Cliente GetModel() =>
            this;

        public override void IsValid()
        {
            throw new NotImplementedException();
        }

        public ClienteView SelectView()
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente Model, int usuarioId)
        {
            this.Nome = Model.Nome;
            this.Endereco = Model.Endereco;
            this.Logadouro = Model.Logadouro;
            this.Cidade = Model.Cidade;
            this.RegistraAlteracao(usuarioId);
        }
        #endregion

    }
}
