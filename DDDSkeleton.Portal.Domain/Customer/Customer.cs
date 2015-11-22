using DDDSkeleton.Portal.Domain.ValueObjects;
using DDDSkeletonNet.Infrastructure.Common.Domain;
using System;

namespace DDDSkeleton.Portal.Domain.Customer
{
    public class Customer : EntityBase<int>, IAggregateRoot
    {
        /// <summary>
        /// Implementation of Validate method from base class
        /// </summary>
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                AddBrokenRule(CustomerBusinessRule.CustomerNameRequired);
            CustomerAddress.ThrowExceptionIfInvalid();
        }

        /// <summary>
        /// Name of the Customer
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Customer address
        /// </summary>
        public Address CustomerAddress { get; set; }
    }
}
