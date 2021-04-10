using Microsoft.EntityFrameworkCore;
using Models;
using Models.Interfaces;
using Models.View;
using PontoEletronicoWeb.Server.Data;
using PontoEletronicoWeb.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Repository
{
    public class BaseRepository<TModel, TView> : BaseModel, ICadastroBase<TModel, TView> 
        where TModel : BaseModelDominio, IDominio<TModel> ,ISelectView<TView> 
        where TView  : IBaseView
    {
        #region Atributos
        private ApplicationDbContext _contexto1;
        protected DbSet<TModel> dbSet;
        protected IQueryable<TModel> dbSetAsQueryable;
        protected ApplicationDbContext contexto
        {
            get => _contexto1;

            set
            {
                _contexto1 = value;
                dbSet = _contexto1.Set<TModel>();
                dbSetAsQueryable = dbSet.AsQueryable();
            }
        }
        #endregion

        #region Construtor
        public BaseRepository(ApplicationDbContext context)
        {
            contexto = context;
        }
        #endregion

        #region Metodos Crud Async
        public async virtual Task<TModel> AlterarAsync(TModel objeto, int usuarioId)
        {
            objeto.IsValid();

            var entidade = await dbSet.FindAsync(objeto.Id);

            IsNull(entidade);

            entidade.Update(objeto, usuarioId);

            await contexto.SaveChangesAsync();

            return objeto;
        }

        public async virtual Task<bool> ExcluirAsync(int codigo, int usuarioLogado)
        {
            var _retorno = false;

            var entidade = await GetEntidade(codigo);

            IsNull(entidade);

            entidade.Desativar(usuarioLogado);

            await contexto.SaveChangesAsync();

            return _retorno;
        }

        public async virtual Task<List<TView>> ListarAsync(bool? ativos)
        {
            var query = dbSetAsQueryable;

            if (ativos != null)
                query = query.Where(x => x.Status == ativos);            

            return await query.Select(x => x.SelectView()).ToListAsync();
        }

        public async virtual Task<TModel> SalvarAsync(TModel model, int usuarioLogado)
        {
            model.IsValid();

            model.RegistraAlteracao(usuarioLogado);

            var entidade = dbSet.Add(model);
            await contexto.SaveChangesAsync();

            return await Task.FromResult(entidade.Entity);
        }

        public async virtual Task<TModel> SelecionarAsync(int id)
        {
            var model = await dbSet.FindAsync(id);

            IsNull(model);

            return model;
        }
        #endregion
        
        #region Metodos Auxiliares       
        protected virtual async Task<TModel> GetEntidade(int id)
        {
            var objeto = await dbSet.FindAsync(id);
            IsNull(objeto);
            return objeto;
        }
               
        protected virtual void IsNull(TModel Entity)
        {
            if (Entity == null)
                throw new ArgumentNullException("Item inexistente!");
        }
        #endregion
    }
}
