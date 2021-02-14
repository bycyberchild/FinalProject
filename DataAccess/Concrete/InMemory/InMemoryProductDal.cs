using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        private List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>();
            _products.Add(new Product() { CategoryId = 1, ProductId = 1, ProductName = "Kalem", SupplierId = 1 });
            _products.Add(new Product() { CategoryId = 1, ProductId = 2, ProductName = "Defter", SupplierId = 1 });
            _products.Add(new Product() { CategoryId = 2, ProductId = 3, ProductName = "Bardak", SupplierId = 1 });
        }
        public void Add(Product entity)
        {
            _products.Add(entity);
        }
        public void Delete(Product entity)
        {
            if (_products.Any(p => p.ProductId == entity.ProductId))
                _products.Remove(_products.SingleOrDefault(p => p.ProductId == entity.ProductId));
        }
        public void Update(Product entity)
        {
            if (_products.Any(p => p.ProductId == entity.ProductId))
            {
                Product selectedProduct = _products.SingleOrDefault(p => p.ProductId == entity.ProductId);
                selectedProduct.CategoryId = entity.CategoryId;
                selectedProduct.ProductName = entity.ProductName;
            }
        }
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return _products.SingleOrDefault(filter.Compile());
        }
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return filter == null ? _products : _products.Where(filter.Compile()).ToList();
        }
    }
}
