using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Repositories;

namespace Northwind.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository customer { get; }

    }
}
