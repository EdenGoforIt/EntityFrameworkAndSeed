using AspnetCoreEFCoreExample.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace AspnetCoreEFCoreExample
{
    public static class MigrateAndSeedData
    {
        public static void MigrateAndSeedDb(this IApplicationBuilder app, bool development = false)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var context = serviceScope.ServiceProvider.GetService<DataBaseContext>())
            {
                //your development/live logic here eg:
                context.Migrate();
                if (development)
                    context.Seed();
            }
        }

        private static void Migrate(this DataBaseContext context)
        {
            context.Database.EnsureCreated();
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();
        }

        private static void Seed(this DataBaseContext context)
        {
            AddOrUpdateSeedData(context);
            context.SaveChanges();
        }

        internal static DbContext AddOrUpdateSeedData(this DataBaseContext dbContext)
        {
            if (dbContext.MyModels == null || dbContext.MyModels.Count() == 0)
            { 
                dbContext.AddRange(new MyModel() { Name = "New one" }, new MyModel { Name = "John" });
            } 

            return dbContext;
        }
    }
}
