using Autofac;
using DataConverter.Persistence;
using DataConverter.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataConverter.Middleware.DependencyContainer
{
    public static class AutofacConfig
    {
        public static void RegisterAutofacDependencies(this ContainerBuilder containerBuilder, IConfiguration configuration)
        {
            containerBuilder.RegisterType<DataConverterService>().As<IDataConverterService>()
                .SingleInstance();
        }
    }
}