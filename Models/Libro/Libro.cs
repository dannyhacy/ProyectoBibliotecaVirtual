using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models.Libro
{
    public class Libro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título del libro es obligatorio.")]
        [StringLength(100, ErrorMessage = "No puede tener más de 100 caracteres.")]
        public string Titulo { get; set; }       

        [Required(ErrorMessage = "El autor del libro es obligatorio.")]
        public int AutorId { get; set; }
        public Autor Autor { get; set; }

        [Required(ErrorMessage = "La editorial del libro es obligatoria.")]
        public int EditorialId { get; set; }
        public Editorial Editorial { get; set; }

        [Required(ErrorMessage = "El género del libro es obligatorio.")]
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }

        [Required(ErrorMessage = "El idioma del libro es obligatorio.")]
        public int IdiomaId { get; set; }
        public Idioma Idioma { get; set; } 

        [Required(ErrorMessage = "El Año de Publicacion es obligatorio.")]
        [StringLength(4, ErrorMessage = "El Año no puede tener más de 4 caracteres (2023).")]
        [Range(1900, 2100, ErrorMessage = "El Año debe estar entre 1900 y 2100.")]
        public string AñoPublicacion { get; set; }

        [Required(ErrorMessage = "La Ubicación del libro es obligatorio.")]
        public int UbicacionLibroId { get; set; }
        public UbicacionLibro UbicacionLibro { get; set; }

        [Required(ErrorMessage = "La Cantidad es obligatoria.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El Año debe contener solo números.")]
        public int Ejemplares { get; set; }

        [Required(ErrorMessage = "El estado de Libro es obligatorio.")]
        public int EstadoLibroId { get; set; }
        public EstadoLibro EstadoLibro { get; set; }

        [Required(ErrorMessage = "El estado de Prestamo es obligatorio.")]
        public int EstadoPrestamoId { get; set; }
        public EstadoPrestamo EstadoPrestamo { get; set; }
    }
}
