using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models.Libro
{
    public class CarritoItem
    {
        [Key]
        public int CarritoItemId { get; set; }

        [Required(ErrorMessage = "El Id del Libro es obligatorio.")]
        public int LibroId { get; set; }
        public Libro Libro { get; set; }
        public int Cantidad { get; set; }
    }
}
