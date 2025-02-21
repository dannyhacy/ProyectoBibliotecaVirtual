using Biblioteca.Data;
using Biblioteca.Models.Libro;
using Microsoft.AspNetCore.Identity;

namespace Biblioteca.Services
{
    public class SeedService
    {
        public static async Task SeedDatabase(IServiceProvider serviceProvicer)
        {
            using var metodo = serviceProvicer.CreateScope();
            var context = metodo.ServiceProvider.GetRequiredService<LoginDbContext>();
            var roleManager = metodo.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = metodo.ServiceProvider.GetRequiredService<UserManager<Users>>();
            var logger = metodo.ServiceProvider.GetRequiredService<ILogger<SeedService>>();

            try
            {
                // Asegurando que la base esta lista
                logger.LogInformation("Asegurando que la base esta creada");
                await context.Database.EnsureCreatedAsync();

                // Adicionando los Roles
                logger.LogInformation("insertando Roles.");
                await AddRoleAsync(roleManager, "Admin");
                await AddRoleAsync(roleManager, "User");

                // Adicionando Usuario "Admin"
                logger.LogInformation("insertando usuario Admin.");
                var adminEmail = "Dannyhacy@admin.com";
                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var adminUser = new Users
                    {
                        FullName = "Danny Cerna",
                        UserName = adminEmail,
                        NormalizedUserName = adminEmail.ToUpper(),
                        Email = adminEmail,
                        NormalizedEmail = adminEmail.ToUpper(),
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    var result = await userManager.CreateAsync(adminUser, "Admin@123");
                    if (result.Succeeded)
                    {
                        logger.LogInformation("asignando rol Admin al usuario Admin");
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                    else
                    {
                        logger.LogError("Error al crear usuario Admin: {Error}", string.Join(",", result.Errors.Select(e => e.Description))) ;
                    }
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrio un error cuando se envió a la base de datos");
            }
        }

        private static async Task AddRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if(!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception($"Error al crear Rol '{roleName}': {string.Join(",", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}
