using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Interfaces
{
    public interface ICrudRequisicoes<TModel, TView>
    {
        
        Task<ActionResult> Post([FromBody] TModel objeto);
              
        Task<ActionResult> Put([FromBody] TModel objeto);

        Task<ActionResult> Get(int id);

        Task<ActionResult<List<TView>>> Get(bool? ativo);    

        Task<ActionResult> Delete(int id);
    }
}
