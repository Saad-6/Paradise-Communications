using Microsoft.AspNetCore.Identity;
using Paradise.Models;
using Paradise.Models.FormModels;

namespace Paradise.Utilities
{
    public static class Utilities
    {
        public static  Dictionary<string, Type> classMap = new Dictionary<string, Type>
        {
            { "Medicare", typeof(Medicare) },
            { "FinalInsurance", typeof(FinalInsurance) },
            { "AutoInsurance", typeof(AutoInsurance) },
            { "MVA", typeof(MVA) },
            { "ACA", typeof(ACA) }
        };
        public static DateTime EasternTime()
        {
            DateTime utcNow = DateTime.UtcNow;

            // Step 2: Define the desired US time zone
            TimeZoneInfo usTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"); // Replace with desired US time zone

            // Step 3: Convert the UTC time to the desired US time zone
            DateTime usTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, usTimeZone);
            return usTime;
        }
        public static async Task SeedAdminUserAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<SuperUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Check if the Admin role exists, if not, create it
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                // Check if the Admin user exists, if not, create it
                var adminUser = await userManager.FindByEmailAsync("admin@paradisecommunications.co");
                if (adminUser == null)
                {
                    adminUser = new SuperUser
                    {
                        UserName = "admin@paradisecommunications.co",
                        Email = "admin@paradisecommunications.co",
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(adminUser, "F7cy93bjsa@");

                    // Assign the Admin role to the admin user
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }

}
