using System;

namespace DDDSkeletonNet.Portal.Repository.Memory.Database
{
    public interface IObjectContextFactory
    {
        InMemoryDatabaseObjectContext Create();
    }
}
