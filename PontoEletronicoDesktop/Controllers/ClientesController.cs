using PontoEletronicoDesktop.Data;
using PontoEletronicoDesktop.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronicoDesktop.Controllers
{
    public class ClientesController
    {
        public async Task<List<Cliente>> BuscaClientesAsync()
        {
            var Lista = new List<Cliente>();

            using (Request _app = new Request())
            {
                Lista = await _app.GetClientesAsync();
            }

            return Lista;
        }

        public bool SalvarCienteSelecionado(Cliente clienteSelecionado)
        {
            try
            {
                var result = SQLConexao.ClienteAdd(clienteSelecionado);

                return Equals(result, 1) ? true : false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Cliente> BuscarClienteAtual()
        {
            try
            {
                var result = await SQLConexao.ClientesAtivo();

                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
