using DDDSkeleton.Portal.Domain.Customer;
using DDDSkeletonNet.Portal.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDSkeletonNet.Portal
{
    public static class ConversionHelper
    {
        public static CustomerViewModel ConvertToViewModel(this Customer customer)
        {
            return new CustomerViewModel()
            {
                AddressLine1 = customer.CustomerAddress.AddressLine1,
                AddressLine2 = customer.CustomerAddress.AddressLine2,
                City = customer.CustomerAddress.City,
                PostalCode = customer.CustomerAddress.PostalCode,
                Id = customer.Id,
                Name = customer.Name
            };
        }
    }
}
