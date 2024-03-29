﻿using Models.Interfaces;
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

        public string CodigoString
        {
            get => Id.ToString().PadLeft(4, '0');
        }

        public string Situacao
        {
            get => Status ? "Ativado" : "Desativado";
        }
    }
}
