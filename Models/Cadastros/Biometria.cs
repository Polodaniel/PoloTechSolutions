﻿using Models.Enus;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Cadastros
{
    public class Biometria : BaseModelDominio, IDominio<Biometria>
    {
        #region Construtor
        public Biometria()
        {
            Status = true;
        }
        #endregion

        public byte[] BiometriaImg { get; set; }

        public DedoBiometria Dedo { get; set; }

        public int FuncionarioId { get; set; }
        
        [ForeignKey(nameof(FuncionarioId))]
        public Funcionario Funcionario { get; set; }

        #region Metodos Dominio
        public Biometria GetModel() =>
            this;

        public override void IsValid()
        {
            throw new NotImplementedException();
        }

        public void Update(Biometria Model, int usuarioId)
        {
            this.FuncionarioId = Model.FuncionarioId;
            this.BiometriaImg = Model.BiometriaImg;
            this.RegistraAlteracao(usuarioId);
        }
        #endregion
    }
}