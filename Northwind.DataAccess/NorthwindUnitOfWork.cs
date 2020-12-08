using System;
using System.Collections.Generic;
using System.Text;

using Northwind.Repositories;
using Northwind.UnitOfWork;

namespace Northwind.DataAccess
{
    public class NorthwindUnitOfWork : IUnitOfWork
    {
        public NorthwindUnitOfWork(string connectionString) {
           customer= new CustomerRepository(connectionString);
        }
        public ICustomerRepository customer { get; private set; }
    }
}
