using Biblioteca.Data;
using Biblioteca.Models.Libro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers.Libros
{
    public class EstadoPrestamoController : Controller
    {
        private readonly BibliotecaContext _EstadoPrestamoContext;

        public EstadoPrestamoController(BibliotecaContext estadpPrestamoContext)
        {
            _EstadoPrestamoContext = estadpPrestamoContext;
        }

        public async Task<IActionResult> Listar()
        {
            var estadoprestamo = await _EstadoPrestamoContext.EstadoPrestamos.ToListAsync();
            return View(estadoprestamo);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Prestamo")] EstadoPrestamo estadoprestamo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _EstadoPrestamoContext.Add(estadoprestamo);
                    await _EstadoPrestamoContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
                return Create();
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "El Estado de Prestamo que está intentando ingresar ya se encuentra en la lista");
            }

            return View(estadoprestamo);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de Editar");
            }
            var estadoprestamo = await _EstadoPrestamoContext.EstadoPrestamos.FirstOrDefaultAsync(ep => ep.Id == id);
            if (estadoprestamo == null)
            {
                ModelState.AddModelError("", "No se encontró el Autor");
            }
            return View(estadoprestamo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Prestamo")] EstadoPrestamo estadoprestamo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _EstadoPrestamoContext.Update(estadoprestamo);
                    await _EstadoPrestamoContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de Editar.");
            }
            return View(estadoprestamo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de eliminar");
            }
            var estadoprestamo = await _EstadoPrestamoContext.EstadoPrestamos.FirstOrDefaultAsync(ep => ep.Id == id);
            if (estadoprestamo == null)
            {
                ModelState.AddModelError("", "No se encontró el Autor");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    _EstadoPrestamoContext.Remove(estadoprestamo);
                    await _EstadoPrestamoContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "No se puede eliminar el Autor");
            }
            return View(estadoprestamo);
        }



    }
}
