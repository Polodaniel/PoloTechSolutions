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
    }
}
