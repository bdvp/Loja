namespace Loja.Infra.CrossCutting.Bus
{
    using Loja.Application.Contracts.AppServices;
    using Loja.Domain.Core.Commands;
    using Loja.Domain.Core.ValueObject;
    using System.Threading.Tasks;

    public interface IBusMediator
    {
        Task<Result> SendCommand<TCommand>(TCommand command) where TCommand : Command;

        Task<TResult> SendQuery<TResult>(IQuery<TResult> query);
    }
}
