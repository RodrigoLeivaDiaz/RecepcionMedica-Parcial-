using RecepcionMedica.Models;

namespace recepcionMedica.ViewModels;

public class EspecialidadesViewModel 
{

     public int Id { get; set; }
    
     public string? Especialidad { get; set; }

    public ICollection<Medico> Medicos { get; set; } = new List<Medico>();

}