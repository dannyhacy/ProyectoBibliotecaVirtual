﻿using Biblioteca.Data;
using Biblioteca.Models.Libro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers.Libros
{
    public class LibroController : Controller
    {
        private readonly BibliotecaContext _LibroContext;

        public LibroController(BibliotecaContext librocontext)
        {
            _LibroContext = librocontext;
        }

        public async Task<IActionResult> Listar()
        {
            var Libro = await _LibroContext.Libros
                .Include(a => a.Autor)
                .Include(e => e.Editorial)
                .Include(g => g.Genero)
                .Include(i => i.Idioma)
                .Include(ul => ul.UbicacionLibro)
                .Include(el => el.EstadoLibro)
                .ToListAsync();
            return View(Libro);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Autores"] = new SelectList(_LibroContext.Autores, "Id","AutorLibro");
            ViewData["Editoriales"] = new SelectList(_LibroContext.Editoriales, "Id", "EditorialLibro");
            ViewData["Generos"] = new SelectList(_LibroContext.Generos, "Id", "GeneroLibro");
            ViewData["Idiomas"] = new SelectList(_LibroContext.Idiomas, "Id", "IdiomaLibro");
            ViewData["UbicacionLibros"] = new SelectList(_LibroContext.UbicacionLibros, "Id", "Ubicacion");
            ViewData["EstadoLibros"] = new SelectList(_LibroContext.EstadoLibros, "Id", "Estado");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,AutorId,EditorialId,GeneroId,IdiomaId,AñoPublicacion,UbicacionLibroId,Ejemplares,EstadoLibroId")] Libro libro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _LibroContext.Add(libro);
                    await _LibroContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
                return Create();
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "El Libro que está intentando ingresar ya se encuentra en la lista");
            }

            return View(libro);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de Editar");
            }
            ViewData["Autores"] = new SelectList(_LibroContext.Autores, "Id", "NombreAutor");
            ViewData["Editoriales"] = new SelectList(_LibroContext.Editoriales, "Id", "NombreEditorial");
            ViewData["Generos"] = new SelectList(_LibroContext.Generos, "Id", "NombreGenero");
            ViewData["Idiomas"] = new SelectList(_LibroContext.Idiomas, "Id", "IdiomaLibro");
            ViewData["UbicacionLibros"] = new SelectList(_LibroContext.UbicacionLibros, "Id", "Ubicacion");
            ViewData["EstadoLibros"] = new SelectList(_LibroContext.EstadoLibros, "Id", "Estado");
            var libro = await _LibroContext.Libros.FirstOrDefaultAsync(l => l.Id == id);
            if (libro == null)
            {
                ModelState.AddModelError("", "El libro no se encuentra en la lista");
            }
            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,AutorId,EditorialId,GeneroId,IdiomaId,AñoPublicacion,UbicacionLibroId,Ejemplares,EstadoLibroId")] Libro libro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _LibroContext.Update(libro);
                    await _LibroContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
                ViewData["Autores"] = new SelectList(_LibroContext.Autores, "Id", "NombreAutor");
                ViewData["Editoriales"] = new SelectList(_LibroContext.Editoriales, "Id", "NombreEditorial");
                ViewData["Generos"] = new SelectList(_LibroContext.Generos, "Id", "NombreGenero");
                ViewData["Idiomas"] = new SelectList(_LibroContext.Idiomas, "Id", "IdiomaLibro");
                ViewData["UbicacionLibros"] = new SelectList(_LibroContext.UbicacionLibros, "Id", "Ubicacion");
                ViewData["EstadoLibros"] = new SelectList(_LibroContext.EstadoLibros, "Id", "Estado");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrio un error al momento de Editar =>" + ex.Message);
            }           
            return View(libro);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "No se encontro el libro");
            }
            var Libro = await _LibroContext.Libros.FirstOrDefaultAsync(m => m.Id == id);
            if (Libro == null)
            {
                ModelState.AddModelError("", "No se encontro el libro");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    _LibroContext.Libros.Remove(Libro);
                    await _LibroContext.SaveChangesAsync();
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception)
            {
                // Manejo de excepciones
                ModelState.AddModelError("", "No se puede eliminar Libro");
            }
            return View(Libro);
        }
    }
}
