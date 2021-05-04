using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ModelView;
using Models.View.Desktop;
using PontoEletronicoWeb.Server.Attributes;
using PontoEletronicoWeb.Server.Repository;
using PontoEletronicoWeb.Server.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Controllers
{

    [ApiKey]
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

        #region Teste Autentica    
        [HttpGet("teste")]
        public async Task<ActionResult<dynamic>> TESTE()
        {
            try
            {
                //new Autentifica() { KeyIndentidade = 123456, Empresa = "Teste" }

                return await Task.FromResult(new VerificaBiometriaModelView());
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu erro ao Listar. \n {ex.Message}");
            }
        }       
        #endregion

        #region  Rotas DeskTop
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

        [HttpPost("funcionario")]
        public async Task<ActionResult<dynamic>> PostSalvarBiometrias([FromServices] IBiometriaRepository biometriaRepository, FuncionarioBiometrias funcionarioBiometrias)
        {
            try
            {
                return await Task.FromResult(biometriaRepository.SalvarAsync(funcionarioBiometrias));
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu erro ao Listar. \n {ex.Message}");
            }
        }

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

        [HttpPost("verifica/biometria")]
        public async Task<ActionResult<bool>> GetFuncionariosView([FromServices] IFolhaPontoRepository folhaPontoRepository, VerificaBiometriaModelView biometriaModelView)
        {
            try
            {
                return await folhaPontoRepository.VerificaBiometria(biometriaModelView);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu erro ao Listar. \n {ex.Message}");
            }
        }
        #endregion

    }
}
