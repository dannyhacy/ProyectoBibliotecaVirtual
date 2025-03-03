using Microsoft.AspNetCore.Identity;

namespace Biblioteca.Models.Libro
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}
