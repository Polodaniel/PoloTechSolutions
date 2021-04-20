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
        public List<FuncionarioView> ListaFuncionarioAdicionados { get; set; }
        public string ApiTurno { get; }
        public string ApiCliente { get; }
        public string ApiFuncionario { get; }
        public List<TurnoView> ListaTurnos { get; private set; }
        public List<ClienteView> ListaClientes { get; private set; }
        public List<FuncionarioView> ListaFuncionarios { get; private set; }
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
            Api = "api/EscalaRestaurante";

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

        protected override void NovaInstanciaModel()
        {
            throw new NotImplementedException();
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

    }
}
