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
    public class FuncionarioController : BaseControllerCrud<Funcionario, FuncionarioView>
    {
        #region Construtor
        public FuncionarioController(IHttpContextAccessor accessor,IFuncionarioRepository repository) : base(accessor,repository)
        {

        }
        #endregion
    }
}
