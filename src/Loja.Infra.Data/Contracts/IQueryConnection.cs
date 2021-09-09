namespace Loja.Infra.Data.Contracts
{
    using System.Data;

    public interface IQueryConnection
    {
        IDbConnection Create();
    }
}
