using Biblioteca.Data;
using Biblioteca.Models.Libro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    public class CarritoController : Controller
    {
        private readonly BibliotecaContext _CarritoContext;

        public CarritoController(BibliotecaContext carritoContext)
        {
            _CarritoContext = carritoContext;
        }

        public IActionResult Index()
        {
            var carritoItems = _CarritoContext.CarritoItems.Include(x => x.Libro).ToList();
            int totalLibros = carritoItems.Sum(item => item.Cantidad);

            ViewBag.TotalLibros = totalLibros;
            return View(carritoItems);
        }

        [HttpPost]
        public IActionResult AgregarAlCarritoAjax(int libroId, int cantidad)
        {
            var libro = _CarritoContext.Libros.Find(libroId);
            if (libro == null)
            {

                return Json(new { sucess = false, message = "Libro no encontrado." });
            }

            var carritoItem = _CarritoContext.CarritoItems.FirstOrDefault(X => X.LibroId == libroId);
            if (carritoItem == null)
            {
                carritoItem = new CarritoItem
                {
                    LibroId = libroId,
                    Cantidad = cantidad
                };
                _CarritoContext.CarritoItems.Add(carritoItem);
            }
            else
            {
                carritoItem.Cantidad = cantidad;
            }
            _CarritoContext.SaveChanges();
            int totalLibros = _CarritoContext.CarritoItems.Sum(item => item.Cantidad);
            return Json(new { sucess = true, totalLibros });

        }

        [HttpPost]

        public IActionResult EliminarDelCarrito(int CarritoItemId)
        {
            var carritoItem = _CarritoContext.CarritoItems.Find(CarritoItemId);
            if (carritoItem != null)
            {
                _CarritoContext.CarritoItems.Remove(carritoItem);
                _CarritoContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
