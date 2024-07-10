using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSND.Business.DTOS
{
    public class MedicoDto
    {
     
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public string Especialidad { get; set; }
            public bool ConTurnosDisponibles { get; set; }
        
    }
}