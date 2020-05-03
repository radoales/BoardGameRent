using Microsoft.Extensions.DependencyInjection;

namespace BGRent.Server.Infrastructure.Extensions
{
    using Microsoft.Extensions.Configuration;
    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("DefaultConnection");
        }

        public static AppSettings GetApplicationSettings(
            this IConfiguration configuration, 
            IServiceCollection services)
        {
            var appSettingsSectionConfiguration = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSectionConfiguration);
            var appSettings = appSettingsSectionConfiguration.Get<AppSettings>();

            return appSettings;
        }
    }
}
