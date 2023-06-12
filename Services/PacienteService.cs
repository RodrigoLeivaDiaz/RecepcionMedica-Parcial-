using RecepcionMedica.Data;
using RecepcionMedica.Models;
using Microsoft.EntityFrameworkCore;

namespace RecepcionMedica.Services;

public class PacienteService : IPacienteService
{
    private readonly MvcMedicoContext _MvcMedicoContext;

    public PacienteService(MvcMedicoContext context)
    {
        _MvcMedicoContext = context;
    }

    public void Create(Paciente obj)
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
    public List<Paciente> GetAll()
    {
        var query = GetQuery();
        return query.ToList();
    }

    public List<Paciente> GetAll(string filter)
    {
        var query = GetQuery();

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.NombreCompleto.Contains(filter));
        }

        return query.ToList();
    }

    public Paciente? GetById(int id)
    {

        var paciente = GetQuery()
                .Include(x=> x.NombreCompleto)
                .FirstOrDefault(m => m.Id == id);

        return paciente;
    }

    public void Update(Paciente obj)
    {
        _MvcMedicoContext.Update(obj);
        _MvcMedicoContext.SaveChanges();
    }

    private IQueryable<Paciente> GetQuery()
    {
        return from Paciente in _MvcMedicoContext.Paciente select Paciente;
    }
}