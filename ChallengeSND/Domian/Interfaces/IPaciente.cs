using ChallengeSND.Domian.Entities;

namespace ChallengeSND.Domian.Interfaces
{
    public interface IPaciente
    {
        IEnumerable<Paciente> GetPacientesByClasificacionEdad(string clasificacionEdad);
    }
}
