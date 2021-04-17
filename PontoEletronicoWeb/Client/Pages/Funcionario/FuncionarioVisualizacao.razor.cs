using Microsoft.AspNetCore.Components;
using Models.View;
using PontoEletronicoWeb.Client.Pages.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

using FuncionarioModel = Models.Cadastros.Funcionario;

namespace PontoEletronicoWeb.Client.Pages.Funcionario
{
    public class FuncionarioVisualizacaoBase : CadastroEditarVisualizarComponentBase<FuncionarioModel, FuncionarioView>
    {
        #region Parametros
        [Parameter]
        public int id { get; set; }
        #endregion

        #region Construtor
        public FuncionarioVisualizacaoBase()
        {
            #region Instancia Funcionario
            model = new FuncionarioModel();
            #endregion

            #region Define as Rotas
            Api = "api/funcionario";
            RotaConsulta = "Funcionario";
            #endregion
        }
        #endregion

        #region Rotinas
        protected override async Task OnInitializedAsync()
        {
            if (id > 0)
            {
                model = await Http.GetFromJsonAsync<FuncionarioModel>($"{Api}/{id}");
            }
        }

        protected override void NovaInstanciaModel()
        {

        }
        #endregion
    }
}
