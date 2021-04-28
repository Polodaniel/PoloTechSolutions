using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Models.View;
using PontoEletronicoWeb.Client.Pages.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Client.Pages.Funcionario
{
    public class FuncionarioConsultaBase : ConsultaComponentBase<FuncionarioView>
    {
        #region Inject
        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Inject]
        protected IJSRuntime JS { get; set; }
        #endregion

        #region Parametros
        [Parameter]
        public string Mensagem { get; set; } = "Excluir o funcionário cadastrado";

        public string SubMensagem { get; set; }

        [Parameter]
        public string IconMensagem { get; set; }

        [Parameter]
        public string BotaoConfirmar { get; set; } = "Sim";

        [Parameter]
        public string BotaoCancelar { get; set; } = "Não";
        #endregion

        #region Eventos
        protected override List<FuncionarioView> FiltrarCampos(List<FuncionarioView> listaTmp)
        {
            throw new NotImplementedException();
        }

        protected override void Limpar()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Propriedades
        private bool _flagVisualizaMessage { get; set; }

        protected bool FlagVisualizaMessage
        {
            get => _flagVisualizaMessage;
            set
            {
                _flagVisualizaMessage = !_flagVisualizaMessage;

                StyleVisualizaMessage = _flagVisualizaMessage ? string.Empty : "display: none;";

                StateHasChanged();
            }
        }

        private bool _visualizaMessage { get; set; }

        protected string StyleVisualizaMessage { get; set; } = "display: none;";
        #endregion

        public FuncionarioConsultaBase()
        {
            Titulo = "Funcionário";
            ControllerName = "Funcionario";

            MensageBox = "Excluir o Funcionário.";
        }

        public void InicializaRotaVisualizar(int ID)
        {
            var URI = Navigation.Uri;

            URI = string.Concat(URI, "/Visualizar/", ID);

            Navigation.NavigateTo(URI);
        }

        public void InicializaRotaEditar(int ID)
        {
            var URI = Navigation.Uri;

            URI = string.Concat(URI, "/Novo/", ID);

            Navigation.NavigateTo(URI);
        }

        public async void InicializaRotaExcluir(int ID)
        {
            FlagVisualizaMessage = !FlagVisualizaMessage;

            if (!Equals(ModelsTmp, null) && ModelsTmp.Count > 0)
                SubMensagem = ModelsTmp.Find(x => x.Id == ID).Descricao;

            ExcluirID = ID;

            StateHasChanged();

            await Task.Delay(500);

            await JS.InvokeVoidAsync("FocoInativar");

        }

        public async void ConfirmaExclusao()
        {
            await RealizaExclusao(ExcluirID);

            FlagVisualizaMessage = !FlagVisualizaMessage;

            StateHasChanged();
        }

        public void CancelaExclusao()
        {
            FlagVisualizaMessage = !FlagVisualizaMessage;
            StateHasChanged();
        }

        protected override void ExcluirItemLista(int ID)
        {
            var obj = ModelsTmp.Where(x => x.Id == ID).FirstOrDefault();

            if (!Equals(obj))
            {
                ModelsTmp.Remove(obj);

                StateHasChanged();
            }
        }
    }
}
