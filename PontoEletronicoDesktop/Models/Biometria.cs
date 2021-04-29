using PontoEletronicoDesktop.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronicoDesktop.Models
{
    [Table(nameof(Biometria))]
    public class Biometria
    {
        #region Construtor
        public Biometria()
        {
            Status = true;
        }
        #endregion

        [Key]
        public int Id { get; set; }

        public bool Status { get; set; }

        public byte[] BiometriaImg { get; set; }

        public DedoBiometria Dedo { get; set; }

        public int FuncionarioId { get; set; }

        [ForeignKey(nameof(FuncionarioId))]
        public Funcionario Funcionario { get; set; }

        [NotMapped]
        public string Descricao { get; set; }
    }
}
