using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public abstract class BaseModelDominio : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public bool Status { get; set; }

        #region Registra ultima alteração
        public DateTime DtaAtualizacao { get; set; }
        public int UsuarioId { get; set; }
        #endregion

        #region Metodos Base
        public virtual void RegistraAlteracao(int usuarioId)
        {
            DtaAtualizacao = DateTime.Now;
            UsuarioId = usuarioId;
        }

        public bool Desativar(int usuarioId)
        {
            this.RegistraAlteracao(usuarioId);
            return Status = false;
        }     

        public bool Ativar(int usuarioId)
        {
            this.RegistraAlteracao(usuarioId);
            return Status = true;
        }
        #endregion

        public abstract void IsValid();
    }
}
