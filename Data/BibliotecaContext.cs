using Biblioteca.Models.Libro;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }

               
        
        // tablas de libro
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Genero> Generos { get; set; } 
        public DbSet<Idioma> Idiomas { get; set; } 
        public DbSet<UbicacionLibro> UbicacionLibros { get; set; }
        public DbSet<EstadoLibro> EstadoLibros { get; set; }
        public DbSet<EstadoPrestamo> EstadoPrestamos { get; set; }
        public DbSet<Libro> Libros { get; set; }

               



        

    }
}
