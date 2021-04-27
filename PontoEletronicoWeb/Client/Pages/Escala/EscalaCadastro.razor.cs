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

using EscalaModel = Models.Ponto.Escala;
using Models.Ponto;
using Microsoft.AspNetCore.Components.Web;
using static PontoEletronicoWeb.Client.Pages.Utils.ValidacaoLista;

namespace PontoEletronicoWeb.Client.Pages.Escala
{
    public class EscalaCadastroBase : CadastroEditarVisualizarComponentBase<EscalaModel, EscalaView>
    {
        #region Parametros
        [Parameter]
        public int ID { get; set; }

        [Parameter]
        public string NomePagina { get; set; }
        #endregion

        #region Propriedades
        protected string SearchText { get; set; }
        protected string SearchTextDois { get; set; }

        public List<FuncionarioView> ListaFuncionarioAdicionados { get; set; }
        public string ApiTurno { get; }
        public string ApiCliente { get; }
        public string ApiFuncionario { get; }
        public List<TurnoView> ListaTurnos { get; private set; }
        public List<ClienteView> ListaClientes { get; private set; }
        public List<FuncionarioView> ListaFuncionarios { get; private set; }
        public bool ErroTurno { get; set; } = false;
        public bool ErroCliente { get; set; } = false;
        public bool ErroFuncionario { get; set; } = false;
        public bool ErroDataEscala { get; set; } = false;
        public string ErroTurnoMsg { get; private set; }
        public string ErroClienteMsg { get; private set; }
        public string ErroFuncionarioMsg { get; private set; }
        public string ErroDataEscalaMsg { get; private set; }
        public TurnoView Turno { get; set; }
        public int TurnoSelecionado
        {
            get => model.TurnoId;
            set
            {
                if (!Equals(model, null))
                {
                    model.TurnoId = value;

                    if (!Equals(ListaTurnos, null) && ListaTurnos.Count > 0)
                    {
                        var turno = ListaTurnos.Where(x => x.Id == value).FirstOrDefault();

                        if (!Equals(turno, null))
                            Turno = turno;
                        else
                            Turno = null;
                    }
                }

                StateHasChanged();
            }
        }

        #endregion

        public EscalaCadastroBase()
        {
            #region Instancia Nova
            model = new EscalaModel();

            ListaFuncionarioAdicionados = new List<FuncionarioView>();
            #endregion

            #region Define as Rotas
            Api = "api/Escala";

            ApiTurno = "api/turno";
            ApiCliente = "api/cliente";
            ApiFuncionario = "api/funcionario";

            RotaConsulta = "/Escala";
            #endregion

            #region Define o Tipo de Operacao
            Operacao = TipoOperacao.Novo;
            #endregion

            #region Define o Status Inical do Objeto
            model.Status = true;
            #endregion

            #region Nome Pagina
            NomePagina = "Cadastrar Nova";
            #endregion

        }

        protected override async Task OnInitializedAsync()
        {
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

            #region Mensagens de Erro
            ErroTurnoMsg = "Selecione um Turno.";
            ErroClienteMsg = "Selecione um Cliente.";
            ErroFuncionarioMsg = "Selecione um Funcionário.";
            ErroDataEscalaMsg = "Informe a data da Escala.";
            #endregion

            #region ID
            if (ID > 0)
            {
                model = await Http.GetFromJsonAsync<EscalaModel>($"{Api}/{ID}");
                NomePagina = "Editar";
                Operacao = TipoOperacao.Edicao;
                //MontarObjetoGravado(model);
            }
            #endregion
        }

        protected void ChangeSelectedItens(FuncionarioView Obj, bool IsSelected)
        {
            if (Obj.Selecionado == IsSelected)
                return;

            Obj.Selecionado = IsSelected;

            StateHasChanged();
        }

        public void RemoverFuncionario(FuncionarioView funcinario) =>
            funcinario.Selecionado = !funcinario.Selecionado;

        protected void FilterText(ChangeEventArgs args)
        {
            SearchText = (string)args.Value;

            Filtrar();
        }

        protected void FilterTextDois(ChangeEventArgs args)
        {
            SearchTextDois = (string)args.Value;

            FiltrarDois();
        }

        private void Filtrar()
        {
            if (!string.IsNullOrEmpty(SearchText))
            {
                var _filteredList = ListaFuncionarios.Where(x => x.Nome.ToLower().Contains(SearchText.ToLower())
                                                              || x.CodigoString.ToLower().Contains(SearchText.ToLower())).ToList();

                ListaFuncionarios.ForEach(x => x.Display = "display: none;");

                if (!Equals(_filteredList, null) && _filteredList.Count > 0)
                    foreach (var item in _filteredList)
                    {
                        var _itemEdit = ListaFuncionarios.Where(x => x.Id == item.Id).FirstOrDefault();

                        if (!Equals(_itemEdit, null))
                            _itemEdit.Display = string.Empty;
                    }
            }
            else
                ListaFuncionarios.ForEach(x => x.Display = string.Empty);

        }

        private void FiltrarDois()
        {
            if (!string.IsNullOrEmpty(SearchTextDois))
            {
                var _filteredList = ListaFuncionarios.Where(x => x.Nome.ToLower().Contains(SearchTextDois.ToLower())
                                                              || x.CodigoString.ToLower().Contains(SearchTextDois.ToLower())).ToList();

                ListaFuncionarios.ForEach(x => x.DisplayDois = "display: none;");

                if (!Equals(_filteredList, null) && _filteredList.Count > 0)
                    foreach (var item in _filteredList)
                    {
                        var _itemEdit = ListaFuncionarios.Where(x => x.Id == item.Id).FirstOrDefault();

                        if (!Equals(_itemEdit, null))
                            _itemEdit.DisplayDois = string.Empty;
                    }
            }
            else
                ListaFuncionarios.ForEach(x => x.DisplayDois = string.Empty);

        }

        protected async void EnterDown(KeyboardEventArgs e)
        {

        }

        protected async Task SalvarInformacoesAsync()
        {
            if (!ValidaInformacoes())
                return;

            MontaObjetoSalvar();

            await SalvarEditar();
        }

        private void MontaObjetoSalvar()
        {
            var FuncionarioSelecionado = ListaFuncionarios.Where(x => x.Selecionado == true).ToList();

            if (ValidacaoList.ListaValida(FuncionarioSelecionado))
            {
                FuncionarioSelecionado.ForEach(funcionario =>
                {
                    model.Funcionarios.Add(new EscalaFuncionario(funcionario));
                });
            }
        }

        private bool ValidaInformacoes()
        {
            #region Reseta Variaveis
            ErroTurno = false;
            ErroCliente = false;
            ErroDataEscala = false;
            ErroFuncionario = false;
            #endregion

            #region Variavel de Controle
            var result = true;
            #endregion

            #region Validações
            if (string.IsNullOrEmpty(model.DataEscala.ToString()))
            {
                ErroDataEscala = true;
                return false;
            }

            if (model.ClienteId == 0)
            {
                ErroCliente = true;
                return false;
            }

            if (model.TurnoId == 0)
            {
                ErroTurno = true;
                return false;
            }
            #endregion

            #region Return
            return true;
            #endregion
        }

        protected override async void NovaInstanciaModel()
        {
            model = new EscalaModel();
            model.Status = true;

            Turno = new TurnoView();

            ListaFuncionarios.ForEach(x => x.Selecionado = false);

            #region Atualizar View
            StateHasChanged();
            #endregion
        }
    }
}
