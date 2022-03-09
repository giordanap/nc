using Northwind.Core.Entities;
using Northwind.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<Customer> GetCustomers()
        {
            var customers = Enumerable.Range(1, 10).Select(x => new Customer
            {
                CustomerId = $"Id: {x}",
                CompanyName = $"Nombre de la empresa: {x}",
                ContactName = $"Nombre del contacto: {x}",
                ContactTitle = $"Cargo del contacto: {x}",
                Address = $"Direccion: {x}",
                City = $"Ciudad: {x}",
                Region = $"Region: {x}",
                PostalCode = $"Codigo Postal: {x}",
                Country = $"Pais: {x}",
                Phone = $"Telefono: {x}",
                Fax = $"Fax: {x}"

            });

            return customers;
        }
    }
}
