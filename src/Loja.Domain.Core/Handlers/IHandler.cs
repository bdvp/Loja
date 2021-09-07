namespace Loja.Domain.Core.Handlers
{
    using FluentValidation.Results;
    using Loja.Domain.Core.Commands;
    using Loja.Domain.Core.ValueObject;
    using MediatR;

    public interface IHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : Command
    {
    }
}
