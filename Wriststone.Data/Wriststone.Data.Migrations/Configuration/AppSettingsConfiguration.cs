using Microsoft.Extensions.Configuration;

namespace Wriststone.Data.Migrations.Configuration
{
    public static class AppSettingsConfiguration
    {
        public static AppSettings GetAppSettings(string filePath)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(filePath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.local.json", optional: true);

            IConfigurationRoot configuration = builder.Build();

            var settings = new AppSettings();
            configuration.Bind(settings);
            return settings;
        }
    }
}
