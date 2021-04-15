using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Models.View;
using PontoEletronicoWeb.Client.Pages.Utils;
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
        #endregion

        #region Parametros
        [Parameter]
        public string Mensagem { get; set; } = "Excluir o turno cadastrado";

        public string SubMensagem { get; set; }

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

        public async void InicializaRotaExcluir(int ID)
        {
            FlagVisualizaMessage = !FlagVisualizaMessage;

            if (!Equals(ModelsTmp, null) && ModelsTmp.Count > 0)
                SubMensagem = ModelsTmp.Find(x => x.Id == ID).Descricao;

            ExcluirID = ID;

            StateHasChanged();
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

            foreach (var item in ModelsTmp)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Descricao);
            }

            if (!Equals(obj))
            {
                ModelsTmp.Remove(obj);

                StateHasChanged();
            }
        }

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    await JS.InvokeAsync<object>("TestDataTablesAdd", "#TabelaTurno");
        //}

    }
}
