using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models.Libro
{
    public class EstadoLibro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción del estado del libro es obligatoria.")]
        [StringLength(40, ErrorMessage = "No puede tener más de 40 caracteres.")]
        public string Estado { get; set; }
    }
}
