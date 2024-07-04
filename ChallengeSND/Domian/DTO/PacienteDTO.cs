namespace ChallengeSND.Domian.DTO
{
    public class PacienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string ClasificacionEdad { get; set; }
    }
}
