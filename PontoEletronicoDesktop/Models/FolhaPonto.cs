using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronicoDesktop.Models
{
    public class FolhaPonto
    {
        [Key]
        public int Id { get; set; }

        public bool Status { get; set; }

        public DateTime DtaEscala { get; set; }

        public int FuncionarioId { get; set; }

        [ForeignKey(nameof(FuncionarioId))]
        public Funcionario Funcionario { get; set; }
    }
}
