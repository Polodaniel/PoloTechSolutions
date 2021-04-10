using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Client.Shared.Componentes
{
    public class PageConsultaBase : ComponentBase
    {
        [Parameter]
        public bool DescTipoBotao { get; set; } = true;

        [Parameter]
        public string NomeTela { get; set; }

        [Parameter]
        public string RotaHome { get; set; }

    }
}
