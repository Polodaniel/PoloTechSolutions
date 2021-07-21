using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Models.View;
using PontoEletronicoWeb.Client.Shared.Componentes.MessageBox;
using PontoEletronicoWeb.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Client.Pages.Utils
{
    public abstract class CadastroEditarVisualizarComponentBase<TModel, TView> : ComponentBase
        where TView : BaseView
    {
        #region Inject
        [Inject]
        protected HttpClient Http { get; set; }

        [Inject]
        protected IJSRuntime JS { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }
        #endregion

        #region Constantes
        protected const string AppJson = "application/json";
        #endregion

        #region Genericos

        public TModel model;

        #endregion

        #region Parametros
        [CascadingParameter]
        public string IdModal { get; set; }

        [Parameter]
        public EventCallback<TView> RegistroSalvo { get; set; }

        [Parameter]
        public TipoOperacao Operacao { get; set; }

        public int ExcluirID { get; set; }
        #endregion

        #region Propriedades

        protected string Api;

        protected string RotaConsulta;

        protected bool Desabilitar { get; set; }

        protected string ErroRetorno { get; set; }

        public string MensagemOperacao { get; set; }

        public string ColorMesagemOperacao { get; set; }

        private bool salvoComSucesse;

        public bool SalvoComSucesso
        {
            get => salvoComSucesse;
            set
            {
                if (value)
                {
                    salvoComSucesse = value;
                    ExecutarTimer(400);
                }
                else
                    salvoComSucesse = value;
            }
        }

        private System.Timers.Timer _timer;

        private int counter = 30;

        public int TimerCounter = 30;

        public bool OverlayDisplay { get; set; }

        #region Propriedades MessageBox
        public MessageBox MessageBoxRef { get; set; }
        public MessageBoxType TypeMessageBox { get; set; }
        public string SubMensagem { get; set; }
        public string TitleMessageBox { get; set; }
        public string TextMessageBox { get; set; }
        public string ButtomConfirmMessageBox { get; set; }
        public string ButtomCancelMessageBox { get; set; }
        #endregion

        #endregion

        #region Rotinas
        protected virtual async Task SalvarEditar()
        {
            try
            {
                OverlayViewUpdate(true);

                var modelJson = JsonSerializer.Serialize(model);

                var modelContent = new StringContent(modelJson, Encoding.UTF8, AppJson);

                var httpResponse = await ExecutaOperacao(modelContent);

                if (httpResponse.IsSuccessStatusCode)
                {
                    StateHasChanged();

                    await Task.Delay(700);

                    var modelObj = JsonSerializer.Deserialize<TModel>(
                        await httpResponse.Content.ReadAsStringAsync()
                        , new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (Operacao == TipoOperacao.Novo)
                    {
                        OverlayViewUpdate(false);

                        RetornarTelaConsulta();
                    }
                    else if (Operacao == TipoOperacao.Edicao)
                    {
                        OverlayViewUpdate(false);

                        RetornarTelaConsulta();
                    }
                }
                else
                {
                    OverlayViewUpdate(false);

                    ErroRetorno = await httpResponse.Content.ReadAsStringAsync();

                    TypeMessageBox = MessageBoxType.Error;
                    TitleMessageBox = "Erro";
                    TextMessageBox = string.Concat(MensagemOperacao, " ", ErroRetorno);
                    ButtomConfirmMessageBox = "OK";
                    ButtomCancelMessageBox = null;

                    MessageBoxRef.AddParameterValues(TypeMessageBox, TitleMessageBox, TextMessageBox, ButtomConfirmMessageBox, ButtomCancelMessageBox);

                    StateHasChanged();

                    await MessageBoxRef.GetUserResponse();
                }
            }
            catch (Exception erro)
            {
                OverlayViewUpdate(false);

                var msgErro = erro.Message;
            }
        }

        public void RetornarTelaConsulta()
        {
            var URI = string.Concat(Navigation.BaseUri, RotaConsulta);

            Navigation.NavigateTo(URI);
        }

        protected async Task<HttpResponseMessage> ExecutaOperacao(StringContent modelContent)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            switch (Operacao)
            {
                case TipoOperacao.Novo:
                    httpResponse = await Http.PostAsync(Api, modelContent);
                    break;
                case TipoOperacao.Edicao:
                    httpResponse = await Http.PutAsync(Api, modelContent);
                    break;
                default:
                    break;
            }

            return httpResponse;
        }

        protected abstract void NovaInstanciaModel();

        protected virtual void SetPropertiesInModel(TModel novoModel) { }

        public void ExecutarTimer(double intervalo)
        {
            _timer = new System.Timers.Timer(intervalo);
            _timer.Elapsed += NotifyTimerElapsed;
            _timer.Enabled = true;
        }


        private void NotifyTimerElapsed(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (counter > 0)
            {
                counter -= 1;
            }
            else
            {
                _timer.Enabled = false;
                SalvoComSucesso = false;
                counter = TimerCounter;
            }

            InvokeAsync(StateHasChanged);
        }

        public void OverlayViewUpdate(bool Status) 
        {
            OverlayDisplay = Status;
            StateHasChanged();
        }

        #endregion
    }

}
