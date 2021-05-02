using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronicoDesktop.Models.View
{
    public class FuncionarioViewDesktop : FuncionarioView
    {
        public FuncionarioViewDesktop() =>
            Biometrias = new List<Biometria>();

        public List<Biometria> Biometrias { get; set; }
    }
}
