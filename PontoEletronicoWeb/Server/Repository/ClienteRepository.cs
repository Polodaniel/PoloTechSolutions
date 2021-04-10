using Models.Cadastros;
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
    public interface IClienteRepository: ICadastroBase<Cliente,ClienteView>
    {

    }
    #endregion

    public class ClienteRepository : BaseRepository<Cliente,ClienteView>, IClienteRepository
    {
        #region Construtor
        public ClienteRepository(ApplicationDbContext context): base(context)
        {

        }
        #endregion
    }
}
