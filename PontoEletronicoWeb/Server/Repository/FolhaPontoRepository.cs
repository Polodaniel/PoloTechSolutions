using Models.Ponto;
using Models.View.Ponto;
using PontoEletronicoWeb.Server.Data;
using PontoEletronicoWeb.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Repository
{
    #region Interface
    public interface IFolhaPontoRepository : ICadastroBase<FolhaPonto, FolhaPontoView>
    {

    }
    #endregion  

    public class FolhaPontoRepository: BaseRepository<FolhaPonto,FolhaPontoView>, IFolhaPontoRepository
    {
        #region Construtor
        public FolhaPontoRepository(ApplicationDbContext context) : base(context)
        {
        }
        #endregion
    }
}
