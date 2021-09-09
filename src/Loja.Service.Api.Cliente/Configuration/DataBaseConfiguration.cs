using Loja.Infra.Data.Context;
using Loja.Infra.Data.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Loja.Service.Api.Cliente.Configuration
{
    public static class DataBaseConfiguration
    {
        public static void AddDataBaseConfiguration(this IServiceCollection services)
        {
            if(services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<ICommandConnection, CommandConnection>();
            services.AddScoped<IQueryConnection, QueryConnection>();
        }
    }
}
