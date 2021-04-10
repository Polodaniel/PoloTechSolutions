using Models.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface ISelectView<TView> where TView : IBaseView
    {
        TView SelectView();
    }
}
