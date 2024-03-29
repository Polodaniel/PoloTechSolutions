﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models.View
{
    public class TurnoView : BaseView
    {
        public string Nome { get; set; }
        public bool PossuiBiometria { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraioFim { get; set; }
        public bool PerNoite { get; set; }

        public string HoraInicioString
        {
            get => HoraInicio.ToShortTimeString();
        }

        public string HoraFimString
        {
            get => HoraioFim.ToShortTimeString();
        }

        public string PerNoiteString
        {
            get => PerNoite ? "Sim" : "Não";
        }
    }
}
