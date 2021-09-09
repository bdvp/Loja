namespace Loja.Application.Contracts.AppServices
{
    using MediatR;

    public interface IQuery<TResult> : IRequest<TResult>
    {
    }
}
