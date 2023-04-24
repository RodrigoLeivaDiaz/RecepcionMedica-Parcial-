namespace RecepcionMedica.Models;

    public class Medico
    {
        public int Id { get; set; }
    
        public string NombreCompleto { get; set; }

        public string Especialidad { get; set; }

        public int Edad { get; set; }

        public int Calificacion { get; set; }
    }