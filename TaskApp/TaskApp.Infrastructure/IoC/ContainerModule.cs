using Autofac;
using AutoMapper.Configuration;
using TaskApp.Infrastructure.IoC.Modules;

namespace TaskApp.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
        }
    }
}
