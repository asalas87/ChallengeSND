﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSND.Data.Models
{
   
        public class Medico : Persona
        {
            public string Especialidad { get; set; }
            public bool ConTurnosDisponibles { get; set; }
            public List<PacienteMedico> PacientesMedicos { get; set; } = new List<PacienteMedico>();
        }
    



}
