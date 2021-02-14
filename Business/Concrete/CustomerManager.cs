using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        private ICustomerDal _CustomerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _CustomerDal = customerDal;
        }
 
    }
}
