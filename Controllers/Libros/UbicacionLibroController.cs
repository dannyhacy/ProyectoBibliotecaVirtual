using Biblioteca.Data;
using Biblioteca.Models.Libro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers.Libros
{
    public class UbicacionLibroController : Controller
    {
        private readonly BibliotecaContext _UbicacionLibroContext;

        public UbicacionLibroController(BibliotecaContext ubicacionLibroContext)
        {
            _UbicacionLibroContext = ubicacionLibroContext;
        }

        public async Task<IActionResult> Listar()
        {
            var ubicacionlibro = await _UbicacionLibroContext.UbicacionLibros.ToListAsync();
            return View(ubicacionlibro);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Ubicacion")] UbicacionLibro ubicacionlibro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _UbicacionLibroContext.Add(ubicacionlibro);
                    await _UbicacionLibroContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
                return Create();
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "El Autor que está intentando ingresar ya se encuentra en la lista");
            }

            return View(ubicacionlibro);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de Editar");
            }
            var ubicacionlibro = await _UbicacionLibroContext.UbicacionLibros.FirstOrDefaultAsync(ul => ul.Id == id);
            if (ubicacionlibro == null)
            {
                ModelState.AddModelError("", "No se encontró el Autor");
            }
            return View(ubicacionlibro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Ubicacion")] UbicacionLibro ubicacionlibro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _UbicacionLibroContext.Update(ubicacionlibro);
                    await _UbicacionLibroContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de Editar");
            }
            return View(ubicacionlibro);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de eliminar");
            }
            var ubicacionlibro = await _UbicacionLibroContext.UbicacionLibros.FirstOrDefaultAsync(ul => ul.Id == id);
            if (ubicacionlibro == null)
            {
                ModelState.AddModelError("", "No se encontró el Autor");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    _UbicacionLibroContext.Remove(ubicacionlibro);
                    await _UbicacionLibroContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "No se puede eliminar el Autor");
            }
            return View(ubicacionlibro);
        }






    }
}
