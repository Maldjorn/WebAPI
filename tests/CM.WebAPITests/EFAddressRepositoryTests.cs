using CM.Customers.EFRepository;
using CM.Customers.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CM.WebAPITests
{
    public class EFAddressRepositoryTests
    {
        [Fact]
        public void ShouldBeCreateArgumentNullException()
        {
            EFAddressRepository eFAddressRepository = new EFAddressRepository();
            Address address = null;

            eFAddressRepository.Invoking(x => x.Create(address)).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ShouldBeValidationExceptionCreate()
        {
            EFAddressRepository eFAddressRepository = new EFAddressRepository();
            Address address = new Address() { AddressLine = "", AddressLine2 = "" };

            eFAddressRepository.Invoking(x => x.Create(address)).Should().Throw<Exception>().WithMessage("Invalid address");
        }

        [Fact]
        public void ShouldBeReadArgementNullException()
        {
            EFAddressRepository eFAddressRepository = new EFAddressRepository();

            eFAddressRepository.Invoking(x => x.Read((int?)null)).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ShouldBeUpdateArgumentNullException()
        {
            EFAddressRepository eFAddressRepository = new EFAddressRepository();
            Address address = null;

            eFAddressRepository.Invoking(x => x.Update(address)).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ShouldBeValidationExceptionUpdate()
        {
            EFAddressRepository eFAddressRepository = new EFAddressRepository();
            Address address = new Address() { AddressLine = "", AddressLine2 = "" };

            eFAddressRepository.Invoking(x => x.Update(address)).Should().Throw<Exception>().WithMessage("Invalid address");
        }
    }
}
