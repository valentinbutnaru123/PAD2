using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Data.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiServer.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;


        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("GetCustomers")]
        public IActionResult GetCustomers()
        {
            var customers = _customerRepository.GetCustomers();
            return Ok(customers);
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public IActionResult CreateCustomer([FromBody]Customer customer)
        {
                _customerRepository.AddNewCustomer(customer);
                return Ok();
        }

        [HttpGet]
        [Route("GetCustomerByID/{customerID:int}")]
        public IActionResult GetCustomerByID(int customerID)
        {
            return Ok(_customerRepository.GetCustomerByID(customerID));
        }

        [HttpDelete]
        [Route("DeleteCustomerByID/{customerID:int}")]
        public IActionResult DeleteCustomerByID(int customerID)
        {
                _customerRepository.DeleteCustomerByID(customerID);
                return Ok();
        }

    }
}
