namespace Planefall.Extensions
{
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Models;

    public static class ApplicationBuilderExtensions
    {
        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            InitializeDatabaseAsync(app).GetAwaiter().GetResult();
        }

        // Migrate database and create administrator role
        private static async Task InitializeDatabaseAsync(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<PlanefallDbContext>();

                await dbContext.Database.MigrateAsync();

                // Create administrator and publisher roles

                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(GlobalConstants.AdministratorRoleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(GlobalConstants.AdministratorRoleName));
                }

                // Create initial administrator

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<PlanefallUser>>();

                if (!dbContext.Users.Any())
                {
                    var admin = new PlanefallUser()
                    {
                        Email = "admin@admin.com",
                        UserName = "admin@admin.com",
                        FirstName = "Admin",
                        LastName = "Adminov",
                        IdNumber = "0000000000",
                        PhoneNumber = "+359123456789",
                        Address = "Beli Brezi 24, Sofia 1000, BG"
                    };

                    await userManager.CreateAsync(admin, "admin123");
                    await userManager.AddToRoleAsync(admin, GlobalConstants.AdministratorRoleName);
                }
            }
        }
    }
}