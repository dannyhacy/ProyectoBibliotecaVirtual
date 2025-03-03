using Biblioteca.Data;
using Biblioteca.Models.Libro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers.Libros
{
    public class AutorController : Controller
    {
        private readonly BibliotecaContext _AutorContext;

        public AutorController(BibliotecaContext autorcontext)
        {
            _AutorContext = autorcontext;
        }
        
        public async Task<IActionResult> Listar()
        {
            var autor = await _AutorContext.Autores.ToListAsync();
            return View(autor); ;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, AutorLibro")] Autor autor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _AutorContext.Add(autor);
                    await _AutorContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
                return Create();
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "El Autor que está intentando ingresar ya se encuentra en la lista");
            }

            return View(autor);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de Editar");
            }
            var autor = await _AutorContext.Autores.FirstOrDefaultAsync(a => a.Id == id);
            if (autor == null)
            {
                ModelState.AddModelError("", "No se encontró el Autor");
            }
            return View(autor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AutorLibro")] Autor autor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _AutorContext.Update(autor);
                    await _AutorContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de Editar => " + ex.Message);
            }
            return View(autor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de eliminar");
            }
            var Autor = await _AutorContext.Autores.FirstOrDefaultAsync(a => a.Id == id);
            if (Autor == null)
            {
                ModelState.AddModelError("", "No se encontró el Autor");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    _AutorContext.Remove(Autor);
                    await _AutorContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "No se puede eliminar el Autor");
            }
            return View(Autor);
        }

    }
}
