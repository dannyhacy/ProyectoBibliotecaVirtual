using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models.Libro
{
    public class UbicacionLibro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La ubicacion del Libro es obligatoria.")]
        [StringLength(40, ErrorMessage = "No puede tener más de 40 caracteres.")]
        public string Ubicacion { get; set; }
    }
}
