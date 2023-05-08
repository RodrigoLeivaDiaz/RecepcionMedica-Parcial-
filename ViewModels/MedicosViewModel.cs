using RecepcionMedica.Models;

namespace recepcionMedica.ViewModels;

public class MedicosViewModel 
{

  public int Id { get; set; }
  public string? NombreCompleto { get; set; }

          public int Edad { get; set; }

        public int Calificacion { get; set; }

      public string? Profesion { get; set; }

      public ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();

}