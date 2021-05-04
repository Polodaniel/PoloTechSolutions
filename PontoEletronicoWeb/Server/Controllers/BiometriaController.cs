using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ModelView;
using Models.View.Desktop;
using PontoEletronicoWeb.Server.Repository;
using PontoEletronicoWeb.Server.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/desktop/[controller]")]
    public class BiometriaController : ControllerBase
    {
        #region Atributos
        private IHttpContextAccessor contextAccessor;

        #endregion

        #region Construtor
        public BiometriaController(IHttpContextAccessor contextAccessor) =>
            this.contextAccessor = contextAccessor;
        #endregion

        #region Teste Autentica
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
                //new Autentifica() { KeyIndentidade = 123456, Empresa = "Teste" }

                return await Task.FromResult(new RegistraPonto());
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
        #endregion

        #region  Rotas DeskTop
        [AllowAnonymous]
        [HttpGet("funcionario")]
        public async Task<ActionResult<List<FuncionarioViewDesktop>>> GetFuncionariosView([FromServices] IFuncionarioRepository funcionarioRepository)
        {
            try
            {
                return await funcionarioRepository.GetFuncionariosViewDesktop(true);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu erro ao Listar. \n {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpPost("funcionario")]
        public async Task<ActionResult<bool>> PostSalvarBiometrias([FromServices] IBiometriaRepository biometriaRepository, FuncionarioBiometrias funcionarioBiometrias)
        {
            try
            {
                var result = await biometriaRepository.SalvarAsync(funcionarioBiometrias);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu erro ao Listar. \n {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpDelete("funcionario")]
        public async Task<ActionResult<dynamic>> DeleteBiometrias([FromServices] IBiometriaRepository biometriaRepository, int CodFuncionario)
        {
            try
            {
                if (CodFuncionario == 0)
                    return Forbid();

                return await Task.FromResult(biometriaRepository.ExcluirBiometriasAsync(CodFuncionario));
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu erro ao Listar. \n {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpPost("registra/ponto")]
        public async Task<ActionResult<dynamic>> PostRegistraPonto([FromServices] IFolhaPontoRepository folhaPontoRepository, RegistraPonto registro)
        {
            try
            {
                if (registro == null)
                    return Forbid();

                return await Task.FromResult(folhaPontoRepository.RegistraPonto(registro));
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu erro ao Listar. \n {ex.Message}");
            }
        }
        #endregion

    }
}
