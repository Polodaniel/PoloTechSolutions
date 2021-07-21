using Models.View;
using Models;
using Models.Cadastros;
using PontoEletronicoWeb.Client.Pages.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PontoEletronicoWeb.Shared.Enum;
using System.Net.Http.Json;

using TurnoModel = Models.Cadastros.Turno;
using MudBlazor;
using System.Globalization;

namespace PontoEletronicoWeb.Client.Pages.Turno
{
    public class TurnoCadastroBase : CadastroEditarVisualizarComponentBase<TurnoModel, TurnoView>
    {
        #region Parametros
        [Parameter]
        public int ID { get; set; }

        [Parameter]
        public string NomePagina { get; set; }

        #endregion

        #region Propriedades

        #endregion

        #region Contrutor
        public TurnoCadastroBase()
        {
            #region Instancia Nova Turma
            model = new TurnoModel();
            #endregion

            #region Define as Rotas
            Api = "api/Turno";
            RotaConsulta = string.Concat("/Turno/");
            #endregion

            #region Define o Tipo de Operacao
            Operacao = TipoOperacao.Novo;
            #endregion

            #region Define o Status Inical do Objeto
            model.Status = true;
            #endregion

            #region Nome Pagina
            NomePagina = "Cadastrar Novo";
            #endregion
        }
        #endregion

        #region Rotinas
        protected override async Task OnInitializedAsync()
        {
            if (ID > 0)
            {
                model = await Http.GetFromJsonAsync<TurnoModel>($"{Api}/{ID}");

                NomePagina = "Editar";

                Operacao = TipoOperacao.Edicao;

                MontarObjetoGravado(model);
            }
        }

        private void MontarObjetoGravado(TurnoModel model)
        {

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

        }

        protected override async void NovaInstanciaModel()
        {
            model = new TurnoModel();
            model.Status = true;

            #region Atualizar View
            StateHasChanged();
            #endregion
        }

        protected void SalvarInformacoes()
        {
            if (!ValidaInformacoes())
                return;

            SalvarEditar();
        }


        private bool ValidaInformacoes()
        {
            #region Variavel de Controle
            var result = true;
            #endregion

            #region Validações
            if (string.IsNullOrEmpty(model.Descricao))
            {
                return false;
            }
            #endregion

            #region Return
            return true;
            #endregion
        }
        #endregion
    }
}
