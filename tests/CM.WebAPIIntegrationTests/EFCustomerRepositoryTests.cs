using AutoFixture;
using CM.Customers;
using CM.Customers.EFRepository;
using CM.Customers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.WebAPIIntegrationTests
{
    public class EFCustomerRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var efCustomerRepository = new EFCustomerRepository();
            var address = new List<Address>() { new Address() { AddressLine = "addressLine"} };
            var someCustomer = new Customer() { FirstName = "name", LastName = "last", AddressList = address, Email = "email@gmail.com", Notes = "11111", PhoneNumber="1111111111111",TotalPurchaseAmount=123};
            efCustomerRepository.Create(someCustomer);
        }
        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            var efCustomerRepository = new EFCustomerRepository();
            var customerResult = efCustomerRepository.Read(3);
            Assert.NotNull(customerResult);
        }

        [Fact]
        public void ShouldBeAbleToGetCustomersList()
        {
            var efCustomerRepository = new EFCustomerRepository();
            var customerResult = efCustomerRepository.GetAll();
            Assert.NotNull(customerResult);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var efCustomerRepository = new EFCustomerRepository();
            efCustomerRepository.Delete(3);
            Assert.NotEmpty(efCustomerRepository.GetAll());
        }
    }
}
