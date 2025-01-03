using Infrastucture.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastucture.Persistence
{
    public class DatabaseContextSeed
    {
        public static async Task SeedDatabaseAsync(DatabaseContext context, UserManager<Aplication> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new Aplication { UserName = "admin" };

                await userManager.CreateAsync(user, "Admin123.?");
            }

            await context.SaveChangesAsync();
        }
    }
}
