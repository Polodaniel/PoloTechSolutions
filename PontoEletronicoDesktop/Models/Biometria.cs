using PontoEletronicoDesktop.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronicoDesktop.Models
{
    public class Biometria : BaseModel
    {
        public Biometria() =>
            Funcionario = new Funcionario();

        public byte[] BiometriaImg { get; set; }

        public DedoBiometria Dedo { get; set; }

        public int FuncionarioId { get; set; }

        [ForeignKey(nameof(FuncionarioId))]
        public Funcionario Funcionario { get; set; }

        [NotMapped]
        public string Descricao { get; set; }
    }
}
