using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;

namespace Xenopedia.Commons.Configuration.Autofac
{
    public class AutofacConfiguration : IAutofacConfiguration
    {
        private readonly ConfigurationBuilder config;

        public AutofacConfiguration() 
        {
            config = new ConfigurationBuilder();
        }

        public ConfigurationModule LoadModules()
        {
            string filesPath = $"{Directory.GetCurrentDirectory()}/Config/";
            string[] configPaths = Directory.GetFiles(filesPath, "autofac.*");

            foreach (string configPath in configPaths) 
            {
                config.AddJsonFile(configPath, true, true);
            }

            ConfigurationModule module = new(config.Build());

            return module;
        }
    }
}
