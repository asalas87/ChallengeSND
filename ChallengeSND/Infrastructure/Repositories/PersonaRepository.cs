using ChallengeSND.Domian.Entities;
using ChallengeSND.Domian.Interfaces;
using ChallengeSND.Infrastructure.Data;

namespace ChallengeSND.Infrastructure.Repositories
{
    public class PersonaRepository : IPersona
    {
        private readonly ChallengeDbContext _context;

        public PersonaRepository(ChallengeDbContext context)
        {
            _context = context;
        }

        public Persona GetById(int id)
        {
            return _context.Personas.Find(id);
        }

        public IEnumerable<Persona> GetAll()
        {
            return _context.Personas.ToList();
        }

        public void Add(Persona persona)
        {
            _context.Personas.Add(persona);
            _context.SaveChanges();
        }

        public void Update(Persona persona)
        {
            _context.Personas.Update(persona);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var persona = _context.Personas.Find(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                _context.SaveChanges();
            }
        }
    }
}
