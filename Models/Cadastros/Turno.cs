using Models.Interfaces;
using Models.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Cadastros
{
    public class Turno : BaseModelDominio, IDominio<Turno>, ISelectView<TurnoView>
    {
        #region Construtor
        public Turno()
        {
            this.Status = true;
        }
        #endregion

        [Required(ErrorMessage = "O Nome do Turno é obrigatório !")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O Nome deve ter no mínimo 1 e no máximo 100 characters !")]
        public string Descricao { get; set; }

        public DateTime HoraInicio { get; set; }
        public DateTime HoraioFim { get; set; }

        public bool PerNoite { get; set; }

        #region Metodos Dominio
        public Turno GetModel() =>
            this;

        public override void IsValid()
        {
        }

        public TurnoView SelectView() =>
        new TurnoView
        {
            Id = this.Id,
            Descricao = this.Descricao,
            Status = this.Status,
            HoraInicio = this.HoraInicio,
            HoraioFim = this.HoraioFim,
            PerNoite = this.PerNoite
        };

        public void Update(Turno Model, int usuarioId)
        {
            this.Descricao = Model.Descricao;
            this.HoraInicio = Model.HoraInicio;
            this.HoraioFim = Model.HoraioFim;
            this.PerNoite = Model.PerNoite;
            this.RegistraAlteracao(usuarioId);
        }
        #endregion
    }
}
