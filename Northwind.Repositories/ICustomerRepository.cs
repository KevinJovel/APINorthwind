using Northwind.Models;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Repositories
{
    public interface ICustomerRepository:IRepository<Customer> 
    {
        //Metodo que no es comun para los demas una paginacion por eso se codifica aqui
        //Este metodo resive dos parametros para ser utilizados en un store procedure
        IEnumerable<Customer> CustomerPagedList(int page, int rows);
    }
}
