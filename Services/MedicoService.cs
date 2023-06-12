using RecepcionMedica.Data;
using RecepcionMedica.Models;
using Microsoft.EntityFrameworkCore;

namespace RecepcionMedica.Services;

public class MedicoService : IMedicoService
{
    private readonly MvcMedicoContext _MvcMedicoContext;

    public MedicoService(MvcMedicoContext context)
    {
        _MvcMedicoContext = context;
    }

    public void Create(Medico obj)
    {
        _MvcMedicoContext.Add(obj);
        _MvcMedicoContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var obj = GetById(id);
        
        if (obj != null){
            _MvcMedicoContext.Remove(obj);
            _MvcMedicoContext.SaveChanges();
        }
    }
    public List<Medico> GetAll()
    {
        var query = GetQuery();
        return query.ToList();
    }

    public List<Medico> GetAll(string filter)
    {
        var query = GetQuery();

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.NombreCompleto.Contains(filter));
        }

        return query.ToList();
    }

    public Medico? GetById(int id)
    {

        var medico = GetQuery()
                .Include(x=> x.NombreCompleto)
                .FirstOrDefault(m => m.Id == id);

        return medico;
    }

    public void Update(Medico obj)
    {
        _MvcMedicoContext.Update(obj);
        _MvcMedicoContext.SaveChanges();
    }

    private IQueryable<Medico> GetQuery()
    {
        return from Medico in _MvcMedicoContext.Medico select Medico;
    }
}