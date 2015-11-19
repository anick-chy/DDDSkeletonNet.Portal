using DDDSkeletonNet.Infrastructure.Common.Domain;
using System;

namespace DDDSkeleton.Portal.Domain.Customer
{
    /// <summary>
    /// Class to define all customer business rules
    /// </summary>
    public static class CustomerBusinessRule
    {
        /// <summary>
        /// Customer name required business rule
        /// </summary>
        public static readonly BusinessRule CustomerNameRequired = new BusinessRule("A customer must have a name");
    }
}
