using DDDSkeleton.Portal.Domain.Customer;
using DDDSkeleton.Portal.Domain.ValueObjects;
using DDDSkeletonNet.Infrastructure.Common.UnitOfWork;
using DDDSkeletonNet.Portal.Repository.Memory.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDSkeletonNet.Portal.Repository.Memory.Repositories
{
    public class CustomerRepository : Repository<Customer, int, DatabaseCustomer>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork unitOfWork, IObjectContextFactory objectContextFactory) : base(unitOfWork, objectContextFactory) { }
        public override DatabaseCustomer ConvertToDatabaseType(Customer domainType)
        {
            return new DatabaseCustomer()
            {
                Address = domainType.CustomerAddress.AddressLine1,
                City = domainType.CustomerAddress.City,
                Country = "N/A",
                CustomerName = domainType.Name,
                Id = domainType.Id,
                Telephone = "N/A"
            };
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
            List<Customer> allCustomers = new List<Customer>();
            List<DatabaseCustomer> allDatabaseCustomers = ObjectContextFactory.Create().DatabaseCustomers.ToList();
            foreach (DatabaseCustomer dc in allDatabaseCustomers)
                allCustomers.Add(ConvertToDomain(dc));

            return allCustomers;

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
