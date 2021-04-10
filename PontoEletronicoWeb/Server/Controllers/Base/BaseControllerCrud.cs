using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Interfaces;
using PontoEletronicoWeb.Server.Interfaces;
using PontoEletronicoWeb.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Controllers
{
    public class BaseControllerCrud<TModel, TView> : BaseController, ICrudRequisicoes<TModel, TView>
         where TModel : BaseModelDominio, IDominio<TModel>, ISelectView<TView>
         where TView : IBaseView
    {
        #region Atributos
        protected ICadastroBase<TModel, TView> _repositorio { get; set; }
        #endregion

        #region Construtor
        public BaseControllerCrud(IHttpContextAccessor contextAccessor, ICadastroBase<TModel,TView> repositorio) : base(contextAccessor)
        {
            _repositorio = repositorio;
        }
        #endregion

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _repositorio.ExcluirAsync(id,0));
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu erro ao Listar. \n {ex.Message}");
            }
        }

        //{Controler}/id
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                return Ok( await _repositorio.SelecionarAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu erro ao selecionar o Item. \n {ex.Message}");
            }
        }

        //api/{Controller}?ativos=false
        [HttpGet]
        public async Task<ActionResult<List<TView>>> Get(bool? ativo)
        {
            try
            {
                return Ok(await _repositorio.ListarAsync(ativo));
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu erro ao Listar. \n {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TModel objeto)
        {
            try
            {

                if (ModelState.IsValid)
                    return Ok(await _repositorio.SalvarAsync(objeto,0));
                else
                    return BadRequest(ModelState.Values
                        .SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage)
                        .ToList()
                        .Aggregate((x, y) => x + "; " + y));

            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu erro ao atualizar  item. \n {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] TModel objeto)
        {
            try
            {

                if (ModelState.IsValid)
                    return Ok(await _repositorio.AlterarAsync(objeto, 0));
                else
                    return BadRequest(ModelState.Values
                        .SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage)
                        .ToList()
                        .Aggregate((x, y) => x + "; " + y));

            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu erro ao Salvar  item. \n {ex.Message}");
            }
        }       

    }
}
