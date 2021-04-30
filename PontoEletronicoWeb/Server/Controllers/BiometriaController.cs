using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ModelView;
using PontoEletronicoWeb.Server.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/desktop/[controller]")]
    public class BiometriaController: ControllerBase
    {
        #region Atributos
        private IHttpContextAccessor contextAccessor;
        
        #endregion

        #region Construtor
        public BiometriaController(IHttpContextAccessor contextAccessor) =>
            this.contextAccessor = contextAccessor;
        #endregion

        [AllowAnonymous]
        [HttpPost("autentica")]
        public async Task<ActionResult<dynamic>> Autentica(Autentifica aut)
        {
            try
            {
                //var user = UserRepository.Get(model.Username, model.Password);

                if (aut == null)
                    return NotFound(new { message = "Usuário ou senha inválidos" });

                var token = TokenService.GenerateToken(aut);

                var retorno = new
                {
                    aut = aut,
                    token = token
                };

                return await Task.FromResult(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu erro ao Listar. \n {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpGet("autentica")]
        public async Task<ActionResult<dynamic>> TESTE()
        {
            try
            {
            
                return await Task.FromResult(new Autentifica() { KeyIndentidade = 123456, Empresa = "Teste"});
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu erro ao Listar. \n {ex.Message}");
            }
        }

        [HttpGet("Autorizado")]
        public async Task<ActionResult<dynamic>> TESTE2()
        {
            try
            {
                return await Task.FromResult("Autorizado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu erro ao Listar. \n {ex.Message}");
            }
        }
    }
}
