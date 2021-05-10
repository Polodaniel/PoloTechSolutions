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
using Models.Ponto;
using Microsoft.AspNetCore.Components.Web;
using System.Text.Json;
using System.Net.Http;
using System.Text;

using static PontoEletronicoWeb.Client.Pages.Utils.ValidacaoLista;
using EscalaModel = Models.Ponto.Escala;

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

        public List<EscalaFuncionario> ListaFuncionarioAdicionados { get; set; }
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
        public TipoEscala TipoEscala { get; set; } = TipoEscala.Diario;
        public int MesSelecionado { get; set; } = 1;

        public List<EscalaModel> ListaEscalaMes { get; set; }
        #endregion

        public EscalaCadastroBase()
        {
            #region Instancia Nova
            model = new EscalaModel();
            ListaEscalaMes = new List<EscalaModel>();

            ListaFuncionarioAdicionados = new List<EscalaFuncionario>();
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
                model = new EscalaModel();

                model = await Http.GetFromJsonAsync<EscalaModel>($"{Api}/{ID}");

                ListaFuncionarioAdicionados = await Http.GetFromJsonAsync<List<EscalaFuncionario>>($"{Api}/EscalaFuncionario/{ID}");

                NomePagina = "Editar";
                Operacao = TipoOperacao.Edicao;

                MontarObjetoGravado(model);
            }

            #endregion
        }

        private void MontarObjetoGravado(EscalaModel model)
        {
            if (!Equals(ListaFuncionarioAdicionados, null) && ListaFuncionarioAdicionados.Count > 0)
            {
                model.Funcionarios = ListaFuncionarioAdicionados;

                foreach (var item in model.Funcionarios)
                {
                    var funcionario = ListaFuncionarios.Where(x => x.Id == item.FuncionarioId).FirstOrDefault();

                    if (!Equals(funcionario, null))
                        funcionario.Selecionado = true;
                }
            }

            StateHasChanged();
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

        public void RemoverFuncionarioEdicao(FuncionarioView funcinario)
        {
            funcinario.Selecionado = !funcinario.Selecionado;
            funcinario.Status = false;

            StateHasChanged();
        }

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

            if (TipoEscala == TipoEscala.Diario)
            {
                MontaObjetoSalvar();

                await SalvarEditar();
            }
            else if (TipoEscala == TipoEscala.Mensal)
            {
                var Lista = MontarObjetoMesSalvar();

                if (ValidacaoList.ListaValida(Lista))
                    foreach (var item in Lista)
                        await SalvarEditarMes(item);
            }
        }

        protected async Task SalvarEditarMes(EscalaModel item)
        {
            try
            {
                var modelJson = JsonSerializer.Serialize(item);

                var modelContent = new StringContent(modelJson, Encoding.UTF8, AppJson);

                var httpResponse = await ExecutaOperacao(modelContent);

                if (httpResponse.IsSuccessStatusCode)
                {
                    StateHasChanged();

                    await Task.Delay(700);

                    var modelObj = JsonSerializer.Deserialize<EscalaModel>(
                        await httpResponse.Content.ReadAsStringAsync()
                        , new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (Operacao == TipoOperacao.Novo)
                    {
                        SalvoComSucesso = true;

                        ColorMesagemOperacao = "bg-success";
                        MensagemOperacao = $"Escala de {item.DataInicio.ToShortDateString()} foi salvada com sucesso !";

                        TimerCounter = 60;

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

                NovaInstanciaModel();

                StateHasChanged();
            }
            catch (Exception erro)
            {
                var msgErro = erro.Message;
            }
        }

        private List<EscalaModel> MontarObjetoMesSalvar()
        {
            ListaEscalaMes = new List<EscalaModel>();

            var FuncionarioSelecionado = ListaFuncionarios.Where(x => x.Selecionado == true).ToList();

            var PrimeiroDiaMes = new DateTime(DateTime.Now.Year, MesSelecionado, 1);
            var UltimoDiaMes = new DateTime(DateTime.Now.Year, MesSelecionado, DateTime.DaysInMonth(DateTime.Now.Year, MesSelecionado));

            if (ValidacaoList.ListaValida(FuncionarioSelecionado))
            {
                for (int i = 1; i <= UltimoDiaMes.Day; i++)
                {
                    var NovaEscala = new EscalaModel();

                    NovaEscala.DataInicio = new DateTime(DateTime.Now.Year, MesSelecionado, i);

                    NovaEscala.DataFim = Turno.PerNoite ? NovaEscala.DataInicio.AddDays(1) : NovaEscala.DataInicio;

                    NovaEscala.ClienteId = model.ClienteId;
                    NovaEscala.Cliente = model.Cliente;

                    NovaEscala.TurnoId = model.TurnoId;
                    NovaEscala.Turno = model.Turno;

                    NovaEscala.Status = true;

                    FuncionarioSelecionado.ForEach(funcionario =>
                    {
                        NovaEscala.Funcionarios.Add(new EscalaFuncionario(funcionario));
                    });

                    ListaEscalaMes.Add(NovaEscala);
                }
            }

            return ListaEscalaMes;
        }

        private void MontaObjetoSalvar()
        {
            var FuncionarioSelecionado = ListaFuncionarios.Where(x => x.Selecionado == true).ToList();

            if (Operacao == TipoOperacao.Novo)
            {
                model.DataFim = Turno.PerNoite ? model.DataInicio.AddDays(1) : model.DataInicio;

                if (ValidacaoList.ListaValida(FuncionarioSelecionado))
                {
                    FuncionarioSelecionado.ForEach(funcionario =>
                    {
                        model.Funcionarios.Add(new EscalaFuncionario(funcionario));
                    });
                }
            }
            else if (Operacao == TipoOperacao.Edicao)
            {
                if (ValidacaoList.ListaValida(FuncionarioSelecionado))
                {
                    foreach (var item in model.Funcionarios)
                    {
                        var funcionario = ListaFuncionarios.Where(x => x.Id == item.FuncionarioId).FirstOrDefault();
                        
                        if (!Equals(funcionario, null)) 
                            item.Status = funcionario.Status;
                    }

                    foreach (var item in FuncionarioSelecionado)
                    {
                        var funcionario = model.Funcionarios.Where(x => x.FuncionarioId == item.Id).FirstOrDefault();

                        if (Equals(funcionario, null))
                            model.Funcionarios.Add(new EscalaFuncionario(item));
                    }
                }
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

            #region Validações

            if (TipoEscala == TipoEscala.Diario)
            {
                if (string.IsNullOrEmpty(model.DataInicio.ToString()))
                {
                    ErroDataEscala = true;
                    return false;
                }
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
            ListaEscalaMes = new List<EscalaModel>();

            Turno = new TurnoView();

            ListaFuncionarios.ForEach(x => x.Selecionado = false);

            MesSelecionado = 1;
            TipoEscala = TipoEscala.Diario;

            #region Atualizar View
            StateHasChanged();
            #endregion
        }
    }
}
