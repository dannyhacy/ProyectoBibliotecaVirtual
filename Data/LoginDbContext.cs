using Biblioteca.Models.Libro;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data
{
    public class LoginDbContext : IdentityDbContext<Users>
    {
        public LoginDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
