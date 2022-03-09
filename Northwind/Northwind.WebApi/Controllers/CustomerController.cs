using Microsoft.AspNetCore.Mvc;
using Northwind.Core.Interfaces;
using Northwind.Infrastructure.Repositories;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = new CustomerRepository().GetCustomers();
            return Ok(customers);
        }
    }
}
