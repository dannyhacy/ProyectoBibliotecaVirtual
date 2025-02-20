﻿using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models.Libro
{
    public class Idioma
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del idioma es obligatorio.")]
        [StringLength(50, ErrorMessage = "No puede tener más de 50 caracteres.")]
        public string IdiomaLibro { get; set; }
    }
}
