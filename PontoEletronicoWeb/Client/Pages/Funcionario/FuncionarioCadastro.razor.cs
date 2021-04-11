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

using FuncionarioModel = Models.Cadastros.Funcionario;

namespace PontoEletronicoWeb.Client.Pages.Funcionario
{
    public class FuncionarioCadastroBase : CadastroEditarVisualizarComponentBase<FuncionarioModel, FuncionarioView>
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
        public FuncionarioCadastroBase()
        {
            #region Instancia Nova Turma
            model = new FuncionarioModel();
            #endregion

            #region Define as Rotas
            Api = "api/Funcionario";
            //Api = "Funcionario";
            RotaConsulta = string.Concat("/Funcionario/");
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
                model = await Http.GetFromJsonAsync<FuncionarioModel>($"{Api}/{ID}");

                NomePagina = "Editar";

                Operacao = TipoOperacao.Edicao;

                MontarObjetoGravado(model);
            }
        }

        private void MontarObjetoGravado(FuncionarioModel model)
        {
            //var DataIni = new DateTime(model.HoraInicioTicks);
            //var DataFim = new DateTime(model.HoraTerminoTicks);

            //HoraInicio = DataIni;
            //HoraTermino = DataFim;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            //if (firstRender)
            //    await DescricaoInput.FocusAsync();
        }

        protected override async void NovaInstanciaModel()
        {
            model = new FuncionarioModel();
            model.Status = true;

            #region Atualizar View
            StateHasChanged();
            #endregion
        }
        #endregion
    }
}
