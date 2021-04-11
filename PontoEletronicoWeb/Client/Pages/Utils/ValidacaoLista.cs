using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Client.Pages.Utils
{
    public class ValidacaoLista
    {
        public static class ValidacaoList
        {
            public static bool ListaValida<T>(List<T> Lista) =>
                Lista != null && Lista.Count > 0;
        }

    }
}
