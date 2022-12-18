using CarMarket.Services.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace CarMarket.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedRoles(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var services = scopedServices.ServiceProvider;

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync("Admin"))
                {
                    return;
                }
                if (await roleManager.RoleExistsAsync("User"))
                {
                    return;
                }

                var adminRole = new IdentityRole { Name = "Admin" };
                var userRole = new IdentityRole { Name = "User" };

                await roleManager.CreateAsync(adminRole);
                await roleManager.CreateAsync(userRole);
            })
            .GetAwaiter()
            .GetResult();

            return app;
        }
    }
}
