using 
    Models;
using Models.Interfaces;
using Models.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Cadastros
{
    public class Funcionario : BaseModelDominio, IDominio<Funcionario>,ISelectView<FuncionarioView>
    {
        #region Construtor
        public Funcionario()
        {
            this.Status = true;
        }
        #endregion

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Pis { get; set; }
        public bool PossuiBiometria { get; set; }
        public List<Biometria> Biometrias { get; set; }

        #region Metodos Dominio
        public Funcionario GetModel() =>
            this;

        public override void IsValid()
        {
            
        }

        public FuncionarioView SelectView() =>
            new FuncionarioView
            {
                Id = this.Id,
                Nome = this.Nome,
                PossuiBiometria = this.PossuiBiometria,
                Status = this.Status,
            };

        public void Update(Funcionario Model, int usuarioId)
        {
            this.Nome = Model.Nome;
            this.Cpf = Model.Cpf;
            this.Pis = Model.Pis;
            this.PossuiBiometria = Model.PossuiBiometria;
            this.Biometrias = Model.Biometrias;

            this.RegistraAlteracao(usuarioId);
        }
        #endregion
    }
}