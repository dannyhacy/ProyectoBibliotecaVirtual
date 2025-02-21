using System.ComponentModel.DataAnnotations;

namespace Biblioteca.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "El Correo es requerido.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
