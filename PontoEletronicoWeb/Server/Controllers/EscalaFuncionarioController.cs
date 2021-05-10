using Microsoft.AspNetCore.Http;
using Models.Ponto;
using Models.View;
using Models.View.Ponto;
using PontoEletronicoWeb.Server.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Controllers
{
    public class EscalaFuncionarioController : BaseControllerCrud<EscalaFuncionario, EscalaFuncionarioView>
    {
        #region Construtor
        public EscalaFuncionarioController(IHttpContextAccessor accessor, IEscalaFuncionarioRepository repository) : base(accessor, repository)
        {

        }
        #endregion
    }
}
