using Microsoft.AspNetCore.Components;
using MudBlazor;
using PontoEletronicoWeb.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PontoEletronicoWeb.Client.Shared.Componentes.MessageBox
{
    public class MessageBoxBase : ComponentBase
    {
        #region Propriedades
        public MudMessageBox mbox { get; set; }

        public Color ButtomCollor { get; set; }
        #endregion

        #region Parametros
        [Parameter]
        public MessageBoxType MessageType { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Message { get; set; }

        [Parameter]
        public string ConfirmText { get; set; }

        [Parameter]
        public string CancelText { get; set; }

        #endregion

        #region Eventos
        public void AddParameterValues(MessageBoxType MessageType, string Title, string Message, string ConfirmText = "OK", string CancelText = null)
        {
            StateHasChanged();

            this.MessageType = MessageType;
            this.Title = Title;
            this.Message = Message;
            this.ConfirmText = ConfirmText;
            this.CancelText = CancelText;

            StateHasChanged();

            switch (this.MessageType)
            {
                case MessageBoxType.Success: ButtomCollor = Color.Tertiary; break;
                case MessageBoxType.Information: ButtomCollor = Color.Tertiary; break;
                case MessageBoxType.Warning: ButtomCollor = Color.Warning; break;
                case MessageBoxType.Error: ButtomCollor = Color.Error; break;
                default: ButtomCollor = Color.Primary; break;
            }

            StateHasChanged();
        }

        public async Task<bool?> GetUserResponse()
        {
            bool? result = await mbox.Show();

            return result;
        }
        #endregion
    }

}
