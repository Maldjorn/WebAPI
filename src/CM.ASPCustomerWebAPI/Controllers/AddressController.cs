using CM.Customers;
using CM.Customers.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CM.ASPCustomerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IRepository<Address> _repository;
        public AddressController(IRepository<Address> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Create(Address address)
        {
            _repository.Create(address);
            return Get(address.AddressID);
        }

        [HttpGet("{addressId}")]
        public IActionResult Get(int addressId)
        {
            var address = _repository.Read(addressId);
            if (address == null)
            {
                return BadRequest("Address not found");
            }
            return Ok(address);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customerList = _repository.GetAll();
            if (customerList.Count == 0 || customerList == null)
            {
                return BadRequest("Customers not found");
            }
            return Ok(customerList);
        }

        [HttpDelete("{addressId}")]
        public IActionResult Delete(int addressID)
        {
            if (addressID == 0)
            {
                return BadRequest("Address not found");
            }
            _repository.Delete(addressID);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Address address)
        {
            if (address == null)
            {
                return BadRequest("Customer not found");
            }
            _repository.Update(address);
            return Ok(address);
        }
    }
}
