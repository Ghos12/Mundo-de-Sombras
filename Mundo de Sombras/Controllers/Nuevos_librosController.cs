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
    public class Nuevos_librosController : Controller
    {
        private readonly Mundo_de_SombrasContext _context;

        public Nuevos_librosController(Mundo_de_SombrasContext context)
        {
            _context = context;
        }

        // GET: Nuevos_libros
        public async Task<IActionResult> Index()
        {
            return View(await _context.nuevos_libros.ToListAsync());
        }

        // GET: Nuevos_libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nuevos_libros = await _context.nuevos_libros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nuevos_libros == null)
            {
                return NotFound();
            }

            return View(nuevos_libros);
        }

        // GET: Nuevos_libros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nuevos_libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Categoria,Autor,Precio")] Nuevos_libros nuevos_libros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nuevos_libros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nuevos_libros);
        }

        // GET: Nuevos_libros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nuevos_libros = await _context.nuevos_libros.FindAsync(id);
            if (nuevos_libros == null)
            {
                return NotFound();
            }
            return View(nuevos_libros);
        }

        // POST: Nuevos_libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Categoria,Autor,Precio")] Nuevos_libros nuevos_libros)
        {
            if (id != nuevos_libros.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nuevos_libros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Nuevos_librosExists(nuevos_libros.Id))
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
            return View(nuevos_libros);
        }

        // GET: Nuevos_libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nuevos_libros = await _context.nuevos_libros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nuevos_libros == null)
            {
                return NotFound();
            }

            return View(nuevos_libros);
        }

        // POST: Nuevos_libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nuevos_libros = await _context.nuevos_libros.FindAsync(id);
            _context.nuevos_libros.Remove(nuevos_libros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Nuevos_librosExists(int id)
        {
            return _context.nuevos_libros.Any(e => e.Id == id);
        }
    }
}
