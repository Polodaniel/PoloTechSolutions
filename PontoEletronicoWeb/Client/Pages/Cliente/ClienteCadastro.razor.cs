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

using ClientesModel = Models.Cadastros.Cliente;
using System.Net.Http;
using System.Text.Json;
using PontoEletronicoWeb.Shared.Auxiliares;

namespace PontoEletronicoWeb.Client.Pages.Cliente
{
    public class ClienteCadastroBase : CadastroEditarVisualizarComponentBase<ClientesModel, ClienteView>
    {
        #region Parametros
        [Parameter]
        public int ID { get; set; }

        [Parameter]
        public string NomePagina { get; set; }

        #endregion

        #region Propriedades
        protected bool ErroNomeCliente { get; set; } = false;

        protected string ErroMsgNomeClientes { get; set; }

        protected ElementReference NomeClienteInput { get; set; }
        protected ElementReference NumeroEnderecoInput { get; set; }
        protected ElementReference NumeroCepInput { get; set; }
        #endregion

        #region Contrutor
        public ClienteCadastroBase()
        {
            #region Instancia Nova Turma
            model = new ClientesModel();
            #endregion

            #region Define as Rotas
            Api = "api/Cliente";
            RotaConsulta = string.Concat("Cliente/");
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
                model = await Http.GetFromJsonAsync<ClientesModel>($"{Api}/{ID}");

                NomePagina = "Editar";

                Operacao = TipoOperacao.Edicao;

                MontarObjetoGravado(model);
            }
        }

        private void MontarObjetoGravado(ClientesModel model)
        {

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
                await NomeClienteInput.FocusAsync();
        }

        protected override async void NovaInstanciaModel()
        {
            model = new ClientesModel();
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
            #region Reseta Variaveis
            ErroNomeCliente = false;
            #endregion

            #region Variavel de Controle
            var result = true;
            #endregion

            #region Validações
            if (string.IsNullOrEmpty(model.Nome))
            {
                ErroNomeCliente = true;
                ErroMsgNomeClientes = "Informe o nome do cliente !";

                return false;
            }
            #endregion

            #region Return
            return true;
            #endregion
        }

        #endregion

        #region Eventos Geral
        protected async Task BuscarCEPAsync()
        {
            if (!string.IsNullOrEmpty(model.Cep))
            {
                FormataCEP();

                if (model.Cep.Length == 9)
                {
                    try
                    {
                        MensagemAguardeInputs("Aguarde...");

                        var RotaAPI = "https://viacep.com.br/ws/" + model.Cep.Replace("-", "") + "/json/";

                        HttpResponseMessage httpResponse = new HttpResponseMessage();

                        httpResponse = await Http.GetAsync(RotaAPI);

                        var modelObj = JsonSerializer.Deserialize<InfoCep>(
                                    await httpResponse.Content.ReadAsStringAsync()
                            , new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                        if (!Equals(modelObj, null))
                        {
                            MensagemAguardeInputs(string.Empty);

                            model.Logadouro = modelObj.logradouro;
                            model.Bairro = modelObj.bairro;
                            model.Cidade = modelObj.localidade;

                            await NumeroEnderecoInput.FocusAsync();
                        }
                    }
                    catch (Exception er)
                    {
                        var teste = er.Message;
                    }
                }
            }
        }

        protected void FormataCEP()
        {
            if (model.Cep.Length == 8)
            {
                var CEP = model.Cep.Substring(0, 5);
                model.Cep = model.Cep.Replace(CEP, string.Concat(CEP, "-"));
            }
        }


        private void MensagemAguardeInputs(string msg)
        {
            model.Logadouro = msg;
            model.Bairro = msg;
            model.Cidade = msg;
        }


        #endregion
    }
}
