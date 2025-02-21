using System.ComponentModel.DataAnnotations;

namespace Biblioteca.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "El Correo es requerido.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at {2} and at max {1} characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        [Compare("ConfirmNewPassword", ErrorMessage = "La contraseña no coincide.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirmar la Contraseña es requerida.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        public string ConfirmNewPassword { get; set; }
    }
}
