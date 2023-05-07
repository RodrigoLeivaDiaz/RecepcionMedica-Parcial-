namespace RecepcionMedica.Models;

    public class Especialidad
    {
        public int Id { get; set; }
    
        public string? NombreEspecialidad { get; set; }

        public ICollection<Medico> Medicos { get; } = new List<Medico>();

    }