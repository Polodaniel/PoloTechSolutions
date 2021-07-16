using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Models.View;
using PontoEletronicoWeb.Client.Pages.Utils;
using PontoEletronicoWeb.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Client.Pages.Turno
{
    public class TurnoConsultaBase : ConsultaComponentBase<TurnoView>
    {
        #region Inject
        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Inject]
        protected IJSRuntime JS { get; set; }
        #endregion

        #region Parametros
        [Parameter]
        public string Mensagem { get; set; } = "Excluir o turno cadastrado";

        [Parameter]
        public string IconMensagem { get; set; }

        [Parameter]
        public string BotaoConfirmar { get; set; } = "Sim";

        [Parameter]
        public string BotaoCancelar { get; set; } = "Não";
        #endregion

        #region Eventos
        protected override List<TurnoView> FiltrarCampos(List<TurnoView> listaTmp)
        {
            throw new NotImplementedException();
        }

        protected override void Limpar()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Propriedades
        protected string StyleVisualizaMessage { get; set; } = "display: none;";
        #endregion

        public TurnoConsultaBase()
        {
            Titulo = "Turno";
            ControllerName = "Turno";

            MensageBox = "Excluir o Turno.";
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

        public string searchString = "";
        public TurnoView selectedItem = null;
        public HashSet<TurnoView> selectedItems = new HashSet<TurnoView>();

        public async void InicializaRotaExcluir(int ID)
        {
            if (!Equals(ModelsTmp, null) && ModelsTmp.Count > 0)
                SubMensagem = ModelsTmp.Find(x => x.Id == ID).Descricao;

            MontarMessageBox("Deseja excluir o Turno");

            var ResultOperacao = await ConfirmarExclusaoAsync();

            if (ResultOperacao)
            {
                ExcluirID = ID;

                await RealizaExclusao(ExcluirID);

                StateHasChanged();
            }
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

        public bool FilterFunc(TurnoView element)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.Descricao.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    await JS.InvokeAsync<object>("TestDataTablesAdd", "#TabelaTurno");
        //}

    }
}
