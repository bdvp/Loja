namespace Loja.Infra.CrossCutting.Bus
{
    using Loja.Application.Contracts.AppServices;
    using Loja.Domain.Core.ValueObject;
    using MediatR;
    using System.Threading.Tasks;

    public class BusMediator : IBusMediator
    {
        private readonly IMediator _mediator;

        public BusMediator(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Result> SendCommand<TCommand>(TCommand command) where TCommand : Domain.Core.Commands.Command
        {
            return await _mediator.Send(command);
        }

        public async Task<TResult> SendQuery<TResult>(IQuery<TResult> query)
        {
            return await _mediator.Send(query);
        }
    }
}
