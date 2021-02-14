using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concreted
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }
        public List<Product> GetAllByCategoryId(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }
        public Product GetByCategodyId(int categoryId)
        {
            return _productDal.Get(p => p.CategoryId == categoryId);
        }
    }
}
