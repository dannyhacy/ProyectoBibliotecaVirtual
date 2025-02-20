using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models.Libro
{
    public class Editorial
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la Editorial es obligatorio.")]
        [StringLength(50, ErrorMessage = "No puede tener más de 50 caracteres.")]
        public string EditorialLibro { get; set; }
    }
}
