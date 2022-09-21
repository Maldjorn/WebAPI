using CM.ASPCustomerWebAPI.Controllers;
using CM.Customers;
using CM.Customers.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CM.WebAPITests
{
    public class AddressControllerTest
    {
        [Fact]
        public void ShouldBeAbleToCreateAddressController()
        {
            var repositoryMock = new Mock<IRepository<Address>>();

            AddressController addressController = new AddressController(repositoryMock.Object);

            Assert.NotNull(addressController);
        }

        [Fact]
        public void ShouldBeAbleToGetAddress()
        {
            var repositoryMock = new Mock<IRepository<Address>>();
            repositoryMock.Setup(r => r.Read(It.IsAny<int>())).Returns(new Address());

            AddressController addressController = new AddressController(repositoryMock.Object);

            var address = new Address() { AddressLine = "addressLine", AddressLine2 = "addressLine2", AddressType = 1, City = "City", Country = "Canada", CustomerID = 2, PostalCode = "123123", State = "state" };
            var result = addressController.Get(1);
            repositoryMock.Verify(r => r.Read(1));
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var repositoryMock = new Mock<IRepository<Address>>();
            repositoryMock.Setup(r => r.Create(It.IsAny<Address>()));

            AddressController addressController = new AddressController(repositoryMock.Object);

            var address = new Address() { AddressLine = "addressLine", AddressLine2 = "addressLine2", AddressType = 1, City = "City", Country = "Canada", CustomerID = 2, PostalCode = "123123", State = "state" };
            addressController.Create(address);

            repositoryMock.Verify(r => r.Create(address));
        }

        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            var repositoryMock = new Mock<IRepository<Address>>();
            repositoryMock.Setup(r => r.Delete(It.IsAny<int>()));

            AddressController addressController = new AddressController(repositoryMock.Object);

            addressController.Delete(1);

            repositoryMock.Verify(r => r.Delete(1));
        }

        [Fact]
        public void ShouldBeAbleToUodateAddress()
        {
            var repositoryMock = new Mock<IRepository<Address>>();
            repositoryMock.Setup(r => r.Update(It.IsAny<Address>()));

            AddressController addressController = new AddressController(repositoryMock.Object);
            var address = new Address() { AddressLine = "addressLine", AddressLine2 = "addressLine2", AddressType = 1, City = "City", Country = "Canada", CustomerID = 2, PostalCode = "123123", State = "state" };

            addressController.Update(address);

            repositoryMock.Verify(r => r.Update(address));

        }

        [Fact]
        public void ShouldBeAbleToGetAllAddresses()
        {
            var repositoryMock = new Mock<IRepository<Address>>();
            repositoryMock.Setup(r => r.GetAll()).Returns(new List<Address>());

            AddressController addressController = new AddressController(repositoryMock.Object);

            addressController.GetAll();

            repositoryMock.Verify(r => r.GetAll());
        }

        [Fact]
        public void ShouldBeCreateBadRequest()
        {
            var repositoryMock = new Mock<IRepository<Address>>();
            repositoryMock.Setup(x => x.Create(It.IsAny<Address>()));
            AddressController customerController = new AddressController(repositoryMock.Object);

            Address address = null;

            var result = customerController.Create(address);

            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public void ShouldBeGetBadRequest()
        {
            var repositoryMock = new Mock<IRepository<Address>>();
            repositoryMock.Setup(x => x.Read(It.IsAny<int>())).Returns((Address)null);
            AddressController customerController = new AddressController(repositoryMock.Object);

            var result = customerController.Get(1);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldBeGetAllBadRequest()
        {
            var repositoryMock = new Mock<IRepository<Address>>();
            repositoryMock.Setup(x => x.GetAll()).Returns(new List<Address>());
            AddressController customerController = new AddressController(repositoryMock.Object);


            var result = customerController.GetAll();

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldBeUpdateBadRequest()
        {
            var repositoryMock = new Mock<IRepository<Address>>();
            repositoryMock.Setup(x => x.Update(It.IsAny<Address>()));
            AddressController customerController = new AddressController(repositoryMock.Object);

            Address address = null;

            var result = customerController.Update(address);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldBeDeleteBadRequest()
        {
            var repositoryMock = new Mock<IRepository<Address>>();
            repositoryMock.Setup(x => x.Delete(It.IsAny<int>()));
            AddressController customerController = new AddressController(repositoryMock.Object);

            var result = customerController.Delete(0);

            result.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
