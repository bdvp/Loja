namespace Loja.Infra.Data.Contracts
{
    using System.Data;

    public interface ICommandConnection
    {
        IDbConnection Create();
    }
}
