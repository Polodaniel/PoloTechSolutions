using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Client.Shared.Componentes
{
    public class MessageBoxBase : ComponentBase
    {
        #region Parametros
        [Parameter]
        public string Mensagem { get; set; }

        [Parameter]
        public string SubMensagem { get; set; }

        [Parameter]
        public string IconMensagem { get; set; }

        [Parameter]
        public string BotaoConfirmar { get; set; } = "Sim";

        [Parameter]
        public string BotaoCancelar { get; set; } = "Não";

        [Parameter]
        public bool VisualizaMessage
        {
            get => _visualizaMessage;
            set
            {
                _visualizaMessage = value;

                StyleVisualizaMessage = _visualizaMessage ? string.Empty : "display: none;";
            }
        }

        [Parameter]
        public EventCallback ConfirmarCallback { get; set; }

        [Parameter]
        public EventCallback CancelarCallback { get; set; }
        #endregion

        #region Propriedades
        private bool _visualizaMessage { get; set; }

        protected string StyleVisualizaMessage { get; set; } = "display: none;";
        #endregion

        public async void ExecutaConfirmacao() =>
            await ConfirmarCallback.InvokeAsync();

        public async void ExecutaCancelamento() =>
            await CancelarCallback.InvokeAsync();
    }

}
