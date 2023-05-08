namespace RecepcionMedica.Models;

    public class Paciente
    {
        public int Id { get; set; }
    
        public string? NombreCompleto { get; set; }

        public string? Sexo { get; set; }

        public string? ObraSocial { get; set; }

        public int Edad { get; set; }

        public int telefono { get; set; }

        public int MedicoId { get; set; } // Required foreign key property
        public Medico? Medico { get; set; } // Required reference navigation to principal

        public string? MedicoTratante => Medico?.NombreCompleto;
    }