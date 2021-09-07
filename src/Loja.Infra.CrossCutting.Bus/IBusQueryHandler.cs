namespace Loja.Infra.CrossCutting.Bus
{
    public interface IBusQueryHandler
    {
        TResult SendQuery<TQuery, TResult>(TQuery query);
    }
}
