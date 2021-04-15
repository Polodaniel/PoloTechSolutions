using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Client.Shared.Componentes
{
    public class CardBase : ComponentBase
    {
        [Parameter]
        public string ID { get; set; } = "Card";

        [Parameter]
        public string Position { get; set; } = "left";

        [Parameter]
        public string Size { get; set; } = ".25rem";

        [Parameter]
        public string Cor { get; set; } = "#4682B4";

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }

}
