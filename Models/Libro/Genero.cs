using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models.Libro
{
    public class Genero
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del género es obligatorio.")]
        [StringLength(50, ErrorMessage = "No puede tener más de 50 caracteres.")]
        public string GeneroLibro { get; set; }
    }
}
