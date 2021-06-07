using System;
using DataConverter.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataConverter.Setup.Database
{
    public static class DbContextSetup
    {
        public static void ConfigureDbContext(this IServiceCollection serviceCollection)
        {
            var configuration = serviceCollection.BuildServiceProvider()
                .GetService<IConfiguration>();

            void ConfigureWarningAction(WarningsConfigurationBuilder warningsConfigurationBuilder)
            {
                warningsConfigurationBuilder.Throw(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning);
            }

            var sqlConnectionString = configuration.GetSqlConfiguration();
            serviceCollection.AddSingleton(sqlConnectionString);

            if (sqlConnectionString.IsInMemory)
            {
                serviceCollection.AddDbContext<ConverterContext>(
                        opt => opt
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                            .ConfigureWarnings(ConfigureWarningAction),
                        ServiceLifetime.Transient,
                        ServiceLifetime.Singleton);
            }
            else
            {
                serviceCollection.AddDbContext<ConverterContext>(
                    opt => opt.UseSqlServer(sqlConnectionString.ConnectionString, 
                            x =>
                            {
                                x.EnableRetryOnFailure(
                                    maxRetryCount: 3,
                                    maxRetryDelay: TimeSpan.FromSeconds(10),
                                    errorNumbersToAdd: null
                                );
                            }
                        )
                        .ConfigureWarnings(ConfigureWarningAction),
                    ServiceLifetime.Transient,
                    ServiceLifetime.Singleton);
            }

            serviceCollection.AddTransient<IConverterContext>(provider => provider.GetService<ConverterContext>());
        }
    }
}