using Autofac.Configuration;

namespace Xenopedia.Commons.Configuration.Autofac
{
    public interface IAutofacConfiguration
    {
        public ConfigurationModule LoadModules();
    }
}
