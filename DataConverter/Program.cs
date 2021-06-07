using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using DataConverter.Persistence;
using DataConverter.Persistence.Extensions;
using DataConverter.Setup.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DataConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void MigrateDatabase(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var connectionString = scope.ServiceProvider.GetRequiredService<SqlConnectionString>();
            if (connectionString.IsInMemory)
            {
                return;
            }

            var baseOptions = scope.ServiceProvider.GetRequiredService<DbContextOptions<ConverterContext>>();
            var options = new DbContextOptionsBuilder<ConverterContext>(baseOptions)
                .UseSqlServer(connectionString.DeploymentConnectionString);
            using var db = new ConverterContext(options.Options);
            db.MigrateDatabase();
        }
    }
}