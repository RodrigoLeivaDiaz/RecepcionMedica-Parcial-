namespace RecepcionMedica.Models;

    public class Paciente
    {
        public int Id { get; set; }
    
        public string? NombreCompleto { get; set; }

<<<<<<< HEAD
        public string? Sexo { get; set; }
=======
        public SexoEnum Sexo { get; set; }
>>>>>>> 5d9bbaa6d9f93df87766794fe5648c83a0e1a581

        public string? ObraSocial { get; set; }

        public int Edad { get; set; }

        public int telefono { get; set; }

        public int MedicoId { get; set; } // Required foreign key property
        public Medico? Medico { get; set; } // Required reference navigation to principal
<<<<<<< HEAD
=======

        public string? MedicoTratante => Medico?.NombreCompleto;
>>>>>>> 5d9bbaa6d9f93df87766794fe5648c83a0e1a581
    }