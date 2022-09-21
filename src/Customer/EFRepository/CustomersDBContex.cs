using CM.Customers.Entities;
using Microsoft.EntityFrameworkCore;

namespace CM.Customers.EFRepository
{
    public class CustomersDBContex : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-JDONGM6\SQLEXPRESS;User Id=sa; Database=customerWebAPI; trusted_connection=true;");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
