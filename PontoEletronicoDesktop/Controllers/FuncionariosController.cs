using PontoEletronicoDesktop.Models;
using PontoEletronicoDesktop.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronicoDesktop.Controllers
{
    public class FuncionariosController
    {
        public async Task<List<Funcionario>> BuscaFuncionariosAsync()
        {
            var ListaFuncionarios = new List<Funcionario>();

            using (Request _app = new Request())
            {
                ListaFuncionarios = await _app.GetFuncionariosAsync();
            }

            return ListaFuncionarios;
        }

        public List<Funcionario> MontaLitaRequest(List<FuncionarioViewDesktop> resultConvert)
        {
            var ListaFuncionarios = new List<Funcionario>();

            resultConvert.ForEach(x => 
            {
                var Funcionario = new Funcionario();

                Funcionario.Id = x.Id;
                Funcionario.Nome = x.Nome;
                Funcionario.PossuiBiometria = x.PossuiBiometria;
                Funcionario.Status = x.Status;

                Funcionario.Biometrias = x.Biometrias;

                ListaFuncionarios.Add(Funcionario);
            });

            return ListaFuncionarios;
        }

        internal Funcionario Selecionar(int codigoFuncionario)
        {
            throw new NotImplementedException();
        }
    }
}
