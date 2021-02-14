using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using(NorthwindContext northwind = new NorthwindContext())
            {
                var addedEntity = northwind.Entry(entity);
                addedEntity.State = EntityState.Added;
                northwind.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext northwind = new NorthwindContext())
            {
                var deletedEntity = northwind.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                northwind.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using(NorthwindContext northwind = new NorthwindContext())
            {
                return northwind.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext northwind = new NorthwindContext())
            {
                return filter == null ? northwind.Set<Product>().ToList() : northwind.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext northwind = new NorthwindContext())
            {
                var modifiedEntity = northwind.Entry(entity);
                modifiedEntity.State = EntityState.Modified;
                northwind.SaveChanges();
            }
        }
    }
}
