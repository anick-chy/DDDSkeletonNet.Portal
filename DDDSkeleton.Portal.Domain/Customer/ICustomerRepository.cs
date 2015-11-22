using DDDSkeletonNet.Infrastructure.Common.Domain;
using System;

namespace DDDSkeleton.Portal.Domain.Customer
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
    }
}
