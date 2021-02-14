using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCustomerDal : ICustomerDal
    {
        private List<Customer> _customer;
        public InMemoryCustomerDal()
        {
            _customer = new List<Customer>();
            _customer.Add(new Customer() { CustomerId = "abcd1", ContactName = "Berk" });
            _customer.Add(new Customer() { CustomerId = "abcd2", ContactName = "Hasan" });
            _customer.Add(new Customer() { CustomerId = "abcd3", ContactName = "Nazlı" });
        }
        public void Add(Customer entity)
        {
            _customer.Add(entity);
        }
        public void Delete(Customer entity)
        {
            if (_customer.Any(c => c.CustomerId == entity.CustomerId))
                _customer.Remove(_customer.SingleOrDefault(c => c.CustomerId == entity.CustomerId));
        }
        public void Update(Customer entity)
        {
            Customer updatedEntitiy;
            if (_customer.Any(c => c.CustomerId == entity.CustomerId))
            {
                updatedEntitiy = _customer.SingleOrDefault(c => c.CustomerId == entity.CustomerId);
                updatedEntitiy.ContactName = entity.ContactName;
                updatedEntitiy.CompanyName = entity.CompanyName;
            }
        }
        public Customer Get(Expression<Func<Customer, bool>> filter)
        {
            return _customer.SingleOrDefault(filter.Compile());
        }
        public List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            return filter == null ? _customer : _customer.Where(filter.Compile()).ToList();
        }


    }
}
