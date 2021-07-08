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
    public interface IClienteRepository : ICadastroBase<Cliente, ClienteView>
    {
        Task<List<ClienteViewDesktop>> GetClienteViewDesktop(bool? ativos);
    }
    #endregion

    public class ClienteRepository : BaseRepository<Cliente, ClienteView>, IClienteRepository
    {
        #region Construtor
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {

        }
        #endregion

        public async Task<List<ClienteViewDesktop>> GetClienteViewDesktop(bool? ativos)
        {
            var query = dbSetAsQueryable.AsQueryable();

            if (ativos != null)
                query = query.Where(x => x.Status == ativos);

            return await query.Select(x =>
                   new ClienteViewDesktop
                   {
                       Id = x.Id,
                       Nome = x.Nome,
                       Cep = x.Cep,
                       Logadouro = x.Logadouro,
                       Numero = x.Numero,
                       Bairro = x.Bairro,
                       Cidade = x.Cidade,
                       Pais = x.Pais,
                       Status = x.Status
                   }).ToListAsync();
        }
    }
}
