using Autofac;
using Xenopedia.Business.TextService;
using Xenopedia.Infrastructure.Text;

namespace Xenopedia.Commons.Configuration.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TextService>().As<ITextService>().InstancePerLifetimeScope();
            builder.RegisterType<TextRepository>().As<ITextRepository>().InstancePerLifetimeScope();
        }
    }
}
