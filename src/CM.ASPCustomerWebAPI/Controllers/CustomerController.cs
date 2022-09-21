using CM.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CM.ASPCustomerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _repository;
        public CustomerController(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if(customer == null)
            {
                return BadRequest();
            }
            _repository.Create(customer);
            return Get(customer.CustomerID);
        }


        [HttpGet("{customerId}")]
        public IActionResult Get(int customerId)
        {
            var customer = _repository.Read(customerId);
            if (customer==null)
            {
                return BadRequest("Customer not found");
            }
            return Ok(customer);
        }

        [HttpGet]
        public  IActionResult GetAll()
        {
            var customerList = _repository.GetAll();
            if (customerList.Count == 0 || customerList == null)
            {
                return BadRequest("Customers not found");
            }
            return Ok(customerList);
        }

        [HttpPut]
        public IActionResult Update(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer not found");
            }
            _repository.Update(customer);
            return Ok(customer);
        }

        [HttpDelete("{customerId}")]
        public IActionResult Delete(int customerId)
        {
            if (customerId == 0)
            {
                return BadRequest("Customer not found");
            }
            _repository.Delete(customerId);
            return Ok();
        }
    }
}
