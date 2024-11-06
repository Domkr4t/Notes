using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Common.Behaviors;
using Notes.Application.Common.Mappings;
using System.Reflection;


namespace Notes.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(
                cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            var assemblyMapping = new AssemblyMapping(Assembly.GetExecutingAssembly());
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(assemblyMapping));

            services.AddSingleton<IMapper>(sp =>
            {
                return mapperConfig.CreateMapper();
            });

            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
