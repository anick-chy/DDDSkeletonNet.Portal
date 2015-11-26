using DDDSkeleton.Portal.Domain.Customer;
using DDDSkeleton.Portal.Domain.ValueObjects;
using DDDSkeletonNet.Portal.Repository.Memory.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDSkeletonNet.Portal.Repository.Memory.Repositories
{
    public class CustomerRepository : Repository<Customer, int, DatabaseCustomer>, ICustomerRepository
    {
        public override DatabaseCustomer ConvertToDatabaseType(Customer domainType)
        {
            throw new NotImplementedException();
        }

        public override Customer FindBy(int id)
        {
            DatabaseCustomer databaseCustomer = ObjectContextFactory.Create().DatabaseCustomers.Where(dc => dc.Id == id).FirstOrDefault();
            if (databaseCustomer != null)
                return ConvertToDomain(databaseCustomer);

            return null;
        }


        public IEnumerable<Customer> FindAll()
        {
            throw new NotImplementedException();
        }

        private Customer ConvertToDomain(DatabaseCustomer databaseCustomer)
        {
            Customer customer = new Customer()
            {
                Id = databaseCustomer.Id,
                Name = databaseCustomer.CustomerName,
                CustomerAddress = new Address()
                {
                    City = databaseCustomer.City,
                    AddressLine1 = databaseCustomer.Address,
                    AddressLine2 = string.Empty,
                    PostalCode = "N/A"
                }
            };

            return customer;
        }
    }
}
