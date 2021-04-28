using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Models.View;
using PontoEletronicoWeb.Client.Pages.Utils;
using PontoEletronicoWeb.Shared.Auxiliares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Client.Pages.Escala
{
    public class EscalaConsultaBase : ConsultaComponentBase<EscalaView>
    {
        #region Inject
        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Inject]
        protected IJSRuntime JS { get; set; }
        #endregion

        #region Parametros
        [Parameter]
        public string Mensagem { get; set; } = "Excluir a escala cadastrado";

        public string SubMensagem { get; set; }

        [Parameter]
        public string IconMensagem { get; set; }

        [Parameter]
        public string BotaoConfirmar { get; set; } = "Sim";

        [Parameter]
        public string BotaoCancelar { get; set; } = "Não";
        #endregion

        #region Propriedades
        protected FiltroEscala Filtro { get; set; }

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

        public string ApiTurno { get; }
        public string ApiCliente { get; }
        public string ApiFuncionario { get; }
        public List<TurnoView> ListaTurnos { get; private set; }
        public List<ClienteView> ListaClientes { get; private set; }
        public List<FuncionarioView> ListaFuncionarios { get; private set; }
        protected bool RealizandoBusca { get; set; } = false;
        #endregion

        #region Construtor
        public EscalaConsultaBase()
        {
            Titulo = "Escala";
            ControllerName = "Escala";

            ApiTurno = "api/turno";
            ApiCliente = "api/cliente";
            ApiFuncionario = "api/funcionario";

            MensageBox = "Excluir a Escala.";
        }
        #endregion

        #region Eventos
        protected override async Task OnInitializedAsync()
        {
            Filtro = new FiltroEscala();

            #region URL
            var uriTurno = string.Concat(ApiTurno, "?ativo=true");
            var uriCliente = string.Concat(ApiCliente, "?ativo=true");
            var uriFuncionario = string.Concat(ApiFuncionario, "?ativo=true");
            #endregion

            #region Listas
            ListaTurnos = await Http.GetFromJsonAsync<List<TurnoView>>(uriTurno);
            ListaClientes = await Http.GetFromJsonAsync<List<ClienteView>>(uriCliente);
            ListaFuncionarios = await Http.GetFromJsonAsync<List<FuncionarioView>>(uriFuncionario);
            #endregion

        }

        protected override List<EscalaView> FiltrarCampos(List<EscalaView> listaTmp)
        {
            throw new NotImplementedException();
        }

        protected override void Limpar()
        {
            throw new NotImplementedException();
        }

        protected void LimparFiltro()
        {
            Filtro = new FiltroEscala();
        }

        protected async void RealizarBusca()
        {
            MensagemBusca(true);

            await Pesquisar();
        }

        protected async Task Pesquisar()
        {
            ModelsTmp = new List<EscalaView>();

            var API = $"api/Escala/filtro";

            var result = await Http.PostAsJsonAsync(API, Filtro);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var lista = JsonSerializer.Deserialize<List<EscalaView>>(
                    await result.Content.ReadAsStringAsync()
                    , new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                ModelsTmp = lista.OrderByDescending(x => x.DataEscala).ToList();

                Console.WriteLine(ModelsTmp);
            }
            else
            {
                var err = await result.Content.ReadAsStringAsync();
            }

            MensagemBusca(false);

            StateHasChanged();
        }

        private void MensagemBusca(bool status) =>
            RealizandoBusca = status;

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
        #endregion
    }
}
