using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        #region Atributos
        private IHttpContextAccessor contextAccessor;
        #endregion

        #region Construtor
        public BaseController(IHttpContextAccessor contextAccessor) =>
            this.contextAccessor = contextAccessor;
        #endregion
    }
}
