namespace TestCase.Domain.Repositories.Base;

public interface ITransactionScope : IDisposable
{
    void BeginTransaction();

    Task CommitTransactionAsync();
}