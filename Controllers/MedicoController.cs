using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecepcionMedica.Data;
using RecepcionMedica.Models;
using recepcionMedica.ViewModels;

namespace RecepcionMedica.Controllers
{
    public class MedicoController : Controller
    {
        private readonly MvcMedicoContext _context;

        public MedicoController(MvcMedicoContext context)
        {
            _context = context;
        }

        // GET: Medico

        public async Task<IActionResult> Index(string NameFilter)
        {
            try
            {
            var query = from Medico in _context.Medico.Include(p => p.Especialidad) select Medico;

            if (!string.IsNullOrEmpty(NameFilter)) {
                query = query.Where(x => x.NombreCompleto.ToLower().Contains(NameFilter.ToLower()) ||
                x.Especialidad.NombreEspecialidad.ToLower().Contains(NameFilter.ToLower()) ||
                x.Edad.ToString() == NameFilter ||
                x.Calificacion.ToString() == NameFilter);
            }

            var model =new MedicoViewModel();

            model.Medicos = await query.ToListAsync();

            return View(model);

            }
              catch(Exception ex) {

              return View("Error");
              }
          {
        }
        }

        // GET: Medico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medico == null)
            {
                return NotFound();
            }

            var medico = await _context.Medico
                .Include(m => m.Especialidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medico == null)
            {
                return NotFound();
            }
            var query = from Paciente in _context.Paciente.Include(p => p.Medico) where Paciente.MedicoId == id select Paciente;

            var viewModel = new MedicosViewModel();

            viewModel.NombreCompleto = medico.NombreCompleto;
            viewModel.Edad = medico.Edad;
            viewModel.Calificacion = medico.Calificacion;
            viewModel.Profesion = medico.Profesión;
            viewModel.Pacientes = await query.ToListAsync();
            viewModel.Id = medico.Id;

            return View(viewModel);
        }

        // GET: Medico/Create
        public IActionResult Create()
        {
            //ViewData["EspecialidadId"] = new SelectList(_context.Especialidad, "Id", "Id");
            ViewData["Profesión"] = new SelectList(_context.Especialidad, "Id", "NombreEspecialidad");

            return View();
        }

        // POST: Medico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreCompleto,Edad,Calificacion,EspecialidadId,Profesión")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidad, "Id", "Id", medico.EspecialidadId);
            return View(medico);
        }

        // GET: Medico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medico == null)
            {
                return NotFound();
            }

            var medico = await _context.Medico.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }
            ViewData["Profesión"] = new SelectList(_context.Especialidad, "Id", "NombreEspecialidad");
            return View(medico);
        }

        // POST: Medico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreCompleto,Edad,Calificacion,EspecialidadId")] Medico medico)
        {
            if (id != medico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicoExists(medico.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidad, "Id", "Id", medico.EspecialidadId);
            return View(medico);
        }

        // GET: Medico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medico == null)
            {
                return NotFound();
            }

            var medico = await _context.Medico
                .Include(m => m.Especialidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medico == null)
            {
                return NotFound();
            }
            
            return View(medico);
        }

        // POST: Medico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medico == null)
            {
                return Problem("Entity set 'MvcMedicoContext.Medico'  is null.");
            }
            var medico = await _context.Medico.FindAsync(id);
            if (medico != null)
            {
                _context.Medico.Remove(medico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicoExists(int id)
        {
          return (_context.Medico?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
