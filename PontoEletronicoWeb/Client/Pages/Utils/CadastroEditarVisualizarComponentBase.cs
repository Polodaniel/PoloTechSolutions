using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Models.View;
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

        #endregion

        #region Rotinas
        protected virtual async Task SalvarEditar()
        {
            try
            {
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
                        SalvoComSucesso = true;
                        SetPropertiesInModel(modelObj);
                        NovaInstanciaModel();

                        ColorMesagemOperacao = "bg-success";
                        MensagemOperacao = "Salvo com Sucesso !";

                        TimerCounter = 30;

                        StateHasChanged();
                    }
                    else if (Operacao == TipoOperacao.Edicao)
                    {
                        StateHasChanged();

                        var URI = string.Concat(Navigation.BaseUri, RotaConsulta);
                        Navigation.NavigateTo(URI);
                    }
                }
                else
                {
                    ColorMesagemOperacao = "bg-danger";
                    MensagemOperacao = "Ops ! Não foi possivel estar salvando. ";

                    ErroRetorno = await httpResponse.Content.ReadAsStringAsync();

                    MensagemOperacao = string.Concat(MensagemOperacao, " ", ErroRetorno);

                    StateHasChanged();
                }
            }
            catch (Exception erro)
            {
                var msgErro = erro.Message;
            }
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

        #endregion
    }

}
