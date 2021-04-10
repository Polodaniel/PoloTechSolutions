using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Cadastros;
using Models.View;
using PontoEletronicoWeb.Server.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Controllers
{
    public class ClienteController : BaseControllerCrud<Cliente,ClienteView>
    {
        #region Contrutor
        public ClienteController(IHttpContextAccessor accessor, IClienteRepository repository):base(accessor, repository)
        {

        }
        #endregion

        //{Controler}/id
        [HttpGet("teste")]
        public async Task<ActionResult> teste()
        {
            try
            {
                var teste = new Cliente();

                return Ok(teste);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu erro ao selecionar o Item. \n {ex.Message}");
            }
        }
    }
}
