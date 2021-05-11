using Newtonsoft.Json;
using PontoEletronicoDesktop.Controllers;
using PontoEletronicoDesktop.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace PontoEletronicoDesktop.Models
{
    public class Request : IDisposable
    {
        #region Rota
        private string API { get; set; }
        #endregion

        #region Constante
        private const string RotaApi = "rota_api";
        private const string ApiKey = "api_key";
        #endregion

        private HttpClient cliente = new HttpClient();

        public Request()
        {
            API = ConfigurationManager.AppSettings.Get(RotaApi);

            var ApiKeyValue = ConfigurationManager.AppSettings.Get(ApiKey);

            cliente.DefaultRequestHeaders.Add(ApiKey, ApiKeyValue);
        }

        public void Dispose() =>
            cliente.Dispose();

        public async Task<List<Funcionario>> GetFuncionariosAsync()
        {
            var ListaFuncionarios = new List<Funcionario>();

            var URL = "api/desktop/Biometria/funcionario";

            cliente.BaseAddress = new Uri(API);

            var request = await cliente.GetAsync(URL);

            var result = await request.Content.ReadAsStringAsync();

            var resultConvert = JsonConvert.DeserializeObject<List<FuncionarioViewDesktop>>(result);

            if (!Equals(resultConvert, null) && resultConvert.Count > 0)
                ListaFuncionarios = new FuncionariosController().MontaLitaRequest(resultConvert);

            return ListaFuncionarios;
        }

        public async Task<bool> PostCadastroFuncionario(Funcionario funcionario)
        {
            var result = false;

            var URL = "api/desktop/Biometria/funcionario";

            cliente.BaseAddress = new Uri(API);

            var NovoRegistro = new FuncionarioBiometrias();

            NovoRegistro.CodFuncionario = funcionario.Id;
            NovoRegistro.Biometrias = funcionario.Biometrias;

            var json = JsonConvert.SerializeObject(NovoRegistro);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await cliente.PostAsync(URL, content);

            var retorno = await request.Content.ReadAsStringAsync();

            result = JsonConvert.DeserializeObject<bool>(retorno);

            return result;
        }

        internal async Task<bool> PostMarcacaoPonto(VerificaBiometriaModelView obj)
        {
            var result = false;

            var URL = "api/desktop/Biometria/verifica/biometria";

            cliente.BaseAddress = new Uri(API);

            var json = JsonConvert.SerializeObject(obj);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await cliente.PostAsync(URL, content);

            var retorno = await request.Content.ReadAsStringAsync();

            result = JsonConvert.DeserializeObject<bool>(retorno);

            return result;
        }

        public async Task<List<Cliente>> GetClientesAsync()
        {
            var ListaFuncionarios = new List<Cliente>();

            var URL = "api/desktop/Biometria/cliente";

            cliente.BaseAddress = new Uri(API);

            var request = await cliente.GetAsync(URL);

            var result = await request.Content.ReadAsStringAsync();

            var resultConvert = JsonConvert.DeserializeObject<List<Cliente>>(result);

            if (!Equals(resultConvert, null) && resultConvert.Count > 0)
                ListaFuncionarios = resultConvert;

            return ListaFuncionarios;
        }
    }
}
