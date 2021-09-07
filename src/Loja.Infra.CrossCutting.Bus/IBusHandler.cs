namespace Loja.Infra.CrossCutting.Bus
{
    using Loja.Domain.Core.Commands;
    using Loja.Domain.Core.ValueObject;
    using System.Threading.Tasks;

    public interface IBusHandler
    {
        Task<Result> SendCommand<TCommand>(TCommand command) where TCommand : Command;
    }
}
