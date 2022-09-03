using Autofac;
using MediatR;
using NewYorkSubway.Core;
using System.Reflection;

namespace NewYorkSubway.Application
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new CoreModule());
            
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterAssemblyTypes(typeof(ApplicationModule).GetTypeInfo().Assembly).AsImplementedInterfaces();
        }
    }
}