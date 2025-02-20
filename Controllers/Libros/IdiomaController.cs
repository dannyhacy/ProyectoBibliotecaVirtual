using Biblioteca.Data;
using Biblioteca.Models.Libro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers.Libros
{
    public class IdiomaController : Controller
    {
        private readonly BibliotecaContext _IdiomaContext;

        public IdiomaController(BibliotecaContext idiomacontext)
        {
            _IdiomaContext = idiomacontext;
        }
        public async Task<IActionResult> Listar()
        {
            var idioma = await _IdiomaContext.Idiomas.ToListAsync();
            return View(idioma);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, IdiomaLibro")] Idioma idioma)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _IdiomaContext.Add(idioma);
                    await _IdiomaContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
                return Create();
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "El Idioma que está intentando ingresar ya se encuentra en la lista");
            }
            return View(idioma);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de Editar");
            }
            var idioma = await _IdiomaContext.Idiomas.FindAsync(id);
            if (idioma == null)
            {
                ModelState.AddModelError("", "No se encontró el Idioma");
            }
            return View(idioma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, IdiomaLibro")] Idioma idioma)
        {            
            try
            {
                if (ModelState.IsValid)
                {                
                    _IdiomaContext.Update(idioma);
                    await _IdiomaContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception ex)
                {
                ModelState.AddModelError("", "Ocurrio un error al momento de Editar => " + ex.Message);
            }            
            return View(idioma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de eliminar");
            }
            var Idioma = await _IdiomaContext.Idiomas.FirstOrDefaultAsync(i => i.Id == id);
            if (Idioma == null)
            {
                ModelState.AddModelError("", "No se encontró el Idioma");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    _IdiomaContext.Idiomas.Remove(Idioma);
                    await _IdiomaContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "No se puede eliminar el Idioma");
            }
            return View(Idioma);
        }
    }
}
