using Biblioteca.Data;
using Biblioteca.Models.Libro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers.Libros
{
    public class GeneroController : Controller
    {
        private readonly BibliotecaContext _GeneroContext;

        public GeneroController(BibliotecaContext generocontext)
        {
            _GeneroContext = generocontext;
        }
        public async Task<IActionResult> Listar()
        {
            var Generos = await _GeneroContext.Generos.ToListAsync();
            return View(Generos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, GeneroLibro")] Genero genero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _GeneroContext.Add(genero);
                    await _GeneroContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
                return Create();
            }
            catch (Exception)
            {
                // Manejo de excepciones
                ModelState.AddModelError("", "El Género que está intentando ingresar ya se encuentra en la lista");
            }

            return View(genero);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de Editar");
            }
            var genero = await _GeneroContext.Generos.FirstOrDefaultAsync(g => g.Id == id);
            if (genero == null)
            {
                ModelState.AddModelError("", "No se encontró el Género Literario");
            }
            return View(genero);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, GeneroLibro")] Genero genero)
        {
            try
            {
                if (ModelState.IsValid)
                {                
                    _GeneroContext.Update(genero);
                    await _GeneroContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de Editar => " + ex.Message);
            }            
            return View(genero);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de Eliminar");
            }
            var Genero = await _GeneroContext.Generos.FirstOrDefaultAsync(g => g.Id == id);
            if (Genero == null)
            {
                ModelState.AddModelError("", "No se encontró el Género Literario");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    _GeneroContext.Generos.Remove(Genero);
                    await _GeneroContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "No se puede eliminar el Género Literario");
            }
            return View(Genero);
        }
    }
}
