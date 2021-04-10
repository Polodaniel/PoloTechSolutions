using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IBaseView
    {
        int Id { get; set; }
        string Descricao { get; set; }
        bool Status { get; set; }
    }
}
