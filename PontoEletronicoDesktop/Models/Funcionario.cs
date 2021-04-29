using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronicoDesktop.Models
{
    [Table(nameof(Funcionario))]
    public class Funcionario
    {
        public Funcionario() =>
            this.Status = true;

        [Key]
        public int Id { get; set; }
        public bool Status { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Pis { get; set; }
        public bool PossuiBiometria { get; set; }
        public List<Biometria> Biometrias { get; set; }
    }

    public class FuncinarioView
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public List<Biometria> Biometrias { get; set; }
    }
}
