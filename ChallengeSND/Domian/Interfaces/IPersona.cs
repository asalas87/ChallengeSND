using ChallengeSND.Domian.Interfaces;
using ChallengeSND.Domian.Entities;

namespace ChallengeSND.Domian.Interfaces
{
    public interface IPersona
    {


        Persona GetById(int id);
        IEnumerable<Persona> GetAll();
        void Add(Persona persona);
        void Update(Persona persona);
        void Delete(int id);
    }
}

