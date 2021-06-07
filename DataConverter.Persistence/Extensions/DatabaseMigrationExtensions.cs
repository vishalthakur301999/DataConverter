using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataConverter.Persistence.Extensions
{
    public static class DatabaseMigrationExtensions
    {
        public static async void MigrateDatabase<TDbContext>(this TDbContext dbContext)
            where TDbContext : DbContext
        {
            var db = dbContext.Database;
            var pendingMigrations = await db.GetPendingMigrationsAsync();
            if (!pendingMigrations.Any())
            {
                return;
            }
            db.SetCommandTimeout(3 * 60);
            await db.MigrateAsync();
        }
    }
}