using CM.Customers;
using CM.Customers.EFRepository;
using CM.Customers.Entities;

namespace CM.WebAPITests
{
    public class EFRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateEFCustomerRepository()
        {
            var efRepository = new EFCustomerRepository();
            Assert.NotNull(efRepository);

            Assert.IsAssignableFrom<IRepository<Customer>>(efRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateEFAddressCRepository()
        {
            var efRepository = new EFAddressRepository();
            Assert.NotNull(efRepository);

            Assert.IsAssignableFrom<IRepository<Address>>(efRepository);
        }


    }
}