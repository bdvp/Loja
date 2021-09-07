namespace Loja.Infra.CrossCutting.Bus
{
    using Loja.Domain.Core.ValueObject;
    using MediatR;
    using System.Threading.Tasks;

    public class BusHandler : IBusHandler
    {
        private readonly IMediator _mediator;

        public BusHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Result> SendCommand<TCommand>(TCommand command) where TCommand : Domain.Core.Commands.Command
        {
            return await _mediator.Send(command);
        }
    }
}
