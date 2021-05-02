using Newtonsoft.Json;
using PontoEletronicoDesktop.Controllers;
using PontoEletronicoDesktop.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronicoDesktop.Models
{
    public class Request : IDisposable
    {
        private string API { get; set; }

        public Request() =>
            API = "https://localhost:44360/";

        public void Dispose()
        {

        }

        public async Task<List<Funcionario>> GetFuncionariosAsync()
        {
            var ListaFuncionarios = new List<Funcionario>();

            using (var cliente = new HttpClient())
            {
                var URL = "api/desktop/Biometria/funcionario";

                cliente.BaseAddress = new Uri(API);

                var request = await cliente.GetAsync(URL);

                var result = await request.Content.ReadAsStringAsync();

                var resultConvert = JsonConvert.DeserializeObject<List<FuncionarioViewDesktop>>(result);

                if (!Equals(resultConvert,null) && resultConvert.Count > 0)
                    ListaFuncionarios = new FuncionariosController().MontaLitaRequest(resultConvert);
            }

            return ListaFuncionarios;
        }

    }
}
