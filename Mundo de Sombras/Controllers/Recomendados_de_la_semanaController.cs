using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mundo_de_Sombras.Data;
using Mundo_de_Sombras.Models;

namespace Mundo_de_Sombras.Controllers
{
    public class Recomendados_de_la_semanaController : Controller
    {
        private readonly Mundo_de_SombrasContext _context;

        public Recomendados_de_la_semanaController(Mundo_de_SombrasContext context)
        {
            _context = context;
        }

        // GET: Recomendados_de_la_semana
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recomendados_de_la_semana.ToListAsync());
        }

        // GET: Recomendados_de_la_semana/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recomendados_de_la_semana = await _context.Recomendados_de_la_semana
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recomendados_de_la_semana == null)
            {
                return NotFound();
            }

            return View(recomendados_de_la_semana);
        }

        // GET: Recomendados_de_la_semana/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recomendados_de_la_semana/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Terror,Sobrenatural,Ficcion")] Recomendados_de_la_semana recomendados_de_la_semana)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recomendados_de_la_semana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recomendados_de_la_semana);
        }

        // GET: Recomendados_de_la_semana/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recomendados_de_la_semana = await _context.Recomendados_de_la_semana.FindAsync(id);
            if (recomendados_de_la_semana == null)
            {
                return NotFound();
            }
            return View(recomendados_de_la_semana);
        }

        // POST: Recomendados_de_la_semana/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Terror,Sobrenatural,Ficcion")] Recomendados_de_la_semana recomendados_de_la_semana)
        {
            if (id != recomendados_de_la_semana.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recomendados_de_la_semana);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Recomendados_de_la_semanaExists(recomendados_de_la_semana.Id))
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
            return View(recomendados_de_la_semana);
        }

        // GET: Recomendados_de_la_semana/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recomendados_de_la_semana = await _context.Recomendados_de_la_semana
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recomendados_de_la_semana == null)
            {
                return NotFound();
            }

            return View(recomendados_de_la_semana);
        }

        // POST: Recomendados_de_la_semana/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recomendados_de_la_semana = await _context.Recomendados_de_la_semana.FindAsync(id);
            _context.Recomendados_de_la_semana.Remove(recomendados_de_la_semana);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Recomendados_de_la_semanaExists(int id)
        {
            return _context.Recomendados_de_la_semana.Any(e => e.Id == id);
        }
    }
}
