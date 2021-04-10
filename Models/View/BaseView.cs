using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.View
{
    public class BaseView : IBaseView
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }
    }
}
