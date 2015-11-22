using DDDSkeletonNet.Infrastructure.Common.Domain;
using System;

namespace DDDSkeleton.Portal.Domain.ValueObjects
{
    public class Address : ValueObjectBase
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        /// <summary>
        /// Validate Address
        /// </summary>
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(City))
            {
                AddBrokenRule(ValueObjectBusinessRule.CityInAddressBusinessRule);
            }
        }
    }
}
