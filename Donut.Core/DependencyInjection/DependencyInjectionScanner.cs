﻿using Donut.Core.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Donut.Core.DependencyInjection;

public static class DependencyInjectionScanner
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration, params Assembly[] assemblies)
    {
        var installers = assemblies.SelectMany(assembly => assembly.DefinedTypes)
                  .Where(TypeChecker.IsAssignableToType<IDependencyInjectionInstaller>)
                  .Select(Activator.CreateInstance)
                  .Cast<IDependencyInjectionInstaller>();

        foreach (var installer in installers)
        {
            installer.Install(services, configuration);
        }
        return services;
    }
}