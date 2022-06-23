using System;
using System.Transactions;

namespace UnitOfWork
{
    public class TransactionScopeUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IsolationLevel _isolationLevel;

        public TransactionScopeUnitOfWorkFactory(IsolationLevel isolationLevel)
        {
            _isolationLevel = isolationLevel;
        }

        public TransactionScopeUnitOfWorkFactory() {}

        public IUnitOfWork GetUnitOfWork(IsolationLevel isolationLevel)
        {
            return new TransactionScopeUnitOfWork(isolationLevel);
        }
        public IUnitOfWork GetUnitOfWork()
        {
            try
            {
                return new TransactionScopeUnitOfWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
