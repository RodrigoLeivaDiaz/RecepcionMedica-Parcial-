using System.ComponentModel.DataAnnotations;

namespace RecepcionMedica.Models;

    public class Medico
    {
        public int Id { get; set; }
    
        public string? NombreCompleto { get; set; }

        public int Edad { get; set; }

        public int Calificacion { get; set; }

<<<<<<< HEAD
        public int EspecialidadId { get; set; } // Required foreign key property
        public Especialidad? Especialidad { get; set; } // Required reference navigation to principal

        public ICollection<Paciente> Pacientes { get; } = new List<Paciente>();
=======

          public int EspecialidadId { get; set; } // Required foreign key property
          [Display(Name = "Especialidad")]
        public Especialidad? Especialidad { get; set; } // Required reference navigation to principal

        public ICollection<Paciente> Pacientes { get; } = new List<Paciente>();

        public string? Profesión => Especialidad?.NombreEspecialidad;
>>>>>>> 5d9bbaa6d9f93df87766794fe5648c83a0e1a581
    }