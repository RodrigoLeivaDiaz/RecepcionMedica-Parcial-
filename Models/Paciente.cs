namespace RecepcionMedica.Models;

    public class Paciente
    {
        public int Id { get; set; }
    
        public string NombreCompleto { get; set; }

        public string Sexo { get; set; }

        public string ObraSocial { get; set; }

        public int Edad { get; set; }

        public int telefono { get; set; }
    }