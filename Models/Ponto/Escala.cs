﻿using Models.Cadastros;
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
        public Escala()
        {
            Funcionarios = new List<EscalaFuncionario>();
            DataInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public int TurnoId { get; set; }
        public Turno Turno { get; set; }

        public int ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; }

        public List<EscalaFuncionario> Funcionarios { get; set; }

        #region Metodos Dominio
        public Escala GetModel() =>
            this;

        public override void IsValid()
        {
        }

        public EscalaView SelectView() =>
            new EscalaView
            {
                Id = this.Id,
                Status = this.Status,
                DataInicio = this.DataInicio,
                DataFim = this.DataFim
            };

        public void Update(Escala Model, int usuarioId)
        {
            this.TurnoId = Model.TurnoId;
            this.ClienteId = Model.ClienteId;

            this.RegistraAlteracao(usuarioId);
        }
        #endregion
    }
}
