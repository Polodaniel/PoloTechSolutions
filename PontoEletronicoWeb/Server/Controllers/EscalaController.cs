using Microsoft.AspNetCore.Http;
using Models.Ponto;
using Models.View;
using PontoEletronicoWeb.Server.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Controllers
{
    public class EscalaController : BaseControllerCrud<Escala,EscalaView>
    {
        #region Construtor
        public EscalaController(IHttpContextAccessor accessor,IEscalaRepository repository) : base(accessor, repository)
        {

        }
        #endregion
    }
}
