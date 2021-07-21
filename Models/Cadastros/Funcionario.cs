using Models;
using Models.Interfaces;
using Models.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "O Nome do Funcionário é obrigatório !")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O Nome deve ter no mínimo 1 e no máximo 100 characters !")]
        public string Nome { get; set; }

        [RegularExpression(@"([0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2})$", ErrorMessage = "CPF Inválido, segue o modelo 123.456.789-00")]
        public string Cpf { get; set; }

        [RegularExpression(@"([0-9]{2}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{1})$", ErrorMessage = "RG Inválido, segue o modelo 12.345.678-9")]
        public string Rg { get; set; }

        [RegularExpression(@"([0-9]{3}\.?[0-9]{5}\.?[0-9]{2}\-?[0-9]{1})$", ErrorMessage = "Pis/Pasep Inválido, segue o modelo 123.45678.90-0")]
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