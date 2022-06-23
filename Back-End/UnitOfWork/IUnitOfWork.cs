using DataAccess;
using System;

namespace UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        DBDKContext Db { get; }

        void StartTransaction();

        void RollBack();
    }
}
