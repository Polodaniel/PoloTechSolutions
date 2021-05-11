using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Cadastros;
using Models.View;
using Models.View.Desktop;
using PontoEletronicoWeb.Server.Data;
using PontoEletronicoWeb.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Repository
{
    #region Interfaces
    public interface IFuncionarioRepository : ICadastroBase<Funcionario, FuncionarioView>
    {
        Task<List<FuncionarioViewDesktop>> GetFuncionariosViewDesktop(bool? ativos);
    }
    #endregion

    public class FuncionarioRepository : BaseRepository<Funcionario, FuncionarioView>, IFuncionarioRepository
    {
        #region Construtor
        public FuncionarioRepository(ApplicationDbContext context) : base(context)
        {

        }
        #endregion

        public async Task<List<FuncionarioViewDesktop>> GetFuncionariosViewDesktop(bool? ativos)
        {
            var queryFunc = dbSetAsQueryable.Include(x => x.Biometrias).AsQueryable();

            if (ativos != null)
                queryFunc = queryFunc.Where(x => x.Status == ativos);

            return await queryFunc.Select(x =>
                                          new FuncionarioViewDesktop
                                          {
                                              Id = x.Id,
                                              Nome = x.Nome,
                                              PossuiBiometria = x.PossuiBiometria,
                                              Status = x.Status,
                                              Biometrias = x.Biometrias
                                          }).ToListAsync();
        }

    }
}
