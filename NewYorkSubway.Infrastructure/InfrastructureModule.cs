using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NewYorkSubway.Infrastructure.EntityFramework;

namespace NewYorkSubway.Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly string _connectionString;

        public InfrastructureModule(string conn)
        {
            _connectionString = conn;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<SubwayDbContext>();
                optionsBuilder.UseNpgsql(_connectionString);
                return new SubwayDbContext(optionsBuilder.Options);
            }).InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

        }
    }
}