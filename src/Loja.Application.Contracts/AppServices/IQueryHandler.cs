namespace Loja.Application.Contracts.AppServices
{
    using MediatR;

    public interface IQueryHandler<TQuery, TResult> 
        : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
}
