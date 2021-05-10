using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronicoDesktop.Models
{
    public class VerificaBiometriaModelView
    {
        public VerificaBiometriaModelView() =>
            DataRegistro = DateTime.Now;

        public VerificaBiometriaModelView(int FuncionarioId) : this() =>
            this.FuncionarioId = FuncionarioId;

        public int FuncionarioId { get; set; }
        public DateTime DataRegistro { get; set; }
        public Biometria Biometria { get; set; }
    }
}
