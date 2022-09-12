using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Context;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class LibrosController : Controller
    {
        //Llamamos a la conexion
        private readonly LibroContext _context;

        public LibrosController(LibroContext context)
        {
            _context = context;
        }
        [Authorize(Roles ="Admin,SuperAdmin,User")]
        public IActionResult Index()
        {
            IEnumerable<Libro> ListaLibros = _context.Libros;
            return View(ListaLibros);
        }
        //Metodo Get
        [Authorize(Roles = "Admin,SuperAdmin")]
        public IActionResult Guardar()
        {
            return View();
        }
        //Metodo Post
        [HttpPost]
        public IActionResult Guardar(Libro libro)
        {
            if (ModelState.IsValid)
            {
                libro.FechaAgregado = DateTime.Now;
                var libros = _context.Libros;
                libros.Add(libro);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [Authorize(Roles = "Admin,SuperAdmin")]
        public IActionResult Editar(int? id)
        {
            if(id == 0 || id == null)
            {
                return NotFound("Id no existente");
            }
            else
            {
                //Devolvemos el libro
                var libros = _context.Libros.Find(id);
                if (libros == null)
                {
                    return NotFound("No existe!");
                }
                return View(libros);
            }
            
        }
        [HttpPost]
        public IActionResult Editar(Libro libro)
        {
            if (ModelState.IsValid)
            {
                
                libro.FechaAgregado = DateTime.Now;
                var libros = _context.Libros;
                libros.Update(libro);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        [AllowAnonymous]
        public IActionResult Eliminar(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound("Id no existente");
            }
            else
            {
                //Devolvemos el libro
                var libros = _context.Libros.Find(id);
                if (libros == null)
                {
                    return NotFound("No existe!");
                }
                return View(libros);
            }

        }

        [HttpPost]
        public IActionResult Eliminar(Libro libro)
        {
            if (ModelState.IsValid)
            {
                var libros = _context.Libros;
                libros.Remove(libro);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
