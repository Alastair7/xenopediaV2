namespace Xenopedia.Service.Startup
{
    public static class ApplicationSettingsBuilder
    {
        public static IHostBuilder ConfigureAppSettings(this IHostBuilder hostBuilder)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            hostBuilder.ConfigureAppConfiguration((ctx, builder) => 
            {
                builder.AddJsonFile("appsettings.json", false, true);
                builder.AddJsonFile($"appsettings.{environment}.json", true, true);
                builder.AddEnvironmentVariables();
            });
            return hostBuilder;
        }
    }
}
