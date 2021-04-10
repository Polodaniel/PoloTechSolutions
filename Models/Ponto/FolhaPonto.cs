using Models.Cadastros;
using Models.Interfaces;
using Models.View.Ponto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Ponto
{
    public class FolhaPonto : BaseModelDominio, IDominio<FolhaPonto>, ISelectView<FolhaPontoView>
    {
        public DateTime DtaEscala { get; set; }
        public int EscalaId { get; set; }

        [ForeignKey(nameof(EscalaId))]
        public Escala Escala { get; set; }
        public int FuncionarioId { get; set; }

        [ForeignKey(nameof(FuncionarioId))]
        public Funcionario Funcionario { get; set; }

        #region Metodos Dominio
        public FolhaPonto GetModel() =>
            this;

        public override void IsValid()
        {
            throw new NotImplementedException();
        }

        public FolhaPontoView SelectView()
        {
            throw new NotImplementedException();
        }

        public void Update(FolhaPonto Model, int usuarioId)
        {
            this.DtaAtualizacao = Model.DtaAtualizacao;
            this.EscalaId = Model.EscalaId;
            this.FuncionarioId = Model.FuncionarioId;
            this.RegistraAlteracao(usuarioId);
        }
        #endregion
    }
}
