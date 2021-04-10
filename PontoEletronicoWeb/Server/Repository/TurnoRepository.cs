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
    public interface ITurnoRepository : ICadastroBase<Turno, TurnoView>
    {

    }
    #endregion

    public class TurnoRepository : BaseRepository<Turno,TurnoView>, ITurnoRepository
    {
        #region Construtor
        public TurnoRepository(ApplicationDbContext context): base(context)
        {

        }
        #endregion
    }
}
