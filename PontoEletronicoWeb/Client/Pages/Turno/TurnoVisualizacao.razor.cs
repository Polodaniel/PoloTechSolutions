using Microsoft.AspNetCore.Components;
using Models.View;
using PontoEletronicoWeb.Client.Pages.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

using TurnoModel = Models.Cadastros.Turno;

namespace PontoEletronicoWeb.Client.Pages.Turno
{
    public class TurnoVisualizacaoBase : CadastroEditarVisualizarComponentBase<TurnoModel, TurnoView>
    {
        #region Parametros
        [Parameter]
        public int id { get; set; }
        #endregion

        #region Construtor
        public TurnoVisualizacaoBase()
        {
            #region Instancia Funcionario
            model = new TurnoModel();
            #endregion

            #region Define as Rotas
            Api = "api/turno";
            RotaConsulta = "/Turno";
            #endregion
        }
        #endregion

        #region Rotinas
        protected override async Task OnInitializedAsync()
        {
            if (id > 0)
            {
                model = await Http.GetFromJsonAsync<TurnoModel>($"{Api}/{id}");
            }
        }

        protected override void NovaInstanciaModel()
        {

        }
        #endregion
    }
}
