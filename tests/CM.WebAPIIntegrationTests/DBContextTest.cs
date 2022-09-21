using CM.Customers.EFRepository;

namespace CM.WebAPIIntegrationTests
{
    public class DBContextTest
    {
        [Fact]
        public void ShouldBeAbleToCreateDBContext()
        {
            var dbContext = new CustomersDBContex();

            Assert.NotNull(dbContext);

            Assert.NotNull(dbContext.Customers);
            Assert.NotNull(dbContext.Addresses);
        }

        [Fact]
        public void ShouldBeAbleToCreateNewCustomer()
        {
            
        }
    }
}