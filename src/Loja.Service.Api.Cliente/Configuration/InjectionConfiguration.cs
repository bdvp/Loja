using Loja.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.Service.Api.Cliente.Configuration
{
    public static class InjectionConfiguration
    {
        public static void AddInjectorConfiguration(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            InjectorBuilder.RegisterServices(services);
        }
    }
}
