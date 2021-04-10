using Microsoft.AspNetCore.Http;
using Models.Cadastros;
using Models.View;
using PontoEletronicoWeb.Server.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Controllers
{
    public class TurnoController : BaseControllerCrud<Turno, TurnoView>
    {
        #region Construtor
        public TurnoController(IHttpContextAccessor accessor, ITurnoRepository repository): base(accessor, repository)
        {

        }
        #endregion
    }
}
