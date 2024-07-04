using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSND.Data.Models
{
    public class Paciente : Persona
    {
        public string ClasificacionEdad { get; set; } 
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
    }

}
