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

        public IActionResult Index()
        {
            var libros = _context.Libros.ToList();
            return View(libros);
        }

        [HttpPost]
        public IActionResult Store(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libros.Add(libro); 
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            var libros = _context.Libros.ToList();
            return View("Index", libros);
        }

        public IActionResult Delete(int id)
        {
            var libro = _context.Libros.Find(id);
            if (libro == null)
                return NotFound();

            _context.Libros.Remove(libro);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
