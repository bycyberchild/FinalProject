using Business.Concreted;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var items in productManager.GetAllByCategoryId(4))
                Console.WriteLine(items.ProductName + " " + items.ProductId);
        }
    }
}
