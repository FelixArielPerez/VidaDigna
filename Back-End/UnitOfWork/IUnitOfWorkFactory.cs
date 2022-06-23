using System.Transactions;

namespace UnitOfWork
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork GetUnitOfWork(IsolationLevel isolationLevel);
        IUnitOfWork GetUnitOfWork();
    }
}
