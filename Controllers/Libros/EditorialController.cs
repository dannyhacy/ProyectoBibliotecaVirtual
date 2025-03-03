using Biblioteca.Data;
using Biblioteca.Models.Libro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers.Libros
{
    public class EditorialController : Controller
    {
        private readonly BibliotecaContext _Editorialcontext;

        public EditorialController(BibliotecaContext editorialcontext)
        {
            _Editorialcontext = editorialcontext;
        }

        public async Task<IActionResult> Listar()
        {
            var Editorial = await _Editorialcontext.Editoriales.ToListAsync();
            return View(Editorial);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, EditorialLibro")]Editorial editorial)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Editorialcontext.Add(editorial);
                    await _Editorialcontext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
                return Create();
            }
            catch (Exception)
            {
                // Manejo de excepciones
                ModelState.AddModelError("", "La editorial que está intentando ingresar ya se encuentra en la lista");
            }
            return View(editorial);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de Editar");
            }
            var editorial = await _Editorialcontext.Editoriales.FirstOrDefaultAsync(e => e.Id == id);
            if (editorial == null)
            {
                ModelState.AddModelError("", "No se encontró Editorial");
            }
            return View(editorial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, EditorialLibro")] Editorial editorial)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Editorialcontext.Update(editorial);
                    await _Editorialcontext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de Editar.");
            }        
            return View(editorial);                                   
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de eliminar");
            }
            var Editorial = await _Editorialcontext.Editoriales.FirstOrDefaultAsync(e => e.Id == id);
            if (Editorial == null)
            {
                ModelState.AddModelError("", "La Editorial no existe");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    _Editorialcontext.Remove(Editorial);
                    await _Editorialcontext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "No se puede eliminar la Editorial");
            }
            return View(Editorial);
        }
    }
}
