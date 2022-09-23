using CM.Customers.Entities;
using CM.Customers.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CM.Customers.EFRepository
{
    public class EFAddressRepository : IRepository<Address>
    {
        private AddressValidator _addressvalidator;

        public EFAddressRepository()
        {
            _addressvalidator = new AddressValidator();
        }
        public void Create(Address entity)
        {
            if (entity != null)
            {
                var results = _addressvalidator.Validate(entity);
                if (results.IsValid)
                {
                    using (var db = new CustomersDBContex())
                    {
                        db.Addresses.Add(entity);
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("Invalid address");
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        public Address Read(int? entityCode)
        {
            if (entityCode != null)
            {
                using (var db = new CustomersDBContex())
                {
                    Address address = db.Addresses.Find(entityCode);
                    return address;
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        public void Update(Address entity)
        {
            if (entity != null)
            {
                var results = _addressvalidator.Validate(entity);
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
                    throw new Exception("Invalid address");
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
                db.Addresses.Remove(Read(entityCode));
                db.SaveChanges();
            }
        }
        public void DeleteAll()
        {
            throw new NotImplementedException();
        }
        public List<Address> GetAll()
        {
            using (var db = new CustomersDBContex())
            {
                return (db.Addresses.ToList());
            }
        }
    }
}
