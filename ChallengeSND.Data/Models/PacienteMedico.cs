using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSND.Data.Models
{
    public class PacienteMedico
    {
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
    }
}
