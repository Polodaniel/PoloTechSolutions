using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using PontoEletronicoWeb.Server.Models;
using System;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Attributes
{

    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {    
       

        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {

            #region Verifirica se possui alguma chave
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKey.ApiKeyName, out var extractedApiKey))
            {
                // Não encontrou
                context.Result = new ContentResult()
                {
                    //401 - Unauthorized
                    StatusCode = 401,
                    Content = "ApiKey não encontrada"
                };
                return;
            }
            #endregion

            #region Verifica se a chave é valida
            if (!ApiKey.Key.Equals(extractedApiKey))
            {
                //Não é valida
                context.Result = new ContentResult()
                {
                    //403 - Forbidden
                    StatusCode = 403,
                    Content = "Acesso não autorizado"
                };
                return;
            }
            #endregion

            await next();
        }
    }
}
