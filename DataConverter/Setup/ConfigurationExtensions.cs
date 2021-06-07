using Microsoft.Extensions.Configuration;

namespace DataConverter.Setup
{
    public static class ConfigurationExtensions
    {
        public static T GetSection<T>(this IConfiguration config, string sectionName)
            where T : class, new()
        {
            var configDto = new T();
            config.GetSection(sectionName).Bind(configDto);
            return configDto;
        }
    }
}