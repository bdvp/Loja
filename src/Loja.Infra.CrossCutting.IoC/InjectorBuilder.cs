namespace Loja.Infra.CrossCutting.IoC
{
    using Loja.Application.AppServices;
    using Loja.Application.Contracts.AppServices;
    using Loja.Domain.Clientes.Commands;
    using Loja.Domain.Clientes.Handlers;
    using Loja.Domain.Core.Repositories;
    using Loja.Domain.Core.ValueObject;
    using Loja.Infra.CrossCutting.Bus;
    using Loja.Infra.Data.Clientes;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    public class InjectorBuilder
    {
        public static void RegisterServices(IServiceCollection services)
        {
            AddDomain(services);
            AddApplicationService(services);
            AddRepository(services);
        }

        private static void AddDomain(IServiceCollection services)
        {
            services.AddScoped<IBusHandler, BusHandler>();
            services.AddScoped<IRequestHandler<ClienteCreateCommand, Result>, ClienteCreateHandler>();
            services.AddScoped<IRequestHandler<ClienteUpdateCommand, Result>, ClienteUpdateHandler>();
            services.AddScoped<IRequestHandler<ClienteDeleteCommand, Result>, ClienteDeleteHandler>();
        }

        private static void AddApplicationService(IServiceCollection services)
        {
            services.AddScoped<IClienteAppService, ClienteAppService>();
        }
        
        private static void AddRepository(IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}
