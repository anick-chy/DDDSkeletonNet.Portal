using DDDSkeletonNet.Infrastructure.Common.Domain;
using DDDSkeletonNet.Infrastructure.Common.UnitOfWork;
using DDDSkeletonNet.Portal.Repository.Memory.Database;
using System;

namespace DDDSkeletonNet.Portal.Repository.Memory
{
    public abstract class Repository<DomainType, IdType, DatabaseType> : IUnitOfWorkRepository where DomainType : IAggregateRoot
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IObjectContextFactory _objectContextFactory;

        public IObjectContextFactory ObjectContextFactory
        {
            get
            {
                return _objectContextFactory;
            }
        }

        public Repository(IUnitOfWork unitOfWork, IObjectContextFactory objectContextFactory)
        {
            if (unitOfWork == null) throw new ArgumentNullException("Unit of work");
            if (objectContextFactory == null) throw new ArgumentNullException("Object context factory");
            _unitOfWork = unitOfWork;
            _objectContextFactory = objectContextFactory;

        }
        public void PersistInsertion(IAggregateRoot aggregateRoot)
        {
            DatabaseType databaseType = RetrieveDatabaseTypeFrom(aggregateRoot);
            _objectContextFactory.Create().AddEntity<DatabaseType>(databaseType);
        }

        public void PersistUpdate(IAggregateRoot aggregateRoot)
        {
            DatabaseType databaseType = RetrieveDatabaseTypeFrom(aggregateRoot);
            _objectContextFactory.Create().UpdateEntity<DatabaseType>(databaseType);
        }

        public void PersistDeletion(IAggregateRoot aggregateRoot)
        {
            DatabaseType databaseType = RetrieveDatabaseTypeFrom(aggregateRoot);
            _objectContextFactory.Create().DeleteEntity<DatabaseType>(databaseType);
        }

        /// <summary>
        /// Converts any domain type to its corresponding database type
        /// </summary>
        /// <param name="domainType">Domain that needs to convert into database type</param>
        /// <returns>Database type represntation of a domain object</returns>
        public abstract DatabaseType ConvertToDatabaseType(DomainType domainType);

        //get database representation of an aggregate
        private DatabaseType RetrieveDatabaseTypeFrom(IAggregateRoot aggregateRoot)
        {
            DomainType domainType = (DomainType)aggregateRoot;
            DatabaseType databaseType = ConvertToDatabaseType(domainType);

            return databaseType;
        }

        public void Insert(DomainType aggregate)
        {
            _unitOfWork.RegisterInsertion(aggregate, this);
        }

        public void Update(DomainType aggregate)
        {
            _unitOfWork.RegisterUpdate(aggregate, this);
        }

        public void Delete(DomainType aggregate)
        {
            _unitOfWork.RegisterDeletion(aggregate, this);
        }

        public abstract DomainType FindBy(IdType id);
    }
}
