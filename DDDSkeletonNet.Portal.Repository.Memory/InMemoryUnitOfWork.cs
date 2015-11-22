using DDDSkeletonNet.Infrastructure.Common.Domain;
using DDDSkeletonNet.Infrastructure.Common.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace DDDSkeletonNet.Portal.Repository.Memory
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> _insertedAggregates;
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> _updatedAggregates;
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> _deletedAggregates;

        public InMemoryUnitOfWork()
        {
            _insertedAggregates = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            _updatedAggregates = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            _deletedAggregates = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
        }

        public void RegisterUpdate(IAggregateRoot aggregateRoot, IUnitOfWorkRepository repository)
        {
            if (!_updatedAggregates.ContainsKey(aggregateRoot))
                _updatedAggregates.Add(aggregateRoot, repository);
        }

        public void RegisterInsertion(IAggregateRoot aggregateRoot, IUnitOfWorkRepository repository)
        {
            if (!_insertedAggregates.ContainsKey(aggregateRoot))
                _insertedAggregates.Add(aggregateRoot, repository);
        }

        public void RegisterDeletion(IAggregateRoot aggregateRoot, IUnitOfWorkRepository repository)
        {
            if (!_deletedAggregates.ContainsKey(aggregateRoot))
                _deletedAggregates.Add(aggregateRoot, repository);
        }


        public void Commit()
        {
            using (TransactionScope scope = new TransactionScope())
            {

            }
        }
    }
}
