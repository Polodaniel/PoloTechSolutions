using Models.Cadastros;
using Models.Interfaces;
using Models.View.Ponto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Ponto
{
    public class EscalaFuncionario : BaseModelDominio, IDominio<EscalaFuncionario>, ISelectView<EscalaFuncionarioView>
    {
        #region Fucionario
        public int FuncionarioId { get; set; }

        [ForeignKey(nameof(FuncionarioId))]
        public Funcionario Funcionario { get; set; }
        #endregion

        #region Escala
        public int EscalaId { get; set; }

        [ForeignKey(nameof(EscalaId))]
        public Escala Escala { get; set; }
        #endregion

        public EscalaFuncionario GetModel() =>
            this;

        public override void IsValid()
        {
           
        }

        public EscalaFuncionarioView SelectView()
        {
            return null;
        }

        public void Update(EscalaFuncionario Model, int usuarioId)
        {
            //this.TurnoId = Model.TurnoId;
            //this.FuncionarioId = Model.FuncionarioId;
            //this.ClienteId = Model.ClienteId;

            this.RegistraAlteracao(usuarioId);
        }
    }
}
