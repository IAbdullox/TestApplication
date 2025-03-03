﻿using Infrastucture.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastucture.Persistence
{
    public class AutomatedMigration
    {
        public static async Task MigrateAsync(IServiceProvider services)
        {
            var context = services.GetRequiredService<DatabaseContext>();

            if (context.Database.IsNpgsql()) await context.Database.MigrateAsync();

            var userManager = services.GetRequiredService<UserManager<Aplication>>();

            await DatabaseContextSeed.SeedDatabaseAsync(context, userManager);
        }
    }
}
