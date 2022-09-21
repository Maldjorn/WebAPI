using CM.Customers.EFRepository;
using CM.Customers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CM.WebAPIIntegrationTests
{
    public class EFAddressRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToReadAddress()
        {
            var eFaddressRepository = new EFAddressRepository();
            var result = eFaddressRepository.Read(1);
            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var eFaddressRepository = new EFAddressRepository();
            var address = new Address() { AddressLine = "addressLineTest", AddressLine2 = "addressLine2", AddressType = 1, City = "City", Country = "Canada", CustomerID = 2, PostalCode = "123123", State = "state" };

            eFaddressRepository.Create(address);
            Assert.True(eFaddressRepository.GetAll().Any(x=>x.AddressLine == "addressLineTest"));
        }

        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            var eFaddressRepository = new EFAddressRepository();
            eFaddressRepository.Delete(6);
            Assert.False(eFaddressRepository.GetAll().Any(x => x.AddressID == 6));
        }

        [Fact]
        public void ShouldBeAbleToUpdateAddresses()
        {
            var eFaddressRepository = new EFAddressRepository();
            var address = new Address() {AddressID = 5, AddressLine = "addressLineTestUpdated", AddressLine2 = "addressLine2", AddressType = 1, City = "City", Country = "Canada", CustomerID = 2, PostalCode = "123123", State = "state" };

            eFaddressRepository.Update(address);
            Assert.True(eFaddressRepository.GetAll().Any(x => x.AddressLine == "addressLineTestUpdated"));
        }
    }
}
