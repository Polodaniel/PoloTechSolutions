using Microsoft.AspNetCore.Components;
using Models.View;
using PontoEletronicoWeb.Client.Pages.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

using ClienteModel = Models.Cadastros.Cliente;

namespace PontoEletronicoWeb.Client.Pages.Cliente
{
    public class ClienteVisualizacaoBase : CadastroEditarVisualizarComponentBase<ClienteModel, ClienteView>
    {
        #region Parametros
        [Parameter]
        public int id { get; set; }
        #endregion

        #region Construtor
        public ClienteVisualizacaoBase()
        {
            #region Instancia
            model = new ClienteModel();
            #endregion

            #region Define as Rotas
            Api = "api/cliente";
            RotaConsulta = "Cliente";
            #endregion
        }
        #endregion

        #region Rotinas
        protected override async Task OnInitializedAsync()
        {
            if (id > 0)
            {
                model = await Http.GetFromJsonAsync<ClienteModel>($"{Api}/{id}");
            }
        }

        protected override void NovaInstanciaModel()
        {

        }
        #endregion
    }
}
