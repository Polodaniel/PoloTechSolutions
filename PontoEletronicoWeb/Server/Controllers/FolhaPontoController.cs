using Microsoft.AspNetCore.Http;
using Models.Ponto;
using Models.View.Ponto;
using PontoEletronicoWeb.Server.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Controllers
{
    public class FolhaPontoController : BaseControllerCrud<FolhaPonto,FolhaPontoView>
    {
        #region Construtor
        public FolhaPontoController(IHttpContextAccessor accessor, IFolhaPontoRepository folhaPonto): base(accessor,folhaPonto)
        {

        }
        #endregion
    }
}
