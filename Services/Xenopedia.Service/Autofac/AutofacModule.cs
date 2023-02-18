using Autofac;
using AutoMapper;
using Xenopedia.Business.Mapper;
using Xenopedia.Business.TextService;
using Xenopedia.Commons.Database;
using Xenopedia.Entities.DTO.Text;
using Xenopedia.Entities.Entity.Text;
using Xenopedia.Infrastructure.Text;

namespace Xenopedia.Service.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TextService>().As<ITextService>().InstancePerLifetimeScope();
            builder.RegisterType<TextRepository>().As<ITextRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TextMapper>().As<ITextMapper>().InstancePerLifetimeScope();
            builder.RegisterType<DatabaseManager>().As<IDatabaseManager>().InstancePerLifetimeScope();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TextEntity, TextDTO>();
                //etc...
            })).AsSelf().SingleInstance();
            builder.Register(m =>
            {
                var context = m.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();

                return config.CreateMapper(context.Resolve);
            }).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
