using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Client.Shared.Componentes
{
    public class SubMenuSuperiorBase : ComponentBase
    {
        #region Propriedades
        protected string DataAtual { get; set; }
        #endregion

        #region Contrutor
        public SubMenuSuperiorBase() =>
            DataAtual = DateTime.Now.ToLongDateString();
        #endregion
    }
}
