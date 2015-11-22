using DDDSkeletonNet.Infrastructure.Common.Domain;
using System;

namespace DDDSkeletonNet.Infrastructure.Common.UnitOfWork
{
    public interface IUnitOfWorkRepository
    {
        void PersistInsertion(IAggregateRoot aggregateRoot);
        void PersistUpdate(IAggregateRoot aggregateRoot);
        void PersistDeletion(IAggregateRoot aggregateRoot);
    }
}
