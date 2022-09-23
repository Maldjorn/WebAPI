using CM.Customers;
using CM.Customers.EFRepository;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.WebAPITests
{
    public class EFCustomerRepositoryTests
    {
        [Fact]
        public void ShouldBeCreateArgementNullException()
        {
            EFCustomerRepository addressRepository = new EFCustomerRepository();
            Customer customer = null;
            addressRepository.Invoking(a => a.Create(customer)).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ShouldValidationException()
        {
            EFCustomerRepository addressRepository = new EFCustomerRepository();
            Customer customer = new Customer() {Email = "2", FirstName = "", LastName = "" };
            addressRepository.Invoking(a => a.Create(customer)).Should().Throw<Exception>().WithMessage("Invalid customer");
        }

        [Fact]
        public void ShouldBeReadException()
        {
            EFCustomerRepository addressRepository = new EFCustomerRepository();
            addressRepository.Invoking(a => a.Read((int?)null)).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ShouldBeUpdateArgementNullException()
        {
            EFCustomerRepository addressRepository = new EFCustomerRepository();
            Customer customer = null;
            addressRepository.Invoking(a => a.Update(customer)).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ShouldBeUpdateValidationException()
        {
            EFCustomerRepository addressRepository = new EFCustomerRepository();
            Customer customer = new Customer() { Email = "2", FirstName = "", LastName = "" };
            addressRepository.Invoking(a => a.Update(customer)).Should().Throw<Exception>().WithMessage("Invalid customer");
        }
    }
}
