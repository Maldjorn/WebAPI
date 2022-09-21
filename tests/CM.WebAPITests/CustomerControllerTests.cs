using CM.ASPCustomerWebAPI.Controllers;
using CM.Customers;
using CM.Customers.EFRepository;
using CM.Customers.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.WebAPITests
{
    public class CustomerControllerTests
    {
        [Fact]
        public void ShoulCreateCustomerController()
        {
            var repositoryMock = new Mock<IRepository<Customer>>();

            CustomerController customerController = new CustomerController(repositoryMock.Object);

            Assert.NotNull(customerController);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var repositoryMock = new Mock<IRepository<Customer>>();
            repositoryMock.Setup(x => x.Create(It.IsAny<Customer>()));
            CustomerController customerController = new CustomerController(repositoryMock.Object);

            var efCustomerRepository = new EFCustomerRepository();
            var address = new List<Address>() { new Address() { AddressLine = "addressLine", AddressLine2 = "addressLine2", AddressType = 1, City = "City", Country = "Canada", CustomerID = 2, PostalCode = "123123", State = "state" } };
            var someCustomer = new Customer() { FirstName = "name", LastName = "last", AddressList = address, Email = "email@gmail.com", Notes = "11111", PhoneNumber = "1111111111111", TotalPurchaseAmount = 123 };
            customerController.Create(someCustomer);
            repositoryMock.Verify(r => r.Create(someCustomer));

        }
        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var repositoryMock = new Mock<IRepository<Customer>>();
            repositoryMock.Setup(x => x.Delete(It.IsAny<int>()));
            CustomerController customerController = new CustomerController(repositoryMock.Object);

            customerController.Delete(3);

            repositoryMock.Verify(r => r.Delete(3));
        }
        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var repositoryMock = new Mock<IRepository<Customer>>();
            repositoryMock.Setup(x => x.Update(It.IsAny<Customer>()));
            CustomerController customerController = new CustomerController(repositoryMock.Object);

            var address = new List<Address>() { new Address() { AddressLine = "addressLine", AddressLine2 = "addressLine2", AddressType = 1, City = "City", Country = "Canada", CustomerID = 2, PostalCode = "123123", State = "state" } };
            var someCustomer = new Customer() { CustomerID = 1, FirstName = "name", LastName = "last", AddressList = address, Email = "email@gmail.com", Notes = "11111", PhoneNumber = "1111111111111", TotalPurchaseAmount = 123 };
            customerController.Update(someCustomer);

            repositoryMock.Verify(r => r.Update(someCustomer));
        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            var repositoryMock = new Mock<IRepository<Customer>>();
            repositoryMock.Setup(x => x.Read(It.IsAny<int>())).Returns(new Customer());
            CustomerController customerController = new CustomerController(repositoryMock.Object);
            var result = customerController.Get(1);
            Assert.NotNull(result);
            repositoryMock.Verify(r => r.Read(1));
        }

        [Fact]
        public void ShouldBeAbleToReadAllCistomers()
        {
            var repositoryMock = new Mock<IRepository<Customer>>();
            repositoryMock.Setup(x => x.GetAll()).Returns(new List<Customer>());
            CustomerController customerController = new CustomerController(repositoryMock.Object);

            customerController.GetAll();

            repositoryMock.Verify(r => r.GetAll());
        }

        [Fact]
        public void ShouldBeCreateBadRequest()
        {
            var repositoryMock = new Mock<IRepository<Customer>>();
            repositoryMock.Setup(x => x.Create(It.IsAny<Customer>()));
            CustomerController customerController = new CustomerController(repositoryMock.Object);

            Customer customer = null;

            var result = customerController.Create(customer);

            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public void ShouldBeGetBadRequest()
        {
            var repositoryMock = new Mock<IRepository<Customer>>();
            repositoryMock.Setup(x => x.Read(It.IsAny<int>())).Returns((Customer)null);
            CustomerController customerController = new CustomerController(repositoryMock.Object);

            var result = customerController.Get(1);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldBeGetAllBadRequest()
        {
            var repositoryMock = new Mock<IRepository<Customer>>();
            repositoryMock.Setup(x => x.GetAll()).Returns(new List<Customer>());
            CustomerController customerController = new CustomerController(repositoryMock.Object);

            var result = customerController.GetAll();

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldBeUpdateBadRequest()
        {
            var repositoryMock = new Mock<IRepository<Customer>>();
            repositoryMock.Setup(x => x.Update(new Customer()));
            CustomerController customerController = new CustomerController(repositoryMock.Object);
            
            Customer customer = null;

            var result = customerController.Update(customer);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldBeDeleteBadRequest()
        {
            var repositoryMock = new Mock<IRepository<Customer>>();
            repositoryMock.Setup(x => x.Delete(It.IsAny<int>()));
            CustomerController customerController = new CustomerController(repositoryMock.Object);

            var result = customerController.Delete(0);

            result.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
