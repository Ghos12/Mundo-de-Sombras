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
    public class Mas_compradosController : Controller
    {
        private readonly Mundo_de_SombrasContext _context;

        public Mas_compradosController(Mundo_de_SombrasContext context)
        {
            _context = context;
        }

        // GET: Mas_comprados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mas_comprados.ToListAsync());
        }

        // GET: Mas_comprados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mas_comprados = await _context.Mas_comprados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mas_comprados == null)
            {
                return NotFound();
            }

            return View(mas_comprados);
        }

        // GET: Mas_comprados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mas_comprados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Categoria,Autor,Precio")] Mas_comprados mas_comprados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mas_comprados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mas_comprados);
        }

        // GET: Mas_comprados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mas_comprados = await _context.Mas_comprados.FindAsync(id);
            if (mas_comprados == null)
            {
                return NotFound();
            }
            return View(mas_comprados);
        }

        // POST: Mas_comprados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Categoria,Autor,Precio")] Mas_comprados mas_comprados)
        {
            if (id != mas_comprados.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mas_comprados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Mas_compradosExists(mas_comprados.Id))
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
            return View(mas_comprados);
        }

        // GET: Mas_comprados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mas_comprados = await _context.Mas_comprados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mas_comprados == null)
            {
                return NotFound();
            }

            return View(mas_comprados);
        }

        // POST: Mas_comprados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mas_comprados = await _context.Mas_comprados.FindAsync(id);
            _context.Mas_comprados.Remove(mas_comprados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Mas_compradosExists(int id)
        {
            return _context.Mas_comprados.Any(e => e.Id == id);
        }
    }
}
