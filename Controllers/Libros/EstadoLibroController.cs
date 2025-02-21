using Biblioteca.Data;
using Biblioteca.Models.Libro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers.Libros
{
    public class EstadoLibroController : Controller
    {
        private readonly BibliotecaContext _EstadoLibroContext;

        public EstadoLibroController(BibliotecaContext estadoLibroContext)
        {
            _EstadoLibroContext = estadoLibroContext;
        }

        public async Task<IActionResult> Listar()
        {
            var estadolibro = await _EstadoLibroContext.EstadoLibros.ToListAsync();
            return View(estadolibro);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Estado")] EstadoLibro estadolibro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _EstadoLibroContext.Add(estadolibro);
                    await _EstadoLibroContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
                return Create();
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "El Estado que está intentando ingresar ya se encuentra en la lista");
            }
            return View(estadolibro);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de Editar");
            }
            var estadolibro = await _EstadoLibroContext.EstadoLibros.FirstOrDefaultAsync(el => el.Id == id);
            if (estadolibro == null)
            {
                ModelState.AddModelError("", "No se encontró el Estado del Libro");
            }
            return View(estadolibro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Estado")] EstadoLibro estadolibro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _EstadoLibroContext.Update(estadolibro);
                    await _EstadoLibroContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de Editar." );
            }
            return View(estadolibro);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de eliminar");
            }
            var estadolibro = await _EstadoLibroContext.EstadoLibros.FirstOrDefaultAsync(a => a.Id == id);
            if (estadolibro == null)
            {
                ModelState.AddModelError("", "No se encontró el Autor");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    _EstadoLibroContext.Remove(estadolibro);
                    await _EstadoLibroContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "No se puede eliminar el Autor");
            }
            return View(estadolibro);
        }



    }
}
