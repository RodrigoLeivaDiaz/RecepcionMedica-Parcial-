namespace RecepcionMedica.Models;

    public class Medico
    {
        public int Id { get; set; }
    
        public string? NombreCompleto { get; set; }

        public int Edad { get; set; }

        public int Calificacion { get; set; }

        public int EspecialidadId { get; set; } // Required foreign key property
        public Especialidad? Especialidad { get; set; } // Required reference navigation to principal

        public ICollection<Paciente> Pacientes { get; } = new List<Paciente>();

        public string? Profesión => Especialidad?.NombreEspecialidad;
    }