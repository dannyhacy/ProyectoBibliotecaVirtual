using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models.Libro
{
    public class EstadoPrestamo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El estado del prestamo es obligatorio.")]
        [StringLength(40, ErrorMessage = "No puede tener más de 40 caracteres.")]
        public string Prestamo { get; set; }
    }
}
