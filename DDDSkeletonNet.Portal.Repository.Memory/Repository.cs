using DDDSkeletonNet.Infrastructure.Common.Domain;
using DDDSkeletonNet.Infrastructure.Common.UnitOfWork;
using System;

namespace DDDSkeletonNet.Portal.Repository.Memory
{
    public abstract class Repository<DomainType, IdType, DatabaseType> : IUnitOfWorkRepository where DomainType : IAggregateRoot
    {
        private readonly IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void PersistInsertion(IAggregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void PersistUpdate(IAggregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void PersistDeletion(IAggregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }
    }
}
