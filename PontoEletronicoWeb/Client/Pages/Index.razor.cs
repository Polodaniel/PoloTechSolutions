using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Client.Pages
{
    [Authorize]
    public class IndexBase : ComponentBase
    {
    }
}
