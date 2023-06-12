using RecepcionMedica.Data;
using RecepcionMedica.Models;
using Microsoft.EntityFrameworkCore;

namespace RecepcionMedica.Services;

public class EspecialidadService : IEspecialidadService
{
    private readonly MvcMedicoContext _MvcMedicoContext;

    public EspecialidadService(MvcMedicoContext context)
    {
        _MvcMedicoContext = context;
    }

    public void Create(Especialidad obj)
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
    public List<Especialidad> GetAll()
    {
        var query = GetQuery();
        return query.ToList();
    }

    public List<Especialidad> GetAll(string filter)
    {
        var query = GetQuery();

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.NombreEspecialidad.Contains(filter));
        }

        return query.ToList();
    }

    public Especialidad? GetById(int id)
    {

        var medicos = GetQuery()
                .Include(x=> x.Medicos)
                .FirstOrDefault(m => m.Id == id);

        return medicos;
    }

    public void Update(Especialidad obj)
    {
        _MvcMedicoContext.Update(obj);
        _MvcMedicoContext.SaveChanges();
    }

    private IQueryable<Especialidad> GetQuery()
    {
        return from Especialidad in _MvcMedicoContext.Especialidad select Especialidad;
    }
}