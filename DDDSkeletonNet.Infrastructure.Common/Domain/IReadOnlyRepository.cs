using System;
using System.Collections.Generic;

namespace DDDSkeletonNet.Infrastructure.Common.Domain
{
    public interface IReadOnlyRepository<AggregateType, IdType> where AggregateType : IAggregateRoot
    {
        AggregateType FindBy(IdType Id);
        IEnumerable<AggregateType> FindAll();
    }
}
