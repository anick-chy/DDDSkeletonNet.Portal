using DDDSkeletonNet.Infrastructure.Common.Domain;
using System;

namespace DDDSkeletonNet.Infrastructure.Common.UnitOfWork
{
    public interface IUnitOfWork
    {
        void RegisterUpdate(IAggregateRoot aggregateRoot, IUnitOfWorkRepository repository);
        void RegisterInsertion(IAggregateRoot aggregateRoot, IUnitOfWorkRepository repository);
        void RegisterDeletion(IAggregateRoot aggregateRoot, IUnitOfWorkRepository repository);
        void Commit();
    }
}
