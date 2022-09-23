using CM.Customers.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CM.Customers.EFRepository
{
    public class EFCustomerRepository : IRepository<Customer>
    {

        private CustomerValidator _customerValidator;
        public EFCustomerRepository()
        {
            _customerValidator = new CustomerValidator();
        }

        public void Create(Customer entity)
        {
            if (entity != null)
            {
                var results = _customerValidator.Validate(entity);
                if (results.IsValid)
                {
                    using (var db = new CustomersDBContex())
                    {
                        db.Customers.Add(entity);
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("Invalid customer");
                }
            }
            else
            {
                throw new ArgumentNullException("Customer is null");
            }

        }

        public Customer Read(int? entityCode)
        {
            if (entityCode != null)
            {
                using (var db = new CustomersDBContex())
                {
                    Customer customer = db.Customers.Find(entityCode);
                    return customer;
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void Delete(int entityCode)
        {
            using (var db = new CustomersDBContex())
            {
                db.Customers.Remove(Read(entityCode));
                db.SaveChanges();
            }
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            using (var db = new CustomersDBContex())
            {
                return (db.Customers.ToList());
            }
        }



        public void Update(Customer entity)
        {
            if (entity != null)
            {
                var results = _customerValidator.Validate(entity);
                if (results.IsValid)
                {
                    using (var db = new CustomersDBContex())
                    {
                        db.Entry(entity)
                            .State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("Invalid customer");
                }
            }
            else
            {
                throw new ArgumentNullException();
            }

        }
    }
}
