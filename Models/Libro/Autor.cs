using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models.Libro
{
    public class Autor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(40, ErrorMessage = "El nombre no puede tener más de 40 caracteres.")]
        public string AutorLibro { get; set; }
    }
}
