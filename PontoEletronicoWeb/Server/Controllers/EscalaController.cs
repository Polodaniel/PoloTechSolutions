using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Ponto;
using Models.View;
using PontoEletronicoWeb.Server.Repository;
using PontoEletronicoWeb.Shared.Auxiliares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Controllers
{
    public class EscalaController : BaseControllerCrud<Escala,EscalaView>
    {
        #region Atributos
        private readonly IEscalaRepository EscalaRepository;
        #endregion

        #region Construtor
        public EscalaController(IHttpContextAccessor accessor,IEscalaRepository repository) : base(accessor, repository)
        {
            _repositorio = this.EscalaRepository = repository;
        }
        #endregion

        //{Controler}/filtro
        [HttpPost("filtro")]
        public async virtual Task<ActionResult> RetornaListaViewFiltro([FromBody] FiltroEscala filtro)
        {
            try
            {
                var result = await EscalaRepository.RetornaListViewEscala(filtro);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu ao selecionar item. \n {ex.Message}");
            }
        }

        [HttpGet("EscalaFuncionario/{id}")]
        public async virtual Task<ActionResult> EscalaFuncionario(int id)
        {
            try
            {
                var result = await EscalaRepository.RetornaEscalaFuncionario(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu ao selecionar item. \n {ex.Message}");
            }
        }

    }
}
