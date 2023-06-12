using RecepcionMedica.Models;

namespace recepcionMedica.ViewModels;

public class MedicoViewModel
{
    public List<Medico> Medicos { get; set;} = new List<Medico>{};

    public string? NameFilter { get; set;}

}