using ChallengeSND.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSND.Data.Repositories
{
    public class MedicoRepository : Repository<Medico>
    {
        public MedicoRepository(DataContext context) : base(context) { }

        public IEnumerable<Medico> GetMedicosByEspecialidad(string especialidad)
        {
            return _context.Medicos.Where(m => m.Especialidad == especialidad).ToList();
        }
    }

}
