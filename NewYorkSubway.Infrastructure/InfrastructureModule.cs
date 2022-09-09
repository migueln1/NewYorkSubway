using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NewYorkSubway.Core.Models;
using NewYorkSubway.Infrastructure.EntityFramework;

namespace NewYorkSubway.Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly IConfiguration _configuration;

        public InfrastructureModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<SubwayDbContext>();
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("RdsConnection"));
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