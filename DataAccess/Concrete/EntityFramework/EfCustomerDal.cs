using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : ICustomerDal
    {
        public void Add(Customer entity)
        {
            //IDisposable pattern implementation c#
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                var addedEntity = northwindContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                northwindContext.SaveChanges();  
            }
        }

        public void Delete(Customer entity)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                var deletedEntity = northwindContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                northwindContext.SaveChanges();
            }
        }

        public void Update(Customer entity)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                var modifiedEntity = northwindContext.Entry(entity);
                modifiedEntity.State = EntityState.Modified;
                northwindContext.SaveChanges();
            }
        }

        public Customer Get(Expression<Func<Customer, bool>> filter)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                return northwindContext.Set<Customer>().SingleOrDefault(filter);
            }
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                return filter == null ? northwindContext.Set<Customer>().ToList() : northwindContext.Set<Customer>().Where(filter).ToList();
            }
        }

        
    }
}
