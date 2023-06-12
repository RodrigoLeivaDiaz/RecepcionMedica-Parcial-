using RecepcionMedica.Models;

namespace RecepcionMedica.Services;

public interface IMedicoService
{
    void Create(Medico obj);
    List<Medico> GetAll(string filter);
    List<Medico> GetAll();
    void Update(Medico obj);
    void Delete(int id);
    Medico? GetById(int id);

}