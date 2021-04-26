using Microsoft.EntityFrameworkCore;
using Models.Ponto;
using Models.View;
using PontoEletronicoWeb.Server.Data;
using PontoEletronicoWeb.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Repository
{
    #region Interfaces
    public interface IEscalaRepository : ICadastroBase<Escala, EscalaView>
    {

    }
    #endregion

    public class EscalaRepository : BaseRepository<Escala,EscalaView>, IEscalaRepository
    {
        #region Construtor
        public EscalaRepository(ApplicationDbContext context):base(context)
        {
        }
        #endregion

        #region Metodos override
        public async override Task<Escala> SalvarAsync(Escala model, int usuarioLogado)
        {
            model.IsValid();

            model.RegistraAlteracao(usuarioLogado);

            var entidade = dbSet.Add(model);
            await contexto.SaveChangesAsync();

            return await Task.FromResult(entidade.Entity);
        }

        public async override Task<Escala> AlterarAsync(Escala objeto, int usuarioId)
        {
            objeto.IsValid();

            var entidade = await dbSet.Include(x => x.Funcionarios).FirstAsync(x => x.Id == objeto.Id);
            IsNull(entidade);

            entidade.Update(objeto, usuarioId);

            #region Atualiza Funcionarios
            var funcionariosAtualizar = entidade.Funcionarios;

            foreach (var funcionario in objeto.Funcionarios)
            {
                var funcAt = funcionariosAtualizar.FirstOrDefault(x => x.Id == funcionario.Id);

                if (funcAt == null)
                {
                    funcionario.RegistraAlteracao(usuarioId);
                    entidade.Funcionarios.Add(funcionario);
                }
                else
                    funcAt.Update(funcionario, usuarioId);
            }
            #endregion

            await contexto.SaveChangesAsync();

            return objeto;
        }
        #endregion
    }
}
