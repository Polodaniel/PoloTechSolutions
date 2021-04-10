using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IDominio<TModel> where TModel : BaseModelDominio
    {
        void Update(TModel Model, int usuarioId);
        TModel GetModel();
    }
}
