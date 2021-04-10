using Models.Cadastros;
using Models.Interfaces;
using Models.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Ponto
{
    public class Escala : BaseModelDominio, IDominio<Escala>, ISelectView<EscalaView>
    {
        public int TurnoId { get; set; }
        public Turno Turno { get; set; }

        public int FuncionarioId { get; set; }

        [ForeignKey(nameof(FuncionarioId))]
        public Funcionario Funcionario { get; set; }

        #region Metodos Dominio
        public Escala GetModel() =>
            this;

        public override void IsValid()
        {
            throw new NotImplementedException();
        }

        public EscalaView SelectView()
        {
            throw new NotImplementedException();
        }

        public void Update(Escala Model, int usuarioId)
        {
            this.TurnoId = Model.TurnoId;
            this.FuncionarioId = Model.FuncionarioId;

            this.RegistraAlteracao(usuarioId);
        }
        #endregion
    }
}
