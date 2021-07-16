using Microsoft.AspNetCore.Components;
using Models.View;
using PontoEletronicoWeb.Client.Shared.Componentes;
using PontoEletronicoWeb.Client.Shared.Componentes.MessageBox;
using PontoEletronicoWeb.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static PontoEletronicoWeb.Client.Pages.Utils.ValidacaoLista;

namespace PontoEletronicoWeb.Client.Pages.Utils
{
    public abstract class ConsultaComponentBase<U> : ComponentBase where U : BaseView
    {
        #region Inject
        [Inject]
        protected HttpClient Http { get; set; }

        //[Inject]
        //protected IJSRuntime JS { get; set; }
        #endregion

        #region Propriedades
        public MessageBox MessageBoxRef { get; set; }

        public List<U> Models { get; set; }

        public List<U> ModelsTmp { get; set; }

        protected string Titulo { get; set; }

        protected string NovoTitulo => $"Novo Cadastro {Titulo}";

        protected string ControllerName;

        protected string UrlApi => $"api/{ControllerName}";

        protected bool Status { get; set; } = true;

        public string PesquisaTexto { get; set; }

        protected bool IsOrderByDescending = false;

        protected bool Desabilitar { get; set; }

        protected bool FiltrarListaAutomatico { get; set; } = true;

        #endregion

        #region Propriedades MessageBox
        public MessageBoxType TypeMessageBox { get; set; }
        public string SubMensagem { get; set; }
        public string TitleMessageBox { get; set; }
        public string TextMessageBox { get; set; }
        public string ButtomConfirmMessageBox { get; set; }
        public string ButtomCancelMessageBox { get; set; }
        #endregion

        #region Métodos

        #region Abstratos
        protected abstract List<U> FiltrarCampos(List<U> listaTmp);

        protected abstract void Limpar();

        #endregion

        #region Virtuais
        protected override async Task OnInitializedAsync()
        {
            if (Status)
            {
                var URI = string.Concat(UrlApi, "?ativo=true");

                Models = await Http.GetFromJsonAsync<List<U>>(URI);
            }
            else
                Models = await Http.GetFromJsonAsync<List<U>>(UrlApi);

            if (Models == null)
                Models = new List<U>();

            ModelsTmp = Models.ToList();

            //Filtrar();
        }

        protected virtual void Filtrar()
        {
            if (Models == null || Models.Count == 0)
                return;

            ModelsTmp = FiltrarCampos(Models.ToList());
        }
        protected virtual U RetornaModelIgualSeExistir(U novoModel) =>
            Models.FirstOrDefault(x => x.Id == novoModel.Id);

        protected virtual async Task ReprocessarLista(U novoModel)
        {
            var modelIgual = RetornaModelIgualSeExistir(novoModel);

            if (modelIgual != null)
                Models.Remove(modelIgual);

            await AddModel(novoModel);

            if (IsOrderByDescending)
                Models = Models.OrderByDescending(x => x.Id).ToList();
            else
                Models = Models.OrderBy(x => x.Id).ToList();

            if (FiltrarListaAutomatico)
                Filtrar();
        }

        protected virtual async Task AddModel(U novoModel) =>
            await Task.Factory.StartNew(() => Models.Add(novoModel));

        protected int IndexOf(U model) =>
            (ValidacaoList.ListaValida(ModelsTmp) ? ModelsTmp : Models).IndexOf(model);

        protected string IdModalEdit(int indexOf) => $"modal-model-{indexOf}";
        protected string IdModalDelete(int indexOf) => $"modal-model-excluir-{indexOf}";
        protected virtual string UrlApiDelete(string codigo) => $"{UrlApi}/codigo/{codigo}";
        protected virtual string UrlApiDelete(int codigo) => $"{UrlApi}/{codigo}";
        #endregion

        #region CRUD
        [Parameter]
        public string MensageBox { get; set; }

        protected int ExcluirID { get; set; }

        protected async Task RealizaExclusao(int ID)
        {
            var result = await Http.DeleteAsync($"{UrlApi}/{ID}");

            if (result.IsSuccessStatusCode)
            {
                ExcluirItemLista(ID);
            }
        }

        public async Task<bool> ConfirmarExclusaoAsync() 
        {
            var ResultMessageBox = false;

            MessageBoxRef.AddParameterValues(TypeMessageBox, TitleMessageBox, TextMessageBox, ButtomConfirmMessageBox, ButtomCancelMessageBox);

            StateHasChanged();

            var result = await MessageBoxRef.GetUserResponse();

            if (!Equals(result,null)) 
                ResultMessageBox = result == true ? true : false;

            return ResultMessageBox;
        }

        protected virtual void ExcluirItemLista(int ID)
        {
            var obj = ModelsTmp.Where(x => x.Id == ID).FirstOrDefault();

            if (!Equals(obj))
            {
                ModelsTmp.Remove(obj);
                StateHasChanged();
            }
        }

        public void MontarMessageBox(string PreSubMensagem)
        {
            TypeMessageBox = MessageBoxType.Information;
            TitleMessageBox = "Excluir";
            TextMessageBox = $"{PreSubMensagem} {SubMensagem} ?";
            ButtomConfirmMessageBox = "Sim";
            ButtomCancelMessageBox = "Não";

            StateHasChanged();
        }
        #endregion

        #endregion
    }

}
