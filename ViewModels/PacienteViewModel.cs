using RecepcionMedica.Models;

namespace recepcionMedica.ViewModels;

public class PacienteViewModel
{
    public List<Paciente> Pacientes { get; set;} = new List<Paciente>{};

    public string? NameFilter { get; set;}

}