using LibreríaELADIO.Data;
using LibreríaELADIO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibreríaELADIO.Controllers
{
    public class LibroController : Controller
    {
        private readonly LibreriaContext _context;

        public LibroController(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var libros = await _context.Libros.ToListAsync();
            return View(libros);
        }

        [HttpPost]
        public async Task<IActionResult> Store(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libros.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var libros = await _context.Libros.ToListAsync();
            return View("Index", libros);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null) return NotFound();

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}