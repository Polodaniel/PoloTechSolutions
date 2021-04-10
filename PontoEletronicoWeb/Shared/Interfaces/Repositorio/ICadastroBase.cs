using Models;
using Models.Interfaces;
using Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Shared.Interfaces
{
    public interface ICadastroBase<TModel, TView> where TModel : BaseModelDominio, IDominio<TModel>, ISelectView<TView>
                                                 where TView : IBaseView
    {
        Task<TModel> SalvarAsync(TModel model, int usuarioLogado);
        Task<TModel> AlterarAsync(TModel objeto, int usuarioId);
        Task<bool> ExcluirAsync(int codigo, int usuarioLogado);
        Task<List<TView>> ListarAsync(bool? ativos);
        Task<TModel> SelecionarAsync(int id);
    }
}
