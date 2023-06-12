using RecepcionMedica.Models;

namespace RecepcionMedica.Services;

public interface IEspecialidadService
{
    void Create(Especialidad obj);
    List<Especialidad> GetAll(string filter);
    List<Especialidad> GetAll();
    void Update(Especialidad obj);
    void Delete(int id);
    Especialidad? GetById(int id);

}