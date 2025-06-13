using DevFreela.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DevFreela.Application;

public static class ApplicationModule
{
    const string projectName = "DevFreela.Application";

    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service
            .AddHandlers()
            .AddBehaviors()
            .AddValidators();

        return service;
    }

    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config
            => config.RegisterServicesFromAssembly(Assembly.Load(projectName)));

        return services;
    }

    private static IServiceCollection AddBehaviors(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.Load(projectName));
        return services;
    }
}
